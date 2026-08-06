namespace E_Commerce.DTOs.Product
{
    public class ProductDto
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public decimal? Price { get; set; }

        public int? Stock { get; set; }

        public int? CategoryId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool? Isdeleted { get; set; }
    }
}
