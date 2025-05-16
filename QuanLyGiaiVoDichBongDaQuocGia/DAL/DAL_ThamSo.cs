using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Data;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    public class DAL_ThamSo: IThamSoRepository
    {
        private readonly MySqlDbContext _context;

        public DAL_ThamSo(MySqlDbContext context)
        {
            _context = context;
        }

        //Add methods
        public void Add(DTO_ThamSo entity) => _context.ThamSoRepository.Add(entity);
        public void AddRange(IEnumerable<DTO_ThamSo> entities) => _context.ThamSoRepository.AddRange(entities);

        //Get methods
        public DTO_ThamSo GetById(object id) => _context.ThamSoRepository.Find(id);
        public IEnumerable<DTO_ThamSo> GetAll() => _context.ThamSoRepository.ToList();
        public IEnumerable<DTO_ThamSo> Find(Expression<Func<DTO_ThamSo, DTO_ThamSo>> selector, Expression<Func<DTO_ThamSo, bool>> filter)
            => _context.ThamSoRepository.Where(filter).Select(selector);

        //Update methods
        public void Update(DTO_ThamSo entity) => _context.ThamSoRepository.Update(entity);

        //Delete methods
        public void Remove(DTO_ThamSo entity) => _context.ThamSoRepository.Remove(entity);
        public void RemoveRange(IEnumerable<DTO_ThamSo> entities) => _context.ThamSoRepository.RemoveRange(entities);

        //Save changes
        public void SaveChanges() => _context.SaveChanges();
    }
}
