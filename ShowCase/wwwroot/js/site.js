// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function AddToCart(item) {

    var itemId = $(item).attr("itemid");
    var itemQty = Math.floor(Math.random() * 10) + 1;
    var formData = new FormData();
    formData.append("ItemId", itemId);
    formData.append("ItemQty", itemQty);

    $.ajax({
        async: true,
        type: 'Post',
        contentType: false,
        processData: false,
        data: formData,
        url: '/Shopping/AddToCart',
        success: function (response) {
            
            if (response.success) {
                response.success
                console.log("Yes" + response.success);
                console.log("Yes" + response.Message);
            }
        },
        error: function (response) {
            console.log("There is some problem")
            console.log(response);
        }
    });
}