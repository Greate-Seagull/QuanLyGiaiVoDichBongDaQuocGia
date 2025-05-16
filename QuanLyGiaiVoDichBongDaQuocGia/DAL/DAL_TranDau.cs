using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Data;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    class DAL_TranDau: ITranDauRepository
    {
        private readonly MySqlDbContext _context;

        public DAL_TranDau(MySqlDbContext context)
        {
            _context = context;
        }

        public string GetLastID()
        {
            var query = _context.TranDauRepository
                                .IgnoreQueryFilters()
                                .AsNoTracking()
                                .OrderByDescending(obj => obj.MaTranDau);

            var result = query.FirstOrDefault();

            if (result != null)
                return result.MaTranDau;
            else
                return "TD000";
        }

        //Add methods
        public void Add(DTO_TranDau entity) => _context.TranDauRepository.Add(entity);
        public void AddRange(IEnumerable<DTO_TranDau> entities) => _context.TranDauRepository.AddRange(entities);

        //Get methods
        public DTO_TranDau GetById(object id) => _context.TranDauRepository.Find(id);
        public IEnumerable<DTO_TranDau> GetAll() => _context.TranDauRepository.ToList();
        public IEnumerable<DTO_TranDau> Find(Expression<Func<DTO_TranDau, DTO_TranDau>> selector, Expression<Func<DTO_TranDau, bool>> filter)
            => _context.TranDauRepository.Where(filter).Select(selector);

        //Update methods
        public void Update(DTO_TranDau entity) => _context.TranDauRepository.Update(entity);

        //Delete methods
        public void Remove(DTO_TranDau entity) => _context.TranDauRepository.Remove(entity);
        public void RemoveRange(IEnumerable<DTO_TranDau> entities) => _context.TranDauRepository.RemoveRange(entities);

        //Save changes
        public void SaveChanges() => _context.SaveChanges();
    }
}
