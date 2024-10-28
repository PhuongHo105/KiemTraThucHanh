using System;
using System.Collections.Generic;

namespace _22521160_KiemTraThucHanh.Models;

public partial class Img
{
    public string IdProduct { get; set; } = null!;

    public string Filename { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
