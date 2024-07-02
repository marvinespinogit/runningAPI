using RunningApplicationAPI.Models;
using RunningApplicationAPI.Models.Request;
using RunningApplicationAPI.ViewModels;

namespace RunningApplicationAPI.Repository
{
    public interface IUserProfileRepository
    {
        Task<IEnumerable<UserProfileViewModel>> GetAll();
        Task<UserProfileViewModel> GetById(int id);
        Task Add(CreateUserProfileRequest userProfile);
        Task Update(UpdateUserProfileRequest userProfile);
        Task Delete(int id);
    }
}
