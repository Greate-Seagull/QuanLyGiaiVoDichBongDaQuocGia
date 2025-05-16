using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Data;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    class DAL_VongDau
    {
        private readonly MySqlDbContext _context;
        public DAL_VongDau(MySqlDbContext context)
        {
            _context = context;
        }

        public string GetLastID()
        {
            var query = _context.VongDauRepository
                                .IgnoreQueryFilters()
                                .AsNoTracking()
                                .OrderByDescending(obj => obj.MaVongDau);

            var result = query.FirstOrDefault();

            if (result != null)
                return result.MaVongDau;
            else
                return "VD000";
        }

        //Add methods
        public void Add(DTO_VongDau entity) => _context.VongDauRepository.Add(entity);
        public void AddRange(IEnumerable<DTO_VongDau> entities) => _context.VongDauRepository.AddRange(entities);

        //Get methods
        public DTO_VongDau GetById(object id) => _context.VongDauRepository.Find(id);
        public IEnumerable<DTO_VongDau> GetAll() => _context.VongDauRepository.ToList();
        public IEnumerable<DTO_VongDau> Find(Expression<Func<DTO_VongDau, DTO_VongDau>> selector, Expression<Func<DTO_VongDau, bool>> filter)
            => _context.VongDauRepository.Where(filter).Select(selector);

        //Update methods
        public void Update(DTO_VongDau entity) => _context.VongDauRepository.Update(entity);

        //Delete methods
        public void Remove(DTO_VongDau entity) => _context.VongDauRepository.Remove(entity);
        public void RemoveRange(IEnumerable<DTO_VongDau> entities) => _context.VongDauRepository.RemoveRange(entities);

        //Save changes
        public void SaveChanges() => _context.SaveChanges();
    }
}
