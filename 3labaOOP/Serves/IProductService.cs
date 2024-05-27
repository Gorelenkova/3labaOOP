using _3labaOOP.DTOs.ProductDtos;

namespace _3labaOOP.Serves
{
    public interface IProductService
    {
        string AddProduct(CreateProductDto productDto);
        List<ProductDto> GetAllProduct();
        ProductDto GetProductById(int productid);
        string ChangeProduct(CreateProductDto productdto, int id);
        string DeleteProduct(int id);
    }
}
