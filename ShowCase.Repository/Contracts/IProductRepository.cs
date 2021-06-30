using ShowCase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCase.Repository.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product, int>
    {
        Task<Product> GetProductWithOwner(int id);
        Task<IEnumerable<Product>> GetAllProductsOrderByDescendingAsync();
        Task<IEnumerable<Product>> GetAllProductsWithOwnersOrderByDescendingAsync(string userId);

        //
        // Summary:
        //     
        //
        // Parameters:
        //   newEmail:
        //     The new email address.
        //
        // Returns:
        //
    }
}
