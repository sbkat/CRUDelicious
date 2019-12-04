using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class CaloriesGreaterThanZeroAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((int)value <= 0)
            {
                return new ValidationResult("Field must be more than 0 calories.");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}