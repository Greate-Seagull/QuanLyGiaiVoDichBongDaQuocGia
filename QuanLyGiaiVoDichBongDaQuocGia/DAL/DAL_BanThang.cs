using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Data;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    class DAL_BanThang
    {
        private readonly DBC_BanThang _context;

        public DAL_BanThang(DBC_BanThang context)
        {
            _context = context;
        }

        public DTO_BanThang? LayMaMoiNhat()
        {
            var query = _context.LocalRepository
                                .AsNoTracking()
                                .OrderByDescending(obj => obj.MaBanThang);

            return query.FirstOrDefault();
        }

        public List<DTO_BanThang> LayDanhSach(Expression<Func<DTO_BanThang, DTO_BanThang>> selector = default, Expression<Func<DTO_BanThang, bool>> filter = default)
        {
            var query = _context.LocalRepository.AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            if (selector != null)
                query = query.Select(selector);
                                  
            return query.AsNoTracking().ToList();
        }

        public void LuuDanhSach(List<DTO_BanThang> insertList)
        {
            foreach(var entity in insertList)
            {
                _context.LocalRepository.Add(entity);
            }

            _context.SaveChanges();
        }
    }
}
