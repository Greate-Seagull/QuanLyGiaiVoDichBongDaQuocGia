using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Data;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    public class DAL_LoaiCauThu: ILoaiCauThuRepository
    {
        private readonly MySqlDbContext _context;

        public DAL_LoaiCauThu(MySqlDbContext context)
        {
            _context = context;
        }
        public string GetLastID()
        {
            var query = _context.LoaiCauThuRepository
                                .IgnoreQueryFilters()
                                .AsNoTracking()
                                .OrderByDescending(obj => obj.MaLoaiCauThu);

            var result = query.FirstOrDefault();

            if (result != null)
                return result.MaLoaiCauThu;
            else
                return "LCT00";
        }

        //Add methods
        public void Add(DTO_LoaiCauThu entity) => _context.LoaiCauThuRepository.Add(entity);
        public void AddRange(IEnumerable<DTO_LoaiCauThu> entities) => _context.LoaiCauThuRepository.AddRange(entities);

        //Get methods
        public DTO_LoaiCauThu GetById(object id) => _context.LoaiCauThuRepository.Find(id);
        public IEnumerable<DTO_LoaiCauThu> GetAll() => _context.LoaiCauThuRepository.ToList();
        public IEnumerable<DTO_LoaiCauThu> Find(Expression<Func<DTO_LoaiCauThu, DTO_LoaiCauThu>> selector, Expression<Func<DTO_LoaiCauThu, bool>> filter)
            => _context.LoaiCauThuRepository.Where(filter).Select(selector);

        //Update methods
        public void Update(DTO_LoaiCauThu entity) => _context.LoaiCauThuRepository.Update(entity);

        //Delete methods
        public void Remove(DTO_LoaiCauThu entity) => _context.LoaiCauThuRepository.Remove(entity);
        public void RemoveRange(IEnumerable<DTO_LoaiCauThu> entities) => _context.LoaiCauThuRepository.RemoveRange(entities);

        //Save changes
        public void SaveChanges() => _context.SaveChanges();
    }
}
