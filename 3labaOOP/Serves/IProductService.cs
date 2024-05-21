using _3labaOOP.DTOs.ProductDtos;
using Microsoft.AspNetCore.Mvc;

namespace _3labaOOP.Serves
{
    public interface IProductService
    {
        ActionResult<string> AddProduct(CreateProductDto productDto);
        ActionResult<List<ProductDto>> GetAllProduct();
        ActionResult<ProductDto> GetProductById(int productid);
        ActionResult<string> ChangeProduct(CreateProductDto productdto, int id);
        ActionResult<string> DeleteProduct(int id);
    }
}
