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

            /*
             * Important Note: 
             * ---------------
             * To retreive responsed data from controller 
             * the corresponding data name should start
             * with small letter.
             * 
             * Example:
             * --------------
             * 
             * Backend Controller:
             * new {
             *  Success = true,
             *  Message = "Item Added Succesfully",
             *  Product = product,
             *  CartCount = _dbContext.ShoppingCart.Count()
             * };
             * 
             *
             */
            console.log(response.success);
            console.log(response.message);
            console.log(response.product);
            console.log(response.cartCount);

            // Set Cart Count in main _Layout
            document.getElementById("itemsInShoppingCart").innerHTML = response.cartCount;
        },
        error: function (response) {
            console.log("There is some problem")
            console.log(response);
        }
    });
}