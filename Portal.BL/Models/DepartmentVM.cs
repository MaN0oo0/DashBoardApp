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
        [MaxLength(50,ErrorMessage ="Max Len 50")]
        [MinLength(3,ErrorMessage ="min Len 3 ")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Code Requird")]
        [Range(1 , 5000,ErrorMessage ="Range btw 1 to 5k")]
        public string Code { get; set; }
    }
}
