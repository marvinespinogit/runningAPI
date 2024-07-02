using RunningApplicationAPI.Models;
using RunningApplicationAPI.Models.Request;
using RunningApplicationAPI.ViewModels;

namespace RunningApplicationAPI.Service
{
    public interface IUserProfileService
    {
        Task<IEnumerable<UserProfileViewModel>> GetAllUserProfiles();
        Task<UserProfileViewModel> GetUserProfileById(int id);
        Task AddUserProfile(CreateUserProfileRequest userProfile);
        Task UpdateUserProfile(UpdateUserProfileRequest userProfile);
        Task DeleteUserProfile(int id);
    }
}
