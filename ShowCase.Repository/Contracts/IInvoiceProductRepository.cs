using ShowCase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCase.Repository.Contracts
{
    public interface IInvoiceProductRepository : IRepositoryBase<InvoiceProduct, int>
    {
        Task AddProductToInvoiceAsync(InvoiceProduct entity);
        Task AddRangeOfProductsToInvoiceAsync(List<InvoiceProduct> entities);
    }
}
