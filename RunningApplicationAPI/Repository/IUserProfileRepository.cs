using RunningApplicationAPI.Models;

namespace RunningApplicationAPI.Repository
{
    public interface IUserProfileRepository
    {
        Task<IEnumerable<UserProfile>> GetAll();
        Task<UserProfile> GetById(int id);
        Task Add(UserProfile userProfile);
        Task Update(UserProfile userProfile);
        Task Delete(int id);
    }
}
