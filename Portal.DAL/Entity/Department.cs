using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalDAL.Entity
{
    [Table("Departments")]
    public class Department
    {
        public int Id { get; set; }
        [Required ,StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(50)]
        public string Code { get; set; }

    }
}
