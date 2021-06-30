using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Models.Specials
{
    public class InvoiceProductInfo
    {
        public Product Product { get; set; }
        public Invoice Invoice { get; set; }
        public int Qty { get; set; }
    }
}

