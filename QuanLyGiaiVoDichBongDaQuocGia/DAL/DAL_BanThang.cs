using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    public class DAL_BanThang: IRepository<DTO_BanThang>, IUsingDbContext
    {
        private readonly MySqlDbContext _context;

        public DAL_BanThang(MySqlDbContext context)
        {
            _context = context;
        }

        public DbContext Context => _context;

        //Add methods
        public void Add(DTO_BanThang entity) => _context.BanThangRepository.Add(entity);
        public void AddRange(IEnumerable<DTO_BanThang> entities) => _context.BanThangRepository.AddRange(entities);

        //Get methods
        public IQueryable<DTO_BanThang> GetAll() => _context.BanThangRepository.AsQueryable();

        //Update methods
        public void Update(DTO_BanThang entity) => _context.BanThangRepository.Update(entity);

        //Delete methods
        public void Remove(DTO_BanThang entity) => _context.BanThangRepository.Remove(entity);
        public void RemoveRange(IEnumerable<DTO_BanThang> entities) => _context.BanThangRepository.RemoveRange(entities);

        //Save changes
        public void SaveChanges() => _context.SaveChanges();
    }
}
