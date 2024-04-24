using Microsoft.AspNetCore.Mvc;

namespace _3labaOOP.dto.CartDtos
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartProduct : ControllerBase
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

    }
}
