using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Models
{
    public class Address
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        [Display(Name ="District")]
        public string District { get; set; }

        [Required]
        [Display(Name = "Street")]
        public string Street { get; set; }
        
        [Required]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Required]
        [Display(Name = "P.O. Box")]
        public string POBox { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }
    }
}
