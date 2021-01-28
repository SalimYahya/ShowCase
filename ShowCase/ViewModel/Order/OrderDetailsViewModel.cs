using ShowCase.Models;
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
        public List<InvoiceProductInfo> ProductInfo { get; set; }
        public Invoice Invoice { get; set; }
    }

}

