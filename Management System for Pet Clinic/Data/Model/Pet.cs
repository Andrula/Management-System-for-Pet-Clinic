using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPC.Model
{
    public class Pet
    {
        // Static list
        private static List<Pet> petList = new List<Pet>();

        // Properties
        public int ID { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Customer Owner { get; set; }

        // Properties for MedicalHistory and Appointment lists
        public List<MedicalHistory> History { get; set; }
        public List<Appointment> Appointments { get; set; }

        // Methods

        public Pet(string name, string species, DateTime date, Customer owner)
        {
            this.Name = name;
            this.Species = species;
            this.DateOfBirth = date;
            this.Owner = owner;

            this.History = new List<MedicalHistory>();
            this.Appointments = new List<Appointment>();
        }

        public static List<Pet> GetAllPets()
        {
            return petList;
        }

        public static Pet FindPetByName(List<Pet> pets ,string name)
        {
            return pets.Find(x => x.Name == name);
        }
        
    }
}
