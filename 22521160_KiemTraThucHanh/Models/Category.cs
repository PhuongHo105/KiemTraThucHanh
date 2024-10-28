using System;
using System.Collections.Generic;

namespace _22521160_KiemTraThucHanh.Models;

public partial class Category
{
    public int IdType { get; set; }

    public string? NameType { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
