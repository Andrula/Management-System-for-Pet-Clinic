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
        public Staff(string name, StaffPosition position, DateTime dateOfBirth, string email, string phone, string address)
        {
            Name = name;
            Position = position;
            DateOfBirth = dateOfBirth;
            Email = email;
            Phone = phone;
            Address = address;
        }

        public Staff()
        {
        }
        #endregion

        #region Methods

        public override void DisplayInfo()
        {
            Console.WriteLine($"Staff ID: {ID,-2} Staff: {Name,-10} Position: {Position,-15} Date of birth: {DateOfBirth.ToShortDateString(),-15} Email: {Email,-15} Phone: {Phone, -15}");
        }

        #endregion
    }
}
