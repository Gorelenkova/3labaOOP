using _3labaOOP.DTOs.UserDtos;
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
        public ActionResult<List<UserDto>> GetUserAll()
        {
            var users = _context.Users.Select(x => new UserDto { Id = x.Id, Name = x.Name, LastName = x.LastName }).ToList();
            return Ok(users);
        }

        [HttpGet("GetById")]
        public ActionResult<UserDto> GetUserById(int userid)
        {
            var user = _context.Users.Where(x => x.Id == userid)
                                    .Select(x => new UserDto { Id = x.Id, LastName = x.LastName, Name = x.Name })
                                    .FirstOrDefault();



            return user;
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
        [HttpPut("ChangeUser")]
        public ActionResult<string> ChangeUser(CreateUserDto userdto, int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return "Такой юзер не найден";
            }
            user.Name = userdto.Name;
            user.LastName = userdto.LastName;

            _context.SaveChanges();
            return "Юзер изменен";
        }


        [HttpDelete("DeleteUser")]
        public ActionResult<string> DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return "Такой продукт не найден";
            }
            _context.Remove(user);
            _context.SaveChanges();
            return "Продукт удален";

        }
    }
}
