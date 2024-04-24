using Microsoft.AspNetCore.Mvc;

namespace _3labaOOP.dto.CartDtos
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartProductDto : ControllerBase
    {
        public string Name { get; set; }
        public int Price { get; set; }

        public string Description { get; set; }

    }
}
