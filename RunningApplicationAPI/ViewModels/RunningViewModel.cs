using RunningApplicationAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace RunningApplicationAPI.ViewModels
{
    public class RunningViewModel
    {
        public int Id { get; set; } 
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Distance { get; set; }
        public TimeSpan Duration { get; set; }
        public double AveragePace { get; set; }
        public UserProfileViewModel UserProfile { get; set; }
    }
}
