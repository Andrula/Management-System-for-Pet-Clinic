using MSPC.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MSPC.Model
{
    public class Customer : Person
    {
        private static List<Customer> customerList = new List<Customer>();
        public List<Pet> Pets { get; set; }

        #region Fields
        private static int _customerID = 0;
        #endregion

        #region Properties
        public int ID { get; }
        #endregion

        public Customer()
        {
            ID = _customerID;
            _customerID++;

            // Initialization of empty lists in the constructor
            Pets = new List<Pet>();
        }

        #region Methods

        // Method to retrieve list of customers.
        public static List<Customer> GetAllCustomers()
        {
            return customerList;
        }

        // Method to add customer to the static customer list when created
        public static void AddCustomer(Customer customer)
        {
            customerList.Add(customer);
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

        
        public override void DisplayInfo()
        {
            Console.WriteLine($"Customer: {Name}, Email: {Email}, Phone: {Phone}, Customer ID: {ID}");
        }
        #endregion
    }
}
