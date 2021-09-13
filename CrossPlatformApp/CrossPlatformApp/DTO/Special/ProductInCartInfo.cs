using System;
using System.Collections.Generic;
using System.Text;

namespace CrossPlatformApp.DTO.Special
{
    public class ProductInCartInfo
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int ProductQty { get; set; }
        public double TotalPrice { get; set; }
        public override string ToString()
        {
            return String.Format("ID: {0}, Name: {1}, Price: ${2}, Qty: {3}, Total Price: {4}",
                this.ProductId, this.ProductName, this.ProductPrice, this.ProductQty, this.TotalPrice);
        }
    }
}
