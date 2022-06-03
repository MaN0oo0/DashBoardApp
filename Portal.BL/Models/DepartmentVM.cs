using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PortalBL.Models
{
    public class DepartmentVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name Requird") , StringLength(50)]
        [MaxLength(50,ErrorMessage = "Max Length 50")]
        [MinLength(2,ErrorMessage ="min Length 3 ")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Code Requird")]
        [Range(1 , 5000,ErrorMessage ="Range between 1 to 1234")]
        public string Code { get; set; }
    }
}
