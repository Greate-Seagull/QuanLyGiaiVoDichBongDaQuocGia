using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    public class DAL_CauThu: IRepository<DTO_CauThu>, IUsingDbContext
    {
        private readonly MySqlDbContext _context;

        public DAL_CauThu(MySqlDbContext context)
        {
            _context = context;
        }

        public DbContext Context => _context;

        //Add methods
        public void Add(DTO_CauThu entity) => _context.CauThuRepository.Add(entity);
        public void AddRange(IEnumerable<DTO_CauThu> entities) => _context.CauThuRepository.AddRange(entities);

        //Get methods
        public IQueryable<DTO_CauThu> GetAll() => _context.CauThuRepository.AsQueryable();

        //Update methods
        public void Update(DTO_CauThu entity) => _context.CauThuRepository.Update(entity);

        //Delete methods
        public void Remove(DTO_CauThu entity) => _context.CauThuRepository.Remove(entity);
        public void RemoveRange(IEnumerable<DTO_CauThu> entities) => _context.CauThuRepository.RemoveRange(entities);

        //Save changes
        public void SaveChanges() => _context.SaveChanges();
    }
}
