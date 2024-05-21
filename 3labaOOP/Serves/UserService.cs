using _3labaOOP.DTOs.UserDtos;
using _3labaOOP.Models;
using Microsoft.AspNetCore.Mvc;

namespace _3labaOOP.Serves
{
    public class UserService : IServiceUser
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;

        }
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

        public ActionResult<List<UserDto>> GetUserAll()
        {
            var users = _context.Users.Select(x => new UserDto { Id = x.Id, Name = x.Name, LastName = x.LastName }).ToList();
            return users;
        }

        public ActionResult<UserDto> GetUserById(int userid)
        {
            var user = _context.Users.Where(x => x.Id == userid)
                                     .Select(x => new UserDto { Id = x.Id, LastName = x.LastName, Name = x.Name })
                                     .FirstOrDefault();



            return user;
        }
    }

}

