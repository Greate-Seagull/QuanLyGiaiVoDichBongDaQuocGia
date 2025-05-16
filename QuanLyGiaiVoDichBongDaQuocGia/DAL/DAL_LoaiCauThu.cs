using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Data;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    public class DAL_LoaiCauThu
    {
        private readonly MySqlDbContext _mySqlContext;

        public DAL_LoaiCauThu(MySqlDbContext context)
        {
            _mySqlContext = context;
        }
        public DTO_LoaiCauThu LayMaMoiNhat()
        {
            var query = _mySqlContext.LoaiCauThuRepository
                                .AsNoTracking()
                                .OrderByDescending(obj => obj.MaLoaiCauThu);

            var result = query.FirstOrDefault();
            result ??= new DTO_LoaiCauThu { MaLoaiCauThu = "LCT00" };
            return result;
        }

        public List<DTO_LoaiCauThu> LayDanhSach(Expression<Func<DTO_LoaiCauThu, DTO_LoaiCauThu>>? selector = default, Expression<Func<DTO_LoaiCauThu, bool>>? filter = default, bool isTracking = false)
        {
            var query = _mySqlContext.LoaiCauThuRepository.AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            if (selector != null)
                query = query.Select(selector);

            if (isTracking == false)
                query = query.AsNoTracking();

            return query.ToList();
        }

        public void LuuDanhSach(List<DTO_LoaiCauThu> insertList)
        {
            foreach (var entity in insertList)
            {
                _mySqlContext.LoaiCauThuRepository.Add(entity);
            }

            _mySqlContext.SaveChanges();
        }
    }
}
