﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Travelblog.Api.Models.UserDto;
using Travelblog.Core.Interfaces;

namespace Travelblog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UserController(IAuthService authService, IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        private readonly IAuthService _authService = authService;

        [HttpPost("login")]
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
