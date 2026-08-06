using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace E_Commerce.Models;

public partial class Role
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public List<UserRoles> userRoles { get; set; } = [];

}