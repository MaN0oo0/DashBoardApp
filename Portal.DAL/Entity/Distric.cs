using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDAL.Entity
{
    [Table("Distric")]
    public class Distric
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }

        public int CityId { get; set; }

        [ForeignKey("CityId")]

        public City? City { get; set; }
    }
}
