
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
                Configuration: $(opt.controlConfiguration).val()
            };
            var model = JSON.stringify(modelData);
            $.ajax({
                type: "POST",
                dataType: "json",
                contentType: "application/json",
                url: "/store/api/cartapi/additem",
                data: model,
                success: function(data) {
                    alert(JSON.stringify(data));
                    if (opt.onSuccess && typeof (opt.onSuccess) === "function") {
                        opt.onSuccess();
                    }
                },
                error: function (error) {
                    console.log(error.responseText);
                    //alert(error.responseText);
                }
            });
        });
    },
    RemoveItem: function (opt) {
        /*
         * OPTIONS (opt): onSuccess, controlRemove, index
         */
        $(opt.controlRemove).click(function() {
            
            var model = JSON.stringify({ index: opt.index });
            $.ajax({
                type: "POST",
                dataType: "json",
                contentType: "application/json",
                url: "/store/api/cartapi/removeitem",
                data: model,
                success: function(data) {
                    alert(JSON.stringify(data));
                    if (opt.onSuccess && typeof (opt.onSuccess) === "function") {
                        opt.onSuccess();
                    }
                },
                error: function(error) {
                    //alert(error.responseText);
                }
            });
        });
    },
    UpdateItemQuantity: function(opt) {
        /*
         * OPTIONS (opt): onSuccess, controlUpdateItemQuantity, index, quanity
         */
        $(opt.controlUpdateItemQuantity).click(function() {
            var model = JSON.stringify({ index: opt.index, quanity: opt.quanity });
            $.ajax({
                type: "POST",
                dataType: "json",
                contentType: "application/json",
                url: "/store/api/cartapi/updateitemquantity",
                data: model,
                success: function(data) {
                    alert(JSON.stringify(data));
                    if (opt.onSuccess && typeof (opt.onSuccess) === "function") {
                        opt.onSuccess();
                    }
                },
                error: function(error) {
                    //alert(error.responseText);
                }
            });
        });
    }
};
