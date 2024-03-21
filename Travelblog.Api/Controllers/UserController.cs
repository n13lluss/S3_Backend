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
        private readonly IAuthService _authService;

        public UserController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
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
                Password = userRegister.Password
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

                // Generate JWT token for the newly registered user
                var token = _authService.GenerateJwtToken(userRegister.Email);

                return Ok(new { Token = token });
            }
            catch
            {
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }
        }

        [HttpGet("checkavailability")]
        public IActionResult CheckAvailability()
        {
            return StatusCode(200);   
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] UserDto userLogin)
        {
            if (userLogin == null)
            {
                return BadRequest("Invalid input. Please provide valid credentials.");
            }

            try
            {
                var isValidUser = _userService.CheckUser(userLogin.UsernameEmail, userLogin.Password);

                if (!isValidUser)
                {
                    return Unauthorized("Invalid credentials. Please check your username/email and password.");
                }

                var token = _authService.GenerateJwtToken(userLogin.UsernameEmail);

                return Ok(new { Token = token });
            }
            catch
            {
                return StatusCode(500, "An error occurred while processing the request. Please try again later.");
            }
        }
    }
}
