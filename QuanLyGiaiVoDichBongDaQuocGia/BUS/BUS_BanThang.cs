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

        internal List<DTO_BanThang> LayDanhSachBanThangTraCuu()
        {
            var query = _DAL.GetAll()
                            .Select(obj => new DTO_BanThang
                            {
                                MaBanThang = obj.MaBanThang,
                                MaTranDau = obj.MaTranDau,
                                MaCauThu = obj.MaCauThu,
                                MaLoaiBanThang = obj.MaLoaiBanThang,
                                ThoiDiemGhiBan = obj.ThoiDiemGhiBan
                            });

            return query.AsNoTracking().ToList();
        }

        internal void DienThongTinTranDau(Dictionary<string, DTO_BanThang> danhSachBanThang, 
                                   Dictionary<string, DTO_TranDau> danhSachTranDau)
        {
            foreach(var banThang in danhSachBanThang.Values)
            {
                if(banThang.MaTranDau is not null)
                {
                    DTO_TranDau tranDau;
                    danhSachTranDau.TryGetValue(banThang.MaTranDau, out tranDau);
                    banThang.TranDau = tranDau;
                }
            }
        }

        internal void DienThongTinCauThu(Dictionary<string, DTO_BanThang> danhSachBanThang,
                                   Dictionary<string, DTO_CauThu> danhSachCauThu)
        {
            foreach (var banThang in danhSachBanThang.Values)
            {
                if (banThang.MaCauThu is not null)
                {
                    DTO_CauThu cauThu;
                    danhSachCauThu.TryGetValue(banThang.MaCauThu, out cauThu);
                    banThang.CauThu = cauThu;
                }
            }
        }

        internal void DienThongTinLoaiBanThang(Dictionary<string, DTO_BanThang> danhSachBanThang,
                                   Dictionary<string, DTO_LoaiBanThang> danhSachLoaiBanThang)
        {
            foreach (var banThang in danhSachBanThang.Values)
            {
                if (banThang.MaLoaiBanThang is not null)
                {
                    DTO_LoaiBanThang loaiBanThang;
                    danhSachLoaiBanThang.TryGetValue(banThang.MaLoaiBanThang, out loaiBanThang);
                    banThang.LoaiBanThang = loaiBanThang;
                }
            }
        }

        internal IEnumerable<DTO_BanThang> TraCuuBanThangTheoTranDau(IEnumerable<DTO_BanThang> danhSachBanThang,
                                                                     IEnumerable<DTO_TranDau>? danhSachTranDau)
        {
            var result = danhSachBanThang;

            if(danhSachTranDau is not null)
            {
                var maTranDau = danhSachTranDau.Select(entity => entity.MaTranDau).ToHashSet();
                result = result.Where(entity => maTranDau.Contains(entity.MaTranDau));
            }

            return result;            
        }

        internal IEnumerable<DTO_BanThang> TraCuuBanThangTheoLoaiBanThang(IEnumerable<DTO_BanThang> danhSachBanThang,
                                                                          DTO_LoaiBanThang? loaiBanThang)
        {
            var result = danhSachBanThang;

            if (loaiBanThang is not null)
                result = result.Where(entity => entity.MaLoaiBanThang == loaiBanThang.MaLoaiBanThang);            

            return result;
        }
        internal IEnumerable<DTO_BanThang> TraCuuBanThangTheoThoiDiemGhiBan(IEnumerable<DTO_BanThang> danhSachBanThang,
                                                                            int? startThoiDiemGhiBan, int? endThoiDiemGhiBan)
        {
            var result = danhSachBanThang;

            if (startThoiDiemGhiBan is not null)
                result = result.Where(entity => entity.ThoiDiemGhiBan >= startThoiDiemGhiBan);
            if (endThoiDiemGhiBan is not null)
                result = result.Where(entity => entity.ThoiDiemGhiBan <= endThoiDiemGhiBan);

            return result;
        }

        internal IEnumerable<DTO_BanThang> TraCuuBanThangTheoMaBanThang(IEnumerable<DTO_BanThang> danhSachBanThang, string maBanThang)
        {
            var result = danhSachBanThang;

            if (string.IsNullOrEmpty(maBanThang) == false)
                result = result.Where(entity => entity.MaBanThang == maBanThang);

            return result;
        }

        internal IEnumerable<DTO_BanThang> TraCuuBanThangTheoTranDau(IEnumerable<DTO_BanThang> danhSachBanThang, DTO_TranDau? tranDau)
        {
            var result = danhSachBanThang;

            if (tranDau is not null)
            {
                result = result.Where(entity => entity.MaTranDau == tranDau.MaTranDau);
            }

            return result;
        }
    }
}
