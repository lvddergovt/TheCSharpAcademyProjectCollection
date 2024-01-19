using Microsoft.Data.Sqlite;
using SQLitePCL;
using System;

namespace HabitLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize SQLitePCL
            SQLitePCL.Batteries.Init();

            // Existing database connection code
            using (var connection = new SqliteConnection("Data Source=habits.db"))
            {
                connection.Open();
                var tableCommand = connection.CreateCommand();

                tableCommand.CommandText =
                    @"CREATE TABLE IF NOT EXISTS practice_guitar(
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Date TEXT,
                    Quantity INTEGER
                )";  // Also, removed the trailing comma from 'Quantity INTEGER,'

                tableCommand.ExecuteNonQuery();

                connection.Close();
            }

            // write a comment tio the consiole
            Console.WriteLine("Hello World!");
        }
    }
}
