using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Models
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        /* 
         *  Navaigation Property: Fully Defined Relationship
         *  -   Relation Type: Many-To-One
         *  
         *  Description:
         *  -   Multiple Invoices, belongs to one 
         *      User (ApplicationUser)
         *
         *   Note:
         *   -  Invoice Table, will have
         *      Many-To-Many relationship with products
         */
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        /*  
         *  Navaigation Property:
         *  -   Relation Type: Many-to-Many
         *  -   Pivot Table (Middle Table): InvoiceProduct Table
         */
        public virtual ICollection<InvoiceProduct> InvoiceProducts { get; set; }

        public DateTime CreatedAt { get; set; }
        public bool IsConfirmed { get; set; }

        public int TotalItems { get; set; }
        public int Vat { get; set; }
        public double TotalExcludeVat { get; set; }
        public double TotalIncludeVat { get; set; }

    }
}
