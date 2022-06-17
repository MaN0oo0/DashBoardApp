using Microsoft.EntityFrameworkCore;
using PortalBL.Interface;
using PortalDAL.Database;
using PortalDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PortalBL.Reposatroy
{
    public class EmployeeRep : IEmployee
    {
       private readonly ApplicationContext db;
        public EmployeeRep(ApplicationContext db)
        {
            this.db = db;
        }
        public async Task CreateAsync(Employee obj)
        {
            obj.CreationDate = DateTime.Now;
            await db.Employee.AddAsync(obj);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var OldData = db.Employee.Find(id);
            OldData.IsDeleted = true;
            OldData.DeleteDate = DateTime.Now;
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> GetAsync(Expression<Func<Employee, bool>> filter = null)
        {
            if (filter != null)
                return
                    await db.Employee.Where(filter).Include("Department").Include("Distric").ToListAsync();
            else
                return
                     await db.Employee.Include("Department").Include("Distric").ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(Expression<Func<Employee, bool>> filter)
        {
            var data = await db.Employee.Where(filter).Include("Department").Include("Distric").FirstOrDefaultAsync();
            return data;
        }

        public async Task<IEnumerable<Employee>> SearchAsync(Expression<Func<Employee, bool>> filter = null)
        {
            var data = await db.Employee.Where(filter).Include("Department").Include("Distric").ToListAsync();
            return data;
        }

        public async Task UpdateAsync(Employee obj)
        {
            obj.UpdateDate = DateTime.Now;
            obj.IsUpdated = true;

            db.Entry(obj).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
