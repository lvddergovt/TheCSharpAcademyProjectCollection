using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using Spectre.Console;

namespace CodingTracker
{
    public class CodingSessionService
    {
        /// <summary>
        /// Represents a coding session.
        /// </summary>
        public CodingSession CreateSession(DateTime startTime, DateTime endTime, string programmingLanguage)
        {
            if (startTime >= endTime)
            {
                throw new ArgumentException("End time must be after start time.");
            }

            TimeSpan duration = endTime - startTime;

            // Logic to create and configure a new CodingSession object
            CodingSession newSession = new CodingSession
            {
                StartTime = startTime,
                EndTime = endTime,
                Duration = duration,
                ProgrammingLanguage = programmingLanguage
            };

            return newSession;
        }

        /// <summary>
        /// Adds a coding session to the database.
        /// </summary>
        /// <param name="session">The coding session to be added.</param>
        public void AddCodingSessionToDatabase(CodingSession session)
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
            var programmingLanguages = new string[] { "javascript", "c#", "vue", "react", "python", "java", "typescript", "php" };

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
        /// Removes a coding session from the database by its ID.
        /// </summary>
        /// <param name="sessionId">The ID of the coding session to remove.</param>
        public void RemoveCodingSessionById(int sessionId)
        {
            using (var context = new CodingTrackerContext())
            {
                var sessionToRemove = context.CodingSessions.Find(sessionId);
                context.CodingSessions.Remove(sessionToRemove);
                context.SaveChanges();
            }
        }
    }
}