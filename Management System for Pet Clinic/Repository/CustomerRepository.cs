using MSCP.Interface;
using MSPC.Enums;
using MSPC.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPC.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        // Work PC
        private string connectionString = "Data Source=INTXL25010160;Initial Catalog=MSPC;Integrated Security=True";
        // Home PC
        //private string connectionString = "Data Source=DESKTOP-UIHP6HL\\SQLEXPRESS;Initial Catalog=MSPC;Integrated Security=True ";

        public void Add(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Customer (name, email, phone) VALUES (@Name, @Email, @Phone)", connection))
                {
                    command.Parameters.AddWithValue("@Name", customer.Name);
                    command.Parameters.AddWithValue("@Email", customer.Email);
                    command.Parameters.AddWithValue("@Phone", customer.Phone);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("DELETE FROM Customer WHERE id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Customer> GetAll()
        {
            List<Customer> customerData = new List<Customer>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT id, name, email, phone FROM Customer", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string email = reader.GetString(2);
                            string phone = reader.GetString(3);

                            Customer customer = new Customer { ID = id, Name = name, Email = email, Phone = phone };

                            
                            PetRepository petRepository = new PetRepository();
                            List<Pet> pets = petRepository.GetPetsByOwnerId(id);
                            customer.Pets.AddRange(pets);

                            customerData.Add(customer);
                        }
                    }
                }
            }
            return customerData;
        }

        public Customer GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT id, name, email, phone FROM Customer WHERE id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string name = reader.GetString(1);
                            string email = reader.GetString(2);
                            string phone = reader.GetString(3);

                            return new Customer { ID = id, Name = name, Email = email, Phone = phone};
                        }
                    }
                }
            }
            return null;
        }
    }
}
