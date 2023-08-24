using MSPC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MSCP.Interface
{
    public interface IDataStaff
    {
        List<Staff> GetData();
    }
}
