﻿namespace _3labaOOP.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Price { get; set; }

        public string Description { get; set; }
        public List<CartProduct> Carts { get; set; }
    }
}
