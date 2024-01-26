using Microsoft.Data.Sqlite;
using SQLitePCL;
using System;

namespace HabitLogger
{
    class Program
    {

        static void Main(string[] args)
        {
            // Create database
            DatabaseHandler dbHandler = new DatabaseHandler();
            dbHandler.CreateDatabase();

            MenuHandler menuHandler = new MenuHandler();
            menuHandler.GetMainMenuInput();
        }

    }
}
