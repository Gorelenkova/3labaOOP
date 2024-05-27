using _3labaOOP.dto.CartDtos;
using _3labaOOP.Serves;
using Microsoft.AspNetCore.Mvc;

namespace _3labaOOP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IServiceCart _serviceCart;
        public CartController(IServiceCart _serviceCart)
        {
            this._serviceCart = _serviceCart;
        }

        [HttpGet("GetOrderById")]
        public ActionResult<CartProductDto[]> GetUsersOrderByUserId(int UserId)
        {
            var result = _serviceCart.GetUsersOrderByUserId(UserId);
            return Ok(result);
        }

        [HttpPost("AddInCart")]
        public ActionResult<string> AddInCart(int userid, int productid)
        {

            _serviceCart.AddInCart(userid, productid);
            return Ok("Добавлено в корзину");
        }
    }
}
