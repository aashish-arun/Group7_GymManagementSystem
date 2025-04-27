using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace Group7_GymManagementSystem.Data
{
    // Represents an Customer class that inherit Person class properties.
    public class Customer : Person
    {
        // Properties for cusomter after inheriting properties from person as well
        public MembershipType MembershipType { get; set; }
        public MembershipStatus MembershipStatus { get; set; }

        // Default constructor
        public Customer() { }

        // Constructor to initialize all properties
        public Customer(int id, string firstName, string lastName, string phoneNumber, string email, string membershipType, string membershipStatus) : base(id, firstName, lastName, phoneNumber, email)
        {
            if (Enum.TryParse<MembershipType>(membershipType, true, out var parsedType))
            {
                MembershipType = parsedType;
            }
            else
            {
                throw new ArgumentException("Invalid membership type");
            }
            
            if (Enum.TryParse<MembershipStatus>(membershipStatus, true, out var parsedStatus))
            {
                MembershipStatus = parsedStatus;
            }
            else
            {
                throw new ArgumentException("Invalid membership status");
            }
        }

        // Retrieves all customers from the database and returns a list of Customer objects.
        public static List<Customer> GetAllCustomers()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Database = "cprg211",
                UserID = "root",
                Password = "password"
            };
            
            MySqlConnection connection = new MySqlConnection(builder.ConnectionString);
            
            List<Customer> customers = new List<Customer>();

            try
            {
                connection.Open();
                Console.WriteLine("Connection made...");
                
                string sql = "SELECT * FROM CUSTOMER";
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
                        string membershipType = reader.GetString("membership_type");
                        string membershipStatus = reader.GetString("membership_status");
                        //MembershipType membershipType = Enum.Parse<MembershipType>(reader.GetString("membership_type"));
                        //MembershipStatus membershipStatus = Enum.Parse<MembershipStatus>(reader.GetString("membership_status"));
                        
                        Customer customer = new Customer(id, firstName, lastName, phoneNumber, email, membershipType, membershipStatus);
                        customers.Add(customer);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL Error: {ex.Message}");
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
            return customers;
        }

        // Inserts a new customer record into the database using parameterized SQL.
        public static void AddCustomer(Customer newCustomer)
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
                
                string sql = "INSERT INTO CUSTOMER (id, first_name, last_name, phone_number, email, membership_type, membership_status) " +
                                 "VALUES (@id, @firstName, @lastName, @phoneNumber, @email, @membershipType, @membershipStatus)";
                MySqlCommand command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", newCustomer.Id);
                command.Parameters.AddWithValue("@firstName", newCustomer.FirstName);
                command.Parameters.AddWithValue("@lastName", newCustomer.LastName);
                command.Parameters.AddWithValue("@phoneNumber", newCustomer.PhoneNumber);
                command.Parameters.AddWithValue("@email", newCustomer.Email);
                command.Parameters.AddWithValue("@membershipType", newCustomer.MembershipType.ToString());
                command.Parameters.AddWithValue("@membershipStatus", newCustomer.MembershipStatus.ToString());

                int result = command.ExecuteNonQuery();
                Console.WriteLine($"Inserted {result} row(s).");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL Error: {ex.Message}");
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

        // Upodates an exisitng customer record by ID from the database.
        public void EditCustomer()
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
                
                string sql = "UPDATE CUSTOMER SET first_name = @firstName, last_name = @lastName, phone_number = @phoneNumber, " +
                                 "email = @email, membership_type = @membershipType, membership_status = @membershipStatus WHERE id = @id";
                MySqlCommand command = new MySqlCommand(sql, connection);
                
                command.Parameters.AddWithValue("@id", Id);
                command.Parameters.AddWithValue("@firstName", FirstName);
                command.Parameters.AddWithValue("@lastName", LastName);
                command.Parameters.AddWithValue("@phoneNumber", PhoneNumber);
                command.Parameters.AddWithValue("@email", Email);
                command.Parameters.AddWithValue("@membershipType", MembershipType.ToString());
                command.Parameters.AddWithValue("@membershipStatus", MembershipStatus.ToString());

            int result = command.ExecuteNonQuery();
                Console.WriteLine($"Updated {result} row(s).");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL Error: {ex.Message}");
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

        // Deletes an customer record by ID from the database.
        public static void DeleteCustomer(int id)
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
                
                string sql = "DELETE FROM CUSTOMER WHERE id = @id";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Parameters.AddWithValue("@id", id);
                
                int result = command.ExecuteNonQuery();
                Console.WriteLine($"Deleted {result} row(s).");
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"MySQL Error: {ex.Message}");
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
