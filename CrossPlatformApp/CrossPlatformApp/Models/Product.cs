using System;
using System.Collections.Generic;
using System.Text;

namespace CrossPlatformApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        //public DateTime CreatedAt { get; set; } = DateTime.Now;
        //public DateTime UpdatedAt { get; set; } = DateTime.Now;

        //public int BrandId { get; set; }
        //public string BrandName { get; set; }

        //public string UserId { get; set; }
        public string UserName { get; set; }

        public override string ToString()
        {
            return String.Format("ID: {0}\nName: {1}\nDescription:{2}\nPrice: {3}\nBy: {4}\n", 
                this.Id, this.Name, this.Description, this.Price, this.UserName);
        }
    }
}
