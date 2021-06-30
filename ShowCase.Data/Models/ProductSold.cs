using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Models
{
    public class ProductSold
    {
        /*
         *  Navigate to Product Table
         */
        public int ProductId { get; set; }
        public Product Product { get; set; }

        /*
         *  Navigate to Sold Table
         */
        public int SoldId { get; set; }
        public Sold Sold { get; set; }
    }
}
