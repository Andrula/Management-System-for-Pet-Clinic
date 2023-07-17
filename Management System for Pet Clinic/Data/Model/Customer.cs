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
        private static int _nextCustomerID = 1;
        private int _customerID;

        public Customer()
        {
            ID = _nextCustomerID++;
        }


        // Properties
        public int ID
        {
            get { return _customerID; }
            set
            {
                if (value < 0)
                {
                    throw new Exception("An error occurred with the ID.");
                }
                _customerID = value;
            }
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Customer: {Name}, Email: {Email}, Phone: {Phone}, Customer ID: {ID}");
        }
    }
}
