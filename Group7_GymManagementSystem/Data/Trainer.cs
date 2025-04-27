using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace Group7_GymManagementSystem.Data
{
    // Represents an Trainer class that inherit Person class properties.
    class Trainer : Person
    {
        // Properties for trainer after inheriting properties from person as well
        public string? Speciality { get; set; }

        // Default constructor
        public Trainer() { }

        // Constructor to initialize all properties
        public Trainer(int id, string firstName, string lastName, string phoneNumber, string email, string speciality) : base(id, firstName, lastName, phoneNumber, email)
        {
            Speciality = speciality;
        }

        // Retrieves all trainers from the database and returns a list of Trainer objects.
        public static List<Trainer> GetAllTrainers()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Database = "cprg211",
                UserID = "root",
                Password = "password"
            };

            MySqlConnection connection = new MySqlConnection(builder.ConnectionString);

            List<Trainer> trainers = new List<Trainer>();

            try
            {
                connection.Open();
                Console.WriteLine("Connection made...");

                string sql = "SELECT * FROM TRAINER";
                MySqlCommand command = new MySqlCommand(sql, connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("id");
                        string firstName = reader.GetString("first_name");
                        string lastName = reader.GetString("last_name");
                        string phoneNumber = reader.GetString("phone_number");
                        string email = reader.GetString("email");
                        string speciality = reader.GetString("speciality");

                        Trainer trainer = new Trainer(id, firstName, lastName, phoneNumber, email, speciality);
                        trainers.Add(trainer);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL Error: {ex.Message}");
                Console.WriteLine($"SQLState: {ex.SqlState}");
                Console.WriteLine($"ErrorCode: {ex.ErrorCode}");

                if ((int)ex.ErrorCode == 1042)
                {
                    Console.WriteLine("Error: Cannot connect to MySQL server. Check your server details.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Connection closed.");
            }
            return trainers;
        }

        // Inserts a new trainer record into the database using parameterized SQL.
        public static void AddTrainer(Trainer newtrainer)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Database = "cprg211",
                UserID = "root",
                Password = "password"
            };

            MySqlConnection connection = new MySqlConnection(builder.ConnectionString);

            try
            {
                connection.Open();
                Console.WriteLine("Connection made...");

                string sql = "INSERT INTO TRAINER (id, first_name, last_name, phone_number, email, speciality) " + "VALUES (@id, @firstName, @lastName, @phoneNumber, @email, @speciality)";
                MySqlCommand command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", newtrainer.Id);
                command.Parameters.AddWithValue("@firstName", newtrainer.FirstName);
                command.Parameters.AddWithValue("@lastName", newtrainer.LastName);
                command.Parameters.AddWithValue("@phoneNumber", newtrainer.PhoneNumber);
                command.Parameters.AddWithValue("@email", newtrainer.Email);
                command.Parameters.AddWithValue("@speciality", newtrainer.Speciality);

                int numOfExecuttion = command.ExecuteNonQuery();
                Console.WriteLine($"Deleted {numOfExecuttion} rows (should be 1 always)");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL Error: {ex.Message}");
                Console.WriteLine($"SQLState: {ex.SqlState}");
                Console.WriteLine($"ErrorCode: {ex.ErrorCode}");

                if ((int)ex.ErrorCode == 1042)
                {
                    Console.WriteLine("Error: Cannot connect to MySQL server. Check your server details.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Connection closed.");
            }
        }

        // Upodates an exisitng trainer record by ID from the database.
        public void EditTrainer()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Database = "cprg211",
                UserID = "root",
                Password = "password"
            };

            MySqlConnection connection = new MySqlConnection(builder.ConnectionString);

            try
            {
                connection.Open();
                Console.WriteLine("Connection made...");

                string sql = "UPDATE TRAINER SET first_name = @firstName, last_name = @lastName, phone_number = @phoneNumber, email = @email, speciality = @speciality WHERE id = @id";
                MySqlCommand command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", Id);
                command.Parameters.AddWithValue("@firstName", FirstName);
                command.Parameters.AddWithValue("@lastName", LastName);
                command.Parameters.AddWithValue("@phoneNumber", PhoneNumber);
                command.Parameters.AddWithValue("@email", Email);
                command.Parameters.AddWithValue("@speciality", Speciality);

                int numOfExecuttion = command.ExecuteNonQuery();
                Console.WriteLine($"Deleted {numOfExecuttion} rows (should be 1 always)");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL Error: {ex.Message}");
                Console.WriteLine($"SQLState: {ex.SqlState}");
                Console.WriteLine($"ErrorCode: {ex.ErrorCode}");

                if ((int)ex.ErrorCode == 1042)
                {
                    Console.WriteLine("Error: Cannot connect to MySQL server. Check your server details.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Connection closed.");
            }
        }

        // Deletes an trainer record by ID from the database.
        public static void DeleteTrainer(int id)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Database = "cprg211",
                UserID = "root",
                Password = "password"
            };

            using MySqlConnection connection = new MySqlConnection(builder.ConnectionString);
            try
            {
                connection.Open();
                Console.WriteLine("Connection made...");

                string sql = "DELETE FROM TRAINER WHERE id = @id";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);

                int numOfExecuttion = command.ExecuteNonQuery();
                Console.WriteLine($"Deleted {numOfExecuttion} rows (should be 1 always)");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL Error: {ex.Message}");
                Console.WriteLine($"SQLState: {ex.SqlState}");
                Console.WriteLine($"ErrorCode: {ex.ErrorCode}");

                if ((int)ex.ErrorCode == 1042)
                {
                    Console.WriteLine("Error: Cannot connect to MySQL server. Check your server details.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                connection.Close();
                Console.WriteLine("Connection closed.");
            }
        }
    }
}
