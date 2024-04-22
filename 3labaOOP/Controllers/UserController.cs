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
        [HttpGet("GetAll")]
        public ActionResult<List<User>> GetUserAll()
        {
            var users = _context.Users.ToList();
            return users;
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetUserId(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
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

        public class UpdatedUser
        {
            public string Name { get; set; }
            public string LastName { get; set; }
        }
        [HttpPut("PutUser")]
        public ActionResult<string> PutUser(int id, UpdatedUser updatedUser)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound(id);
            }
            user.Name = updatedUser.Name;
            user.LastName = updatedUser.LastName;
            _context.SaveChanges();
            return Ok(user);
        }
        [HttpDelete("DeleteUser")]
        public ActionResult<string> DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound(id);
            }
            _context.Remove(user);
            _context.SaveChanges();
            return Ok(user);

        }
    }
}
