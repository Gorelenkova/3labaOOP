using _3labaOOP.DTOs.UserDtos;
using _3labaOOP.Serves;
using Microsoft.AspNetCore.Mvc;

namespace _3labaOOP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServiceUser _userServesecs;

        public UserController(IServiceUser userServesecs)
        {
            _userServesecs = userServesecs;
        }

        [HttpGet("GetAll")]
        public ActionResult<List<UserDto>> GetUserAll()
        {
            var users = _userServesecs.GetUserAll();
            return Ok(users);
        }

        [HttpGet("GetById")]
        public ActionResult<UserDto> GetUserById(int userid)
        {
            var user = _userServesecs.GetUserById(userid);

            return Ok(user);
        }
        //теперь добавление юзера только через регестрацию
        //[HttpPost("AddUser")]
        //public ActionResult<string> CreateUser(string Name, string LastName, string Login, string Password)
        //{
        //    _userServesecs.CreateUser(Name, LastName, Login, Password);

        //    return Ok();

        //}
        [HttpPut("ChangeUser")]
        public ActionResult<string> ChangeUser(CreateUserDto userdto, int id)
        {
            _userServesecs.ChangeUser(userdto, id);
            return Ok();
        }


        [HttpDelete("DeleteUser")]
        public ActionResult<string> DeleteUser(int id)
        {
            _userServesecs.DeleteUser(id);
            return Ok();

        }

    }
}
