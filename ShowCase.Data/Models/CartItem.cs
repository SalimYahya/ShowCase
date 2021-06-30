using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Models
{
    public class CartItem
    {
        public int id { get; set; }
        public string name { get; set; }

        public string desc { get; set; }
        public double price { get; set; }
        public string image { get; set; }

        public int count { get; set; }
    }
}
