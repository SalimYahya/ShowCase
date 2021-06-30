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

        [Range(0.1, 1000.00, ErrorMessage = "Price Must be Greater than 0")]
        public double Price { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return String.Format("{0}", this.Name);
        }


        /* 
         *  Navaigation Property: 
         *  -   Relation Type: Many-To-One
         *  -   Target: Brand
         *  
         */

        // Note: the ? in type int, is make Foreign_Key Nullable - For more details please refere to 
        // https://www.tektutorialshub.com/entity-framework-core/ef-core-one-to-many-relationship/
        public int? BrandId { get; set; }
        public Brand Brand { get; set; }


        /*  
         *  Navaigation Property:
         *  -   Relation Type: Many-to-Many
         *  -   Pivot Table (Middle Table): InvoiceProduct Table
         */
        public virtual ICollection<InvoiceProduct> InvoiceProducts { get; set; }


        /* 
         *  Navaigation Property: Fully Defined Relationship
         *  -   Relation Type: Many-To-One
         *  
         *  Description:
         *  -   Multiple Products, belongs to one 
         *      User (ApplicationUser) with Role ("Seller")
         */
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

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
