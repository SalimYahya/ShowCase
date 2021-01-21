using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Models
{
    public class ShoppingCart
    {
        public string ApplicationUserID { get; set; }
        public int ProductId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Product Product { get; set; }

        public int Qty { get; set; }
    }
}
