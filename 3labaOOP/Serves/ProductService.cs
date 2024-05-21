using _3labaOOP.DTOs.ProductDtos;
using _3labaOOP.Models;
using Microsoft.AspNetCore.Mvc;

namespace _3labaOOP.Serves
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;

        }
        public ActionResult<string> AddProduct(CreateProductDto productDto)
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

        public ActionResult<string> ChangeProduct(CreateProductDto productdto, int id)
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

        public ActionResult<string> DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return "Такой продукт не найден";
            }
            _context.Remove(product);
            _context.SaveChanges();
            return "Продукт удален";
        }

        public ActionResult<List<ProductDto>> GetAllProduct()
        {
            var product = _context.Products.Select(x => new ProductDto { Description = x.Description, Price = x.Price, Name = x.Name }).ToList();
            return product;
        }


        public ActionResult<ProductDto> GetProductById(int productid)
        {
            var product = _context.Products.Where(x => x.Id == productid)
                                    .Select(x => new ProductDto { Id = x.Id, Description = x.Description, Name = x.Name, Price = x.Price })
                                    .FirstOrDefault();



            return product;
        }
    }
}
