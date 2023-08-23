using MSCP.Interface;
using MSPC.Enums;
using MSPC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPC.Data.Database
{
    public class TxtFileData : IDataStaff
    {
        public List<Staff> GetData()
        {

            var path = @"C:\Users\xAndr\source\repos\Management-System-for-Pet-Clinic\Management System for Pet Clinic\Data\Files\staff.txt"; // Brug et lokalt bibliotek

            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (string line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length >= 6)
                    {
                        StaffPosition position = (StaffPosition)Enum.Parse(typeof(StaffPosition), parts[2]);
                        DateTime dateOfBirth = DateTime.Parse(parts[3]);

                        Staff staff = new Staff(parts[1], position, dateOfBirth, parts[4], parts[5]);
                        staffList.Add(staff); // Add to the static list directly
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading staff data: {ex.Message}");
            }

            return staffList;
        }
    }
}
