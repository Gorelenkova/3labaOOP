using _3labaOOP.dto.CartDtos;
using Microsoft.AspNetCore.Mvc;

namespace _3labaOOP.Serves
{
    public interface IServiceCart
    {
        ActionResult<string> AddInCart(int userid, int productid);
        ActionResult<List<CartProductDto>> GetUsersOrderByUserId(int UserId);
    }
}
