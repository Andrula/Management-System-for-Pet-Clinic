using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPC.Data.Model
{
    public abstract class Person
    {
        // Fields
        private string _name;
        private string _email;
        private string _phone;
        private string _address;

        // Properties (accessor methods) 

        public int ID { get; set; } 

        public string Name
        {
            get { return _name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _name = value;
                }
            }
        }
        public string Address
        {
            get { return _address; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _address = value;
                }
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _email = value;
                }
            }
        }
        public string Phone
        {
            get { return _phone; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _phone = value;
                }
            }
        }

        // Methods
        public abstract void DisplayInfo();
    }
}
