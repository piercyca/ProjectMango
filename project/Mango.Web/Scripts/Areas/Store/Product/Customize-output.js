/**
 * Created by Delilah on 2/3/2015.
 */
//Output pulls all data from the database and will be with the end user will see

//Display the product image -- as canvas background
/*NOTE: Product image that used here is created with admin to, and should not be the
/product image*/

$(function () {

    var canvas = new fabric.Canvas('c');
    $('.canvas-container').addClass('panel');
    var center = canvas.getCenter();
    var canvasConfig = $('#Configuration').val();
    var bgurl = $('#CanvasImage').val();

    if (bgurl == "") {
        //default
        var bgurl = $('#noimage').val();
    }

    if (canvasConfig != "") {
        //If the config settings is already set
        var parseConfig = JSON.parse(canvasConfig);
        var imgConfig = parseConfig.layout.pic;
        var textConfig = parseConfig.layout.text;
    }

        //TODO: this is an example -- the final version should grab the image from the admin tool
        canvas.setBackgroundImage(bgurl, canvas.renderAll.bind(canvas), {
            //center the background image
            scaleX: 1,
            scaleY: 1,
            top: center.top,
            left: center.left,
            originX: 'center',
            originY: 'center'
        });

    //Helper -- get all objects by name
    fabric.Canvas.prototype.getItemByName = function (name) {
        var object = null,
            objects = this.getObjects();

        for (var i = 0, len = this.size() ; i < len; i++) {
            if (objects[i].name && objects[i].name === name) {
                object = objects[i];
                break;
            }
        } return object;
    };

    //IMAGES / LOGOS
    //activate clicked icon
    $(".icons div").click(function (e) {
        $('#' + this.id).addClass('active').siblings().removeClass('active');
        var logoURL = $(".active img").attr('src');

        var imgObj = new Image();
        imgObj.src = logoURL;

        var image = new fabric.Image(imgObj);
        image.set({
            //TODO: using and offsetting center for now but NEED to get image position coord from db
            name: 'logo',
            //top: center.top * .75,
            //left: center.left,
            top: imgConfig.height / 2 + imgConfig.top,
            left: imgConfig.width / 2 + imgConfig.left,
            padding: 0,
            cornersize: 0,
            selectable: false,
            originX: 'center',
            originY: 'center'
        });


        if (imgConfig.width/2 > imgConfig.height) {
            image.scaleToHeight(imgConfig.height * .75);
        } else {
            image.scaleToWidth(imgConfig.width * .75);
        }

        if (imgConfig.height/2 > imgConfig.width) {
            image.scaleToWidth(imgConfig.width * .75);
        }
     

        //TODO: get size from db
        //image.scaleToWidth(imgConfig.width * .75);
        //image.scaleToHeight(imgConfig.height);


        //get name in order to overwrite the logo object
        var newImg = canvas.getItemByName(image.name);
        if (!newImg)
        { canvas.add(image); }
        else {
            canvas.remove(newImg);
            canvas.add(image);
        }
    });

    //TEXT / APPLY SELECTED FONT
    function addText() {
        var fontSelection = $('#fontselector').val();
        var addTextField = $('#addTextField').val();
        var link = document.createElement('link');
        link.rel = 'stylesheet';
        link.type = 'text/css';
        link.href = 'http://fonts.googleapis.com/css?family=' + fontSelection;
        $('head').append(link);


        //NOTE: For applying text to canvas -- get from inputs
        //TODO: Fonts should be placed here
        var unformatted = new fabric.Text(addTextField, {
            name: 'text',
            fill: 'white',
            fontFamily: fontSelection,
            fontSize: 25,
            top: textConfig.top,
            left: center.left,
            originX: 'center'
        });


        //need to fit within coordinates
        //TODO: change height and width to textcoord h/w and font selection
        var formatted = wrapCanvasText(unformatted, canvas, textConfig.width, textConfig.height, 'left');
        formatted.name = 'text';
        formatted.selectable = false;

        var newText = canvas.getItemByName(unformatted.name);

        if (!newText) {
            canvas.add(formatted);
        }
        else {
            canvas.remove(newText);
            canvas.add(formatted);
        }
    }

    canvas.renderAll();


    //TODO: Load available fonts from db
    //TODO: load available logos from db

    //apply new text on change
    $("#addTextField").on('keyup', function () {
        addText();
    });
    $("#fontselector").change(function () {
        addText();
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
    $("#download").click(function () {
        downloadFabric(canvas, 'download');
    });


});