using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Models
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }
    
        public virtual ICollection<Product> Products { get; set; }

    }
}
