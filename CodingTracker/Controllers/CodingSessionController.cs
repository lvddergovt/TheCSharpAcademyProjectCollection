using System;
using System.Collections.Generic;
using System.Linq;
using CodingTracker;

public class CodingController
{
    // Constructor
    public CodingController()
    {
        // Initialization, if needed
    }

    // Method to create a new coding session
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

        // Create a new coding session
        CodingSession newSession = new CodingSession
        {
            StartTime = startTime,
            EndTime = endTime,
            Duration = duration
        };

        // Add the new session to the database
        using (var context = new CodingTrackerContext())
        {
            context.CodingSessions.Add(newSession);
            context.SaveChanges();
        }
    }

    // Method to calculate the duration of a coding session
    private TimeSpan CalculateDuration(DateTime start, DateTime end)
    {
        return end - start;
    }

    // Method to retrieve all coding sessions
    public List<CodingSession> GetAllCodingSessions()
    {
        using (var context = new CodingTrackerContext())
        {
            return context.CodingSessions.ToList();
        }
    }

    // (Other methods as needed, e.g., update or delete sessions)
}
