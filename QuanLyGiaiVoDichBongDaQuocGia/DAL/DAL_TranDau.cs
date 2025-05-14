using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Data;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    class DAL_TranDau
    {
        private readonly DBC_TranDau _context;

        public DAL_TranDau(DBC_TranDau context)
        {
            _context = context;
        }

        public DTO_TranDau? LayMaMoiNhat()
        {
            var query = _context.LocalRepository
                                .AsNoTracking()
                                .OrderByDescending(obj => obj.MaTranDau);

            return query.FirstOrDefault();
        }

        public List<DTO_TranDau> LayDanhSach(Expression<Func<DTO_TranDau, DTO_TranDau>> selector = default, Expression<Func<DTO_TranDau, bool>> filter = default)
        {
            var query = _context.LocalRepository.AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            if (selector != null)
                query = query.Select(selector);

            return query.AsNoTracking().ToList();
        }

        public void LuuDanhSach(List<DTO_TranDau> insertList)
        {
            foreach (var entity in insertList)
            {
                _context.LocalRepository.Add(entity);
            }

            _context.SaveChanges();
        }
    }
}
