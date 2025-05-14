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

        public DTO_ThamSo? LayDanhSach(Expression<Func<DTO_ThamSo, DTO_ThamSo>>? selector = default)
        {
            var query = _context.LocalRepository.AsQueryable();

            if (selector != null)
                query = query.Select(selector);

            return query.AsNoTracking().FirstOrDefault();
        }
    }
}
