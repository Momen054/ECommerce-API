namespace E_Commerce.DTOs.Order
{
    public class GetOrderDto
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public DateTime? OrderDate { get; set; }

        public decimal? TotalPrice { get; set; }

        public byte? Status { get; set; }

        public string? ShippingAddress { get; set; }
    }
}
