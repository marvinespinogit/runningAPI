using RunningApplicationAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RunningApplicationAPI.ViewModels
{
    public class UserProfileViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; } // in kg
        public double Height { get; set; } // in cm

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public int Age { get; set; }

        public double BMI { get; set; }

        public ICollection<RunningViewModel>? RunningActivities { get; set; }
    }
}
