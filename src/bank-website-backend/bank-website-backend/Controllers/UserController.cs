using bank_website_backend.Entities;
using bank_website_backend.Model.Request;
using bank_website_backend.Repository;
using bank_website_backend.Services;
using Microsoft.AspNetCore.Http;
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
        public IActionResult Register(RegisterRequest request)
        {
            var user=_userService.MapUserAndUserRequest(request);
            return Ok(_userService.Register(request));
        }
    }
}


