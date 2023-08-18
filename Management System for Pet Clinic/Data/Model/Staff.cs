using MSPC.Enums;
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
        // Static list
        private static List<Staff> staffList = new List<Staff>();

        // Fields
        private DateTime _dateOfBirth;
        private static int _staffID = 1;

        // Properties
        public StaffPosition Position { get; set; }

        public int ID { get; }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                if (value.Year <= 1900)
                {
                    throw new Exception("Date out of range");
                }
                _dateOfBirth = value;
            }
        }

        // Constructor
        public Staff()
        {
            try
            {
                // Assign the current _staffID to ID and then increment it.
                ID = _staffID;
                _staffID++;

                // Add each instance to the static list
                staffList.Add(this);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Failed to create staff member. Reason: {ex.Message}");
                Console.ReadKey();
            }
        }

        // Methods
        public static List<Staff> GetStaffList()
        {
            return staffList;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Staff ID: {ID} Staff: {Name} Position: {Position} Date of birth: {DateOfBirth.ToShortDateString()} Email: {Email} Phone: {Phone}");
        }



    }
}
