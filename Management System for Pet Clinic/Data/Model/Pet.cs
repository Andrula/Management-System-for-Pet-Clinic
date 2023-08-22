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

        public List<Appointment> Appointments { get; set; }
        #endregion

        #region Constructor(s)
        public Pet()
        {
            
        }

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

        public List<Pet> GetData()
        {
            List<Pet> petList = new List<Pet>();
            var path = @"C:\Users\xAndr\source\repos\Management-System-for-Pet-Clinic\Management System for Pet Clinic\Data\Files\pet.txt"; // Update the file path

            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length >= 4)
                    {
                        int age = int.Parse(parts[3]);

                        Pet pet = new Pet(parts[1], parts[2], age, null); // Set the owner to null for now
                        petList.Add(pet);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading pet data: {ex.Message}");
            }

            return petList;
        }

        private string PetToTextLine(Pet pet)
        {
            return $"{pet.ID}|{pet.Name}|{pet.Species}|{pet.Age}";
        }

        public void WritePetsToText()
        {
            var path = @"C:\Users\xAndr\source\repos\Management-System-for-Pet-Clinic\Management System for Pet Clinic\Data\Files\pet.txt"; // Update the file path
            List<string> textLines = new List<string>();
            foreach (Pet pet in petList)
            {
                textLines.Add(PetToTextLine(pet));
            }

            File.WriteAllLines(path, textLines);
        }

        public void AddPetAndSave(Pet pet)
        {
            petList.Add(pet);
            WritePetsToText();
        }
        #endregion
    }
}
