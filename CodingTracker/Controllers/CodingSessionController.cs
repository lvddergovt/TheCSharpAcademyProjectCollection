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
        // Constructor
        public CodingSessionController()
        {

        }


        /// <summary>
        /// Creates a new coding session with the specified start and end times.
        /// </summary>
        /// <param name="startTime">The start time of the coding session.</param>
        /// <param name="endTime">The end time of the coding session.</param>
        public void CreateCodingSession(DateTime startTime, DateTime endTime)
        {
            // Validate start and end times
            if (startTime >= endTime)
            {
                Console.WriteLine("End time must be after start time.");
                return;
            }

            // Calculate duration
            TimeSpan duration = CalculateDuration(startTime, endTime);

            // Get the programming language
            var programmingLanguage = GetProgrammingLanguage();

            // Create a new coding session
            CodingSession newSession = new CodingSession
            {
                StartTime = startTime,
                EndTime = endTime,
                Duration = duration,
                ProgrammingLanguage = programmingLanguage
            };

            // Add the new session to the database
            AddCodingSessionToDatabase(newSession);
        }


        /// <summary>
        /// Creates a new coding session based on user input for date, start time, and end time.
        /// </summary>
        public void CreateCodingSession()
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

            // Calculate duration
            TimeSpan duration = CalculateDuration(startTime, endTime);

            CreateCodingSession(startTime, endTime);
        }

        /// <summary>
        /// Adds a coding session to the database.
        /// </summary>
        /// <param name="session">The coding session to be added.</param>
        private void AddCodingSessionToDatabase(CodingSession session)
        {
            AnsiConsole.Status()
                .Start("Saving...", ctx =>
                {
                    // Update the status and spinner
                    ctx.Status("Creating coding session...");
                    ctx.Spinner(Spinner.Known.Star);
                    ctx.SpinnerStyle(Style.Parse("green"));

                    Thread.Sleep(2000);
                });

            using (var context = new CodingTrackerContext())
            {
                context.CodingSessions.Add(session);
                context.SaveChanges();
            }

            AnsiConsole.MarkupLine("[green]Coding session created![/]");
        }


        /// <summary>
        /// Calculates the duration between two DateTime values.
        /// </summary>
        /// <param name="start">The starting DateTime value.</param>
        /// <param name="end">The ending DateTime value.</param>
        /// <returns>The TimeSpan representing the duration between the start and end DateTime values.</returns>
        private TimeSpan CalculateDuration(DateTime start, DateTime end)
        {
            return end - start;
        }


        /// <summary>
        /// Retrieves all coding sessions from the database.
        /// </summary>
        /// <returns>A list of coding sessions sorted by newest first.</returns>
        public List<CodingSession> GetAllCodingSessions()
        {
            using (var context = new CodingTrackerContext())
            {
                // sort by newest first
                return context.CodingSessions.OrderByDescending(s => s.StartTime).ToList();
            }
        }

        // a method where the console asks the user if he wants to specify which programming language he used
        // if yes, ask the user to enter the programming language
        // if no, set the programming language to "N/A"
        // return the programming language
        public string GetProgrammingLanguage()
        {
            Console.WriteLine("Do you want to specify which programming language you used? (Y/n)");
            string specifyProgrammingLanguage = Console.ReadLine();
            string programmingLanguage;

            // Todo: add more programming languages
            var programmingLanguages = new string[] { "javascript", "c#", "vue", "react" };

            // if yes, let the user pick a programming language from a predefined list
            // use a Ansi Console selection list to make the user pick a programming language
            if (specifyProgrammingLanguage.ToLower() == "y")
            {
                AnsiConsole.MarkupLine("[green]Pick a programming language:[/]");
                var selection = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .PageSize(10)
                        .AddChoices(programmingLanguages)
                        .Title("[bold]Programming Languages[/]")
                        .MoreChoicesText("[grey](Move up and down to reveal more programming languages)[/]")
                        .HighlightStyle("green")
                );
                programmingLanguage = selection;
            }
            else
            {
                programmingLanguage = "N/A";
            }

            return programmingLanguage;
        }


        /// <summary>
        /// Displays all coding sessions in a table format.
        /// </summary>
        public void DisplayAllCodingSessions()
        {
            var table = new Table();

            table.AddColumn("[bold]Start Time[/]");
            table.AddColumn("[bold]End Time[/]");
            table.AddColumn("[bold]Duration[/]");
            table.AddColumn("[bold]Programming Language[/]");

            List<CodingSession> codingSessions = GetAllCodingSessions();



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



    }
}