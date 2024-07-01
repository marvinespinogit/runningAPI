using Microsoft.EntityFrameworkCore;
using RunningApplicationAPI.Models;

namespace RunningApplicationAPI.Repository
{
    public class RunningRepository : IRunningRepository
    {
        private readonly RunningApplicationContext _dbContext;

        public RunningRepository(RunningApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<RunningActivity>> GetAll()
        {
            return await _dbContext.RunningActivities.Include(r => r.UserProfile).ToListAsync();
        }

        public async Task<RunningActivity> GetById(int id)
        {
            return await _dbContext.RunningActivities.Include(r => r.UserProfile)
                                                   .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task Add(RunningActivity runningActivity)
        {
            _dbContext.RunningActivities.Add(runningActivity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(RunningActivity runningActivity)
        {
            _dbContext.Entry(runningActivity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var runningActivity = await _dbContext.RunningActivities.FindAsync(id);
            if (runningActivity != null)
            {
                _dbContext.RunningActivities.Remove(runningActivity);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
