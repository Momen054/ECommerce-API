namespace E_Commerce.DTOs.Cart
{
    public class GetCartDto
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
