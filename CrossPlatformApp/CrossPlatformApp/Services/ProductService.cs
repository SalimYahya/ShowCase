using CrossPlatformApp.Models;
using CrossPlatformApp.Utils;
using CrossPlatformApp.Utils.Urls;
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
        public const string TAG = nameof(ProductService);
        HttpClient _httpClinet;

        public ProductService()
        {
            _httpClinet = new HttpClient(HttpHandler
                           .GetInstance()
                           .GetInsecureHandler()
                       );
        }

        public async Task<Product> GetProductAsync(int productId)
        {
            Debug.WriteLine($"{TAG}: {nameof(ProductService.GetProductAsync)}, Api: {ApiEndpoints.Products.GetProduct+productId}");

            var json = await _httpClinet.GetStringAsync(ApiEndpoints.Products.GetProduct + productId);
            Product product = JsonConvert.DeserializeObject<Product>(json);

            return product;
        }

        public async Task<IEnumerable<Product>> GetProductsListAsync(bool forceRefresh = false)
        {
            Debug.WriteLine(TAG, $"Member: {nameof(ProductService.GetProductsListAsync)}, Api: {ApiEndpoints.Products.GetAllProducts}");

            var json = await _httpClinet.GetStringAsync(ApiEndpoints.Products.GetAllProducts);
            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);

            return products;
        }
    }
}


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

