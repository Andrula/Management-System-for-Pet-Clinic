using MSPC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPC.Interface
{
    public interface IAppointmentRepository
    {
        List<Appointment> GetAll();
        Customer GetById(int id);
        void Add(Appointment appointment);
        void Delete(int id);
    }
}
