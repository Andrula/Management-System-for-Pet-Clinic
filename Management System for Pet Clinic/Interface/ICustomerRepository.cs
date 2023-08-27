using MSPC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCP.Interface
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
        Customer GetById(int id);
        Customer GetByIdWithPets(int id);
        void Add(Customer customer);
        void Delete(int id);
    }
}
