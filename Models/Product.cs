using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace E_Commerce.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public int? Stock { get; set; }

    public int? CategoryId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public bool? Isdeleted { get; set; }

    
    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    
    public virtual Category? Category { get; set; }

    
    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
