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
    public class Staff : Person
    {
        // Static list
        private static List<Staff> staffList = new List<Staff>();

        #region Fields
        private DateTime _dateOfBirth;
        //private int _staffID = 0;
        #endregion

        #region Properties
        public StaffPosition Position { get; set; }



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
        public Staff(string name, StaffPosition position, DateTime dateOfBirth, string email, string phone)
        {
            Name = name;
            Position = position;
            DateOfBirth = dateOfBirth;
            Email = email;
            Phone = phone;

            ID = GetNextAvailableID();
        }

        public Staff()
        {
        }
        #endregion

        #region Methods

        private static int GetNextAvailableID()
        {
            if (staffList.Count > 0)
            {
                return staffList.Max(s => s.ID) + 1;
            }
            return 0;
        }

        public static Staff FindStaffByName(List<Staff> staffList, string name)
        {
            return staffList.Find(s => s.Name == name);
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Staff ID: {ID,-2} Staff: {Name,-10} Position: {Position,-15} Date of birth: {DateOfBirth.ToShortDateString(),-15} Email: {Email,-15} Phone: {Phone, -15}");
        }

        // Takes staff as parameter and uses string interpolation to join each element with the | splitter.
        private string StaffToTextLine(Staff staff)
        {
            return $"{staff.ID}|{staff.Name}|{staff.Position}|{staff.DateOfBirth}|{staff.Email}|{staff.Phone}";
        }

        public void WriteStaffToText()
        {
            var path = @"C:\Users\xAndr\source\repos\Management-System-for-Pet-Clinic\Management System for Pet Clinic\Data\Files\staff.txt";
            List<string> textLines = new List<string>();
            foreach (Staff staff in staffList)
            {
                textLines.Add(StaffToTextLine(staff));
            }

            File.AppendAllLines(path, textLines);
        }

        // Takes staff as parameter and add the staff to the list + writes to text file to secure synchronization
        public void AddStaffAndSave(Staff staff)
        {
            staffList.Add(staff);
            WriteStaffToText();
        }
        #endregion
    }
}
