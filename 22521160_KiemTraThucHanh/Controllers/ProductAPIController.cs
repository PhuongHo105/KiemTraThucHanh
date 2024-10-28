using _22521160_KiemTraThucHanh.Models;
using Microsoft.AspNetCore.Mvc;

namespace _22521160_KiemTraThucHanh.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {

        QlspContext db = new QlspContext();
        [HttpGet]
        public IEnumerable<Product> GetAllProduct()
        {
            var sanPham = (from p in db.Products
                           select new Product
                           {
                               IdProduct = p.IdProduct,
                               Name = p.Name,
                               IdType = p.IdType,
                               MImage = p.MImage,
                               Price = p.Price,
                               Weight = p.Weight,
                               Description = p.Description
                           }).ToList();
            return sanPham;
        }
        [HttpGet("{MaLoai}")]
        public IEnumerable<Product> GetAllProductByCategory(int MaLoai)
        {
            var sanPham = (from p in db.Products
                           where p.IdType == MaLoai
                           select new Product
                           {
                               IdProduct = p.IdProduct,
                               Name = p.Name,
                               IdType = p.IdType,
                               MImage = p.MImage,
                               Price = p.Price,
                               Weight = p.Weight,
                               Description = p.Description
                           }).ToList();
            return sanPham;
        }
    }
}
