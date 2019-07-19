using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KRWebDesign.Models
{
    public class Min18YearsMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            var playerData = (PlayerData)context.ObjectInstance;

            if (playerData.MembershipTypeId == 1)
                return ValidationResult.Success;

            if (playerData.Birthday == null)
                return new ValidationResult("Birthday is required.");

            var age = DateTime.Today.Year - playerData.Birthday.Year;

            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer should be at least 18 to purchase");
        }
    }
}
