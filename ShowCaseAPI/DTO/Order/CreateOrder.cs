using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCaseAPI.DTO.Order
{
    public class CreateOrder
    {
        public int id { get; set; }
        public double price { get; set; }
        public int count { get; set; }
    }
}
