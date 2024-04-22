using _3labaOOP.Models;
using Microsoft.AspNetCore.Mvc;

namespace _3labaOOP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        [HttpPost("AddUser")]
        public ActionResult<string> CreateUser(string Name, string LastName)
        {
            var user = new User()
            {
                Name = Name,
                LastName = LastName,
                Cart = new Cart()
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return "Sce horosho";

        }
    }
}
