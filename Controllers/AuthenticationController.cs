using Core.DTOs;
using Core.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        IdentityResult result;
        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            if (loginDTO == null)
            {
                return BadRequest("Please enter the correct username and password.");
            }

            try
            {
                await _userService.Login(loginDTO);

                return Ok("Logged in successfully!");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDto)
        {
            if (registerDto == null)
            {
                return BadRequest("Please enter the required data.");
            }

            try
            {
                result = await _userService.Register(registerDto);
                if (result.Succeeded)
                {
                    return Ok(result);

                }
                else
                {
                    return BadRequest(result.Errors);
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
