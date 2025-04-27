using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace Group7_GymManagementSystem.Data
{
    // Represents an Staff class that inherit Person class properties.
    public class Staff : Person
    {
        // Properties for staff after inheriting properties from person as well
        public string? JobTitle { get; set; }

        // Default constructor
        public Staff() { }

        // Constructor to initialize all properties
        public Staff(int id, string firstName, string lastName, string phoneNumber, string email, string jobTitle) : base(id, firstName, lastName, phoneNumber, email)
        {
            JobTitle = jobTitle;
        }

        // Retrieves all staffs from the database and returns a list of Staff objects.
        public static List<Staff> GetAllStaffs()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Database = "cprg211",
                UserID = "root",
                Password = "password"
            };

            MySqlConnection connection = new MySqlConnection(builder.ConnectionString);

            List<Staff> staffs = new List<Staff>();

            try
            {
                connection.Open();
                Console.WriteLine("Connection made...");

                string sql = "SELECT * FROM STAFF";
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
                        string jobTitle = reader.GetString("job_title");

                        Staff staff = new Staff(id, firstName, lastName, phoneNumber, email, jobTitle);
                        staffs.Add(staff);
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
            return staffs;
        }


        // Inserts a new staff record into the database using parameterized SQL.
        public static void AddStaff(Staff newStaff)
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

                string sql = "INSERT INTO STAFF (id, first_name, last_name, phone_number, email, job_title) " + "VALUES (@id, @firstName, @lastName, @phoneNumber, @email, @jobTitle)";
                MySqlCommand command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", newStaff.Id);
                command.Parameters.AddWithValue("@firstName", newStaff.FirstName);
                command.Parameters.AddWithValue("@lastName", newStaff.LastName);
                command.Parameters.AddWithValue("@phoneNumber", newStaff.PhoneNumber);
                command.Parameters.AddWithValue("@email", newStaff.Email);
                command.Parameters.AddWithValue("@jobTitle", newStaff.JobTitle);

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

        // Upodates an exisitng staff record by ID from the database.
        public void EditStaff()
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

                string sql = "UPDATE STAFF SET first_name = @firstName, last_name = @lastName, phone_number = @phoneNumber, email = @email, job_title = @jobTitle WHERE id = @id";
                MySqlCommand command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", Id);
                command.Parameters.AddWithValue("@firstName", FirstName);
                command.Parameters.AddWithValue("@lastName", LastName);
                command.Parameters.AddWithValue("@phoneNumber", PhoneNumber);
                command.Parameters.AddWithValue("@email", Email);
                command.Parameters.AddWithValue("@jobTitle", JobTitle);

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

        // Deletes an staff record by ID from the database.
        public static void DeleteStaff(int id)
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

                string sql = "DELETE FROM STAFF WHERE id = @id";
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