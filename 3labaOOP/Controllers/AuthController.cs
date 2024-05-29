using _3labaOOP.Serves;
using Microsoft.AspNetCore.Mvc;

namespace _3labaOOP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IServiceUser _usercontroller;
        private readonly IAuthService _authservice;
        public AuthController(IServiceUser userController, IAuthService authservice)
        {
            _usercontroller = userController;
            _authservice = authservice;
        }

        [HttpPost("register")]
        public ActionResult<string> Register(string name, string lastName, string login, string password)
        {
            return Ok(_usercontroller.CreateUser(name, lastName, login, password));
        }

        [HttpGet("login")]
        public ActionResult<string> Login(string login, string password)
        {
            var result = _authservice.Login(login, password);
            return Ok(result);
        }
    }
}
