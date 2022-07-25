using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PortalBL.Models
{
    public class LoginVM
    {

     
        public string? UserName { get; set; }
        [Required(ErrorMessage ="Email is Required")]
        [EmailAddress(ErrorMessage ="Email is Invalid")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        
        public string Password { get; set; }

        public bool RemmberMe { get; set; }

    }
}
