using System;
using System.Collections.Generic;

namespace _22521160_KiemTraThucHanh.Models;

public partial class Product
{
    public string IdProduct { get; set; } = null!;

    public string? Name { get; set; }

    public int? IdType { get; set; }

    public double? Weight { get; set; }

    public decimal? Price { get; set; }

    public string? Description { get; set; }

    public string? MImage { get; set; }

    public virtual Category? IdTypeNavigation { get; set; }
}
