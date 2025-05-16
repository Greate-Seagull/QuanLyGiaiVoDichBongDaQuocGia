using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Data;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    public class DAL_BanThang
    {
        private readonly MySqlDbContext _mySqlContext;

        public DAL_BanThang(MySqlDbContext context)
        {
            _mySqlContext = context;
        }

        public DTO_BanThang LayMaMoiNhat()
        {
            var query = _mySqlContext.BanThangRepository
                                .Where(obj => obj.Deleted == false)
                                .AsNoTracking()
                                .OrderByDescending(obj => obj.MaBanThang);

            var result = query.FirstOrDefault();
            result ??= new DTO_BanThang { MaBanThang = "BT000" };
            return result;
        }

        public List<DTO_BanThang> LayDanhSach(Expression<Func<DTO_BanThang, DTO_BanThang>>? selector = default, Expression<Func<DTO_BanThang, bool>>? filter = default, bool isTracking = false)
        {
            var query = _mySqlContext.BanThangRepository.AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            if (selector != null)
                query = query.Select(selector);

            if (isTracking == false)
                query = query.AsNoTracking();
                                  
            return query.ToList();
        }

        public void LuuDanhSach(List<DTO_BanThang> insertList)
        {
            foreach(var entity in insertList)
            {
                _mySqlContext.BanThangRepository.Add(entity);
            }

            _mySqlContext.SaveChanges();
        }
    }
}
