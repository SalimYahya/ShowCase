using CrossPlatformApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformApp.Services
{
    public interface IProductService
    {
        Task<Product> GetProductAsync(int productId);
        Task<IEnumerable<Product>> GetProductsListAsync(bool forceRefresh = false);
    }
}
