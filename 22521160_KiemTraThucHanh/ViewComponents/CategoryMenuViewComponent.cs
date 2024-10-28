using _22521160_KiemTraThucHanh.Models;
using _22521160_KiemTraThucHanh.Repository;
using Microsoft.AspNetCore.Mvc;
namespace _22521160_KiemTraThucHanh.ViewComponents
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly ICategoryRepository _loaiSp;
        public CategoryMenuViewComponent(ICategoryRepository loaiSpRepository)
        {
            _loaiSp = loaiSpRepository;
        }
        public IViewComponentResult Invoke()
        {
            var loaiSp = _loaiSp.GetAllLoaiSp().OrderBy(x => x.IdType);
            return View(loaiSp);
        }
    }
}
