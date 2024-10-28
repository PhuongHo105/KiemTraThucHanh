namespace _22521160_KiemTraThucHanh.Models.ProductModels
{
    public class MProduct
    {
        public string IdProduct { get; set; } = null!;

        public string? Name { get; set; }

        public int? IdType { get; set; }

        public double? Weight { get; set; }

        public decimal? Price { get; set; }

        public string? Description { get; set; }

        public string? MImage { get; set; }

    }
}
