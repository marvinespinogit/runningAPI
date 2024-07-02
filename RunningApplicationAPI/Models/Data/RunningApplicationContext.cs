using Microsoft.EntityFrameworkCore;

namespace RunningApplicationAPI.Models.Data
{
    public class RunningApplicationContext : DbContext
    {
        public RunningApplicationContext(DbContextOptions<RunningApplicationContext> options)
             : base(options)
        {
        }

        public RunningApplicationContext()
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<RunningActivity> RunningActivities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-CCAB9C7\\SQLEXPRESS02;Database=DB_Athlete;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True;");
            }
        }
    }
}
