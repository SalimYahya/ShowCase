using CrossPlatformApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformApp.Services
{
    public class ProductService : IProductService
    {
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
        public async Task<IEnumerable<Product>> GetProductsAsync(bool forceRefresh = false)
        {
            string url = "https://10.0.2.2:5001/api/Products";

            Debug.WriteLine("Calling Rest");
            HttpClientHandler insecureHandler = GetInsecureHandler();
            HttpClient client = new HttpClient(insecureHandler);

            var json = await client.GetStringAsync(url);
            Debug.WriteLine("Json", json.ToString());

            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);

            //Debug.WriteLine("Products", products.ToString());
            //List<Product> products = new List<Product>
            //{
            //    new Product { Id = 1, Name = "First item", Description = "This is an item description." },
            //    new Product { Id = 2, Name = "Second item", Description = "This is an item description." },
            //    new Product { Id = 3, Name = "Third item", Description = "This is an item description." },
            //    new Product { Id = 4, Name = "Fourth item", Description = "This is an item description." },
            //    new Product { Id = 5, Name = "Fifth item", Description = "This is an item description." },
            //    new Product { Id = 6, Name = "Sixth item", Description = "This is an item description." }
            //};

            //HttpClient client = new HttpClient {BaseAddress = new Uri("http://10.0.2.2:500") };

            //var json = await client.GetStringAsync("api/products");
            //var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
            //Debug.WriteLine(products.ToString());

            return products;
        }
    }
}

