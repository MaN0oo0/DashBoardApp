using PortalBL.Models;
using PortalDAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalBL.Interface
{
    public interface IDepartment
    {
        Task<IEnumerable<Department>> GetData();

        Task<Department> GetDataById(int id);

        Task CreateAsync(Department obj);
        Task UpdateAsync(Department obj);
        Task DeleteAsync(int id);

    }
}
