using RunningApplicationAPI.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RunningApplicationAPI.Models
{
    public class UserProfile : BaseEntity
    {
        public string Name { get; set; }
        public double Weight { get; set; } // in kg
        public double Height { get; set; } // in cm

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public ICollection<RunningActivity>? RunningActivities { get; set; }
    }
}
