using PortalDAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalBL.Models
{
    public class CityVM
    {

        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public Country? Country { get; set; }
    }
}
