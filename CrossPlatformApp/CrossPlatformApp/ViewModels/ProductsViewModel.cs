using CrossPlatformApp.Models;
using CrossPlatformApp.Services;
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
        public ObservableCollection<Product> Products { get; }
        public Command LoadProductsCommand { get; }

        public ProductsViewModel()
        {
            Title = "Browse Products";
            Products = new ObservableCollection<Product>();

            LoadProductsCommand = new Command(async () => await ExecuteLoadProductsCommand());
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }

        async Task ExecuteLoadProductsCommand()
        {
            Debug.WriteLine("ExecuteLoadProductsCommand");

            IsBusy = true;

            try
            {
                Products.Clear();
                var products = await _productService.GetProductsAsync();
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
    }
}
