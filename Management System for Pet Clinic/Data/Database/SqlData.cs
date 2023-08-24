using MSCP.Interface;
using MSPC.Enums;
using MSPC.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPC.Data.Database
{
    public class SqlData : IDataStaff
    {
        private string connectionString = "Data Source=INTXL25010160;Initial Catalog=MSPC;Integrated Security=True";
        public List<Staff> GetData()
        {

            List<Staff> staffData = new List<Staff>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT id, name, email, phone, address, dob, positionID FROM Staff", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string email = reader.GetString(2);
                            string phone = reader.GetString(3);
                            string address = reader.GetString(4);
                            DateTime dateTime = reader.GetDateTime(5);
                            int positionValue = reader.GetInt32(6);

                            StaffPosition staffPosition = (StaffPosition)positionValue - 1;

                            staffData.Add(new Staff { ID = id, Name = name, Email = email, Phone = phone, Address = address, DateOfBirth = dateTime, Position = staffPosition });
                        }
                    }
                }
            }
            return staffData;
        }
    }
}
