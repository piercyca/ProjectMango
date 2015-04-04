$(document).ready(function () {
    $('.sortable-images').sortable({
        handle: '.sortable-move'
    });
    $('.sortable-move').click(function (e) { e.preventDefault(); });
    $('.sortable-delete').click(function (e) {
        e.preventDefault();
        $(this).parent().parent().remove();
    });

    $('#product-form').submit(function () {
        console.log("click");
        var urls = [];
        $('.sortable-item').each(function (index, value) {
            var url = $(value).find('img').prop('src');
            console.log(url);
            urls.push(url);
        });
        $('#ProductImagesString').val(JSON.stringify(urls));
        console.log($('#ProductImagesString').val());
    });
});