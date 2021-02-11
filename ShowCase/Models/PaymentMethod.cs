using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Models
{
    public class PaymentMethod : IValidatableObject
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public string Type { get; set; }

        public string HolderName { get; set; }

        [Required]
        [MaxLength(15, ErrorMessage = "Card Number Must Be 15 digits")]
        public string CardNumber { get; set; }

        public string CVCCode { get; set; }

        [Required]
        public DateTime ExpiresAt { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ExpiresAt < DateTime.Now)
            {
                yield return new ValidationResult(
                        errorMessage: "EndDate must be greater than StartDate",
                        memberNames: new[] { "ExpiresAt" }
                    );
            }
        }
    }
}
