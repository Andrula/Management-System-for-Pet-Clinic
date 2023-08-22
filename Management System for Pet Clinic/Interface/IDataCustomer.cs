using MSPC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCP.Interface
{
    public interface IDataCustomer
    {
        List<Customer> GetData();
    }
}
