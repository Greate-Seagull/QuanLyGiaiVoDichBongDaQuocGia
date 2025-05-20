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

        internal List<DTO_TranDau> LayDanhSachTranDauTraCuu()
        {
            var query = _DAL.GetAll()
                            .Select(obj => new DTO_TranDau
                            {
                                MaTranDau = obj.MaTranDau,
                                MaDoi1 = obj.MaDoi1,
                                MaDoi2 = obj.MaDoi2,
                                NgayGio = obj.NgayGio,
                                TiSoDoi1 = obj.TiSoDoi1,
                                TiSoDoi2 = obj.TiSoDoi2,
                                MaVongDau = obj.MaVongDau
                            });

            return query.AsNoTracking().ToList();
        }

        internal void DienThongTinDoiBong(Dictionary<string, DTO_TranDau> danhSachTranDau,
                                   Dictionary<string, DTO_DoiBong> danhSachDoiBong)
        {
            foreach(var tranDau in danhSachTranDau.Values)
            {
                if(tranDau.MaDoi1 is not null)
                {
                    DTO_DoiBong doiBong;
                    danhSachDoiBong.TryGetValue(tranDau.MaDoi1, out doiBong);
                    tranDau.DoiBong1 = doiBong;
                }
                if (tranDau.MaDoi2 is not null)
                {
                    DTO_DoiBong doiBong;
                    danhSachDoiBong.TryGetValue(tranDau.MaDoi2, out doiBong);
                    tranDau.DoiBong2 = doiBong;
                }
            }
        }

        internal void DienThongTinVongDau(Dictionary<string, DTO_TranDau> danhSachTranDau,
                                   Dictionary<string, DTO_VongDau> danhSachVongDau)
        {
            foreach (var tranDau in danhSachTranDau.Values)
            {

                if (tranDau.MaVongDau is not null)
                {
                    DTO_VongDau vongDau;
                    danhSachVongDau.TryGetValue(tranDau.MaVongDau, out vongDau);
                    tranDau.VongDau = vongDau;
                }
            }
        }

        internal IEnumerable<DTO_TranDau> TraCuuTranDauTheoVongDau(IEnumerable<DTO_TranDau> danhSachTranDau, 
                                                                   IEnumerable<DTO_VongDau>? danhSachVongDau)
        {
            var result = danhSachTranDau;

            if(danhSachVongDau is not null)
            {
                var maVongDau = danhSachVongDau.Select(entity => entity.MaVongDau).ToHashSet();
                result = result.Where(entity => maVongDau.Contains(entity.MaVongDau));
            }

            return result;
        }

        internal IEnumerable<DTO_TranDau> TraCuuTranDauTheoTiSo(IEnumerable<DTO_TranDau> danhSachTranDau,
                                                                int? tiSoDoi1, int? tiSoDoi2)
        {
            var result = danhSachTranDau;

            if (tiSoDoi1 is not null)
                result = result.Where(entity => entity.TiSoDoi1 == tiSoDoi1);
            if (tiSoDoi2 is not null)
                result = result.Where(entity => entity.TiSoDoi2 == tiSoDoi2);

            return result;
        }

        internal IEnumerable<DTO_TranDau> TraCuuTranDauTheoNgay(IEnumerable<DTO_TranDau> danhSachTranDau,
                                                                DateTime? startNgay, DateTime? endNgay)
        {
            var result = danhSachTranDau;

            if (startNgay is not null)
                result = result.Where(entity => entity.NgayGio?.Date >= startNgay?.Date);
            if (endNgay is not null)
                result = result.Where(entity => entity.NgayGio?.Date <= endNgay?.Date);

            return result;
        }

        internal IEnumerable<DTO_TranDau> TraCuuTranDauTheoGio(IEnumerable<DTO_TranDau> danhSachTranDau,
                                                               DateTime? startGio, DateTime? endGio)
        {
            var result = danhSachTranDau;

            if (startGio is not null)
                result = result.Where(entity => entity.NgayGio?.TimeOfDay >= startGio?.TimeOfDay);
            if (endGio is not null)
                result = result.Where(entity => entity.NgayGio?.TimeOfDay <= endGio?.TimeOfDay);

            return result;
        }

        internal IEnumerable<DTO_TranDau> TraCuuTranDauTheoMaTranDau(IEnumerable<DTO_TranDau> danhSachTranDau, string maTranDau)
        {
            var result = danhSachTranDau;

            if (string.IsNullOrEmpty(maTranDau) == false)
                result = result.Where(entity => entity.MaTranDau == maTranDau);

            return result;
        }

        internal IEnumerable<DTO_TranDau> TraCuuTranDauTheoVongDau(IEnumerable<DTO_TranDau> danhSachTranDau, DTO_VongDau? vongDau)
        {
            var result = danhSachTranDau;

            if (vongDau is not null)
            {
                result = result.Where(entity => entity.MaVongDau == vongDau.MaVongDau);
            }

            return result;
        }

        internal List<DTO_TranDau> LayDanhSachTranDauXepHang()
        {
            var query = _DAL.GetAll()
                            .Select(entity => new DTO_TranDau
                            {
                                MaTranDau = entity.MaTranDau,
                                MaDoi1 = entity.MaDoi1,
                                MaDoi2 = entity.MaDoi2,
                                TiSoDoi1 = entity.TiSoDoi1,
                                TiSoDoi2 = entity.TiSoDoi2,
                                NgayGio = entity.NgayGio
                            });

            return query.AsNoTracking().ToList();
        }
    }
}
