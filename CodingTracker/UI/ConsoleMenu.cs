using System;
using Spectre.Console;

namespace CodingTracker
{
    public class ConsoleMenu
    {
        private readonly CodingSessionController _codingSessionController;

        public ConsoleMenu(CodingSessionController codingSessionController)
        {
            _codingSessionController = codingSessionController;
        }

        /// <summary>
        /// Displays the menu for the Coding Tracker application and handles user input.
        /// </summary>
        public void DisplayMenu()
        {
            bool exitApp = false;
            while (!exitApp)
            {
                Console.Clear();
                var panel = new Panel(new Rows(
                    new Text("1. Add New Coding Session"),
                    new Text("2. Edit Coding Session"),
                    new Text("3. Remove Coding Session"),
                    new Text("4. View All Coding Sessions"),
                    new Text("5. Exit"))
                );
                panel.Border = BoxBorder.Double;
                panel.Padding = new Padding(2, 2, 2, 2);
                panel.Header = new PanelHeader("Coding Tracker");
                AnsiConsole.Render(panel);
                Console.WriteLine("Coding Tracker Application");
                Console.WriteLine("1. Add New Coding Session");
                Console.WriteLine("2. Edit Coding Session");
                Console.WriteLine("3. Remove Coding Session");
                Console.WriteLine("4. View All Coding Sessions");
                Console.WriteLine("5. Exit");
                Console.Write("\nSelect an option: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        _codingSessionController.CreateCodingSessionFromUserInput();
                        break;
                    case "2":
                        // Edit Coding Session
                        break;
                    case "3":
                        // Remove Coding Session
                        break;
                    case "4":
                        // View All Coding Sessions
                        _codingSessionController.DisplayAllCodingSessions();
                        break;
                    case "5":
                        exitApp = true;

                        AnsiConsole.Render(new FigletText("Take care, happy coding!").Centered().Color(Color.Green));


                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }

                if (!exitApp)
                {
                    Console.WriteLine("\nPress any key to return to the menu...");
                    Console.ReadKey();
                }
            }
        }

    }
}
