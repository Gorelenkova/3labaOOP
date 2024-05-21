using _3labaOOP.dto.CartDtos;
using _3labaOOP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _3labaOOP.Serves
{
    public class CartService : IServiceCart
    {

        private readonly ApplicationDbContext _context;
        public CartService(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        public ActionResult<string> AddInCart(int userid, int productid)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == productid);
            var user = _context.Users.Include(x => x.Cart).FirstOrDefault(x => x.Id == userid);
            if (user == null || product == null)
            {
                return null;
            }

            var cartProduct = new CartProduct()
            {
                Cart = user.Cart,
                Product = product
            };
            _context.CartProducts.Add(cartProduct);
            _context.SaveChanges();
            return "Добавлено в корзину";
        }

        public ActionResult<List<CartProductDto>> GetUsersOrderByUserId(int UserId)
        {
            var user = _context.Users.Include(x => x.Cart).FirstOrDefault(x => x.Id == UserId);

            var cartproduct = _context.CartProducts.Where(x => x.Cart == user.Cart).Select(x => x.ProductId).ToList();

            var products = new List<Product>();

            foreach (var p in cartproduct)
            {
                products.Add(_context.Products.FirstOrDefault(x => x.Id == p));
            }


            var productdto = products.Select(x => new CartProductDto { Name = x.Name, Description = x.Description, Price = x.Price }).ToList();

            return productdto;
        }
    }
}
