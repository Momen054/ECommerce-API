using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace E_Commerce.Models;

public partial class Review
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? ProductId { get; set; }

    public byte? Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime? CreatedAt { get; set; }

    
    public virtual Product? Product { get; set; }

    
    public virtual User? User { get; set; }
}
