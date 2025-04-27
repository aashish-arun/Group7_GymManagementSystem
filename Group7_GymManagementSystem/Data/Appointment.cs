using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace Group7_GymManagementSystem.Data
{
    // Represents an Appointment class implementing a marker interface IAppointment(empty interface). We tried to implement a function one but wasn't able to in time for submission
    public class Appointment : IAppointment
    {
        // Properties for appointment
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int CustomerId { get; set; }
        public int TrainerId { get; set; }
        public DateTime ScheduledDate { get; set; }
        public ScheduledTime ScheduledTime { get; set; }

        // Default constructor
        public Appointment() { }

        // Constructor to initialize all properties
        public Appointment(int id, DateTime date, int customerId, int trainerId, DateTime scheduledDate, ScheduledTime scheduledTime)
        {
            Id = id;
            Date = date;
            CustomerId = customerId;
            TrainerId = trainerId;
            ScheduledDate = scheduledDate;
            ScheduledTime = scheduledTime;
        }

        // Retrieves all appointments from the database and returns a list of Appointment objects.
        public static List<Appointment> GetAllAppointments()
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Database = "cprg211",
                UserID = "root",
                Password = "password"
            };

            MySqlConnection connection = new MySqlConnection(builder.ConnectionString);

            List<Appointment> appointments = new List<Appointment>();

            try
            {
                connection.Open();
                Console.WriteLine("Connection made...");

                string sql = "SELECT * FROM APPOINTMENT";
                MySqlCommand command = new MySqlCommand(sql, connection);

                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("id");
                        DateTime date = reader.GetDateTime("date");
                        int customerId = reader.GetInt32("customer_id");
                        int trainerId = reader.GetInt32("trainer_id");
                        DateTime scheduledDate = reader.GetDateTime("scheduled_date");
                        string scheduledTimeStr = reader.GetString("scheduled_time");
                        ScheduledTime scheduledTime = Enum.Parse<ScheduledTime>(scheduledTimeStr);

                        Appointment appointment = new Appointment(id, date, customerId, trainerId, scheduledDate, scheduledTime);
                        appointments.Add(appointment);
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

            return appointments;
        }

        // Inserts a new appointment record into the database using parameterized SQL.
        public static void AddAppointment(Appointment newAppointment)
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

                string sql = "INSERT INTO appointment (id, date, customer_id, trainer_id, scheduled_date, scheduled_time) " +
                             "VALUES (@id, @date, @customerId, @trainerId, @scheduledDate, @scheduledTime)";

                MySqlCommand command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", newAppointment.Id);
                command.Parameters.AddWithValue("@date", newAppointment.Date);
                command.Parameters.AddWithValue("@customerId", newAppointment.CustomerId);
                command.Parameters.AddWithValue("@trainerId", newAppointment.TrainerId);
                command.Parameters.AddWithValue("@scheduledDate", newAppointment.ScheduledDate);
                command.Parameters.AddWithValue("@scheduledTime", newAppointment.ScheduledTime.ToString());


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

        // Deletes an appointment record by ID from the database.
        public static void DeleteAppointment(int id)
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

                string sql = "DELETE FROM APPOINTMENT WHERE id = @id";
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

        // Utility method to get a display name for a ScheduledTime enum value using Display attribute metadata.
        public static string? GetDisplayName(ScheduledTime time)
        {
            Type type = typeof(ScheduledTime);
            MemberInfo[] memInfo = type.GetMember(time.ToString());
            object[] attributes = memInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
            return (attributes.Length > 0) ? ((DisplayAttribute)attributes[0]).Name : time.ToString();
        }
    }
}
