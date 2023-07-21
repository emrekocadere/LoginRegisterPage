using bank_website_backend.Model.Request;
using bank_website_backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace bank_website_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) {
            _userService = userService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = await _userService.Register(request);

            if(result.Succeeded)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.Errors);
            }

        }


        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var result=await _userService.Login(request);
            if(result.Succeeded)
            {
                return Ok("logged in");
            }
            else { return BadRequest("errorrrrr"); }

        }


    }
}


