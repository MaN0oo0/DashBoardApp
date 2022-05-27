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
        Task<IEnumerable<DepartmentVM>> GetData();

        Task<DepartmentVM> GetDataById(int id);

        Task CreateAsync(DepartmentVM obj);
        Task UpdateAsync(DepartmentVM obj);
        Task DeleteAsync(int id);
    }
}
