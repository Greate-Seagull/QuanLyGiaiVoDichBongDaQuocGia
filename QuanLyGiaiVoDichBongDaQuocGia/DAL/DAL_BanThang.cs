using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Data;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    public class DAL_BanThang: IBanThangRepository
    {
        private readonly MySqlDbContext _context;

        public DAL_BanThang(MySqlDbContext context)
        {
            _context = context;
        }

        public string GetLastID()
        {
            var query = _context.BanThangRepository
                                .IgnoreQueryFilters()
                                .AsNoTracking()
                                .OrderByDescending(obj => obj.MaBanThang);

            var result = query.FirstOrDefault();

            if (result != null)
                return result.MaBanThang;
            else
                return "BT000";
        }

        //Add methods
        public void Add(DTO_BanThang entity) => _context.BanThangRepository.Add(entity);
        public void AddRange(IEnumerable<DTO_BanThang> entities) => _context.BanThangRepository.AddRange(entities);

        //Get methods
        public DTO_BanThang GetById(object id) => _context.BanThangRepository.Find(id);
        public IEnumerable<DTO_BanThang> GetAll() => _context.BanThangRepository.ToList();
        public IEnumerable<DTO_BanThang> Find(Expression<Func<DTO_BanThang, DTO_BanThang>> selector, Expression<Func<DTO_BanThang, bool>> filter)
            => _context.BanThangRepository.Where(filter).Select(selector);

        //Update methods
        public void Update(DTO_BanThang entity) => _context.BanThangRepository.Update(entity);

        //Delete methods
        public void Remove(DTO_BanThang entity) => _context.BanThangRepository.Remove(entity);
        public void RemoveRange(IEnumerable<DTO_BanThang> entities) => _context.BanThangRepository.RemoveRange(entities);

        //Save changes
        public void SaveChanges() => _context.SaveChanges();
    }
}
