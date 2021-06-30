using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Models
{
    public class InvoiceProduct
    {
        /*
         *  Navigate to Invoice Table
         */
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }


        /*
         *  Navigate to Product Table
         */
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Qty { get; set; }

    }
}
