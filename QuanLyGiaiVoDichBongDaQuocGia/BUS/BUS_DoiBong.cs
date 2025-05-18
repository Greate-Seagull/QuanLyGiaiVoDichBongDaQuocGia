using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.DAL;
using System.Transactions;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace QuanLyGiaiVoDichBongDaQuocGia.BUS
{
    public class BUS_DoiBong
    {
        private readonly DAL_DoiBong _DAL;
        private readonly BUS_CauThu _BUS_CauThu;

        public BUS_DoiBong(DAL_DoiBong dAL, BUS_CauThu bUS_CauThu)
        {
            _DAL = dAL;
            _BUS_CauThu = bUS_CauThu;
        }

        public string LayMaMoiNhat()
        {
            var query = _DAL.GetAll()
                            .IgnoreQueryFilters()
                            .AsNoTracking()
                            .OrderByDescending(obj => obj.MaDoiBong);

            var result = query.FirstOrDefault();

            if (result != null)
                return result.MaDoiBong;
            else
                return "DB000";
        }

        public bool TiepNhanDoiBong(DTO_DoiBong doiBongTiepNhan)
        {
            var danhSachTam = new List<DTO_DoiBong> { doiBongTiepNhan };

            this.KiemTraNhapLieu(danhSachTam);

            using (var transaction = _DAL.Context.Database.BeginTransaction())
            {
                try
                {
                    _BUS_CauThu.KiemTraNhapLieu(doiBongTiepNhan.CacCauThu);
                    if(_DAL.ExistsLocally(doiBongTiepNhan) == false) _DAL.Add(doiBongTiepNhan);        
                    _DAL.SaveChanges();
                    transaction.Commit();
                    return true;

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }            
        }

        private void KiemTraNhapLieu(IEnumerable<DTO_DoiBong> danhSachKiemTra)
        {
            foreach(var entity in danhSachKiemTra)
            {
                if (string.IsNullOrEmpty(entity.TenDoiBong))
                    throw new Exception("Tên đội bóng không được để trống");
                if (string.IsNullOrEmpty(entity.TenSanNha))
                    throw new Exception("Tên sân nhà không được để trống");
            }
        }        
    }
}
