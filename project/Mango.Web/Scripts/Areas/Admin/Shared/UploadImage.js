
var uploadImage = (function (options) {

    function showUploadModal() {
        $(options.modalId).modal('show');
    }

    function hideUploadModal() {
        $(options.modalId).modal('hide');
    }

    function showUploadControls() {
        $(options.containerControls).show();
        $(options.containerProgress).hide();
    }

    function showUploadProgress() {
        $(options.containerControls).hide();
        $(options.containerProgress).show();
    }

    function clearFileInput(controlId) {
        var oldInput = $(controlId);
        if (typeof oldInput !== "undefined" && oldInput !== null) {
            oldInput.replaceWith(oldInput.val('').clone(true));
        }
    }

    function onUpload(evt) {
        var files = $(options.fileUpload).get(0).files;
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
                        //$(options.containerResults).empty();
                        for (var i = 0; i < results.length; i++) {
                            //$(options.containerResults).append($("<li/>").text(results[i]));
                            var url = results[i];
                            lc.updateCanvas(url); // update canvas url
                            $(options.controlImage).val(url); // save image url to CanvasImage hidden field
                            clearFileInput(options.fileUpload);

                            hideUploadModal();
                        }
                        showUploadControls();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        showUploadControls();
                        //alert(xhr.responseText);
                    }
                });
            }
            //else {
            //alert("Your browser doesn't support HTML5 multiple file uploads! Please use some decent browser.");
            //}
        }
    }

    $(options.buttonModalOpen).click(function() {
        console.log(options.buttonModalOpen);
    });

    $(document).ready(function () {
        console.log(options.buttonUpload);
        $(options.buttonUpload).click(onUpload);
    });

});