using MSPC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCP.Interface
{
    public interface IPetRepository
    {
        List<Pet> GetAll();
        Pet GetById(int id);
        void Add(Pet pet);
        void Delete(int id);
    }
}
