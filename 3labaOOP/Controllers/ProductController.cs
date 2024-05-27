﻿using _3labaOOP.DTOs.ProductDtos;
using _3labaOOP.Serves;
using Microsoft.AspNetCore.Mvc;

namespace _3labaOOP.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productServesecs;
        public ProductController(IProductService productServesecs)
        {
            _productServesecs = productServesecs;
        }

        [HttpPost("AddProduct")]
        public ActionResult<string> AddProduct(CreateProductDto productDto)
        {
            _productServesecs.AddProduct(productDto);
            return Ok("Добавлено в корзину");
        }

        [HttpGet("GetAllProduct")]
        public ActionResult<List<ProductDto>> GetAllProduct()
        {
            var product = _productServesecs.GetAllProduct();
            return Ok(product);
        }

        [HttpGet("GetById")]
        public ActionResult<ProductDto> GetProductById(int productid)
        {
            var product = _productServesecs.GetProductById(productid);
            return Ok(product);
        }

        [HttpPut("ChangeProduct")]
        public ActionResult<string> ChangeProduct(CreateProductDto productdto, int id)
        {
            _productServesecs.ChangeProduct(productdto, id);
            return Ok("Продукт изменен");
        }

        [HttpDelete("DeleteProduct")]
        public ActionResult<string> DeleteProduct(int id)
        {
            _productServesecs.DeleteProduct(id);
            return Ok("Продукт удален");

        }
    }
}
