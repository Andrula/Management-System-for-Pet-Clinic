using MSCP.Interface;
using MSPC.Enums;
using MSPC.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSPC.Repository
{
    public class PetRepository : IPetRepository
    {
        // Work PC
        private string connectionString = "Data Source=INTXL25010160;Initial Catalog=MSPC;Integrated Security=True";
        // Home PC
        //private string connectionString = "Data Source=DESKTOP-UIHP6HL\\SQLEXPRESS;Initial Catalog=MSPC;Integrated Security=True ";

        public List<Pet> GetAll()
        {
            List<Pet> petData = new List<Pet>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT id, name, species, age, ownerID FROM Pet", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string species = reader.GetString(2);

                            int age = reader.GetInt32(3);
                            int customerID = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);

                            CustomerRepository customerRepository = new CustomerRepository();
                            Customer owner = customerRepository.GetById(customerID);

                            petData.Add(new Pet { ID = id, Name = name, Age = age, Species = species, Owner = owner });
                        }
                    }
                }
            }
            return petData;
        }

        public void Add(Pet pet)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Pet (name, species, age, ownerID) VALUES (@Name, @Species, @Age, @ownerID); SELECT SCOPE_IDENTITY()", connection))
                {
                    command.Parameters.AddWithValue("@Name", pet.Name);
                    command.Parameters.AddWithValue("@Species", pet.Species);
                    command.Parameters.AddWithValue("@Age", pet.Age);
                    command.Parameters.AddWithValue("@ownerID", pet.Owner.ID);

                    int newPetID = Convert.ToInt32(command.ExecuteScalar());

                    pet.ID = newPetID;
                }
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("DELETE FROM Pet WHERE id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    command.ExecuteNonQuery();
                }
            }
        }


        public Pet GetById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT ID, name, species, age, ownerID FROM Pet WHERE ID = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string name = reader.GetString(1);
                            string species = reader.GetString(2);
                            int age = reader.GetInt32(3);
                            int ownerID = reader.GetInt32(4);

                            CustomerRepository CRInstance = new CustomerRepository();
                            Customer owner = CRInstance.GetById(ownerID);

                            return new Pet { ID = id, Name = name, Species = species, Age = age, Owner = owner };
                        }
                    }
                }
            }
            return null;
        }
        public List<Pet> GetPetsByOwnerId(int ownerId)
        {
            List<Pet> petData = new List<Pet>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT id, name, species, age FROM Pet WHERE ownerID = @OwnerId", connection))
                {
                    command.Parameters.AddWithValue("@OwnerId", ownerId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string species = reader.GetString(2);
                            int age = reader.GetInt32(3);

                            petData.Add(new Pet { ID = id, Name = name, Species = species, Age = age });
                        }
                    }
                }
            }

            return petData;
        }
    }
}

