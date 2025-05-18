using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    public class DAL_TranDau: IRepository<DTO_TranDau>, IUsingDbContext
    {
        private readonly MySqlDbContext _context;

        public DAL_TranDau(MySqlDbContext context)
        {
            _context = context;
        }

        public DbContext Context => _context;

        //Add methods
        public void Add(DTO_TranDau entity) => _context.TranDauRepository.Add(entity);
        public void AddRange(IEnumerable<DTO_TranDau> entities) => _context.TranDauRepository.AddRange(entities);

        //Get methods
        public IQueryable<DTO_TranDau> GetAll() => _context.TranDauRepository.AsQueryable();

        //Update methods
        public void Update(DTO_TranDau entity) => _context.TranDauRepository.Update(entity);

        //Delete methods
        public void Remove(DTO_TranDau entity) => _context.TranDauRepository.Remove(entity);
        public void RemoveRange(IEnumerable<DTO_TranDau> entities) => _context.TranDauRepository.RemoveRange(entities);

        //Save changes
        public void SaveChanges() => _context.SaveChanges();
    }
}
