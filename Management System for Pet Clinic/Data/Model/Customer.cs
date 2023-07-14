using M.Data.Model;
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
        private int _customerID;

        // Properties
        public int ID
        {
            get { return _customerID; }
            set
            {
                if (_customerID > 0)
                {
                    _customerID = value;
                }
            }
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Customer: {Name}, Email: {Email}, Phone: {Phone}, Customer ID: {ID}");
        }
    }
}
