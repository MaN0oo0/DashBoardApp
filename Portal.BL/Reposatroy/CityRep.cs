using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PortalBL.Interface;
using PortalDAL.Database;
using PortalDAL.Entity;

namespace PortalBL.Reposatroy
{
    public class CityRep : ICity
    {
        readonly ApplicationContext db;
        public CityRep(ApplicationContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<City>> GetAsync(Expression<Func<City, bool>> filter = null)
        {
            if (filter != null)
                return
                    await db.City.Where(filter).Include("Country").ToListAsync();
            else
                return
                     await db.City.ToListAsync();
        }
    }
}
