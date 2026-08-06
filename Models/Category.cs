using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace E_Commerce.Models;

public partial class Category
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool? IsDeleted { get; set; }
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
