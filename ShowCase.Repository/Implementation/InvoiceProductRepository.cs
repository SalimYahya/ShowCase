using ShowCase.Data;
using ShowCase.Models;
using ShowCase.Repository.Contracts;
using ShowCase.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCase.Repository.Implementation
{
    public class InvoiceProductRepository : RepositoryBase<InvoiceProduct, int>, IInvoiceProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public InvoiceProductRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }
        public async Task AddProductToInvoiceAsync(InvoiceProduct entity)
        {
            await _appDbContext.InvoiceProduct.AddAsync(entity);
        }

        public async Task AddRangeOfProductsToInvoiceAsync(List<InvoiceProduct> entities)
        {
            await _appDbContext.InvoiceProduct.AddRangeAsync(entities);
        }
    }
}
