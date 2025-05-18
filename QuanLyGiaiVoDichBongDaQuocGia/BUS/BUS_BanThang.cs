using Microsoft.EntityFrameworkCore;
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

        public string LayMaMoiNhat()
        {
            var query = _DAL.GetAll()
                            .IgnoreQueryFilters()
                            .AsNoTracking()
                            .OrderByDescending(obj => obj.MaBanThang);

            var result = query.FirstOrDefault();

            if (result != null)
                return result.MaBanThang;
            else
                return "BT000";
        }

        public void GhiNhanBanThang(IEnumerable<DTO_BanThang> danhSachGhiNhan)
        {
            _DAL.AddRange(danhSachGhiNhan);
        }

        internal void KiemTraNhapLieu(IEnumerable<DTO_BanThang>? danhSachKiemTra)
        {
            foreach(var entity in danhSachKiemTra)
            {
                if (entity.MaCauThu is null)
                    throw new Exception($"Cầu thủ chưa được chọn của bàn thắng {entity.MaBanThang}");
                if (entity.MaLoaiBanThang is null)
                    throw new Exception($"Loại bàn thắng chưa được chọn của bàn thắng {entity.MaBanThang}");
                if (entity.ThoiDiemGhiBan is null)
                    throw new Exception($"Thời điểm ghi bàn chưa được điều chỉnh của bàn thắng {entity.MaBanThang}");
            }
        }
    }
}
