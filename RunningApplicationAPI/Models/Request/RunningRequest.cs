using System.ComponentModel.DataAnnotations.Schema;

namespace RunningApplicationAPI.Models.Request
{
    public class CreateRunningRequest
    {
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Distance { get; set; }
        public int UserProfileId { get; set; }
    }

    public class UpdateRunningRequest : CreateRunningRequest
    { 
        public int Id { get; set; }
    }

}
