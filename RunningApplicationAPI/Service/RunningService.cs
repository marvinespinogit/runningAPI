using RunningApplicationAPI.Models;
using RunningApplicationAPI.Repository;

namespace RunningApplicationAPI.Service
{
    public class RunningService : IRunningService
    {
        private readonly IRunningRepository _repository;
        private readonly ILogger<RunningService> _logger;
        public RunningService(IRunningRepository repository, ILogger<RunningService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<RunningActivity>> GetAllRunningActivities()
        {
            _logger.LogInformation("Getting all running activities.");
            return await _repository.GetAll();
        }

        public async Task<RunningActivity> GetRunningActivityById(int id)
        {
            _logger.LogInformation($"Getting running activity with id {id}.");
            return await _repository.GetById(id);
        }

        public async Task AddRunningActivity(RunningActivity runningActivity)
        {
            _logger.LogInformation($"Adding running activity at location {runningActivity.Location}.");
            await _repository.Add(runningActivity);
        }

        public async Task UpdateRunningActivity(RunningActivity runningActivity)
        {
            _logger.LogInformation($"Updating running activity with id {runningActivity.Id}.");
            await _repository.Update(runningActivity);
        }

        public async Task DeleteRunningActivity(int id)
        {
            _logger.LogInformation($"Deleting running activity with id {id}.");
            await _repository.Delete(id);
        }
    }
}
