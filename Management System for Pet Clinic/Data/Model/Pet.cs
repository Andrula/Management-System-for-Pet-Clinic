using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPC.Model
{
    public class Pet
    {
        // Properties
        public int ID { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Customer Owner { get; set; }

        // Methods

        public Pet(string name, string species, DateTime date, Customer owner)
        {
            Name = name;
            Species = species;
            DateOfBirth = date;
            Owner = owner;
        }
    }
}
