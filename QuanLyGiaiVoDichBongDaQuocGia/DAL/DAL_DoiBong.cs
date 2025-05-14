using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Data;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    class DAL_DoiBong
    {
        private readonly DBC_DoiBong _context;

        public DAL_DoiBong(DBC_DoiBong context)
        {
            _context = context;
        }

        public DTO_DoiBong? LayMaMoiNhat()
        {
            var query = _context.LocalRepository
                                .AsNoTracking()
                                .OrderByDescending(obj => obj.MaDoiBong);

            return query.FirstOrDefault();
        }

        internal List<DTO_DoiBong> LayDanhSach(Expression<Func<DTO_DoiBong, DTO_DoiBong>>? selector = default, Expression<Func<DTO_DoiBong, bool>>? filter = default, bool isTracking = false)
        {
            var query = _context.LocalRepository
                                .AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            if (selector != null)
                query = query.Select(selector);

            if (isTracking == false)
                query = query.AsNoTracking();

            return query.ToList();
        }

        internal void LuuDanhSach(List<DTO_DoiBong> insertList)
        {
            foreach(var entity in insertList)
            {
                _context.LocalRepository.Add(entity);
            }

            _context.SaveChanges();
        }
    }
}
