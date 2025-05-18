using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.BUS
{        
    public class BUS_TranDau
    {
        private readonly DAL_TranDau _DAL;
        private readonly BUS_BanThang _BUS_BanThang;

        public BUS_TranDau(DAL_TranDau dAL, BUS_BanThang bUS_BanThang)
        {
            _DAL = dAL;
            _BUS_BanThang = bUS_BanThang;
        }

        public string LayMaMoiNhat()
        {
            var query = _DAL.GetAll()
                            .IgnoreQueryFilters()
                            .AsNoTracking()
                            .OrderByDescending(obj => obj.MaTranDau);

            var result = query.FirstOrDefault();

            if (result != null)
                return result.MaTranDau;
            else
                return "TD000";
        }

        public void LapTranDau(IEnumerable<DTO_TranDau> danhSachTranDau)
        {
            this.KiemTraNhapLieu(danhSachTranDau);
            _DAL.AddRange(danhSachTranDau);
        }

        private void KiemTraNhapLieu(IEnumerable<DTO_TranDau> danhSachKiemTra)
        {
            foreach (var entity in danhSachKiemTra)
            {
                if (string.IsNullOrEmpty(entity.MaDoi1))
                    throw new Exception($"Đội bóng 1 chưa được chọn cho trận đấu {entity.MaTranDau}");
                if (string.IsNullOrEmpty(entity.MaDoi2))
                    throw new Exception($"Đội bóng 2 chưa được chọn cho trận đấu {entity.MaTranDau}");
            }
        }

        internal bool GhiNhanKetQua(DTO_TranDau tranDauGhiNhan, IEnumerable<DTO_BanThang> danhSachBanThang)
        {
            _BUS_BanThang.GhiNhanBanThang(danhSachBanThang);
            return true;
        }

        internal List<DTO_TranDau> LayDanhSachCapDauNgoaiTruVongDau(string? maVongDau)
        {
            var query = _DAL.GetAll()
                            .Where(obj => obj.MaVongDau != maVongDau)
                            .Select(obj => new DTO_TranDau
                            {
                                MaTranDau = obj.MaTranDau,
                                MaDoi1 = obj.MaDoi1,
                                MaDoi2 = obj.MaDoi2
                            });

            return query.AsNoTracking().ToList();
        }

        internal List<DTO_TranDau> LayDanhSachTranDauGhiNhanKetQua()
        {
            var query = _DAL.GetAll()
                            .Select(obj => new DTO_TranDau
                            {
                                MaTranDau = obj.MaTranDau,
                                MaDoi1 = obj.MaDoi1,
                                MaDoi2 = obj.MaDoi2,
                                NgayGio = obj.NgayGio,
                                TiSoDoi1 = obj.TiSoDoi1,
                                TiSoDoi2 = obj.TiSoDoi2
                            });

            //use tracking
            return query.ToList();
        }
    }
}
