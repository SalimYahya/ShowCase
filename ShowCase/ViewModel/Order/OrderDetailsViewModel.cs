using ShowCase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.ViewModel.Order
{
    public class OrderDetailsViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        public List<ShowCase.Models.Product> Products { get; set; }
        public Invoice Invoice { get; set; }
    }
}
