var SortableImages = (function (opt) {
    $(document).ready(function () {
        $('.sortable-images').sortable({
            handle: '.sortable-move'
        });
        $('.sortable-move').click(function (e) { e.preventDefault(); });
        $('.sortable-delete').click(function (e) {
            e.preventDefault();
            $(this).parent().parent().remove();
        });

        $(opt.formId).submit(function () {
            console.log("click");
            var urls = [];
            $('.sortable-item').each(function (index, value) {
                var url = $(value).find('img').prop('src');
                console.log(url);
                urls.push(url);
            });
            $(opt.controlImagesString).val(JSON.stringify(urls));
            console.log($(opt.controlImagesString).val());
        });
    });
});