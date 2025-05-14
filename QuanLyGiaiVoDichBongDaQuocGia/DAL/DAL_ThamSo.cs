using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Data;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    class DAL_ThamSo
    {
        private readonly DBC_ThamSo _context;

        public DAL_ThamSo(DBC_ThamSo context)
        {
            _context = context;
        }

        public List<DTO_ThamSo> LayDanhSach(Expression<Func<DTO_ThamSo, DTO_ThamSo>> selector = default, Expression<Func<DTO_ThamSo, bool>> filter = default)
        {
            var query = _context.LocalRepository.AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            if (selector != null)
                query = query.Select(selector);

            return query.AsNoTracking().ToList();
        }

        public void LuuDanhSach(List<DTO_ThamSo> insertList)
        {
            foreach (var entity in insertList)
            {
                _context.LocalRepository.Add(entity);
            }

            _context.SaveChanges();
        }
    }
}
