using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Data;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    class DAL_CauThu
    {
        private readonly DBC_CauThu _context;

        public DAL_CauThu(DBC_CauThu context)
        {
            _context = context;
        }

        public DTO_CauThu? LayMaMoiNhat()
        {
            var query = _context.LocalRepository
                                .AsNoTracking()
                                .OrderByDescending(obj => obj.MaCauThu);

            return query.FirstOrDefault();
        }

        public void LuuDanhSach(List<DTO_CauThu> insertList)
        {
            foreach(var entity in insertList)
            {
                _context.LocalRepository.Add(entity);
            }

            _context.SaveChanges();
        }

        internal List<DTO_CauThu> LayDanhSach(Expression<Func<DTO_CauThu, DTO_CauThu>> selector = default, Expression<Func<DTO_CauThu, bool>> filter = default)
        {
            var query = _context.LocalRepository
                                .AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            if (selector != null)
                query = query.Select(selector);

            return query.AsNoTracking().ToList();
        }
    }
}
