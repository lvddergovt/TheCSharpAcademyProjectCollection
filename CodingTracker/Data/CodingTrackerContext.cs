using Microsoft.EntityFrameworkCore;

namespace CodingTracker
{
    public class CodingTrackerContext : DbContext
    {
        public DbSet<CodingSession> CodingSessions { get; set; }

        /// <summary>
        /// Configures the context to connect to a SQLite database.
        /// </summary>
        /// <param name="optionsBuilder">The options builder used to configure the context.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=coding_tracker.db");
        }
    }
}