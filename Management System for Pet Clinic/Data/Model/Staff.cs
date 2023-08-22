using MSPC.Enums;
using System;
using MSPC.Data.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSCP.Interface;
using System.IO;

namespace MSPC.Model
{
    public class Staff : Person, IDataStaff
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

        List<Staff> IDataStaff.GetAll()
        {
            List<Staff> staffList = new List<Staff>();

            string[] lines = File.ReadAllLines("staff.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split('|'); 
                if (parts.Length >= 5) 
                {
                    Staff staff = new Staff
                    {
                        Name = parts[0],
                        Position = (StaffPosition)Enum.Parse(typeof(StaffPosition), parts[1]),
                        DateOfBirth = DateTime.Parse(parts[2]),
                        Email = parts[3],
                        Phone = parts[4],

                    };
                    staffList.Add(staff);
                }
            }
            return staffList;
        }
        #endregion
    }
}
