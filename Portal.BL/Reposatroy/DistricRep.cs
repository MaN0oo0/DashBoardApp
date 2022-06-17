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
    public class DistricRep : IDistric
    {
        readonly ApplicationContext db;
        public DistricRep(ApplicationContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<Distric>> GetAsync(Expression<Func<Distric, bool>> filter = null)
        {
            if (filter != null)
                return
                    await db.Distric.Where(filter).Include("City").ToListAsync();
            else
                return
                     await db.Distric.ToListAsync();
        }
    }
}
