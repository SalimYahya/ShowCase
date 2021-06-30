using ShowCase.Models;
using ShowCase.Models.Specials;
using ShowCase.Models.Temp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.ViewModel.Order
{
    public class OrderDetailsViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        public IEnumerable<InvoiceProductInfo> ProductInfo { get; set; }
        public Invoice Invoice { get; set; }
    }

}

