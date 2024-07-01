using RunningApplicationAPI.Models.Base;

namespace RunningApplicationAPI.Models
{
    public class RunningActivity : BaseEntity
    {
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Distance { get; set; } 
        public TimeSpan Duration => EndTime - StartTime;
        public double AveragePace => Distance > 0 ? Duration.TotalMinutes / Distance : 0; 

        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
    }
}
