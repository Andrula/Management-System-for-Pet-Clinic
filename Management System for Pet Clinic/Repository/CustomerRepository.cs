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
        //private string connectionString = "Data Source=INTXL25010160;Initial Catalog=MSPC;Integrated Security=True";
        // Home PC
        private string connectionString = "Data Source=DESKTOP-UIHP6HL\\SQLEXPRESS;Initial Catalog=MSPC;Integrated Security=True ";

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

                            customerData.Add(new Customer { ID = id, Name = name, Email = email, Phone = phone});
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

        public Customer GetByIdWithPets(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT c.ID, c.name, c.email, c.phone, p.ID AS PetID, p.name AS PetName, p.species, p.age FROM Customer c LEFT JOIN Pet p ON c.ID = p.ownerID WHERE c.ID = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Customer customer = null;

                        while (reader.Read())
                        {
                            if (customer == null)
                            {
                                string name = reader.GetString(1);
                                string email = reader.GetString(2);
                                string phone = reader.GetString(3);

                                customer = new Customer { ID = id, Name = name, Email = email, Phone = phone };
                            }

                            if (!reader.IsDBNull(reader.GetOrdinal("PetID")))
                            {
                                int petID = reader.GetInt32(reader.GetOrdinal("PetID"));
                                string petName = reader.GetString(reader.GetOrdinal("PetName"));
                                string species = reader.GetString(reader.GetOrdinal("species"));
                                int age = reader.GetInt32(reader.GetOrdinal("age"));

                                Pet pet = new Pet { ID = petID, Name = petName, Species = species, Age = age };
                                customer.Pets.Add(pet);
                            }
                        }

                        return customer;
                    }
                }
            }
            return null;
        }
    }
}
