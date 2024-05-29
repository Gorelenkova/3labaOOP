using Microsoft.AspNetCore.Mvc;

namespace _3labaOOP.Serves
{
    public interface IAuthService
    {
        ActionResult<string> Register(string name, string lastName, string login, string password);

    }
}
