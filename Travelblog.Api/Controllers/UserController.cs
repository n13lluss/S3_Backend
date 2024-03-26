using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Travelblog.Api.Models.UserDto;
using Travelblog.Core.Interfaces;
using Travelblog.Core.Models;

namespace Travelblog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public IActionResult Register([FromBody] UserRegisterDto userRegister)
        {
            if (userRegister == null)
            {
                return BadRequest("Invalid input. Please provide valid registration details.");
            }

            User user = new()
            {
                UserName = userRegister.Name,
                Email = userRegister.Email,
                Password = ""
            };

            try
            {
                // Check if the username or email is already registered
                var isAvailable = _userService.CheckAvailability(user);
                if (!isAvailable)
                {
                    return Conflict("Username or email is already taken. Please choose a different one.");
                }

                // Register the user
                _userService.RegisterUser(user);

                return Ok();
            }
            catch
            {
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }
        }
    }
}
