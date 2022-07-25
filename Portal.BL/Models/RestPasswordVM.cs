using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PortalBL.Models
{
    public class RestPasswordVM
    {
        [Required(ErrorMessage = "Password is Required"), MinLength(6,ErrorMessage="Min Len 6 Word")]

        public string Password { get; set; }

        [Required(ErrorMessage = "Password is Required"),Compare("Password",ErrorMessage ="Password Not Mathing To Others")]

        public string ConfirmPassword { get; set; }


        public string? Email { get; set; }
        public string? Token { get; set; }
    }
}
