using CrossPlatformApp.DTO.Special;
using CrossPlatformApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CrossPlatformApp.ViewModels
{
    [QueryProperty(nameof(ProductId), nameof(ProductId))]
    public class ProductDetailViewModel : BaseViewModel
    {
        private const string TAG = nameof(ProductDetailViewModel);

        private int _id;
        private string _name;
        private string _description;
        private double _price;
        private string _username;
        private int _quantity;

        private Product _productModel;

        public Command IncreaseQuantityCommand { get; set; }
        public Command DecreaseQuantityCommand { get; set; }
        public Command AddToCartCommand { get; set; }

        public ProductDetailViewModel() : base()
        {
            Title = "Product Details";
            IncreaseQuantityCommand = new Command(()=> IncreaseQuantity());
            DecreaseQuantityCommand = new Command(() => DecreaseQuantity());
            AddToCartCommand = new Command(()=> AddProductToShoppingCart());

            base.Initialize();
        }

        private void AddProductToShoppingCart()
        {
            if (Quantity > 0)
            {
                ProductInCartInfo productInfo = new ProductInCartInfo 
                {
                    ProductId = Id,
                    ProductName = Name,
                    ProductPrice = Price,
                    ProductQty = Quantity
                };

                Debug.WriteLine($"{TAG} - AddProductToShoppingCart: Adding {productInfo.ToString()}"); 
                MessagingCenter.Send("UpdateShoppingCart", "Add Product", productInfo);
            }
            else
                Debug.WriteLine($"{TAG} - AddProductToShoppingCart: You need to increase Qty");

        }

        private void DecreaseQuantity()
        {
            if (Quantity >= 1)
                Quantity--;

            Debug.WriteLine($"{TAG} - Quantity: {Quantity}");
        }

        private void IncreaseQuantity()
        {
            Quantity++;
            Debug.WriteLine($"{TAG} - Quantity: {Quantity}");
        }

        private int productId;
        public int ProductId 
        {
            get { return productId; }
            set 
            {
                productId = value;
                LoadProduct(value);
            }
        }

        public async void LoadProduct(int productId) 
        {
            try 
            {
                var product = await _productService.GetProductAsync(productId);
                Id = product.Id;
                Name = product.Name;
                Description = product.Description;
                Price = product.Price;
                Username = product.UserName;
            } 
            catch (Exception ex) 
            {
                Debug.WriteLine($"{TAG}: Faild to load product with id:{productId}, due to error: {ex}");
            }
        }

        public int Id { get => _id; set =>SetProperty(ref _id, value); }
        public string Name { get => _name; set => SetProperty(ref _name, value); }
        public string Description { get => _description; set => SetProperty(ref _description, value); }
        public double Price { get => _price; set => SetProperty(ref _price, value); }
        public string Username { get => _username; set => SetProperty(ref _username, value); }
        public int Quantity { get => _quantity; set=> SetProperty(ref _quantity, value); }

        public Product Product 
        {
            get { return _productModel; }
            set
            {
                _productModel = new Product
                {
                    Id = Id,
                    Name = Name,
                    Description = Description,
                    Price = Price,
                    UserName = Username
                };
            }
        }

    }
}


//Debug.WriteLine($"Searching product with id: {ProductId}");
//Debug.WriteLine($"Searching product with id: {productId}");
//Debug.WriteLine($"TypeOf(ProductId): {ProductId.GetType()}");