using _3labaOOP.Models;
using Microsoft.AspNetCore.Mvc;

namespace _3labaOOP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CartController(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        [HttpPost("AddInCart")]
        public ActionResult<string> AddInCart(int userid, int productid)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == userid);
            var product = _context.Products.FirstOrDefault(x => x.Id == productid);

            var cartProduct = new CartProduct()
            {
                Cart = user.Cart,
                Product = product
            };
            _context.CartProducts.Add(cartProduct);
            _context.SaveChanges();
            return Ok("Добавлено в корзину");
        }

    }
}
