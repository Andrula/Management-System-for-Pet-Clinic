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
                if (_staffID > 0)
                {
                    _staffID = value;
                }
            }
        }

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

        public override void DisplayInfo()
        {
            Console.WriteLine($"Staff: {Name} Position: {Position} Email: {Email} Phone: {Phone} Staff ID: {ID}");
        }
    }
}
