using JWT.API_.Models;
using JWT.API_.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWT.API_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Login")]
        public IActionResult Login(User user)
        {
            var token = _userService.Login(user);

            if (token == null || token == string.Empty)
            {
                return BadRequest(new { message = "Invalid Username/Password" });
            }
            return Ok(token);
        }

    }
}
