using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        public string City { get; set; }

        /* 
         *  Navaigation Property:
         *  -   Relation Type: Many-to-Many
         *  -   Pivot Table (Middle Table): ShoppingCart Table
         */
        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }

        /* 
         *  Navaigation Property: Fully Defined Relationship
         *  -   Relation Type: One-to-Many
         *  
         *  Description: 
         *  -   Each User (ApplicationUser) can have 
         *      one or many orders.
         *      
         *   Note:
         *   -  Order Table, will have
         *      Many-To-Many relationship with products
         */
        //public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
