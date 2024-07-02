using RunningApplicationAPI.Models;
using RunningApplicationAPI.Models.Request;
using RunningApplicationAPI.ViewModels;

namespace RunningApplicationAPI.Service
{
    public interface IRunningService
    {
        Task<IEnumerable<RunningViewModel>> GetAllRunningActivities();
        Task<RunningViewModel> GetRunningActivityById(int id);
        Task AddRunningActivity(CreateRunningRequest runningActivity);
        Task UpdateRunningActivity(UpdateRunningRequest runningActivity);
        Task DeleteRunningActivity(int id);
    }
}
