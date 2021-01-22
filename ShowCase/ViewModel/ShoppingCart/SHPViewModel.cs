using ShowCase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.ViewModel.ShoppingCart
{
    public class SHPViewModel
    {
        public ApplicationUser ApplicationUser { get; set; }
        public List<ShowCase.Models.Product> Products { get; set; }
        public List<ShowCase.Models.ShoppingCart> ShoppingCarts { get; set; }
    }
}
