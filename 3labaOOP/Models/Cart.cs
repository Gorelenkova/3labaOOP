namespace _3labaOOP.Models
{
    public class Cart
    {

        public int Id { get; set; }


        public User User { get; set; }
        public int UserId { get; set; }

        public List<CartProduct> Products { get; set; }
    }
}
