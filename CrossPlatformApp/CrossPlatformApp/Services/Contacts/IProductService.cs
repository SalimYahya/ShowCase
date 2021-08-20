using CrossPlatformApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CrossPlatformApp.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProductsAsync(bool forceRefresh = false);
    }
}
