using MSCP.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace MSPC.Model
{
    public class Pet : IDataPet
    {
        // Static list
        private static List<Pet> petList = new List<Pet>();

        #region Fields
        private static int _petID = 1;
        #endregion

        #region Properties
        public int ID { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public int Age { get; set; }
        public Customer Owner { get; set; }

        public List<NOTUSEDMedicalHistory> History { get; set; }
        public List<Appointment> Appointments { get; set; }
        #endregion

        #region Constructor(s)

        public Pet(string name, string species, int age, Customer owner)
        {
            this.ID = _petID;
            this.Name = name;
            this.Species = species;
            this.Age = age;
            this.Owner = owner;

            _petID++;
        }
        #endregion

        #region Methods
        public static void AddPet(Pet pet)
        {
            petList.Add(pet);
        }

        public static List<Pet> GetAllPets()
        {
            return petList;
        }

        public static Pet FindPetByID(List<Pet> pets , int petID)
        {
            return pets.Find(x => x.ID == petID);
        }

        public static Pet FindPetByName(List<Pet> pets, string petName)
        {
            return pets.Find(x => x.Name == petName);
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Pet ID: {ID} Pet name: {Name} Age: {Age}");
        }

        public List<Pet> GetAll()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
