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
    public class StaffRepository : IStaffRepository
    {
        private string connectionString = "Data Source=INTXL25010160;Initial Catalog=MSPC;Integrated Security=True";
        public List<Staff> GetAll()
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

        public Staff GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT id, name, email, phone, address, dob, positionID FROM Staff WHERE id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string name = reader.GetString(1);
                            string email = reader.GetString(2);
                            string phone = reader.GetString(3);
                            string address = reader.GetString(4);
                            DateTime dateTime = reader.GetDateTime(5);
                            int positionValue = reader.GetInt32(6);

                            StaffPosition staffPosition = (StaffPosition)positionValue - 1;

                            return new Staff { ID = id, Name = name, Email = email, Phone = phone, Address = address, DateOfBirth = dateTime, Position = staffPosition };
                        }
                    }
                }
            }
            return null;
        }

        public void Add(Staff staff)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Staff (name, email, phone, address, dob, positionID) VALUES (@Name, @Email, @Phone, @Address, @DOB, @PositionID)", connection))
                {
                    command.Parameters.AddWithValue("@Name", staff.Name);
                    command.Parameters.AddWithValue("@Email", staff.Email);
                    command.Parameters.AddWithValue("@Phone", staff.Phone);
                    command.Parameters.AddWithValue("@Address", staff.Address);
                    command.Parameters.AddWithValue("@DOB", staff.DateOfBirth);
                    command.Parameters.AddWithValue("@PositionID", (int)staff.Position + 1);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("DELETE FROM Staff WHERE id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
