using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name Cannot Exceed 50 characters")]
        public string Name { get; set; }

        [MaxLength(150, ErrorMessage = "Description Cannot Exceed 150 characters")]
        public string Description { get; set; }

        [Range(0.1, 100000.00, ErrorMessage = "Price Must be Greater than 0")]
        public double Price { get; set; }

        /* 
         *  Navaigation Property:
         *  -   Relation Type: Many-to-Many
         *  -   Pivot Table (Middle Table): ShoppingCart Table
         */
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }
    }
}
