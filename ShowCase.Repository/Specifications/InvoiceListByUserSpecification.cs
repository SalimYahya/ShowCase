using ShowCase.Models;
using ShowCase.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCase.Repository.Specifications
{
    public class InvoiceListByUserSpecification : BaseSpecification<Invoice>
    {
        public InvoiceListByUserSpecification()
        {
            AddInclude(i => i.ApplicationUser);
            AddOrderByDescending(i => i.CreatedAt);
        }
    }
}
