namespace E_Commerce.Models
{
    public enum OrderStatus : byte
    {
        Pending = 0,
        Processing = 1,
        Shipped = 2,
        Delivered = 3,
        Cancelled = 4
    }
}
