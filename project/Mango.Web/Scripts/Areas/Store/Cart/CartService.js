
var CartService = {
    AddItem: function (opt) {
        /*
         * OPTIONS (opt): onSuccess, controlProductId, controlQuantity, controlPrice, controlConfiguration
         */

        $(opt.controlSubmit).click(function() {
            var modelData = {
                ProductId: $(opt.controlProductId).val(),
                Quantity: $(opt.controlQuantity).val(),
                UnitPrice: $(opt.controlPrice).val(),
                Configuration: $(opt.controlConfiguration).val(),
                CartImg: canvas.toDataURL("image/png").toString() //may want to convert from base64 and save it
            };
            var model = JSON.stringify(modelData);
            console.log(model);

            $.ajax({
                type: "POST",
                dataType: "json",
                contentType: "application/json",
                url: "/store/api/cartapi/additem",
                data: model,
                success: function(data) {
                    console.log(JSON.stringify(data));
                    if (opt.onSuccess && typeof (opt.onSuccess) === "function") {
                        opt.onSuccess();
                    }
                },
                error: function (error) {
                    console.log(error.responseText);
                }
            });
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
                url: "/store/api/cartapi/removeitem",
                data: opt.index,
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
            url: "/store/api/cartapi/updateitemquantity",
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
