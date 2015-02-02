// Run only when HTML is loaded and
// DOM properly initialized (courtesy jquery)
$(function () {

    // Obtain a canvas drawing surface from fabric.js
    var canvas = new fabric.Canvas('c');

    // Create a text object.
    // Does not display it-the canvas doesn't
    // know about it yet.
    var pic = new fabric.Rect({
        left: 0,
        top: 0,
        fill: 'green',
        width: 100,
        height: 100,
        opacity: 0.8

    });

    var text = new fabric.Rect({
        left: 0,
        top: pic.height,
        fill: 'blue',
        width: 100,
        height: 100,
        opacity: 0.8
    });

    // Attach it to the canvas object, then (re)display
    // the canvas.

    $("#addPic").click(function(){
        //remove if exist then add
        canvas.remove(pic);
        canvas.add(pic);
    });

    $("#addText").click(function(){
        //remove if exist then add
        canvas.remove(text);
        canvas.add(text);
    });

    pic.on('moving', function() {
        $("#contents").html(
            '<div class=\"pic\">'+
            'Pic Top: ' + pic.top + '<br/>' +
            'Pic Left: ' + pic.left + '<br/>' +
            'Pic Width: ' + pic.getWidth() + '<br/>' +
            'Pic Height: ' + pic.getHeight() + '<br/><br/>' +
            '</div><div class=\"text\">'+
            'Text Top: ' + text.top + '<br/>' +
            'Text Left: ' + text.left + '<br/>' +
            'Text Width: ' + text.getWidth() + '<br/>' +
            'Text Height: ' + text.getHeight() + '<br/>'
            + '</div>'
        )
    });

    text.on('moving', function() {
        $("#contents").html(
            '<div class=\"pic\">'+
            'Pic Top: ' + pic.top + '<br/>' +
            'Pic Left: ' + pic.left + '<br/>' +
            'Pic Width: ' + pic.getWidth() + '<br/>' +
            'Pic Height: ' + pic.getHeight() + '<br/><br/>' +
            '</div><div class=\"text\">'+
            'Text Top: ' + text.top + '<br/>' +
            'Text Left: ' + text.left + '<br/>' +
            'Text Width: ' + text.getWidth() + '<br/>' +
            'Text Height: ' + text.getHeight() + '<br/>'
            + '</div>'
        )
    });

    $("#removeObject").click(function(){
        var activeO = canvas.getActiveObject();
        if(!activeO) return;
        canvas.remove(activeO) });
});