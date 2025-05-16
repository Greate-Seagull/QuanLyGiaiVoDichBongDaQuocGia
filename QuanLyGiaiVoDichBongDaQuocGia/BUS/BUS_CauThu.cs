using QuanLyGiaiVoDichBongDaQuocGia.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.BUS
{    
    public class BUS_CauThu
    {
        private readonly DAL_CauThu _DAL;

        public BUS_CauThu(DAL_CauThu dAL)
        {
            _DAL = dAL;
        }

        public List<DTO_CauThu> LayDanhSach(Expression<Func<DTO_CauThu, DTO_CauThu>>? selector = default, Expression<Func<DTO_CauThu, bool>>? filter = default, bool isTracking = false)
        {
            return _DAL.LayDanhSach(selector, filter, isTracking);
        }

        public DTO_CauThu LayMaMoiNhat()
        {
            return _DAL.LayMaMoiNhat();
        }

        public bool TiepNhanCauThu(List<DTO_CauThu> danhSachTiepNhan)
        {
            KiemTraNhapLieu(danhSachTiepNhan);
            return LuuThongTin(danhSachTiepNhan);
        }

        public bool LuuThongTin(List<DTO_CauThu> danhSachLuu)
        {
            _DAL.LuuDanhSach(danhSachLuu);
            return true;
        }

        private void KiemTraNhapLieu(List<DTO_CauThu> danhSachTiepNhan)
        {
            foreach(var entity in danhSachTiepNhan)
            {
                if (string.IsNullOrEmpty(entity.TenCauThu))
                    throw new Exception("Tên cầu thủ không được bỏ trống");
            }
        }
    }
}
