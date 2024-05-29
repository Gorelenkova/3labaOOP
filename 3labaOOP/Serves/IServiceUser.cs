using _3labaOOP.DTOs.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace _3labaOOP.Serves
{
    public interface IServiceUser
    {
        ActionResult<List<UserDto>> GetUserAll();
        ActionResult<UserDto> GetUserById(int userid);
        ActionResult<string> CreateUser(string Name, string LastName, string Login, string Password);
        ActionResult<string> ChangeUser(CreateUserDto userdto, int id);
        ActionResult<string> DeleteUser(int id);

    }
}
