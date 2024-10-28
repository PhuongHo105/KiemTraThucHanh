using _22521160_KiemTraThucHanh.Models;

namespace _22521160_KiemTraThucHanh.Repository
{
    public interface ICategoryRepository
    {
        Category Add(Category loaiSp);
        Category Update(Category loaiSp);
        Category Delete(string maLoaiSp);
        Category GetLoaiSp(string maLoaiSp);
        IEnumerable<Category> GetAllLoaiSp();
    }
}
