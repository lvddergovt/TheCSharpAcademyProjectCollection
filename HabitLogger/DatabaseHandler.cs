using Microsoft.Data.Sqlite;

namespace HabitLogger
{
    public class DatabaseHandler
    {
        private string connectionString = "Data Source=habits.db";

        public void CreateDatabase()
        {
            // Code to create database
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
        }

    }
}