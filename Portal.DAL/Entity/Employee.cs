using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PortalDAL.Entity
{

    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Address { get; set; }
        public string? Email { get; set; }
        public string? Notes { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public bool IsUpdated { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int DepartmentId { get; set; }

        // Navigation Property
        //[ForeignKey("DepartmentId")]
        public Department? Department { get; set; }

        public int DistricId { get; set; }
        [ForeignKey("DistricId")]
        public Distric? Distric { get; set; }


    }
}
