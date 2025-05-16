using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Data;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    public class DAL_CauThu: ICauThuRepository
    {
        private readonly MySqlDbContext _context;

        public DAL_CauThu(MySqlDbContext context)
        {
            _context = context;
        }

        public string GetLastID()
        {
            var query = _context.CauThuRepository
                                .IgnoreQueryFilters()
                                .AsNoTracking()
                                .OrderByDescending(obj => obj.MaCauThu);

            var result = query.FirstOrDefault();

            if (result != null)
                return result.MaCauThu;
            else
                return "CT000";
        }

        //Add methods
        public void Add(DTO_CauThu entity) => _context.CauThuRepository.Add(entity);
        public void AddRange(IEnumerable<DTO_CauThu> entities) => _context.CauThuRepository.AddRange(entities);

        //Get methods
        public DTO_CauThu GetById(object id) => _context.CauThuRepository.Find(id);
        public IEnumerable<DTO_CauThu> GetAll() => _context.CauThuRepository.ToList();
        public IEnumerable<DTO_CauThu> Find(Expression<Func<DTO_CauThu, DTO_CauThu>> selector, Expression<Func<DTO_CauThu, bool>> filter)
            => _context.CauThuRepository.Where(filter).Select(selector);

        //Update methods
        public void Update(DTO_CauThu entity) => _context.CauThuRepository.Update(entity);

        //Delete methods
        public void Remove(DTO_CauThu entity) => _context.CauThuRepository.Remove(entity);
        public void RemoveRange(IEnumerable<DTO_CauThu> entities) => _context.CauThuRepository.RemoveRange(entities);

        //Save changes
        public void SaveChanges() => _context.SaveChanges();
    }
}
