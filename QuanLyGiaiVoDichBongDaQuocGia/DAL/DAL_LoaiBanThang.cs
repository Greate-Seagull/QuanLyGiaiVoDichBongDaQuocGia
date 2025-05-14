using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Data;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    class DAL_LoaiBanThang
    {
        private readonly DBC_LoaiBanThang _context;

        public DAL_LoaiBanThang(DBC_LoaiBanThang context)
        {
            _context = context;
        }

        public DTO_LoaiBanThang? LayMaMoiNhat()
        {
            var query = _context.LocalRepository
                                .AsNoTracking()
                                .OrderByDescending(obj => obj.MaLoaiBanThang);

            return query.FirstOrDefault();
        }

        public List<DTO_LoaiBanThang> LayDanhSach(Expression<Func<DTO_LoaiBanThang, DTO_LoaiBanThang>> selector = default, Expression<Func<DTO_LoaiBanThang, bool>> filter = default)
        {
            var query = _context.LocalRepository.AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            if (selector != null)
                query = query.Select(selector);

            return query.AsNoTracking().ToList();
        }

        public void LuuDanhSach(List<DTO_LoaiBanThang> insertList)
        {
            foreach (var entity in insertList)
            {
                _context.LocalRepository.Add(entity);
            }

            _context.SaveChanges();
        }
    }
}
