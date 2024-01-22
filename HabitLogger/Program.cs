using Microsoft.Data.Sqlite;
using SQLitePCL;
using System;

/*
# Requirements

- This is an application where you’ll register one habit.
- This habit can't be tracked by time (ex. hours of sleep), only by quantity (ex. number of water glasses a day)
- The application should store and retrieve data from a real database
- When the application starts, it should create a sqlite database, if one isn’t present.
- It should also create a table in the database, where the habit will be logged.
- The app should show the user a menu of options.
- The users should be able to insert, delete, update and view their logged habit.
- You should handle all possible errors so that the application never crashes.
- The application should only be terminated when the user inserts 0.
- You can only interact with the database using raw SQL. You can’t use mappers such as Entity Framework.

*/

namespace HabitLogger
{
    class Program
    {
        static string connectionString = "Data Source=habits.db";

        static void Main(string[] args)
        {
            // Initialize SQLitePCL
            SQLitePCL.Batteries.Init();

            // Existing database connection code
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var tableCommand = connection.CreateCommand();

                tableCommand.CommandText =
                    @"CREATE TABLE IF NOT EXISTS read(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Date TEXT,
                    Quantity INTEGER
                )";  // Also, removed the trailing comma from 'Quantity INTEGER,'

                tableCommand.ExecuteNonQuery();

                connection.Close();
            }

            // write a comment tio the consiole
            GetMainMenuInput();
        }

        // get user input for the main menu
        static int GetMainMenuInput()
        {
            Console.Clear();
            bool closeApp = false;

            while (!closeApp)
            {
                // display the main menu
                int input = DisplayMainMenu();

                // handle the input
                switch (input)
                {
                    case 1:
                        // insert a new habit
                        InsertRecord();
                        break;
                    case 2:
                        // delete a habit
                        DeleteHabit();
                        break;
                    case 3:
                        // update a habit
                        UpdateHabit();
                        break;
                    case 4:
                        // view all habits
                        ViewAllHabits();
                        break;
                    case 5:
                        // get the amount of pages read last week
                        GetPagesReadLastWeek();
                        break;
                    case 0:
                        // exit the application
                        closeApp = true;
                        break;
                    default:
                        // invalid input
                        Console.WriteLine("Invalid input. Please try again.");
                        break;
                }
            }
            return -1;
        }

        // create dislayManu() method
        static int DisplayMainMenu()
        {
            Console.WriteLine("Welcome to Habit Logger!");
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1. Insert record");
            Console.WriteLine("2. Delete record");
            Console.WriteLine("3. Update record");
            Console.WriteLine("4. View all records");
            Console.WriteLine("5. Statistic: Pages read last week");
            Console.WriteLine("0. Exit the application");

            // get user input
            int input = int.Parse(Console.ReadLine());


            return input;
        }

        // create InsertRecord() method
        private static void InsertRecord()
        {
            Console.Clear();
            Console.WriteLine("How many pages did you read today?");

            // todays date
            string date = DateTime.Now.ToString("yyyy-MM-dd");

            Console.WriteLine("Please enter the quantity:");
            int quantity = int.Parse(Console.ReadLine());

            // insert the record into the database
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText =
                    $@"INSERT INTO read (Date, Quantity) VALUES ('{date}', {quantity})";

                command.ExecuteNonQuery();

                connection.Close();
            }

            Console.WriteLine("Record inserted successfully!");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // create DeleteHabit() method
        private static void DeleteHabit()
        {
            Console.Clear();
            Console.WriteLine("Delete a record");

            Console.WriteLine("Please enter the id of the record you want to delete:");
            int id = int.Parse(Console.ReadLine());

            // delete the record from the database
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText =
                    $@"DELETE FROM read WHERE Id = {id}";

                command.ExecuteNonQuery();

                connection.Close();
            }

            Console.WriteLine("Record deleted successfully!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // create UpdateHabit() method
        private static void UpdateHabit()
        {
            Console.Clear();
            Console.WriteLine("Update a record");

            // show all records
            ViewAllHabits();

            Console.WriteLine("Please enter the id of the record you want to update:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter the new quantity:");
            int quantity = int.Parse(Console.ReadLine());

            // update the record in the database
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText =
                    $@"UPDATE read SET Quantity = {quantity} WHERE Id = {id}";

                command.ExecuteNonQuery();

                connection.Close();
            }

            Console.WriteLine("Record updated successfully!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // create ViewAllHabits() method
        private static void ViewAllHabits()
        {
            Console.Clear();
            Console.WriteLine("View all records");

            // view all records from the database
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText =
                    $@"SELECT * FROM read";

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"Id: {reader["Id"]}, Date: {reader["Date"]}, Quantity: {reader["Quantity"]}");
                }

                connection.Close();
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        // add a method which gets the amount of pages read last week
        private static void GetPagesReadLastWeek()
        {
            Console.Clear();
            Console.WriteLine("Pages read last week");

            // get the date from last week
            DateTime lastWeek = DateTime.Now.AddDays(-7);

            // view all records from the database
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();

                command.CommandText =
                    $@"SELECT SUM(Quantity) AS TotalQuantity FROM read WHERE Date >= '{lastWeek}'";

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"Pages read last week: {reader["TotalQuantity"]}");
                }

                connection.Close();
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
