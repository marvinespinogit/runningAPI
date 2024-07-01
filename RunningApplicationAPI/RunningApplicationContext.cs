using Microsoft.EntityFrameworkCore;
using RunningApplicationAPI.Models;

namespace RunningApplicationAPI
{
    public class RunningApplicationContext : DbContext
    {
        public RunningApplicationContext(DbContextOptions<RunningApplicationContext> options)
        : base(options)
        {
        }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<RunningActivity> RunningActivities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProfile>()
                .HasMany(u => u.RunningActivities)
                .WithOne(r => r.UserProfile)
                .HasForeignKey(r => r.UserProfileId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
