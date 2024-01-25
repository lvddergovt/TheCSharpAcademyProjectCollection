using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using Spectre.Console;

namespace CodingTracker
{
    /// <summary>
    /// Represents a controller for managing coding sessions.
    /// </summary>
    public class CodingSessionController
    {
        private readonly CodingSessionService _codingSessionService;

        // Constructor
        public CodingSessionController()
        {
            _codingSessionService = new CodingSessionService();
        }

        /// <summary>
        /// Creates a new coding session with the specified start and end times.
        /// </summary>
        /// <param name="startTime">The start time of the coding session.</param>
        /// <param name="endTime">The end time of the coding session.</param>
        public void CreateCodingSession(DateTime startTime, DateTime endTime)
        {

            // Get the programming language
            string programmingLanguage = _codingSessionService.GetProgrammingLanguage();

            CodingSession newSession = _codingSessionService.CreateSession(startTime, endTime, programmingLanguage);

            // Add the new session to the database
            _codingSessionService.AddCodingSessionToDatabase(newSession);
        }


        /// <summary>
        /// Creates a new coding session based on user input for date, start time, and end time.
        /// </summary>
        public void CreateCodingSessionFromUserInput()
        {

            // ask the user if he wants to use the current date
            Console.WriteLine("Do you want to use the current date? (Y/n)");
            string useCurrentDate = Console.ReadLine();
            string dateRaw;

            // if the user wants to use the current date, set the date to the current date
            if (useCurrentDate.ToLower() == "y")
            {
                dateRaw = DateTime.Now.ToString("yyyy-MM-dd");
            }
            else
            {
                Console.WriteLine("Enter the date (yyyy-MM-dd):");
                dateRaw = Console.ReadLine();
            }

            Console.WriteLine("Enter the start time (HH:mm):");
            string startTimeRaw = Console.ReadLine();

            Console.WriteLine("Enter the end time (HH:mm):");
            string endTimeRaw = Console.ReadLine();

            DateTime startTime = DateTime.ParseExact(dateRaw + " " + startTimeRaw, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
            DateTime endTime = DateTime.ParseExact(dateRaw + " " + endTimeRaw, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);

            CreateCodingSession(startTime, endTime);
        }

        /// <summary>
        /// Displays all coding sessions in a table format.
        /// </summary>
        public void DisplayAllCodingSessions()
        {
            List<CodingSession> codingSessions = _codingSessionService.GetAllCodingSessions();

            var table = new Table();

            table.AddColumn("[bold]Start Time[/]");
            table.AddColumn("[bold]End Time[/]");
            table.AddColumn("[bold]Duration[/]");
            table.AddColumn("[bold]Programming Language[/]");

            foreach (CodingSession session in codingSessions)
            {
                table.AddRow(
                    session.StartTime.ToString(),
                    session.EndTime.ToString(),
                    session.Duration.ToString(),
                    session.ProgrammingLanguage ?? ""
                );
            }

            AnsiConsole.Render(table);

        }

        /// <summary>
        /// Removes a coding session by prompting the user for the session ID and calling the appropriate service method.
        /// </summary>
        public void RemoveCodingSession()
        {
            List<CodingSession> codingSessions = _codingSessionService.GetAllCodingSessions();

            var table = new Table();

            table.AddColumn("[bold]Id[/]");
            table.AddColumn("[bold]Start Time[/]");
            table.AddColumn("[bold]End Time[/]");
            table.AddColumn("[bold]Duration[/]");
            table.AddColumn("[bold]Programming Language[/]");

            foreach (CodingSession session in codingSessions)
            {
                table.AddRow(
                    session.Id.ToString(),
                    session.StartTime.ToString(),
                    session.EndTime.ToString(),
                    session.Duration.ToString(),
                    session.ProgrammingLanguage ?? ""
                );
            }

            AnsiConsole.Write(table);

            // enter the id of the coding session you want to remove
            Console.WriteLine("Enter the id of the coding session you want to remove:");
            string sessionId = Console.ReadLine();

            // sessionId the id to the service, it expects an int
            _codingSessionService.RemoveCodingSessionById(int.Parse(sessionId));

            AnsiConsole.MarkupLine("[green]Coding session removed![/]");
        }
    }
}