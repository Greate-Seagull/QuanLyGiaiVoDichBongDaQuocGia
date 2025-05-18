using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    public class DAL_DoiBong: IRepository<DTO_DoiBong>, IUsingDbContext
    {
        private readonly MySqlDbContext _context;

        public DAL_DoiBong(MySqlDbContext context)
        {
            _context = context;
        }

        public DbContext Context => _context;

        //Add methods
        public void Add(DTO_DoiBong entity) => _context.DoiBongRepository.Add(entity);
        public void AddRange(IEnumerable<DTO_DoiBong> entities) => _context.DoiBongRepository.AddRange(entities);

        //Get methods
        public IQueryable<DTO_DoiBong> GetAll() => _context.DoiBongRepository.AsQueryable();

        //Update methods
        public void Update(DTO_DoiBong entity) => _context.DoiBongRepository.Update(entity);

        //Delete methods
        public void Remove(DTO_DoiBong entity) => _context.DoiBongRepository.Remove(entity);
        public void RemoveRange(IEnumerable<DTO_DoiBong> entities) => _context.DoiBongRepository.RemoveRange(entities);

        //Save changes
        public void SaveChanges() => _context.SaveChanges();

        public bool ExistsLocally(DTO_DoiBong doiBongTiepNhan)
        {
            return _context.ChangeTracker.Entries<DTO_DoiBong>()
                           .Any(e => e.Entity.MaDoiBong == doiBongTiepNhan.MaDoiBong &&
                                     e.State != EntityState.Deleted);
        }
    }
}
