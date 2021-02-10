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

        public DateTime JoinedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;


        /* 
        *  Navaigation Property: Fully Defined Relationship
        *  -   Relation Type: One-to-One
        *  
        *  Description: 
        *  -   Each User (ApplicationUser) can have 
        *      one Address.
        *      
        *   Note:
        *   -  Address Table, will have
        *      One-To-One relationship with User
        */
        public virtual Address Address { get; set; }

        /* 
        *  Navaigation Property: Fully Defined Relationship
        *  -   Relation Type: One-to-One
        *  
        *  Description: 
        *  -   Each User (ApplicationUser) can have 
        *      one PaymentMethod.
        *      
        *   Note:
        *   -  PaymentMethod Table, will have
        *      One-To-One relationship with User
        */
        public virtual PaymentMethod PaymentMethod { get; set; }

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
        public virtual ICollection<Invoice> Invoices { get; set; }

        /* 
        *  Navaigation Property: Fully Defined Relationship
        *  -   Relation Type: One-to-Many
        *  
        *  Description: 
        *  -   Each User (ApplicationUser) can have 
        *      one or many orders.
        *      
        *   Note:
        *   -  A user with role Seller, will have
        *      One-To-Many relationship with products
        */
        public virtual ICollection<Product> Products { get; set; }

    }
}
