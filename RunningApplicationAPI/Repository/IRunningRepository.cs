using RunningApplicationAPI.Models;
using RunningApplicationAPI.Models.Request;
using RunningApplicationAPI.ViewModels;

namespace RunningApplicationAPI.Repository
{
    public interface IRunningRepository
    {
        Task<IEnumerable<RunningViewModel>> GetAll();
        Task<RunningViewModel> GetById(int id);
        Task Add(CreateRunningRequest runningActivity);
        Task Update(UpdateRunningRequest runningActivity);
        Task Delete(int id);
    }
}
