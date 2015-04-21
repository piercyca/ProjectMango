
var CartService = {
    AddItem: function (opt) {
        /*
         * OPTIONS (opt): onSuccess, controlProductId, controlQuantity, controlPrice, controlConfiguration
         */
        var modelData;

        function doAddItem(orderImage) {
            modelData = {
                OrderImage: orderImage,
                ProductId: $(opt.controlProductId).val(),
                Quantity: $(opt.controlQuantity).val(),
                UnitPrice: $(opt.controlPrice).val(),
                Configuration: $(opt.controlConfiguration).val()
            };
            var model = JSON.stringify(modelData);
            $.ajax({
                type: "POST",
                dataType: "json",
                contentType: "application/json",
                url: "/api/cart/additem",
                data: model,
                success: function (data) {
                    console.log(JSON.stringify(data));
                    if (opt.onSuccess && typeof (opt.onSuccess) === "function") {
                        opt.onSuccess();
                    }
                },
                error: function (error) {
                    //console.log(error.responseText);
                }
            });
        }

        function submitOrderImage() {
            var imageString = opt.customizeOutput.canvasDataUrl();
            $.ajax({
                type: "POST",
                dataType: "json",
                contentType: "application/json",
                url: "/api/orderimage",
                processData: false,
                data: JSON.stringify({ value: imageString }),
                success: function (results) {
                    doAddItem(results);
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    console.log(xhr.responseText);
                }
            });
        }

        $(opt.controlSubmit).click(function () {
            submitOrderImage();
            console.log(modelData);


        });
    },
    RemoveItem: function (opt) {
        /*
         * OPTIONS (opt): onSuccess, index
         */
            $.ajax({
                type: "POST",
                dataType: "json",
                contentType: "application/json",
                url: "/api/cart/removeitem",
                data: opt.index,
                success: function(data) {
                    //console.log(JSON.stringify(data));
                    if (opt.onSuccess && typeof (opt.onSuccess) === "function") {
                        opt.onSuccess();
                    }
                },
                error: function(error) {
                    //console.log(error.responseText);
                }
            });
    },
    UpdateItemQuantity: function(opt) {
        /*
         * OPTIONS (opt): onSuccess, index, quantity
         */
        var model = JSON.stringify({ index: opt.index, quantity: opt.quantity });
        $.ajax({
            type: "POST",
            dataType: "json",
            contentType: "application/json",
            url: "/api/cart/updateitemquantity",
            data: model,
            success: function(data) {
                console.log(JSON.stringify(data));
                if (opt.onSuccess && typeof (opt.onSuccess) === "function") {
                    opt.onSuccess();
                }
            },
            error: function(error) {
                console.log(error.responseText);
            }
        });
    }
};
