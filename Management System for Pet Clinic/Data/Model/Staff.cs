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

        #region Fields
        private DateTime _dateOfBirth;
        private static int _staffID = 0;
        #endregion

        #region Properties
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
        #endregion

        #region Constructor(s)
        public Staff()
        {
            try
            {
                ID = _staffID;
                _staffID++;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Failed to create staff member. Reason: {ex.Message}");
                Console.ReadKey();
            }
        }
        #endregion

        #region Methods
        public static List<Staff> GetStaffList()
        {
            return staffList;
        }

        public static void AddStaff(Staff staff)
        {
            staffList.Add(staff);
        }

        public static Staff FindStaffByName(List<Staff> staffList, string name)
        {
            return staffList.Find(s => s.Name == name);
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Staff ID: {ID} Staff: {Name} Position: {Position} Date of birth: {DateOfBirth.ToShortDateString()} Email: {Email} Phone: {Phone}");
        }
        #endregion
    }
}
