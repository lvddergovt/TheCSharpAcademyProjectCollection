
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Microsoft.Data.Sqlite;
using SQLitePCL;

namespace HabitLogger
{
    class Program
    {
        static string connectionString = @"Data Source=../../../habit-logger.db";

        static void Main(string[] args)
        {

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var tableCommand = connection.CreateCommand();

                tableCommand.CommandText =
                @"CREATE TABLE IF NOT EXISTS read (
          id INTEGER PRIMARY KEY AUTOINCREMENT,
          Date TEXT,
          Quantity INTEGER
          )";

                tableCommand.ExecuteNonQuery();

                connection.Close();
            }
        }

        static void GetUserInput()
        {
            Console.Clear();
            bool closeApp = false;
            while (!closeApp)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1) Add a new entry");
                Console.WriteLine("2) View all entries");
                Console.WriteLine("3) Exit");
                Console.Write("\r\nSelect an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        AddEntry();
                        break;
                    case "2":
                        // ViewEntries();
                        break;
                    case "3":
                        closeApp = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }

        private static void AddEntry()
        {
            string date = GetDateInput();

            int quantity = GetQuantityInput();

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText =
                @"INSERT INTO read (Date, Quantity)
          VALUES ($date, $quantity)";

                command.Parameters.AddWithValue("$date", date);
                command.Parameters.AddWithValue("$quantity", quantity);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }

        internal static string GetDateInput()
        {
            // ask date input from user or give option (type '0') to return to main menu
            Console.WriteLine("Enter date (YYYY-MM-DD) or type '0' to return to main menu");
            string date = Console.ReadLine();
            if (date == "0")
            {
                GetUserInput();
            }
            else
            {
                // check if date is valid
                if (DateTime.TryParse(date, out DateTime result))
                {
                    return date;
                }
                else
                {
                    Console.WriteLine("Invalid date");
                    GetDateInput();
                }
            }

            return null; // Add this line to return a value in case no other return statement is reached.
        }

        internal static int GetQuantityInput()
        {
            // ask quantity input from user or give option (type '0') to return to main menu
            Console.WriteLine("Enter quantity or type '0' to return to main menu");
            string quantity = Console.ReadLine();
            if (quantity == "0")
            {
                GetUserInput();
            }
            else
            {
                // check if quantity is valid
                if (int.TryParse(quantity, out int result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Invalid quantity");
                    GetQuantityInput();
                }
            }

            return 0; // Add this line to return a value in case no other return statement is reached.
        }
    }
}
