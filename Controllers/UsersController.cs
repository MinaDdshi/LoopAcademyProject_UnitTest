using LoopAcademyProject.Entities;
using LoopAcademyProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoopAcademyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;
        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> Create(User request)
        {
            await _userService.Create(request);
            _logger.LogInformation("The desired user was created");
            return Ok();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<User>> Read(int Id)
        {
            var user = await _userService.Read(Id);
            _logger.LogInformation("The desired user was selected.");

            if (user == null)
            {
                _logger.LogError("User not found.");
            }

            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<User>> ReadAll()
        {
            var user = await _userService.ReadAll();
            _logger.LogInformation("All users are displayed.");

            if (user == null)
            {
                _logger.LogError("There is no user.");
            }

            return Ok(user);
        }

        [HttpPut]
        public async Task<ActionResult> Update(User request)
        {
            await _userService.Update(request);
            _logger.LogInformation("The user was edited.");
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int Id)
        {
            await _userService.Delete(Id);
            _logger.LogInformation("The user was deleted.");
            return Ok();
        }
    }
}

