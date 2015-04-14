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

    //Font and Selections
    //style preload and style font options
    $(".option li a").each(function (index) {
        var v = $(this).html();
        var link = document.createElement('link');
        link.rel = 'stylesheet';
        link.type = 'text/css';
        link.href = 'https://fonts.googleapis.com/css?family=' + v;
        $('head').append(link);
        $(this).css("font-family", v);
    });

    //style selected fonts
    var fontSelection = $('#fontselector span.selected').html();
    $('#fontselector span.selected').css("font-family", fontSelection);

    //selections
    $('body').on('click', '.option li', function () {
        var i = $(this).parents('.select').attr('id');
        var v = $(this).children().text();
        var o = $(this).attr('id');
        $('#' + i + ' .selected').attr('id', o).text(v).css("font-family", v);
        addText();
    });

    $('body').on('click', '#alignBtn a', function () {
        var o = $(this).attr('id');
        $('#' + o + ' .selected').attr('id', o);
        addText(o);
    }); /*end font and selections*/



    if (bgurl === "") {
        //default
        var bgurl = $('#noimage').val();
    }

    if (canvasConfig !== "") {
        //If the config settings is already set
        var parseConfig = JSON.parse(canvasConfig);
        var imgConfig = parseConfig.layout.pic;
        var textConfig = parseConfig.layout.text;
    }


    if (!textConfig) {
        $('#textOptions').hide();
    }
    if (!imgConfig) {
        $('#logos').hide();
    }

    if ((!textConfig) && (!imgConfig)) {
        $('#textOptions').show(); $('#logos').show();
        $('h3:first').append('<div class="warning"><i class="fa fa-exclamation-triangle fa-fw"></i><strong>The Live Preview is unavailable.</strong> However, you can still order this product.</div>');
    }

        canvas.setBackgroundImage(bgurl, canvas.renderAll.bind(canvas), {
            //center the background image (minus 8 for padding ?)
            scaleX: 1,
            scaleY: 1,
            top: center.top - 8,
            left: center.left - 8,
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

        if (!imgConfig) return;
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
     
        //get name in order to overwrite the logo object
        var newImg = canvas.getItemByName(image.name);
        if (!newImg)
        { canvas.add(image); }
        else {
            canvas.remove(newImg);
            canvas.add(image);
        }
    });

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


    //TEXT / APPLY SELECTED FONT
    function addText(o) {
        var fontSelection = $('#fontselector span.selected').html();
        var addTextField = $('#addTextField').val();
        //NOTE: For applying text to canvas -- get from inputs

        if ((textConfig) && (imgConfig)) {
            //TODO: Fonts should be placed here
            var unformatted = new fabric.Text(addTextField, {
                name: 'text',
                fill: 'white',
                fontFamily: fontSelection,
                fontSize: 25,
                top: textConfig.top,
                left: textConfig.width / 2 + textConfig.left,
                originX: 'center'
            });


            //fits coords
            var formatted = wrapCanvasText(unformatted, canvas, textConfig.width, textConfig.height, o);
            formatted.name = 'text';
            formatted.orginX = 'center';
            formatted.selectable = true;

            var newText = canvas.getItemByName(unformatted.name);


            if (!newText) {
                canvas.add(formatted);
            }
            else {
                canvas.remove(newText);
                canvas.add(formatted);
            }
        }
    }

});