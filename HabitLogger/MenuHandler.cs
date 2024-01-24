using System;

namespace HabitLogger
{
    public class MenuHandler
    {

        private UserActionsHandler actionHandler;

        public MenuHandler()
        {
            actionHandler = new UserActionsHandler();
        }

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


        public int GetMainMenuInput()
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
                        actionHandler.InsertRecord();
                        break;
                    case 2:
                        // delete a habit
                        actionHandler.DeleteHabit();
                        break;
                    case 3:
                        // update a habit
                        actionHandler.UpdateHabit();
                        break;
                    case 4:
                        // view all habits
                        actionHandler.ViewAllHabits();
                        break;
                    case 5:
                        // get the amount of pages read last week
                        actionHandler.GetPagesReadLastWeek();
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

    }
}