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

        IProductService _productService = DependencyService.Get<IProductService>();

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

        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }

        async Task ExecuteLoadProductsCommand()
        {
            Debug.WriteLine("ExecuteLoadProductsCommand");

            IsBusy = true;

            try
            {

                //string url = "https://10.0.2.2:5001/api/Products";

                //Debug.WriteLine("Calling Rest");
                //HttpClientHandler insecureHandler = GetInsecureHandler();
                //HttpClient client = new HttpClient(insecureHandler);

                //var json = await client.GetStringAsync(url);
                //Debug.WriteLine("Json", json.ToString());

                //var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                //Debug.WriteLine("Products", products.ToString());


                Products.Clear();
                var products = await ProductDataStore.GetProductsAsync();
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
