using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPC.Data.Model
{
    public abstract class Person
    {

        // Properties (accessor methods) 
        public int ID { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        // Methods
        public abstract void DisplayInfo();
    }
}
