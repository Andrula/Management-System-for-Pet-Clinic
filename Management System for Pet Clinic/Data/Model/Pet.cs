using MSCP.Interface;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MSPC.Model
{
    public class Pet
    {

        #region Properties
        public int ID { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
        public Customer Owner { get; set; }

        public List<Appointment> Appointments { get; set; }
        #endregion

        #region Constructor(s)
        public Pet()
        {
            
        }

        public Pet(string name, string species, int age, Customer owner)
        {
            this.Name = name;
            this.Species = species;
            this.Age = age;
            this.Owner = owner;
        }
        #endregion

        #region Methods

        public void DisplayInfo()
        {
            Console.WriteLine($"Pet ID: {ID} Pet name: {Name} Age: {Age}");
        }

        #endregion
    }
}
