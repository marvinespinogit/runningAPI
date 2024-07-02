using Azure.Core;
using Microsoft.EntityFrameworkCore;
using RunningApplicationAPI.Models;
using RunningApplicationAPI.Models.Data;
using RunningApplicationAPI.Models.Request;
using RunningApplicationAPI.ViewModels;

namespace RunningApplicationAPI.Repository
{
    public class RunningRepository : IRunningRepository
    {
        private readonly RunningApplicationContext _dbContext;

        public RunningRepository(RunningApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<RunningViewModel>> GetAll()
        {
            var running = await _dbContext.RunningActivities.Include(u => u.UserProfile).ToListAsync();

            var result = running.Select(r => new RunningViewModel
            {
                Id = r.Id,
                Location = r.Location,
                StartTime = r.StartTime,
                EndTime = r.EndTime,
                Distance = r.Distance,
                Duration = r.EndTime - r.StartTime,
                AveragePace = r.Distance > 0 ? (r.EndTime - r.StartTime).TotalMinutes / r.Distance : 0,
                UserProfile = new UserProfileViewModel
                {
                    Id = r.UserProfile.Id,
                    Name = r.UserProfile.Name,
                    Weight = r.UserProfile.Weight,
                    Height = r.UserProfile.Height,
                    BirthDate = r.UserProfile.BirthDate,
                    Age = DateTime.Now.Year - r.UserProfile.BirthDate.Year,
                    BMI = r.UserProfile.Weight / Math.Pow(r.UserProfile.Height / 100, 2),
                }
            }).ToList();

            return result;
        }

        public async Task<RunningViewModel> GetById(int id)
        {
            var r = await _dbContext.RunningActivities.Where(o => o.Id == id).Include(u => u.UserProfile).FirstOrDefaultAsync();

            var result = new RunningViewModel
            {
                Id = r.Id,
                Location = r.Location,
                StartTime = r.StartTime,
                EndTime = r.EndTime,
                Distance = r.Distance,
                Duration = r.EndTime - r.StartTime,
                AveragePace = r.Distance > 0 ? (r.EndTime - r.StartTime).TotalMinutes / r.Distance : 0,
                UserProfile = new UserProfileViewModel
                {
                    Id = r.UserProfile.Id,
                    Name = r.UserProfile.Name,
                    Weight = r.UserProfile.Weight,
                    Height = r.UserProfile.Height,
                    BirthDate = r.UserProfile.BirthDate,
                    Age = DateTime.Now.Year - r.UserProfile.BirthDate.Year,
                    BMI = r.UserProfile.Weight / Math.Pow(r.UserProfile.Height / 100, 2),
                }
            };

            return result;
        }

        public async Task Add(CreateRunningRequest req)
        {
            var running = new RunningActivity()
            {
                Location = req.Location,
                StartTime = req.StartTime,
                EndTime = req.EndTime,
                Distance = req.Distance,
                UserProfileId = req.UserProfileId
            };

            _dbContext.RunningActivities.Add(running);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(UpdateRunningRequest request)
        {
            var running = await _dbContext.RunningActivities.FirstOrDefaultAsync(p => p.Id == request.Id);
            if (running != null)
            {
                running.Location = request.Location;
                running.StartTime = request.StartTime;
                running.EndTime = request.EndTime;
                running.Distance = request.Distance;
                running.UserProfileId = request.UserProfileId;

                _dbContext.RunningActivities.Update(running);
                await _dbContext.SaveChangesAsync();
            }
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
