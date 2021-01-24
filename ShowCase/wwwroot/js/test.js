// ************************************************
// Shopping Cart API
// ************************************************

var shoppingCart = (function () {
    // =============================
    // Private methods and propeties
    // =============================
    cart = [];

    // Constructor
    function Item(id, name, desc, price, image, count) {
        this.id = id;
        this.name = name;
        this.desc = desc;
        this.price = price;
        this.image = image;
        this.count = count;
    }

    // Save cart
    function saveCart() {
        sessionStorage.setItem('shoppingCart', JSON.stringify(cart));
        sessionStorage.setItem('cart');

    }

    // Load cart
    function loadCart() {
        cart = JSON.parse(sessionStorage.getItem('shoppingCart'));
    }
    if (sessionStorage.getItem("shoppingCart") != null) {
        loadCart();
    }

 
    // =============================
    // Public methods and propeties
    // =============================
    var obj = {};

    // Add to cart
    obj.addItemToCart = function (id, name, desc, price, image, count) {

        for (var item in cart) {
            if (cart[item].id === id) {
                cart[item].count++;
                saveCart();
                return;
            }
        }

        var item = new Item(id, name, desc, price, image, count);
        cart.push(item);
        saveCart();
    }
    // Set count from item
    obj.setCountForItem = function (id, count) {
        for (var i in cart) {
            if (cart[i].id === id) {
                cart[i].count = count;
                break;
            }
        }
    };
    // Remove item from cart
    obj.removeItemFromCart = function (id) {
        for (var item in cart) {
            if (cart[item].id === id) {
                cart[item].count--;
                if (cart[item].count === 0) {
                    cart.splice(item, 1);
                }
                break;
            }
        }
        saveCart();
    }

    // Remove all items from cart
    obj.removeItemFromCartAll = function (id) {
        for (var item in cart) {
            if (cart[item].id === id) {
                cart.splice(item, 1);
                break;
            }
        }
        saveCart();
    }

    // Clear cart
    obj.clearCart = function () {
        cart = [];
        saveCart();
    }

    // Count cart 
    obj.totalCount = function () {
        var totalCount = 0;
        for (var item in cart) {
            totalCount += cart[item].count;
        }
        return totalCount;
    }

    // Total cart
    obj.totalCart = function () {
        var totalCart = 0;
        for (var item in cart) {
            totalCart += cart[item].price * cart[item].count;
        }
        return Number(totalCart.toFixed(2));
    }

    // List cart
    obj.listCart = function () {
        var cartCopy = [];
        for (i in cart) {
            item = cart[i];
            itemCopy = {};
            for (p in item) {
                itemCopy[p] = item[p];

            }
            itemCopy.total = Number(item.price * item.count).toFixed(2);
            cartCopy.push(itemCopy)
        }
        return cartCopy;
    }

    // cart : Array
    // Item : Object/Class
    // addItemToCart : Function
    // removeItemFromCart : Function
    // removeItemFromCartAll : Function
    // clearCart : Function
    // countCart : Function
    // totalCart : Function
    // listCart : Function
    // saveCart : Function
    // loadCart : Function
    return obj;
})();


// *****************************************
// Triggers / Events
// ***************************************** 
// Add item
$('.add-to-cart').click(function (event) {
    event.preventDefault();

    var id = Number($(this).data('id'));
    var name = $(this).data('name');
    var desc = $(this).data('desc');
    var price = Number($(this).data('price'));
    var image = $(this).data('image');

    shoppingCart.addItemToCart(id, name, desc, price, image, 1);
    displayCart();
});


// Clear items
$('.clear-cart').click(function () {
    shoppingCart.clearCart();
    displayCart();
});


function displayCart() {
    var cartArray = shoppingCart.listCart();
    var output = "";
    for (var i in cartArray) {
        output += "<tr>"
            + "<td class='align-middle'><img class='img-fluid' width='150' height='180' src='" + cartArray[i].image + "'/></td> "
            + "<td class='align-middle'>" + cartArray[i].name + "</td>"
            + "<td class='align-middle'>(" + cartArray[i].price + ")</td>"
            + "<td class='align-middle'><div class='input-group'><button class='minus-item input-group-addon btn btn-primary' data-id=" + cartArray[i].id + ">-</button>"
            + "<input type='number' class='item-count form-control' data-id='" + cartArray[i].id + "' value='" + cartArray[i].count + "'>"
            + "<button class='plus-item btn btn-primary input-group-addon' data-id=" + cartArray[i].id + ">+</button></div></td>"
            + "<td class='align-middle'><button class='delete-item btn btn-danger' data-id=" + cartArray[i].id + ">X</button></td>"
            + " = "
            + "<td class='align-middle'>" + cartArray[i].total + "</td>"
            + "</tr>";
    }
    $('.show-cart').html(output);
    $('.total-cart').html(shoppingCart.totalCart());
    $('.total-count').html(shoppingCart.totalCount());
}

// Delete item button

$('.show-cart').on("click", ".delete-item", function (event) {
    var id = $(this).data('id')
    shoppingCart.removeItemFromCartAll(id);
    displayCart();
})


// -1
$('.show-cart').on("click", ".minus-item", function (event) {
    var id = $(this).data('id')
    shoppingCart.removeItemFromCart(id);
    displayCart();
})
// +1
$('.show-cart').on("click", ".plus-item", function (event) {
    var id = $(this).data('id')
    shoppingCart.addItemToCart(id);
    displayCart();
})

// Item count input
$('.show-cart').on("change", ".item-count", function (event) {
    var id = $(this).data('id');
    var count = Number($(this).val());
    shoppingCart.setCountForItem(id, count);
    displayCart();
});

displayCart();




function OrderNow() {
    //var cart = JSON.stringify(sessionStorage.getItem('shoppingCart'));
    var data1 = {};
    data1.ItmeList = sessionStorage.getItem('shoppingCart');

    var data = {
        companyId: 5,
        people: [
            { name: 'Some Guy', age: 34, location: 'Las Vegas, NV 89128' },
            { name: 'Some Girl', age: 25, location: 'Seattle, WA 98145' }
        ]
    };
    
    if (cart != null) {
        console.log("Session: " + sessionStorage.getItem('shoppingCart'));
        console.log("data1: " + JSON.stringify(data1));
        console.log("data: " + JSON.stringify(data));

        $.ajax({
            async: true,
            type: 'Post',
            contentType: false,
            processData: false,
            data: test,
            url: '/Shopping/Order',
            success: function (response) {
                console.log("response.sussces: " + response.success);
                console.log("response.message: " + response.message);
                console.log("response.data: " + response.data);
            },
            error: function (response) {
                console.log("There is some problem")
                console.log(response);
            }
        });

    } else {
        console.log("Empty");
    }
}