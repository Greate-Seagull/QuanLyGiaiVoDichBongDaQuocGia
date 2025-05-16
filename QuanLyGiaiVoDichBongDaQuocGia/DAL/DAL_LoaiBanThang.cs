using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Data;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    class DAL_LoaiBanThang: ILoaiBanThangRepository
    {
        private readonly MySqlDbContext _context;

        public DAL_LoaiBanThang(MySqlDbContext context)
        {
            _context = context;
        }

        public string GetLastID()
        {
            var query = _context.LoaiBanThangRepository
                                .IgnoreQueryFilters()
                                .AsNoTracking()
                                .OrderByDescending(obj => obj.MaLoaiBanThang);

            var result = query.FirstOrDefault();

            if (result != null)
                return result.MaLoaiBanThang;
            else
                return "LBT00";
        }

        //Add methods
        public void Add(DTO_LoaiBanThang entity) => _context.LoaiBanThangRepository.Add(entity);
        public void AddRange(IEnumerable<DTO_LoaiBanThang> entities) => _context.LoaiBanThangRepository.AddRange(entities);

        //Get methods
        public DTO_LoaiBanThang GetById(object id) => _context.LoaiBanThangRepository.Find(id);
        public IEnumerable<DTO_LoaiBanThang> GetAll() => _context.LoaiBanThangRepository.ToList();
        public IEnumerable<DTO_LoaiBanThang> Find(Expression<Func<DTO_LoaiBanThang, DTO_LoaiBanThang>> selector, Expression<Func<DTO_LoaiBanThang, bool>> filter)
            => _context.LoaiBanThangRepository.Where(filter).Select(selector);

        //Update methods
        public void Update(DTO_LoaiBanThang entity) => _context.LoaiBanThangRepository.Update(entity);

        //Delete methods
        public void Remove(DTO_LoaiBanThang entity) => _context.LoaiBanThangRepository.Remove(entity);
        public void RemoveRange(IEnumerable<DTO_LoaiBanThang> entities) => _context.LoaiBanThangRepository.RemoveRange(entities);

        //Save changes
        public void SaveChanges() => _context.SaveChanges();
    }
}
