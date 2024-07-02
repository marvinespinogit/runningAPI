using Microsoft.AspNetCore.Mvc;
using RunningApplicationAPI.Models;
using RunningApplicationAPI.Models.Request;
using RunningApplicationAPI.Service;
using RunningApplicationAPI.ViewModels;

namespace RunningApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RunningController : ControllerBase
    {

        private readonly IRunningService _runningService;
        public RunningController(IRunningService runningService)
        {
            _runningService = runningService;
        }

        [HttpGet]
        public async Task<IEnumerable<RunningViewModel>> GetAllRunningActivities()
        {
            var result = await _runningService.GetAllRunningActivities();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RunningViewModel>> GetRunningActivityById(int id)
        {
            var result = await _runningService.GetRunningActivityById(id);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        [HttpPost]
        public async Task<IActionResult> PostRunningActivity(CreateRunningRequest runningActivity)
        {
            await _runningService.AddRunningActivity(runningActivity);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> PutRunningActivity(UpdateRunningRequest runningActivity)
        {
            if (runningActivity == null)
            {
                return BadRequest();
            }

            await _runningService.UpdateRunningActivity(runningActivity);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var runningActivity = await _runningService.GetRunningActivityById(id);
            if (runningActivity == null)
            {
                return NotFound();
            }

            await _runningService.DeleteRunningActivity(id);
            return NoContent();
        }
    }
}
