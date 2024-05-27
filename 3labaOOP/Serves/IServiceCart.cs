using _3labaOOP.dto.CartDtos;

namespace _3labaOOP.Serves
{
    public interface IServiceCart
    {
        string AddInCart(int userid, int productid);
        CartProductDto[] GetUsersOrderByUserId(int UserId);
    }
}
