using DevExpress.DirectX.Common;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
using QuanLyGiaiVoDichBongDaQuocGia.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.InteropServices;

namespace QuanLyGiaiVoDichBongDaQuocGia.BUS
{    
    public class BUS_CauThu
    {
        private readonly DAL_CauThu _DAL;

        public BUS_CauThu(DAL_CauThu dAL)
        {
            _DAL = dAL;
        }

        public string LayMaMoiNhat()
        {
            var query = _DAL.GetAll()
                            .IgnoreQueryFilters()
                            .AsNoTracking()
                            .OrderByDescending(obj => obj.MaCauThu);

            var result = query.FirstOrDefault();

            if (result != null)
                return result.MaCauThu;
            else
                return "CT000";
        }

        public void KiemTraNhapLieu(IEnumerable<DTO_CauThu> danhSachTiepNhan)
        {
            foreach(var entity in danhSachTiepNhan)
            {
                if (string.IsNullOrEmpty(entity.TenCauThu))
                    throw new Exception("Tên cầu thủ không được bỏ trống");
            }
        }

        internal List<DTO_CauThu> LayDanhSachCauThuThuocHaiDoi(string maDoi1, string maDoi2)
        {
            var query = _DAL.GetAll()
                            .Include(obj => obj.DoiBong)
                            .Where(obj => obj.MaDoiBong == maDoi1 || obj.MaDoiBong == maDoi2)
                            .Select(obj => new DTO_CauThu
                            {
                                MaCauThu = obj.MaCauThu,
                                TenCauThu = obj.TenCauThu,
                                MaDoiBong = obj.MaDoiBong,
                                DoiBong = obj.DoiBong
                            });

            return query.AsNoTracking().ToList();
        }

        internal Dictionary<string, int> DemSoLuongCauThuTheoLoai(IEnumerable<DTO_CauThu> entities)
        {
            var result = new Dictionary<string, int>();

            foreach(var entity in entities)
            {
                if (string.IsNullOrEmpty(entity.MaLoaiCauThu))
                    continue;

                if (result.ContainsKey(entity.MaLoaiCauThu))
                    result[entity.MaLoaiCauThu]++;
                else
                    result[entity.MaLoaiCauThu] = 1;
            }

            return result;
        }

        internal List<DTO_CauThu> LayDanhSachCauThuTraCuu()
        {
            var query = _DAL.GetAll()
                            .Select(obj => new DTO_CauThu
                            {
                                MaCauThu = obj.MaCauThu,
                                TenCauThu = obj.TenCauThu,
                                MaDoiBong = obj.MaDoiBong,
                                MaLoaiCauThu = obj.MaLoaiCauThu,
                                NgaySinh = obj.NgaySinh,
                                GhiChu = obj.GhiChu
                            });

            return query.AsNoTracking().ToList();
        }

        internal void DienThongTin(Dictionary<string, DTO_CauThu> danhSachCauThu, Dictionary<string, DTO_DoiBong> danhSachDoiBong, Dictionary<string, DTO_LoaiCauThu> danhSachLoaiCauThu)
        {
            foreach(var cauThu in danhSachCauThu.Values)
            {
                if(danhSachDoiBong is not null && cauThu.MaDoiBong is not null)
                {
                    DTO_DoiBong doiBong;
                    danhSachDoiBong.TryGetValue(cauThu.MaDoiBong, out doiBong);
                    cauThu.DoiBong = doiBong;
                }

                if(danhSachLoaiCauThu is not null && cauThu.MaLoaiCauThu is not null)
                {
                    DTO_LoaiCauThu loaiCauThu;
                    danhSachLoaiCauThu.TryGetValue(cauThu.MaLoaiCauThu, out loaiCauThu);
                    cauThu.LoaiCauThu = loaiCauThu;
                }
            }
        }

        internal IEnumerable<DTO_CauThu> TraCuuCauThu(IEnumerable<DTO_CauThu> danhSachCauThu, 
                                                      IEnumerable<DTO_LoaiCauThu>? ketQuaTimKiemLoaiCauThu)
        {
            var result = danhSachCauThu;

            if(ketQuaTimKiemLoaiCauThu is not null)
            {
                var maLoaiCauThu = ketQuaTimKiemLoaiCauThu.Select(entity => entity.MaLoaiCauThu).ToHashSet();
                result = result.Where(entity => maLoaiCauThu.Contains(entity.MaLoaiCauThu));
            }

            return result;
        }

        internal IEnumerable<DTO_CauThu> TraCuuCauThu(IEnumerable<DTO_CauThu> danhSachCauThu,
                                                      IEnumerable<DTO_DoiBong>? ketQuaTimKiemDoiBong)
        {
            var result = danhSachCauThu;

            if (ketQuaTimKiemDoiBong is not null)
            {
                var maDoiBong = ketQuaTimKiemDoiBong.Select(entity => entity.MaDoiBong).ToHashSet();
                result = result.Where(entity => maDoiBong.Contains(entity.MaDoiBong));
            }

            return result;
        }

        internal IEnumerable<DTO_CauThu> TraCuuCauThu(IEnumerable<DTO_CauThu> danhSachCauThu,
                                                      IEnumerable<DTO_BanThang>? ketQuaTimKiemBanThang)
        {
            var result = danhSachCauThu;

            if (ketQuaTimKiemBanThang is not null)
            {
                var maBanThang = ketQuaTimKiemBanThang.Select(entity => entity.MaCauThu).ToHashSet();
                result = result.Where(entity => maBanThang.Contains(entity.MaCauThu));
            }

            return result;
        }

        internal IEnumerable<DTO_CauThu> TraCuuCauThu(IEnumerable<DTO_CauThu> danhSachCauThu, string maCauThu, string tenCauThu)
        {
            var result = danhSachCauThu;

            if (string.IsNullOrEmpty(maCauThu) == false)
            {
                result = result.Where(entity => entity.MaCauThu.ToLower().Contains(maCauThu));
            }
            if (string.IsNullOrEmpty(tenCauThu) == false)
            {
                result = result.Where(entity => entity.TenCauThu.ToLower().Contains(tenCauThu));
            }

            return result;
        }

        internal IEnumerable<DTO_CauThu> TraCuuCauThu(IEnumerable<DTO_CauThu> danhSachCauThu, DateTime? startNgaySinh, DateTime? endNgaySinh)
        {
            var result = danhSachCauThu;

            if (startNgaySinh is not null)
            {
                result = result.Where(entity => entity.NgaySinh >= startNgaySinh);
            }
            if (endNgaySinh is not null)
            {
                result = result.Where(entity => entity.NgaySinh <= endNgaySinh);
            }

            return result;
        }

        internal IEnumerable<DTO_CauThu> TraCuuCauThu(IEnumerable<DTO_CauThu> danhSachCauThu, int? startSoBanThang, int? endSoBanThang)
        {
            var result = danhSachCauThu;

            if (startSoBanThang is not null)
            {
                result = result.Where(entity => entity.CacBanThang?.Count >= startSoBanThang);
            }
            if (endSoBanThang is not null)
            {
                result = result.Where(entity => entity.CacBanThang?.Count <= endSoBanThang);
            }

            return result;
        }

        internal void DienThongTinBanThang(Dictionary<string, DTO_CauThu> danhSachCauThu, Dictionary<string, DTO_BanThang> danhSachBanThang)
        {
            foreach(var cauThu in danhSachCauThu.Values)
            {
                if (cauThu.CacBanThang is null)
                    cauThu.CacBanThang = new();
            }

            foreach (var banThang in danhSachBanThang.Values)
            {
                DTO_CauThu cauThu;
                if (banThang.MaCauThu is not null && danhSachCauThu.TryGetValue(banThang.MaCauThu, out cauThu))
                    cauThu.CacBanThang.Add(banThang);
            }
        }
    }
}
