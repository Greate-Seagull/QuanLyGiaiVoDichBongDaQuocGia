using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Data;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    public class DAL_LoaiCauThu: IRepository<DTO_LoaiCauThu>, IUsingDbContext
    {
        private readonly MySqlDbContext _context;

        public DAL_LoaiCauThu(MySqlDbContext context)
        {
            _context = context;
        }

        public DbContext Context => _context;

        //Add methods
        public void Add(DTO_LoaiCauThu entity) => _context.LoaiCauThuRepository.Add(entity);
        public void AddRange(IEnumerable<DTO_LoaiCauThu> entities) => _context.LoaiCauThuRepository.AddRange(entities);

        //Get methods
        public IQueryable<DTO_LoaiCauThu> GetAll() => _context.LoaiCauThuRepository.AsQueryable();

        //Update methods
        public void Update(DTO_LoaiCauThu entity) => _context.LoaiCauThuRepository.Update(entity);

        //Delete methods
        public void Remove(DTO_LoaiCauThu entity) => _context.LoaiCauThuRepository.Remove(entity);
        public void RemoveRange(IEnumerable<DTO_LoaiCauThu> entities) => _context.LoaiCauThuRepository.RemoveRange(entities);

        //Save changes
        public void SaveChanges() => _context.SaveChanges();     
    }
}
