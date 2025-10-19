using System;
using System.ComponentModel.DataAnnotations;

namespace ExpensesTracker.Models
{
    public class Obligation
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Amount { get; set; }

        public double PaidAmount { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        [Required] 
        public string userId { get; set; }
        public bool IsPaid => PaidAmount == Amount;
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (PaidAmount > Amount)
            {
                yield return new ValidationResult(
                    "Paid amount cannot be greater than total amount.",
                    new[] { nameof(PaidAmount) }
                );
            }

        }       
    }
}