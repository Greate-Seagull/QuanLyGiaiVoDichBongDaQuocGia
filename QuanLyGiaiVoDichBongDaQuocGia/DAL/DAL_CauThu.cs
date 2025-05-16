using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Data;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    public class DAL_CauThu
    {
        private readonly MySqlDbContext _mySqlContext;

        public DAL_CauThu(MySqlDbContext context)
        {
            _mySqlContext = context;
        }

        public DTO_CauThu LayMaMoiNhat()
        {
            var query = _mySqlContext.CauThuRepository
                                .Where(obj => obj.Deleted == false)
                                .AsNoTracking()
                                .OrderByDescending(obj => obj.MaCauThu);

            var result = query.FirstOrDefault();
            result ??= new DTO_CauThu { MaCauThu = "CT000" };
            return result;
        }

        public void LuuDanhSach(List<DTO_CauThu> insertList)
        {
            foreach(var entity in insertList)
            {
                _mySqlContext.CauThuRepository.Add(entity);
            }

            _mySqlContext.SaveChanges();
        }

        internal List<DTO_CauThu> LayDanhSach(Expression<Func<DTO_CauThu, DTO_CauThu>>? selector = default, Expression<Func<DTO_CauThu, bool>>? filter = default, bool isTracking = false)
        {
            var query = _mySqlContext.CauThuRepository
                                .AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            if (selector != null)
                query = query.Select(selector);

            if (isTracking == false)
                query = query.AsNoTracking();

            return query.ToList();
        }
    }
}
