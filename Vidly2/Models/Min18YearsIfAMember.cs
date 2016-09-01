using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidly2.Models
{
    //Ensuring validation of data using custome attribute.
    //For example, if we only want customers older than 18 year old 
    //to be able to subscribe (any option of membership type except first)
    //then we can validate that input using a class derrived from
    //ValidationAttribute as an attribute to Birthday property in
    //Customer class.
    public class Min18YearsIfAMember : ValidationAttribute
    {
        //overrideing IsValid member
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            #region Magic numbers like "0" and "1" are not the best option
            /*
             Magic numbers like "0" and "1" are not the best option
             as they might become hardly mentainable in the future.
             It is better to avoid using them like that by explicitly
             defining needed types in the domain model of the application
             to make code more mantainable.
             */
            //Another approach is to use Enum of MembershipTypeId's 
            //instead of static fields in MembershipTypeId class.
            //But then we have to cast to (byte) the call to Enum
            #endregion
            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
                return ValidationResult.Success;
            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is required.");

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age >= 18) ? ValidationResult.Success 
                : new ValidationResult("Customer should be atleast 18 years old to go on a membership");
        }
    }
}
