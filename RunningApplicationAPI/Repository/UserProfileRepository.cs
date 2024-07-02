using Microsoft.EntityFrameworkCore;
using RunningApplicationAPI.Models;
using RunningApplicationAPI.Models.Data;
using RunningApplicationAPI.Models.Request;
using RunningApplicationAPI.ViewModels;
using System.Collections.Generic;

namespace RunningApplicationAPI.Repository
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly RunningApplicationContext _dbContext;
        public UserProfileRepository(RunningApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<UserProfileViewModel>> GetAll()
        {
            var userProfiles = await _dbContext.UserProfiles.Include(u => u.RunningActivities).ToListAsync();

            var result = userProfiles.Select(u => new UserProfileViewModel
            {
                Id = u.Id,
                Name = u.Name,
                Weight = u.Weight,
                Height = u.Height,
                BirthDate = u.BirthDate,
                Age = DateTime.Now.Year - u.BirthDate.Year,
                BMI = u.Weight / Math.Pow(u.Height / 100, 2),
                RunningActivities = u.RunningActivities.Select(r => new RunningViewModel
                {
                    Id = r.Id,
                    Location = r.Location,
                    StartTime = r.StartTime,
                    EndTime = r.EndTime,
                    Distance = r.Distance,
                    Duration = r.EndTime - r.StartTime,
                    AveragePace = r.Distance > 0 ? (r.EndTime - r.StartTime).TotalMinutes / r.Distance : 0
                }).ToList()
            }).ToList();

            return result;
        }

        public async Task<UserProfileViewModel> GetById(int id)
        {
            var userProfiles = await _dbContext.UserProfiles.Where(o => o.Id == id).Include(u => u.RunningActivities).FirstOrDefaultAsync();

            var result = new UserProfileViewModel
            {
                Id = id,
                Name = userProfiles.Name,
                Weight = userProfiles.Weight,
                Height = userProfiles.Height,
                BirthDate = userProfiles.BirthDate,
                Age = DateTime.Now.Year - userProfiles.BirthDate.Year,
                BMI = userProfiles.Weight / Math.Pow(userProfiles.Height / 100, 2),
                RunningActivities = userProfiles.RunningActivities.Select(r => new RunningViewModel
                {
                    Id = r.Id,
                    Location = r.Location,
                    StartTime = r.StartTime,
                    EndTime = r.EndTime,
                    Distance = r.Distance,
                    Duration = r.EndTime - r.StartTime,
                    AveragePace = r.Distance > 0 ? (r.EndTime - r.StartTime).TotalMinutes / r.Distance : 0
                }).ToList()
            };

            return result;
        }

        public async Task Add(CreateUserProfileRequest req)
        {
            var userProfile = new UserProfile()
            {
                Name = req.Name,
                BirthDate = req.BirthDate,
                Height = req.Height,
                Weight = req.Weight
            };

            _dbContext.UserProfiles.Add(userProfile);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(UpdateUserProfileRequest request)
        {
            var userProfile = await _dbContext.UserProfiles.FirstOrDefaultAsync(p => p.Id == request.Id);
            if (userProfile != null)
            {
                userProfile.Name = request.Name;
                userProfile.BirthDate = request.BirthDate;
                userProfile.Height = request.Height;
                userProfile.Weight = request.Weight;

                _dbContext.UserProfiles.Update(userProfile);
                await _dbContext.SaveChangesAsync();
            }
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
