/**
 * Created by Delilah on 2/3/2015.
 */
//Output pulls all data from the database and will be with the end user will see

//Display the product image -- as canvas background
/*NOTE: Product image that used here is created with admin to, and should not be the
/product image*/

var CustomizeOutput = (function (opt) {
    var canvas = new fabric.Canvas('c');
    $('.canvas-container').addClass('panel'); //for stying purposes only
    var center = canvas.getCenter();
    var canvasConfig = $(opt.controlConfiguration).val();
    var canvasImage = $(opt.controlCanvasImage).val();
    var filter = new fabric.Image.filters.Tint({
        color: '#ddd',
        opacity: 1
    });

    var parseConfig, imgConfig, textConfig;

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


    //TEXT / APPLY SELECTED FONT
    function addText(o) {
        var fontSelection = $(opt.controlFontSelector + ' span.selected').html();
        var addTextField = $(opt.controlTextToAdd).val();
        //NOTE: For applying text to canvas -- get from inputs

        if ((textConfig) && (imgConfig)) {
            //TODO: Fonts should be placed here
            var unformatted = new fabric.Text(addTextField, {
                name: 'text',
                fill: '#eeeeee',
                fontFamily: fontSelection,
                fontSize: 25,
                top: textConfig.top,
                left: textConfig.width / 2 + textConfig.left,
                originX: 'center',
                selectable: false
            });

            //fits coords
            var formatted = wrapCanvasText(unformatted, canvas, textConfig.width, textConfig.height, o);
            formatted.name = 'text';
            formatted.orginX = 'center';
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
    }

    //RESIZE CANVAS ONLOAD
    resizeCanvas();
    window.onresize = function () { resizeCanvas(); }

    function resizeCanvas() {
        //let's make canvas responsive
        var oriX = 520, oriY = 500; //default
        var x = $(window).outerWidth() || $(document.documentElement).width() || $('body').width();
        var p = x - $("#logos").outerWidth(); //padding      
        var cv = $("canvas");
        var cc = $(".canvas-container");
        var cx, cy;

        cx = (x - p);
        cy = (x * oriY / oriX) - p;

        //shrink the canvas as the window decreases
        if (x < 820) {
            cc.attr("style", "width: " + cx + "px; height: " + cy + "px;");
            cv.attr("style", "width: " + cx + "px; height: " + cy + "px; position: relative; left: 0px");
        }
            //show default size
        else {
            cc.attr("style", "width: " + oriX + "px; height: " + oriY + "px;");
            cv.attr("style", "width: " + oriX + "px; height: " + oriY + "px; position: relative; left: 0px");
        }
    }

    // INITIALIZE
    function init() {
        //Font and Selections
        //style preload and style font options
        $(opt.controlFontList + " li a").each(function(index) {

            var v = $(this).text();
            var link = document.createElement('link');
            link.rel = 'stylesheet';
            link.type = 'text/css';
            link.href = 'https://fonts.googleapis.com/css?family=' + v;
            $('head').append(link);
            $(this).css("font-family", v);
        });

        //style selected fonts
        var fontSelection = $(opt.controlFontSelector + ' span.selected').html();
        $(opt.controlFontSelector + ' span.selected').css("font-family", fontSelection);


        //selections
        $(opt.controlFontList + " li").click(function () {
        //$('body').on('click', '.option li', function () {
            var i = $(this).parents('.select').attr('id');
            var v = $(this).children().text();
            var o = $(this).attr('id');
            $('#' + i + ' .selected').attr('id', o).text(v).css("font-family", v);
            console.log(i);
            console.log(v);
            console.log(o);
            addText();
        });

        if (canvasConfig !== "") {
            //If the config settings is already set
            parseConfig = JSON.parse(canvasConfig);
            imgConfig = parseConfig.layout.pic;
            textConfig = parseConfig.layout.text;
        }


        if (typeof textConfing === 'undefined' && !textConfig) {
            $(opt.wrapperTextOptions).hide();
        }
        if (typeof imgConfing === 'undefined' && !imgConfig) {
            $(opt.wrapperLogoOptions).hide();
        }

        if ((!textConfig) && (!imgConfig)) {
            $(opt.wrapperTextOptions).show();
            $(opt.wrapperLogoOptions).show();
            $('h3:first').append(
                '<div class="warning">' +
                '<i class="fa fa-exclamation-triangle fa-fw"></i><strong>The Live Preview is unavailable.</strong> However, you can still order this product.' +
                '</div>');
        }

        canvas.setBackgroundImage(canvasImage, canvas.renderAll.bind(canvas), {
            //center the background image (minus 8 for padding ?)
            scaleX: 1,
            scaleY: 1,
            top: center.top - 8,
            left: center.left - 8,
            originX: 'center',
            originY: 'center'
        });

        $(opt.controlTextAlign + ' a').click(function() {
            var o = $(this).attr('id');
            $('#' + o + ' .selected').attr('id', o);
            addText(o);
        });/*end font and selections*/

        if (canvasImage === "") {
            //default
            canvasImage = $(opt.imgNoImage).val();
        }


        //IMAGES / LOGOS
        //activate clicked icon
        $(opt.wrapperLogoOptions + " div").click(function (e) {
            $('#' + this.id).addClass('active').siblings().removeClass('active');
            var logoUrl = $(".active img").attr('src');

            var imgObj = new Image();
            imgObj.src = logoUrl;

            var image = new fabric.Image(imgObj);
            image.filters.push(filter);
            image.applyFilters(canvas.renderAll.bind(canvas));

            if (!imgConfig) {
                return;
            }

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


            if (imgConfig.width / 2 > imgConfig.height) {
                image.scaleToHeight(imgConfig.height * .75);
            } else {
                image.scaleToWidth(imgConfig.width * .75);
            }

            if (imgConfig.height / 2 > imgConfig.width) {
                image.scaleToWidth(imgConfig.width * .75);
            }

            //get name in order to overwrite the logo object
            var newImg = canvas.getItemByName(image.name);
            if (!newImg) {
                canvas.add(image);
            }
            else {
                canvas.remove(newImg);
                canvas.add(image);
            }
        });

        //apply new text on change
        $(opt.controlTextToAdd).on('change keyup paste', function () {
            addText();
        });
        $(opt.controlFontSelector).change(function () {
            addText();
        });
  
    }





    init();

    this.canvasDataUrl = function() {
        return canvas.toDataURL();
    }


 
});   