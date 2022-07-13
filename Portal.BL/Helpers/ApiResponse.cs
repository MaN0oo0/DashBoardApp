using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalBL.Helpers
{
    public class ApiResponse<T1>
    {
        public int Code { get; set; }
        public string Stauts { get; set; }
        public string Message { get; set; }
        public T1 Data { get; set; }
    }
}
