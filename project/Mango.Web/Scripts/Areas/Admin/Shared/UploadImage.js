
var UploadImage = (function (opt) {

    var showConsoleLog = true;
    function consoleLog(message) {
        if (showConsoleLog) {
            console.log(message);
        }
    }


    function showUploadModal() {
        $(opt.modalId).modal('show');
    }

    function hideUploadModal() {
        $(opt.modalId).modal('hide');
    }

    function showUploadControls() {
        $(opt.modalId + ' [data-upload="controls"]').show();
        $(opt.modalId + ' [data-upload="progress"]').hide();
    }

    function showUploadProgress() {
        $(opt.modalId + ' [data-upload="controls"]').hide();
        $(opt.modalId + ' [data-upload="progress"]').show();
    }

    function clearFileInput() {
        var oldInput = $(opt.modalId + ' [data-upload="fileupload"]');
        if (typeof oldInput !== "undefined" && oldInput !== null) {
            oldInput.replaceWith(oldInput.val('').clone(true));
        }
    }

    function getUrl() {
        if (typeof opt.urlDataTarget !== "undefined" && opt.urlDataTargetoldInput !== null) {
            consoleLog($(opt.urlDataTarget).val());
            return $(opt.urlDataTarget).val();
        }
        return "";
    }

    function showImage(url) {
        consoleLog("showImage: " + url);
        if (url.length > 0) {
            $(opt.containerDisplay).html('<img src="' + url + '" />');
        } else {
            $(opt.containerDisplay).html('<p class="col-md-3 bg-info">No Image</div>');
        }
        
    }

    function setUrl(url) {
        var urlDataTarget = opt.urlDataTarget;
        if (typeof urlDataTarget !== "undefined" && urlDataTarget !== null) {
            $(urlDataTarget).val(url); // save image url to CanvasImage hidden field
            showImage(url);
        } else {
            consoleLog("opt.urlDataTarget is not set");
        }
    }
    
    function onUpload(evt) {
        var files = $(opt.modalId + ' [data-upload="fileupload"]').get(0).files;
        if (files.length > 0) {

            showUploadProgress();

            if (window.FormData !== undefined) {
                var data = new FormData();
                for (i = 0; i < files.length; i++) {
                    data.append("file" + i, files[i]);
                }
                $.ajax({
                    type: "POST",
                    url: "/admin/api/fileupload",
                    contentType: false,
                    processData: false,
                    data: data,
                    success: function (results) {
                        //$(opt.containerResults).empty();
                        for (var i = 0; i < results.length; i++) {
                            //$(opt.containerResults).append($("<li/>").text(results[i]));

                            var url = results[i];
                            //lc.updateCanvas(url); // update canvas url
                            setUrl(url);

                            hideUploadModal();
                            clearFileInput();

                            // fire uploaded callback
                            if (opt.onUploaded && typeof (opt.onUploaded) === "function") {
                                consoleLog("onUploaded FOUND");
                                opt.onUploaded(url);
                            }
                        }
                        showUploadControls();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        showUploadControls();
                        consoleLog(xhr.responseText);
                    }
                });
            }
        }
    }

    $(opt.modalTrigger).click(function() {
        consoleLog(opt.modalTrigger);
        showUploadModal();
    });

    $(document).ready(function () {
        consoleLog(opt.modalId + ' [data-upload="upload"]');
        $(opt.modalId + ' [data-upload="upload"]').click(onUpload);
        showUploadControls();
        showImage(getUrl()); // populate existing data
    });

});