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
    public class Customer : Person, IDataCustomer
    {
        private static List<Customer> customerList = new List<Customer>();
        public List<Pet> Pets { get; set; }

        #region Constructor
        public Customer(string name, string phone, string email)
        {
            Name = name;
            Phone = phone;
            Email = email;

            ID = GetNextAvailableID();
        }

        public Customer()
        {
            // Initialization of empty lists in the constructor
            Pets = new List<Pet>();
        }
        #endregion

        #region Methods
        // Method to increment the ID.
        private static int GetNextAvailableID()
        {
            if (customerList.Count > 0)
            {
                return customerList.Max(s => s.ID) + 1;
            }
            return 0;
        }

        // Method to find element that matches a given ID.
        public static Customer FindCustomerById(List<Customer> customers, int id)
        {
            return customers.Find(x => x.ID == id);
        }

        // Method to find element that matches a given name.
        public static Customer FindCustomerByName(List<Customer> customers, string name)
        {
            return customers.Find(x => x.Name == name);
        }

        // Method to add pets to customer
        public void AddPet(Pet pet)
        {
            Pets.Add(pet);
        }

        // Method to display customer info
        public override void DisplayInfo()
        {
            Console.WriteLine($"Customer ID: {ID}, Customer: {Name}, Email: {Email}, Phone: {Phone}");
        }

        public List<Customer> GetData()
        {
            customerList.Clear(); // Clear the static list
            var path = @"C:\Users\xAndr\source\repos\Management-System-for-Pet-Clinic\Management System for Pet Clinic\Data\Files\customer.txt";
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length >= 4)
                    {
                        Customer customer = new Customer(parts[1], parts[2], parts[3]);
                        customerList.Add(customer); 
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading staff data: {ex.Message}");
            }

            return customerList;
        }

        // Takes staff as parameter and uses string interpolation to join each element with the | splitter.
        private string CustomerToTextLine(Customer customer)
        {
            return $"{customer.ID}|{customer.Name}||{customer.Email}|{customer.Phone}";
        }

        public void WriteCustomerToText()
        {
            var path = @"C:\Users\xAndr\source\repos\Management-System-for-Pet-Clinic\Management System for Pet Clinic\Data\Files\customer.txt";
            List<string> textLines = new List<string>();
            foreach (Customer customer in customerList)
            {
                textLines.Add(CustomerToTextLine(customer));
            }

            File.AppendAllLines(path, textLines);
        }

        // Takes staff as parameter and add the staff to the list + writes to text file to secure synchronization
        public void AddCustomerAndSave(Customer customer)
        {
            customerList.Add(customer);
            WriteCustomerToText();
        }
        #endregion
    }
}
