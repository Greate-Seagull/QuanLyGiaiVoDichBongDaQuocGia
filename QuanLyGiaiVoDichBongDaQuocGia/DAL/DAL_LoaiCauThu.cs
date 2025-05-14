using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Data;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    public class DAL_LoaiCauThu
    {
        private readonly DBC_LoaiCauThu _context;

        public DAL_LoaiCauThu(DBC_LoaiCauThu context)
        {
            _context = context;
        }
        public DTO_LoaiCauThu? LayMaMoiNhat()
        {
            var query = _context.LocalRepository
                                .AsNoTracking()
                                .OrderByDescending(obj => obj.MaLoaiCauThu);

            return query.FirstOrDefault();
        }

        public List<DTO_LoaiCauThu> LayDanhSach(Expression<Func<DTO_LoaiCauThu, DTO_LoaiCauThu>>? selector = default, Expression<Func<DTO_LoaiCauThu, bool>>? filter = default, bool isTracking = false)
        {
            var query = _context.LocalRepository.AsQueryable();

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
                _context.LocalRepository.Add(entity);
            }

            _context.SaveChanges();
        }
    }
}
