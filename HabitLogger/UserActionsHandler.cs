using System;
using Microsoft.Data.Sqlite;

namespace HabitLogger
{
    public class UserActionsHandler
    {
        static string connectionString = "Data Source=habits.db";

        public void InsertRecord()
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
        public void DeleteHabit()
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
        public void UpdateHabit()
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
        public void ViewAllHabits()
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
        public void GetPagesReadLastWeek()
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