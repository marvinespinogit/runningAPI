using RunningApplicationAPI.Models;
using RunningApplicationAPI.Models.Request;
using RunningApplicationAPI.Repository;
using RunningApplicationAPI.ViewModels;

namespace RunningApplicationAPI.Service
{
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _repository;
        private readonly ILogger<UserProfileService> _logger;

        public UserProfileService(IUserProfileRepository repository, ILogger<UserProfileService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<UserProfileViewModel>> GetAllUserProfiles()
        {
            _logger.LogInformation("Getting all user profiles.");
            return await _repository.GetAll();
        }

        public async Task<UserProfileViewModel> GetUserProfileById(int id)
        {
            _logger.LogInformation($"Getting user profile with id {id}.");
            return await _repository.GetById(id);
        }

        public async Task AddUserProfile(CreateUserProfileRequest userProfile)
        {
            _logger.LogInformation($"Adding user profile with name {userProfile.Name}.");
            await _repository.Add(userProfile);
        }

        public async Task UpdateUserProfile(UpdateUserProfileRequest userProfile)
        {
            _logger.LogInformation($"Updating user profile with id {userProfile.Id}.");
            await _repository.Update(userProfile);
        }

        public async Task DeleteUserProfile(int id)
        {
            _logger.LogInformation($"Deleting user profile with id {id}.");
            await _repository.Delete(id);
        }
    }
}
