using Management_System_for_Pet_Clinic.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPC.Model
{
    public class Staff
    {
        // Fields
        private DateTime _dateOfBirth;

        // Properties
        public int ID { get; set; }
        public string Name { get; set; }
        public StaffPosition Position { get; set; }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                if (_dateOfBirth.Year < 1900)
                {
                    throw new Exception("Date is out of range!");
                }
            }
        }
    }
}
