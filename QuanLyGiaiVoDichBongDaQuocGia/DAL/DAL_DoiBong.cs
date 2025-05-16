using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Data;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    public class DAL_DoiBong: IDoiBongRepository
    {
        private readonly MySqlDbContext _context;

        public DAL_DoiBong(MySqlDbContext context)
        {
            _context = context;
        }

        public string GetLastID()
        {
            var query = _context.DoiBongRepository
                                .IgnoreQueryFilters()
                                .AsNoTracking()
                                .OrderByDescending(obj => obj.MaDoiBong);

            var result = query.FirstOrDefault();

            if (result != null)
                return result.MaDoiBong;
            else
                return "DB000";
        }

        //Add methods
        public void Add(DTO_DoiBong entity) => _context.DoiBongRepository.Add(entity);
        public void AddRange(IEnumerable<DTO_DoiBong> entities) => _context.DoiBongRepository.AddRange(entities);

        //Get methods
        public DTO_DoiBong GetById(object id) => _context.DoiBongRepository.Find(id);
        public IEnumerable<DTO_DoiBong> GetAll() => _context.DoiBongRepository.ToList();
        public IEnumerable<DTO_DoiBong> Find(Expression<Func<DTO_DoiBong, DTO_DoiBong>> selector, Expression<Func<DTO_DoiBong, bool>> filter)
            => _context.DoiBongRepository.Where(filter).Select(selector);

        //Update methods
        public void Update(DTO_DoiBong entity) => _context.DoiBongRepository.Update(entity);

        //Delete methods
        public void Remove(DTO_DoiBong entity) => _context.DoiBongRepository.Remove(entity);
        public void RemoveRange(IEnumerable<DTO_DoiBong> entities) => _context.DoiBongRepository.RemoveRange(entities);

        //Save changes
        public void SaveChanges() => _context.SaveChanges();
    }
}
