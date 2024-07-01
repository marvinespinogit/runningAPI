using Microsoft.EntityFrameworkCore;
using RunningApplicationAPI.Models;

namespace RunningApplicationAPI.Repository
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly RunningApplicationContext _dbContext;
        public UserProfileRepository(RunningApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<UserProfile>> GetAll()
        {
            return await _dbContext.UserProfiles.Include(u => u.RunningActivities).ToListAsync();
        }

        public async Task<UserProfile> GetById(int id)
        {
            return await _dbContext.UserProfiles.Include(u => u.RunningActivities)
                                              .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task Add(UserProfile userProfile)
        {
            _dbContext.UserProfiles.Add(userProfile);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(UserProfile userProfile)
        {
            _dbContext.Entry(userProfile).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var userProfile = await _dbContext.UserProfiles.FindAsync(id);
            if (userProfile != null)
            {
                _dbContext.UserProfiles.Remove(userProfile);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
