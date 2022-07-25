using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using PortalBL.Helpers;

namespace PortalBL.Models
{
    public class SignUpVM
    {
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Email is Invalid")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Password is Required"), MinLength(6,ErrorMessage ="Max Len 6 Word")]

        public string Password { get; set; }    
        
        [Required(ErrorMessage = "ConfirmPassword is Required"), Compare("Password",ErrorMessage ="Password Not Matching To Others")]

        public string ConfirmPassword { get; set; }

        [CheckBoxRequired(ErrorMessage = "Please checked Agree")]
        public bool IsAccepted { get; set; }
        

    }

}
