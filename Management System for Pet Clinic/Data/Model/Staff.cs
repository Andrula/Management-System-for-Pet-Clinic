using MSPC.Enum;
using System;
using MSPC.Data.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPC.Model
{
    public class Staff : Person
    {
        // Fields
        private DateTime _dateOfBirth;
        private int _staffID;

        // Properties

        public StaffPosition Position { get; set; }

        public int ID
        {
            get { return _staffID; }
            set {
                if (value < 0)
                {
                    throw new Exception("An error has occured!");
                }
                _staffID = value;
            }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                if (value.Year <= 1900)
                {
                    throw new Exception("Date is out of range!");
                }
                _dateOfBirth = value;
            }
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Staff ID: {ID} Staff: {Name} Position: {Position} Date of birth: {DateOfBirth.ToShortDateString()} Email: {Email} Phone: {Phone}");
        }
    }
}
