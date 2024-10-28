using _22521160_KiemTraThucHanh.Models;

namespace _22521160_KiemTraThucHanh.Repository
{
    public class CategoryRepository:ICategoryRepository
    {
        public readonly QlspContext _context;
        public CategoryRepository(QlspContext context)
        {
            _context = context;
        }

        public Category Add(Category loaiSp)
        {
            _context.Categories.Add(loaiSp);
            _context.SaveChanges();
            return loaiSp;
        }

        public Category Delete(string maLoaiSp)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Category> GetAllLoaiSp()
        {
            return _context.Categories;
        }

        public Category GetLoaiSp(string maLoaiSp)
        {
            return _context.Categories.Find(maLoaiSp);
        }

        public Category Update(Category loaiSp)
        {
            _context.Update(loaiSp);
            _context.SaveChanges();
            return loaiSp;
        }
    }
}
