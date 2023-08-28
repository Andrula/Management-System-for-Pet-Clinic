using MSPC.Interface;
using MSPC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPC.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        // Work PC
        private string connectionString = "Data Source=INTXL25010160;Initial Catalog=MSPC;Integrated Security=True";
        // Home PC
        //private string connectionString = "Data Source=DESKTOP-UIHP6HL\\SQLEXPRESS;Initial Catalog=MSPC;Integrated Security=True ";

        public void Add(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Appointment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
