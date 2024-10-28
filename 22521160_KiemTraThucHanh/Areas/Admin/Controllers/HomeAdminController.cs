using _22521160_KiemTraThucHanh.Models;
using Azure;
using _22521160_KiemTraThucHanh.Models.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace _22521160_KiemTraThucHanh.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin")]
    [Route("Admin/HomeAdmin")]
    public class HomeAdminController : Controller
    {
        QlspContext db = new QlspContext();
        [Route("")]
        [Route("Index")]
        [Authentication]
        public IActionResult Index()
        {
            return View();
        }
        [Route("QuanLySanPham")]
        [Authentication]
        public IActionResult QuanLySanPham(int? page)
        {
            int pageSize = 12;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var lstSanpham = db.Products.AsNoTracking().OrderBy(x => x.Name);
            PagedList<Product> lst = new PagedList<Product>(lstSanpham, pageNumber, pageSize);
            return View(lst);
        }
        [Route("ThemSanPhamMoi")]
        [HttpGet]
        [Authentication]
        public IActionResult ThemSanPhamMoi()
        {

            ViewBag.IdType = new SelectList(db.Categories.ToList(), "IdType", "NameType");
            return View();
        }
        [Route("ThemSanPhamMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public IActionResult ThemSanPhamMoi(Product sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("QuanLySanPham");
            }
            return View(sanPham);
        }
        [Route("SuaSanPham")]
        [HttpGet]
        [Authentication]
        public IActionResult SuaSanPham(string idPro)
        {

            ViewBag.IdType = new SelectList(db.Categories.ToList(), "IdType", "NameType");
            var sanPham = db.Products.Find(idPro);
            return View(sanPham);
        }
        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authentication]
        public IActionResult SuaSanPham(Product sanPham)
        {
            if (ModelState.IsValid)
            {
                db.Update(sanPham);
                db.SaveChanges();
                return RedirectToAction("QuanLySanPham", "HomeAdmin");
            }
            return View(sanPham);
        }
        [Route("XoaSanPham")]
        [HttpGet]
        [Authentication]
        public IActionResult XoaSanPham(string idPro)
        {
            TempData["Message"] = "";
            
            var anhSP = db.Imgs.Where(x => x.IdProduct == idPro).ToList();
            if (anhSP.Any())
            {
                db.RemoveRange(anhSP);
            }
            db.Remove(db.Products.Find(idPro));
            db.SaveChanges();
            TempData["Message"] = "Sản phẩm đã được xóa";
            return RedirectToAction("QuanLySanPham", "HomeAdmin");
        }
    }
   
    

}
