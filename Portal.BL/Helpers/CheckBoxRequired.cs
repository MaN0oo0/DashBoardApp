using PortalBL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalBL.Helpers
{
    public class CheckBoxRequired: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //get the entered value
            var student = (SignUpVM)validationContext.ObjectInstance;
            //Check whether the IsAccepted is selected or not.
            if (student.IsAccepted == false)
            {
                //if not checked the checkbox, return the error message.
                return new ValidationResult(ErrorMessage == null ? "Please checked the checkbox" : ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }
}
