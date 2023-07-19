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
        // Fields
        private static int _customerID = 1;

        // Properties
        public int ID { get; }

        public Customer()
        {
            ID = _customerID;
            _customerID++;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Customer: {Name}, Email: {Email}, Phone: {Phone}, Customer ID: {ID}");
        }
    }
}
