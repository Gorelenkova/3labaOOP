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

            _usercontroller.CreateUser(name, lastName, login, password);
            return "User created successfully.";
        }
        public ActionResult<string> Login(string login, string password)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
                if (user != null)
                {
                    return "Успешный вход";
                }
                else
                {
                    return "Неверные логин или пароль";
                }
            }
            catch (Exception ex)
            {
                // Логирование ошибки
                return "Произошла внутренняя ошибка сервера";
            }
        }
    }
}
