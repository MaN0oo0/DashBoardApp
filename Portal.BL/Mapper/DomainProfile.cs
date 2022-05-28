using AutoMapper;
using PortalBL.Models;
using PortalDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalBL.Mapper
{
    public class DomainProfile:Profile
    {
        public DomainProfile()
        {

            //Form Entity To VM (GetData)
            CreateMap<Department, DepartmentVM>();



            //Form VM To Entity (Create -Edite-Delete) 

            CreateMap<DepartmentVM, Department>();
        }
    }
}
