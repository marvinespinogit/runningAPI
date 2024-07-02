using System.ComponentModel.DataAnnotations;

namespace RunningApplicationAPI.Models.Request
{
    public class CreateUserProfileRequest
    {
        public string Name { get; set; }
        public double Weight { get; set; } // in kg
        public double Height { get; set; } // in cm

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
    }

    public class UpdateUserProfileRequest : CreateUserProfileRequest
    {
        public int Id { get; set; } 
    }
}
