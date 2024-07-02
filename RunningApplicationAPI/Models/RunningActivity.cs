using RunningApplicationAPI.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RunningApplicationAPI.Models
{
    public class RunningActivity : BaseEntity
    {
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Distance { get; set; }
        public int UserProfileId { get; set; }
        public UserProfile? UserProfile { get; set; }
    }
}
