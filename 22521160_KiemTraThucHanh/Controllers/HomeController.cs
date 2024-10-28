using _22521160_KiemTraThucHanh.Models;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using X.PagedList;

namespace _22521160_KiemTraThucHanh.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        QlspContext db = new QlspContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNumber = page==null||page<0?1:page.Value;
            var lstSanPham = db.Products.AsNoTracking().OrderBy(x => x.Name);
            PagedList<Product> lst = new PagedList<Product>(lstSanPham, pageNumber, pageSize);

            return View(lst);
        }
        public IActionResult ProductByCategory(int idCate, int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstSanpham = db.Products.AsNoTracking().Where(x => x.IdType == idCate).
                OrderBy(x => x.Name).OrderBy(x => x.Name);
            PagedList<Product> lst = new PagedList<Product>(lstSanpham, pageNumber, pageSize);
            ViewBag.category = idCate;
            return View(lst);
        }

        public IActionResult ProductDetail(string idPro)
        {
            var product = db.Products.SingleOrDefault(x => x.IdProduct == idPro);
            var img = db.Imgs.Where(x => x.IdProduct == idPro).ToList();
            ViewBag.img = img;
            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
