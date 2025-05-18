using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Data;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    public class DAL_LoaiBanThang: IRepository<DTO_LoaiBanThang>, IUsingDbContext
    {
        private readonly MySqlDbContext _context;

        public DAL_LoaiBanThang(MySqlDbContext context)
        {
            _context = context;
        }

        public DbContext Context => _context;

        //Add methods
        public void Add(DTO_LoaiBanThang entity) => _context.LoaiBanThangRepository.Add(entity);
        public void AddRange(IEnumerable<DTO_LoaiBanThang> entities) => _context.LoaiBanThangRepository.AddRange(entities);

        //Get methods
        public IQueryable<DTO_LoaiBanThang> GetAll() => _context.LoaiBanThangRepository.AsQueryable();

        //Update methods
        public void Update(DTO_LoaiBanThang entity) => _context.LoaiBanThangRepository.Update(entity);

        //Delete methods
        public void Remove(DTO_LoaiBanThang entity) => _context.LoaiBanThangRepository.Remove(entity);
        public void RemoveRange(IEnumerable<DTO_LoaiBanThang> entities) => _context.LoaiBanThangRepository.RemoveRange(entities);

        //Save changes
        public void SaveChanges() => _context.SaveChanges();
    }
}
