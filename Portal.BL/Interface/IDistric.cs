using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PortalDAL.Entity;
using System.Linq.Expressions;

namespace PortalBL.Interface
{
    public interface IDistric
    {
        Task<IEnumerable<Distric>> GetAsync(Expression<Func<Distric, bool>> filter = null);

    }
}
