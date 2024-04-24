using _3labaOOP.DTOs.ProductDtos;
using _3labaOOP.Models;
using Microsoft.AspNetCore.Mvc;

namespace _3labaOOP.Controllers
{
    public class ProductController
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        [HttpPost("AddProduct")]
        public ActionResult<string> AddProduct(ProductDto productDto)
        {
            var product = new Product()
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Description = productDto.Description,
            };
            _context.Add(product);
            _context.SaveChanges();
            return "Добавлено в корзину";
        }
        [HttpGet("GetAllProduct")]
        public ActionResult<List<Product>> GetAllProduct()
        {
            var product = _context.Products.ToList();
            return product;
        }
        [HttpPut("ChangeProduct")]
        public ActionResult<string> ChangeProduct(ProductDto productdto, int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return "Такой продукт не найден";
            }
            product.Name = productdto.Name;
            product.Price = productdto.Price;
            product.Description = productdto.Description;
            _context.SaveChanges();
            return "Продукт изменен";
        }

        [HttpDelete("DeleteProduct")]
        public ActionResult<string> DeleteProduct(int id)
        {
            var product = _context.Users.Find(id);
            if (product == null)
            {
                return "Такой продукт не найден";
            }
            _context.Remove(product);
            _context.SaveChanges();
            return "Продукт удален";

        }
    }
}
