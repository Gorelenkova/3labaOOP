﻿namespace _3labaOOP.Models
{
    public class CartProduct
    {
        public int Id { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }

        public Cart Cart { get; set; }
        public int CartId { get; set; }
    }
}
