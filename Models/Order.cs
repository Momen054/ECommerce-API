using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace E_Commerce.Models;

public partial class Order
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public DateTime? OrderDate { get; set; }

    public decimal? TotalPrice { get; set; }

    public byte? Status { get; set; }

    public string? ShippingAddress { get; set; }

    
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    
    public virtual User? User { get; set; }
}
