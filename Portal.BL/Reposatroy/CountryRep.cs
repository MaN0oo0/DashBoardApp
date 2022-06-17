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
    public class CountryRep : ICountry
    {
        readonly ApplicationContext db;
        public CountryRep(ApplicationContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<Country>> GetAsync(Expression<Func<Country, bool>> filter = null)
        {
            if (filter != null)
                return
                    await db.Country.Where(filter).ToListAsync();
            else
                return
                     await db.Country.ToListAsync();
        }
    }
}
