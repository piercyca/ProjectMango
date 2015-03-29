
var LayoutCanvas = (function(options) {

    var canvas = new fabric.Canvas('c');
    //Rect for Images
    var pic = new fabric.Rect({ left: 0, top: 0, fill: 'green', width: 480, height: 220, opacity: 0.8 });
    //Rect for Text
    var text = new fabric.Rect({ left: 0, top: pic.height, fill: 'blue', width: 480, height: 220, opacity: 0.8 });

    function setConfig() {
        options.config =
        {
            pic: {
                top: Math.ceil(pic.top),
                left: Math.ceil(pic.left),
                width: Math.ceil(pic.getWidth()),
                height: Math.ceil(pic.getHeight())
            },
            text: {
                top: Math.ceil(text.top),
                left: Math.ceil(text.left),
                width: Math.ceil(text.getWidth()),
                height: Math.ceil(text.getHeight())
            }
        }
        $(options.inputConfiguration).val(options.config);
    }


    //on click add objects
    $(options.controlAddPic).click(function () {
        //remove if exist then add
        canvas.remove(pic);
        canvas.add(pic);
    });

    $(options.controlAddText).click(function() {
        //remove if exist then add
        canvas.remove(text);
        canvas.add(text);
    });

    //observe any mouse movement
    canvas.observe('mouse:move', function () {
        setConfig();
        $("#contents").html(
            '<div class=\"pic\">' +
            'Pic Top: ' + options.config.pic.top + '<br/>' +
            'Pic Left: ' + options.config.pic.left + '<br/>' +
            'Pic Width: ' + options.config.pic.width + '<br/>' +
            'Pic Height: ' + options.config.pic.height + '<br/><br/>' +
            '</div><div class=\"text\">' +
            'Text Top: ' + options.config.text.top + '<br/>' +
            'Text Left: ' + options.config.text.left + '<br/>' +
            'Text Width: ' + options.config.text.width + '<br/>' +
            'Text Height: ' + options.config.text.height + '<br/>'
            + '</div>'
        );
    });

    //remove selected object
    $(options.controlRemoveText).click(function () {
        var activeO = canvas.getActiveObject();
        if (!activeO) {
            return;
        }
        canvas.remove(activeO);
    });

    //TODO: upload and resize image (optional)
    //TODO: BIG -- Apply coordinate data to product

    $("#uploadImg").change(function(e) {
        var reader = new FileReader();
        reader.onload = function(event) {
            var imgObj = new Image();
            imgObj.src = event.target.result;
            imgObj.onload = function() {

                var image = new fabric.Image(imgObj);
                image.set({
                    left: 0,
                    top: 0,
                    padding: 0,
                    cornersize: 0,
                    lockUniScaling: true,
                    lockRotation: true
                });
                //image.scale(getRandomNum(0.1, 0.25)).setCoords();
                canvas.add(image);
            }

        }
        reader.readAsDataURL(e.target.files[0]);
    });

    //Download canvas output to file (Placeholder)
    function download(url, name) {
        //make the link. set the href and download. emulate dom click
        $('<a>').attr({ href: url, download: name })[0].click();
    }

    function downloadFabric(canvas, name) {
        //convert the canvas to a data url and download it.
        download(canvas.toDataURL(), name + '.png');
    }

    var center = canvas.getCenter();
    this.updateCanvas = function(url) {
        canvas.setBackgroundImage(url, canvas.renderAll.bind(canvas), {
            //center the background image
            scaleX: 1,
            scaleY: 1,
            top: center.top,
            left: center.left,
            originX: 'center',
            originY: 'center'
        });
    };

//download should be productname or id
    $(options.controlDownload).click(function() {
        downloadFabric(canvas, 'download');
    });
});