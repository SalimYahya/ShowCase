using Microsoft.EntityFrameworkCore;
using ShowCase.Data;
using ShowCase.Models;
using ShowCase.Repository.Contracts;
using ShowCase.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShowCase.Repository
{
    public class ProductRepository : RepositoryBase<Product, int>, IProductRepository
    {
        private readonly AppDbContext _appDbContext;
        public ProductRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }

        public Task<Product> GetProductWithOwner(int id)
        {
            return _appDbContext.Products
                                    .Include(u => u.ApplicationUser)
                                    .Where(p => p.Id == id)
                                    .FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Product>> GetAllProductsOrderByDescendingAsync()
        {
            return await _appDbContext.Products
                                .OrderByDescending(p => p.CreatedAt)
                                .ToListAsync();
        }
        public async Task<IEnumerable<Product>> GetAllProductsWithOwnersOrderByDescendingAsync(string userId)
        {
            return await _appDbContext.Products
                                .OrderByDescending(p => p.CreatedAt)
                                .Include(u => u.ApplicationUser)
                                .Where(u => u.ApplicationUser.Id == userId)
                                .ToListAsync();
        }

        public async Task<List<Product>> GetAllProductsListWithOwnersOrderByDescendingAsync()
        {
            return await _appDbContext.Products
                            .Include(p => p.ApplicationUser)
                            .OrderByDescending(p => p.CreatedAt)
                            .ToListAsync();
        }
    }
}
