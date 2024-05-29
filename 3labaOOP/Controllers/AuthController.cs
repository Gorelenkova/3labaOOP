using _3labaOOP.Serves;
using Microsoft.AspNetCore.Mvc;

namespace _3labaOOP.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IServiceUser _usercontroller;
        public AuthController(ApplicationDbContext context, IServiceUser userController)
        {
            _usercontroller = userController;
        }

        [HttpPost("register")]
        public ActionResult<string> Register(string name, string lastName, string login, string password)
        {
            return Ok(_usercontroller.CreateUser(name, lastName, login, password));
        }
    }
}
