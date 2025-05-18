using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using Microsoft.EntityFrameworkCore;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    public class DAL_ThamSo: IRepository<DTO_ThamSo>, IUsingDbContext
    {
        private readonly MySqlDbContext _context;

        public DAL_ThamSo(MySqlDbContext context)
        {
            _context = context;
        }

        public DbContext Context => _context;

        //Add methods
        public void Add(DTO_ThamSo entity) => _context.ThamSoRepository.Add(entity);
        public void AddRange(IEnumerable<DTO_ThamSo> entities) => _context.ThamSoRepository.AddRange(entities);

        //Get methods
        public IQueryable<DTO_ThamSo> GetAll() => _context.ThamSoRepository.AsQueryable();

        //Update methods
        public void Update(DTO_ThamSo entity) => _context.ThamSoRepository.Update(entity);

        //Delete methods
        public void Remove(DTO_ThamSo entity) => _context.ThamSoRepository.Remove(entity);
        public void RemoveRange(IEnumerable<DTO_ThamSo> entities) => _context.ThamSoRepository.RemoveRange(entities);

        //Save changes
        public void SaveChanges() => _context.SaveChanges();
    }
}
