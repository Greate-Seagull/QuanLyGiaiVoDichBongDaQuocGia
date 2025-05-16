using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Data;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    public class DAL_ThamSo
    {
        private readonly MySqlDbContext _mySqlContext;

        public DAL_ThamSo(MySqlDbContext context)
        {
            _mySqlContext = context;
        }

        public DTO_ThamSo? LayDanhSach(Expression<Func<DTO_ThamSo, DTO_ThamSo>>? selector = default)
        {
            var query = _mySqlContext.ThamSoRepository.AsQueryable();

            if (selector != null)
                query = query.Select(selector);

            return query.AsNoTracking().FirstOrDefault();
        }
    }
}
