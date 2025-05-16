using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Data;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    class DAL_VongDau
    {
        private readonly MySqlDbContext _mySqlContext;
        public DAL_VongDau(MySqlDbContext context)
        {
            _mySqlContext = context;
        }

        public DTO_VongDau LayMaMoiNhat()
        {
            var query = _mySqlContext.VongDauRepository
                                .Where(obj => obj.Deleted == false)
                                .AsNoTracking()
                                .OrderByDescending(obj => obj.MaVongDau);

            var result = query.FirstOrDefault();
            result ??= new DTO_VongDau { MaVongDau = "VD000" };
            return result;
        }

        public List<DTO_VongDau> LayDanhSach(Expression<Func<DTO_VongDau, DTO_VongDau>>? selector = default, Expression<Func<DTO_VongDau, bool>>? filter = default, bool isTracking = false)
        {
            var query = _mySqlContext.VongDauRepository.AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            if (selector != null)
                query = query.Select(selector);

            if (isTracking == false)
                query = query.AsNoTracking();

            return query.ToList();
        }

        public void LuuDanhSach(List<DTO_VongDau> insertList)
        {
            foreach (var entity in insertList)
            {
                _mySqlContext.VongDauRepository.Add(entity);
            }

            _mySqlContext.SaveChanges();
        }
    }
}
