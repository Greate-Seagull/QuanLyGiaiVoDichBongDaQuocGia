using QuanLyGiaiVoDichBongDaQuocGia.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.BUS
{        
    class BUS_TranDau
    {
        private readonly DAL_TranDau _DAL;
        private readonly BUS_BanThang _BUS_BanThang;

        public BUS_TranDau(DAL_TranDau dAL, BUS_BanThang bUS_BanThang)
        {
            _DAL = dAL;
            _BUS_BanThang = bUS_BanThang;
        }

        public List<DTO_TranDau> LayDanhSach(Expression<Func<DTO_TranDau, DTO_TranDau>>? selector = default, Expression<Func<DTO_TranDau, bool>>? filter = default, bool isTracking = false)
        {
            return _DAL.LayDanhSach(selector, filter, isTracking);
        }

        public DTO_TranDau? LayMaMoiNhat()
        {
            return _DAL.LayMaMoiNhat();
        }

        public bool LapTranDau(List<DTO_TranDau> danhSachTranDau)
        {
            KiemTraNhapLieu(danhSachTranDau);
            return LuuThongTin(danhSachTranDau);
        }

        public bool LuuThongTin(List<DTO_TranDau> danhSachLuu)
        {
            _DAL.LuuDanhSach(danhSachLuu);
            return true;
        }

        private void KiemTraNhapLieu(List<DTO_TranDau> danhSachKiemTra)
        {
            foreach (var entity in danhSachKiemTra)
            {
                if (string.IsNullOrEmpty(entity.MaDoi1))
                    throw new Exception($"Đội bóng 1 chưa được chọn cho trận đấu {entity.MaTranDau}");
                if (string.IsNullOrEmpty(entity.MaDoi2))
                    throw new Exception($"Đội bóng 2 chưa được chọn cho trận đấu {entity.MaTranDau}");
            }
        }

        internal bool GhiNhanKetQua(List<DTO_BanThang> danhSachBanThang)
        {
            _BUS_BanThang.GhiNhanBanThang(danhSachBanThang);
            return LuuThongTin(new());
        }
    }
}
