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
                    new Text("2. Remove Coding Session"),
                    new Text("3. View All Coding Sessions"),
                    new Text("4. Exit"))
                );
                panel.Border = BoxBorder.Double;
                panel.Padding = new Padding(2, 2, 2, 2);
                panel.Header = new PanelHeader("Coding Tracker");
                AnsiConsole.Render(panel);

                switch (Console.ReadLine())
                {
                    case "1":
                        _codingSessionController.CreateCodingSessionFromUserInput();
                        break;
                    case "2":
                        // Remove Coding Session
                        _codingSessionController.RemoveCodingSession();
                        break;
                    case "3":
                        // View All Coding Sessions
                        _codingSessionController.DisplayAllCodingSessions();
                        break;
                    case "4":
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
