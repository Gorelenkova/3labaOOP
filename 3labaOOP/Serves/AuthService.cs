using Microsoft.AspNetCore.Mvc;

namespace _3labaOOP.Serves
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;

        private readonly IServiceUser _usercontroller;

        public AuthService(ApplicationDbContext context, IServiceUser userController)
        {
            _context = context;
            _usercontroller = userController;
        }
        public ActionResult<string> Register(string name, string lastName, string login, string password)
        {
            //var existingUser = _context.Users.Any(u => u.Login == login);
            //if (existingUser != null)
            //{
            //    return "User with this login already exists.";
            //}

            _usercontroller.CreateUser(name, lastName, login, password);
            return "User created successfully.";
        }
    }
}
