using RunningApplicationAPI.Models;

namespace RunningApplicationAPI.Repository
{
    public interface IRunningRepository
    {
        Task<IEnumerable<RunningActivity>> GetAll();
        Task<RunningActivity> GetById(int id);
        Task Add(RunningActivity runningActivity);
        Task Update(RunningActivity runningActivity);
        Task Delete(int id);
    }
}
