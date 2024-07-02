using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RunningApplicationAPI.Models;
using RunningApplicationAPI.Models.Data;
using RunningApplicationAPI.Models.Request;
using RunningApplicationAPI.Service;
using RunningApplicationAPI.ViewModels;

namespace RunningApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileService _userProfileService;
        public UserProfileController( IUserProfileService userProfileService)
        {
            _userProfileService = userProfileService;
        }


        [HttpGet]
        public async Task<IEnumerable<UserProfileViewModel>> GetUserProfiles()
        {
            var getUserProfile = await _userProfileService.GetAllUserProfiles();
            return getUserProfile;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserProfileViewModel>> GetUserProfile(int id)
        {
            var userProfile = await _userProfileService.GetUserProfileById(id);

            if (userProfile == null)
            {
                return NotFound();
            }

            return userProfile;
        }

        [HttpPost]
        public async Task<ActionResult<UserProfileViewModel>> PostUserProfile(CreateUserProfileRequest userProfile)
        {
            await _userProfileService.AddUserProfile(userProfile);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> PutUserProfile(UpdateUserProfileRequest userProfile)
        {
            if (userProfile == null)
            {
                return BadRequest();
            }

            await _userProfileService.UpdateUserProfile(userProfile);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserProfile(int id)
        {
            var userProfile = await _userProfileService.GetUserProfileById(id);
            if (userProfile == null)
            {
                return NotFound();
            }

            await _userProfileService.DeleteUserProfile(id);
            return NoContent();
        }
    }
}
