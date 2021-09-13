using CrossPlatformApp.Models;
using CrossPlatformApp.Services;
using CrossPlatformApp.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CrossPlatformApp.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        private const string TAG = nameof(ProductsViewModel);
        private Product _selectedProduct;

        public ObservableCollection<Product> Products { get; }
        public Command LoadProductsCommand { get; }
        public Command ProductTapped { get; }

        public ProductsViewModel()
        {
            Title = "Products";
            Products = new ObservableCollection<Product>();
            
            LoadProductsCommand = new Command(async () => await ExecuteLoadProductsCommand());
            ProductTapped = new Command<Product>(OnProductSelected);
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedProduct = null;
        }

        async Task ExecuteLoadProductsCommand()
        {
            Debug.WriteLine("ExecuteLoadProductsCommand");

            IsBusy = true;

            try
            {
                Products.Clear();
                var products = await _productService.GetProductsListAsync();
                Debug.WriteLine(products.ToString());

                foreach (var product in products)
                {
                    Products.Add(product);
                    Debug.WriteLine(product);
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                SetProperty(ref _selectedProduct, value);
                OnProductSelected(value);
            }
        }

         async void OnProductSelected(Product product)
        {
            if (product == null)
                return;

            Debug.Write($"{TAG} - Product: {product.ToString()}");
            await Shell.Current.GoToAsync($"{nameof(ProductDetailPage)}?{nameof(ProductDetailViewModel.ProductId)}={product.Id}");
        }

        public override void Initialize()
        {
            base.Initialize();
        }
    }
}
