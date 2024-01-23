using Microsoft.EntityFrameworkCore;

namespace CodingTracker
{
    public class CodingTrackerContext : DbContext
    {
        public DbSet<CodingSession> CodingSessions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=coding_tracker.db");
        }
    }
}