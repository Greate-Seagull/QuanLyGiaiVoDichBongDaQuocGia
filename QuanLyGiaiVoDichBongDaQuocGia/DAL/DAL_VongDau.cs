using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Data;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    class DAL_VongDau
    {
        private readonly DBC_VongDau _context;
        public DAL_VongDau(DBC_VongDau context)
        {
            _context = context;
        }

        public DTO_VongDau? LayMaMoiNhat()
        {
            var query = _context.LocalRepository
                                .AsNoTracking()
                                .OrderByDescending(obj => obj.MaVongDau);

            return query.FirstOrDefault();
        }

        public List<DTO_VongDau> LayDanhSach(Expression<Func<DTO_VongDau, DTO_VongDau>>? selector = default, Expression<Func<DTO_VongDau, bool>>? filter = default, bool isTracking = false)
        {
            var query = _context.LocalRepository.AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            if (selector != null)
                query = query.Select(selector);

            if (isTracking == false)
                query = query.AsNoTracking();

            return query.ToList();
        }

        public void LuuDanhSach(List<DTO_VongDau> insertList)
        {
            foreach (var entity in insertList)
            {
                _context.LocalRepository.Add(entity);
            }

            _context.SaveChanges();
        }
    }
}
