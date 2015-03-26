$(function() {

    var canvas = new fabric.Canvas('c');
    //Rect for Images
    var pic = new fabric.Rect({
        left: 0,
        top: 0,
        fill: 'green',
        width: 480,
        height: 220,
        opacity: 0.8

    });
    //Rect for Text
    var text = new fabric.Rect({
        left: 0,
        top: pic.height,
        fill: 'blue',
        width: 480,
        height: 220,
        opacity: 0.8
    });


    //on click add objects
    $("#addPic").click(function() {
        //remove if exist then add
        canvas.remove(pic);
        canvas.add(pic);
    });

    $("#addText").click(function() {
        //remove if exist then add
        canvas.remove(text);
        canvas.add(text);
    });

    //observe any mouse movement
    canvas.observe('mouse:move', function() {
        $("#contents").html(
            '<div class=\"pic\">' +
            'Pic Top: ' + Math.ceil(pic.top) + '<br/>' +
            'Pic Left: ' + Math.ceil(pic.left) + '<br/>' +
            'Pic Width: ' + Math.ceil(pic.getWidth()) + '<br/>' +
            'Pic Height: ' + Math.ceil(pic.getHeight()) + '<br/><br/>' +
            '</div><div class=\"text\">' +
            'Text Top: ' + Math.ceil(text.top) + '<br/>' +
            'Text Left: ' + Math.ceil(text.left) + '<br/>' +
            'Text Width: ' + Math.ceil(text.getWidth()) + '<br/>' +
            'Text Height: ' + Math.ceil(text.getHeight()) + '<br/>'
            + '</div>'
        )
    });

    //remove selected object
    $("#removeObject").click(function() {
        var activeO = canvas.getActiveObject();
        if (!activeO) return;
        canvas.remove(activeO)
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

//download should be productname or id
    $("#download").click(function() {
        downloadFabric(canvas, 'download');
    });
});