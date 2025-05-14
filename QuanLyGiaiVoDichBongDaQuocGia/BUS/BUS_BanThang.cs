using QuanLyGiaiVoDichBongDaQuocGia.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.BUS
{
    public class BUS_BanThang
    {
        private readonly DAL_BanThang _DAL;

        public BUS_BanThang(DAL_BanThang DAL)
        {
            _DAL = DAL;
        }

        public List<DTO_BanThang> LayDanhSach(Expression<Func<DTO_BanThang, DTO_BanThang>>? selector = default, Expression<Func<DTO_BanThang, bool>>? filter = default, bool isTracking = false)
        {
            return _DAL.LayDanhSach(selector, filter, isTracking);
        }

        public DTO_BanThang? LayMaMoiNhat()
        {
            return _DAL.LayMaMoiNhat();
        }

        public bool GhiNhanBanThang(List<DTO_BanThang> danhSachGhiNhan)
        {
            return LuuThongTin(danhSachGhiNhan);
        }

        public bool LuuThongTin(List<DTO_BanThang> danhSachLuu)
        {
            _DAL.LuuDanhSach(danhSachLuu);
            return true;
        }
    }
}
