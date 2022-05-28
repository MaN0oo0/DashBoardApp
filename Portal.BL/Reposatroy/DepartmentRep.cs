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
        private readonly ApplicationContext db;

        public DepartmentRep(ApplicationContext db)
        {
            this.db = db;
        }

       
        public async Task CreateAsync(Department obj)
        {
   
           await db.AddAsync(obj);
         await   db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Department>> GetData()
        {
            var data = await db.Department.ToListAsync();
            return data;
        }

        public async Task<Department> GetDataById(int id)
        {
                var data = await db.Department.Where(x=>x.Id == id).FirstOrDefaultAsync();
           
                return data;
        }

      
        public async Task UpdateAsync(Department obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var OldData = db.Department.Find(id);
            db.Department.Remove(OldData);
           await db.SaveChangesAsync();
        }
    }
}
