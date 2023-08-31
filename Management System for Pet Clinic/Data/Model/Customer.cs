using MSCP.Interface;
using MSPC.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using MSPC.Enums;

namespace MSPC.Model
{
    public class Customer : Person
    {
        public List<Pet> Pets { get; set; }

        #region Constructor
        public Customer(string name, string phone, string email)
        {
            Name = name;
            Phone = phone;
            Email = email;

            Pets = new List<Pet>();
        }

        public Customer()
        {
            // Initialization of empty lists in the constructor
            Pets = new List<Pet>();
        }
        #endregion

        #region Methods

        // Method to display customer info
        public override void DisplayInfo()
        {
            Console.WriteLine($"Customer ID: {ID}, Customer: {Name}, Email: {Email}, Phone: {Phone}");
        }
        #endregion
    }
}
