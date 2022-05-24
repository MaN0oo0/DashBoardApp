using Microsoft.EntityFrameworkCore;
using PortalBL.Interface;
using PortalBL.Models;
using PortalDAL.Database;
using PortalDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalBL.Reposatroy
{
    public class DepartmentRep : IDepartment
    {
        ApplicationContext db = new ApplicationContext();

        public async Task CreateAsync(DepartmentVM obj)
        {
            Department d = new Department()
            {
                Name = obj.Name,
                Code = obj.Code,
            };
           await db.AddAsync(d);
              await   db.SaveChangesAsync();
        }

        public async Task<IEnumerable<DepartmentVM>> GetData()
        {
            var data = await db.Department.Select(x => new DepartmentVM()
            {
                Name= x.Name,
                Code= x.Code,
                Id= x.Id
            }).ToListAsync();
            return data;
        }

        public async Task<DepartmentVM> GetDataById(int id)
        {
                var data = await db.Department.Where(x=>x.Id == id).Select(x=>new DepartmentVM()
                {
                    Id= x.Id,
                    Code=x.Code,
                    Name=x.Name
                }).FirstOrDefaultAsync();
           
                return data;
        }
    }
}
