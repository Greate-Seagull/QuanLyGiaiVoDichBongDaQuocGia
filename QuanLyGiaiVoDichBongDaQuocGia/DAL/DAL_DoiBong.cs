using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Data;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    public class DAL_DoiBong
    {
        private readonly MySqlDbContext _mySqlContext;

        public DAL_DoiBong(MySqlDbContext context)
        {
            _mySqlContext = context;
        }

        public DTO_DoiBong LayMaMoiNhat()
        {
            var query = _mySqlContext.DoiBongRepository
                                .Where(obj => obj.Deleted == false)
                                .AsNoTracking()
                                .OrderByDescending(obj => obj.MaDoiBong);

            var result = query.FirstOrDefault();
            result ??= new DTO_DoiBong { MaDoiBong = "DB000" };
            return result;
        }

        internal List<DTO_DoiBong> LayDanhSach(Expression<Func<DTO_DoiBong, DTO_DoiBong>>? selector = default, Expression<Func<DTO_DoiBong, bool>>? filter = default, bool isTracking = false)
        {
            var query = _mySqlContext.DoiBongRepository
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
                _mySqlContext.DoiBongRepository.Add(entity);
            }

            _mySqlContext.SaveChanges();
        }
    }
}
