using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Data;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    class DAL_TranDau
    {
        private readonly MySqlDbContext _mySqlContext;

        public DAL_TranDau(MySqlDbContext context)
        {
            _mySqlContext = context;
        }

        public DTO_TranDau LayMaMoiNhat()
        {
            var query = _mySqlContext.TranDauRepository
                                .Where(obj => obj.Deleted == false)
                                .AsNoTracking()
                                .OrderByDescending(obj => obj.MaTranDau);

            var result = query.FirstOrDefault();
            result ??= new DTO_TranDau { MaTranDau = "TD000" };
            return result;
        }

        public List<DTO_TranDau> LayDanhSach(Expression<Func<DTO_TranDau, DTO_TranDau>>? selector = default, Expression<Func<DTO_TranDau, bool>>? filter = default, bool isTracking = false)
        {
            var query = _mySqlContext.TranDauRepository.AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            if (selector != null)
                query = query.Select(selector);

            if (isTracking == false)
                query = query.AsNoTracking();

            return query.ToList();
        }

        public void LuuDanhSach(List<DTO_TranDau> insertList)
        {
            foreach (var entity in insertList)
            {
                _mySqlContext.TranDauRepository.Add(entity);
            }

            _mySqlContext.SaveChanges();
        }
    }
}
