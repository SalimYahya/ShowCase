using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Models
{
    public class Sold
    {
        [Key]
        public int Id { get; set; }
        public int Qty { get; set; }
        public int DiscountRate { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        /* 
        *  Navaigation Property: Fully Defined Relationship
        *  -   Relation Type: Many-to-Many
        *  
        *  Description: 
        *  -   Each Product can have 
        *      Many to many ProductSold.
        *      
        *   Note:
        *   -  ProductSold Table, will have
        *      Many-To-Many relationship with products
        */
        public virtual ICollection<ProductSold> ProductSolds { get; set; }
    }
}
