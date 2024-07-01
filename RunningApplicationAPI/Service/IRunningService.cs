using RunningApplicationAPI.Models;

namespace RunningApplicationAPI.Service
{
    public interface IRunningService
    {
        Task<IEnumerable<RunningActivity>> GetAllRunningActivities();
        Task<RunningActivity> GetRunningActivityById(int id);
        Task AddRunningActivity(RunningActivity runningActivity);
        Task UpdateRunningActivity(RunningActivity runningActivity);
        Task DeleteRunningActivity(int id);
    }
}
