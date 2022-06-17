using PortalDAL.Entity;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalBL.Interface
{
    public interface ICountry
    {
        Task<IEnumerable<Country>> GetAsync(Expression<Func<Country, bool>> filter = null);

    }
}
