using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Data;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    class DAL_LoaiBanThang
    {
        private readonly MySqlDbContext _mySqlContext;

        public DAL_LoaiBanThang(MySqlDbContext context)
        {
            _mySqlContext = context;
        }

        public DTO_LoaiBanThang LayMaMoiNhat()
        {
            var query = _mySqlContext.LoaiBanThangRepository
                                .AsNoTracking()
                                .OrderByDescending(obj => obj.MaLoaiBanThang);

            var result = query.FirstOrDefault();
            result ??= new DTO_LoaiBanThang { MaLoaiBanThang = "LBT00" };
            return result;
        }

        public List<DTO_LoaiBanThang> LayDanhSach(Expression<Func<DTO_LoaiBanThang, DTO_LoaiBanThang>>? selector = default, Expression<Func<DTO_LoaiBanThang, bool>>? filter = default, bool isTracking = false)
        {
            var query = _mySqlContext.LoaiBanThangRepository.AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            if (selector != null)
                query = query.Select(selector);

            if (isTracking == false)
                query = query.AsNoTracking();

            return query.ToList();
        }

        public void LuuDanhSach(List<DTO_LoaiBanThang> insertList)
        {
            foreach (var entity in insertList)
            {
                _mySqlContext.LoaiBanThangRepository.Add(entity);
            }

            _mySqlContext.SaveChanges();
        }
    }
}
