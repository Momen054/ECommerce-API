namespace E_Commerce.DTOs.Review
{
    public class ReviewDto
    {
        public int? UserId { get; set; }

        public int? ProductId { get; set; }

        public byte? Rating { get; set; }

        public string? Comment { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
