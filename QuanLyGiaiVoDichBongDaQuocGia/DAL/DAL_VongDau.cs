using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Data;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    public class DAL_VongDau: IRepository<DTO_VongDau>, IUsingDbContext
    {
        private readonly MySqlDbContext _context;
        public DAL_VongDau(MySqlDbContext context)
        {
            _context = context;
        }

        public DbContext Context => _context;

        //Add methods
        public void Add(DTO_VongDau entity) => _context.VongDauRepository.Add(entity);
        public void AddRange(IEnumerable<DTO_VongDau> entities) => _context.VongDauRepository.AddRange(entities);

        //Get methods
        public IQueryable<DTO_VongDau> GetAll() => _context.VongDauRepository.AsQueryable();

        //Update methods
        public void Update(DTO_VongDau entity) => _context.VongDauRepository.Update(entity);

        //Delete methods
        public void Remove(DTO_VongDau entity) => _context.VongDauRepository.Remove(entity);
        public void RemoveRange(IEnumerable<DTO_VongDau> entities) => _context.VongDauRepository.RemoveRange(entities);

        //Save changes
        public void SaveChanges() => _context.SaveChanges();

        internal bool ExistsLocally(DTO_VongDau vongDau)
        {
            return _context.ChangeTracker.Entries<DTO_VongDau>()
                           .Any(e => e.Entity.MaVongDau == vongDau.MaVongDau &&
                                     e.State != EntityState.Deleted);
        }
    }
}
