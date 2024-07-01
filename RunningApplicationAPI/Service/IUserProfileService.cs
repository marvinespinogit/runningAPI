using RunningApplicationAPI.Models;

namespace RunningApplicationAPI.Service
{
    public interface IUserProfileService
    {
        Task<IEnumerable<UserProfile>> GetAllUserProfiles();
        Task<UserProfile> GetUserProfileById(int id);
        Task AddUserProfile(UserProfile userProfile);
        Task UpdateUserProfile(UserProfile userProfile);
        Task DeleteUserProfile(int id);
    }
}
