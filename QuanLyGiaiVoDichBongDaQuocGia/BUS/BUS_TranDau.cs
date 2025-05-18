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
                            .OrderByDescending(obj => obj.MaTranDau);

            var result = query.AsNoTracking().FirstOrDefault();

            if (result != null)
                return result.MaTranDau;
            else
                return "TD000";
        }

        public void KiemTraNhapLieu(IEnumerable<DTO_TranDau> danhSachKiemTra)
        {
            foreach (var entity in danhSachKiemTra)
            {
                if (string.IsNullOrEmpty(entity.MaDoi1))
                    throw new Exception($"Đội bóng 1 chưa được chọn cho trận đấu {entity.MaTranDau}");
                if (string.IsNullOrEmpty(entity.MaDoi2))
                    throw new Exception($"Đội bóng 2 chưa được chọn cho trận đấu {entity.MaTranDau}");
                if (entity.NgayGio is null)
                    throw new Exception($"Ngày giờ chưa được lập cho trận đấu {entity.MaTranDau}");
            }
        }

        internal bool GhiNhanKetQua(DTO_TranDau tranDauGhiNhan, IEnumerable<DTO_BanThang> danhSachBanThang)
        {
            _BUS_BanThang.GhiNhanBanThang(danhSachBanThang);
            return true;
        }

        internal List<DTO_TranDau> LayDanhSachCapDau()
        {
            var query = _DAL.GetAll()
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

        internal List<string> LayDanhSachMaDoiBongDaThiDau(List<DTO_TranDau> danhSachCapDau)
        {
            return danhSachCapDau.SelectMany(entity => new[] { entity.MaDoi1, entity.MaDoi2 })
                                 .Distinct()
                                 .ToList();
        }

        internal List<string> LayDanhSachMaDoiBongDaThiDauVoi(string? maDoi1, List<DTO_TranDau> danhSachCapDau)
        {
            return danhSachCapDau.Where(entity => entity.MaDoi1 == maDoi1)
                                 .Select(entity => entity.MaDoi2)
                                 .Distinct()
                                 .ToList();
        }
    }
}
