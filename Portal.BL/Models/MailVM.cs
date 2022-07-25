using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace PortalBL.Models
{
    public class MailVM
    {

         [Required(ErrorMessage = "Mail is Required")]
         public string ToEmail { get; set; }   
        [Required(ErrorMessage = "Mail is Required")]
         public string FromEmail { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Subject is Required")]
            public string Subject { get; set; }
            public string? Message { get; set; }
           // public IFormFile? Attachments { get; set; }
     
    }
}
