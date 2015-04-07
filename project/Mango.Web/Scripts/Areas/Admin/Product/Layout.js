
var LayoutCanvas = (function(options) {

    var canvas = new fabric.Canvas('c');
    var center = canvas.getCenter();
    var canvasConfig = $('#Configuration').val();
    var bgurl = $('#CanvasImage').val();
    var pic = new fabric.Rect({ left: 0, top: 0, fill: 'green', width: 340, height: 220, opacity: 0.8 });
    var text = new fabric.Rect({ left: 0, top: pic.height, fill: 'blue', width: 340, height: 220, opacity: 0.8 });

    if (bgurl == "") {
        //default
        var bgurl = $('#noimage').val();
    }
    if (canvasConfig != "") {
        //If the config settings is already set
        var parseConfig = JSON.parse(canvasConfig);
        var imgConfig = parseConfig.layout.pic;
        var textConfig = parseConfig.layout.text;
        var pic = new fabric.Rect({ left: imgConfig.left, top: imgConfig.top, fill: 'green', width: imgConfig.width, height: imgConfig.height, opacity: 0.8 });
        var text = new fabric.Rect({ left: textConfig.left, top: textConfig.top, fill: 'blue', width: textConfig.width, height: textConfig.height, opacity: 0.8 });
        canvas.add(pic);
        canvas.add(text);
}
    canvas.setBackgroundImage(bgurl, canvas.renderAll.bind(canvas), {
        //center the background image
        scaleX: 1,
        scaleY: 1,
        top: center.top,
        left: center.left,
        originX: 'center',
        originY: 'center'
    });



    function setConfig() {
        options.config =
        {
            layout: {
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
        }
        $(options.inputConfiguration).val(JSON.stringify(options.config));
    }


    //on click add objects
    $(options.controlAddPic).click(function () {
        //remove if exist then add
        canvas.remove(pic);
        canvas.add(pic);
        canvas.renderAll();
    });

    $(options.controlAddText).click(function() {
        //remove if exist then add
        canvas.remove(text);
        canvas.add(text);
        canvas.renderAll();
    });

    //observe any mouse movement
    canvas.observe('mouse:move', function () {
        setConfig();
        $("#contents").html(
            '<div class=\"pic col-sm-6\">' +
            'Pic Top: ' + Math.ceil(pic.top) + '<br/>' +
            'Pic Left: ' + Math.ceil(pic.left) + '<br/>' +
            'Pic Width: ' + Math.ceil(pic.getWidth()) + '<br/>' +
            'Pic Height: ' + Math.ceil(pic.getHeight()) +
            '</div><div class=\"text col-sm-6\">' +
            'Text Top: ' + Math.ceil(text.top) + '<br/>' +
            'Text Left: ' + Math.ceil(text.left) + '<br/>' +
            'Text Width: ' + Math.ceil(text.getWidth()) + '<br/>' +
            'Text Height: ' + Math.ceil(text.getHeight())
            + '</div>'
        )
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

    //var center = canvas.getCenter();
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