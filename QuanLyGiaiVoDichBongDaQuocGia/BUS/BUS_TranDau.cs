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
                            .Include(obj => obj.DoiBong1)
                            .Include(obj => obj.DoiBong2)
                            .Include(obj => obj.CacBanThang);

            return query.AsNoTracking().ToList();
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

        internal bool GhiNhanKetQua(DTO_TranDau tranDauGhiNhan)
        {
            var trackedEntity = _DAL.GetAll().FirstOrDefault(obj => obj.MaTranDau == tranDauGhiNhan.MaTranDau);
            if (trackedEntity is null)
                return false;

            _BUS_BanThang.KiemTraNhapLieu(tranDauGhiNhan.CacBanThang);

            trackedEntity.TiSoDoi1 = tranDauGhiNhan.TiSoDoi1;
            trackedEntity.TiSoDoi2 = tranDauGhiNhan.TiSoDoi2;
            trackedEntity.CacBanThang = tranDauGhiNhan.CacBanThang;
            _DAL.SaveChanges();
            return true;
        }

        internal void CapNhatTiSo(DTO_TranDau tranDauGhiNhan, List<DTO_CauThu> danhSachCauThuThuocHaiDoi)
        {
            tranDauGhiNhan.TiSoDoi1 = 0;
            tranDauGhiNhan.TiSoDoi2 = 0;

            foreach(var entity in tranDauGhiNhan.CacBanThang)
            {
                if (entity.Deleted == false)
                {
                    var cauThu = danhSachCauThuThuocHaiDoi.FirstOrDefault(obj => obj.MaCauThu == entity.MaCauThu);
                    if (cauThu is null)
                        continue;

                    if (cauThu.MaDoiBong == tranDauGhiNhan.MaDoi1)
                        tranDauGhiNhan.TiSoDoi1++;
                    else //if (cauThu.MaDoiBong == tranDauGhiNhan.MaDoi2)
                        tranDauGhiNhan.TiSoDoi2++;
                }
            }
        }
    }
}
