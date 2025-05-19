using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.DAL;
using System.Transactions;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using DevExpress.Utils.Extensions;

namespace QuanLyGiaiVoDichBongDaQuocGia.BUS
{
    public class BUS_DoiBong
    {
        private readonly DAL_DoiBong _DAL;
        private readonly BUS_CauThu _BUS_CauThu;

        public BUS_DoiBong(DAL_DoiBong dAL, BUS_CauThu bUS_CauThu)
        {
            _DAL = dAL;
            _BUS_CauThu = bUS_CauThu;
        }

        public string LayMaMoiNhat()
        {
            var query = _DAL.GetAll()
                            .IgnoreQueryFilters()
                            .AsNoTracking()
                            .OrderByDescending(obj => obj.MaDoiBong);

            var result = query.FirstOrDefault();

            if (result != null)
                return result.MaDoiBong;
            else
                return "DB000";
        }

        public bool TiepNhanDoiBong(DTO_DoiBong doiBongTiepNhan)
        {
            var danhSachTam = new List<DTO_DoiBong> { doiBongTiepNhan };

            this.KiemTraNhapLieu(danhSachTam);

            using (var transaction = _DAL.Context.Database.BeginTransaction())
            {
                try
                {
                    _BUS_CauThu.KiemTraNhapLieu(doiBongTiepNhan.CacCauThu);
                    if(_DAL.ExistsLocally(doiBongTiepNhan) == false) _DAL.Add(doiBongTiepNhan);        
                    _DAL.SaveChanges();
                    transaction.Commit();
                    return true;

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }            
        }

        internal void DienDanhSach(Dictionary<string, DTO_DoiBong> danhSachDoiBong, Dictionary<string, DTO_CauThu> danhSachCauThu)
        {
            foreach(var cauThu in danhSachCauThu.Values)
            {
                DTO_DoiBong doiBong;
                if(cauThu.MaDoiBong is not null && danhSachDoiBong.TryGetValue(cauThu.MaDoiBong, out doiBong))
                {
                    if (doiBong.CacCauThu is null)
                        doiBong.CacCauThu = new();

                    doiBong.CacCauThu.Add(cauThu);
                }
            }
        }

        internal List<DTO_DoiBong> LayDanhSachDoiBongLapLich()
        {
            var query = _DAL.GetAll()
                            .Select(obj => new DTO_DoiBong
                            {
                                MaDoiBong = obj.MaDoiBong,
                                TenDoiBong = obj.TenDoiBong,
                                TenSanNha = obj.TenSanNha
                            });

            return query.AsNoTracking().ToList();
        }

        internal List<DTO_DoiBong> LayDanhSachDoiBongThiDauHopLe(List<DTO_DoiBong> danhSachDoiBong, List<string> danhSachMaDoiBongDangLapLich, List<string> danhSachMaDoiBongDaLapLich)
        {
            return danhSachDoiBong.Where(entity => danhSachMaDoiBongDaLapLich.Contains(entity.MaDoiBong) == false && danhSachMaDoiBongDangLapLich.Contains(entity.MaDoiBong) == false)
                                  .ToList();
        }

        internal List<DTO_DoiBong> LayDanhSachDoiBongTraCuu()
        {
            var query = _DAL.GetAll()
                            .Select(obj => new DTO_DoiBong
                            {
                                MaDoiBong = obj.MaDoiBong,
                                TenDoiBong = obj.TenDoiBong,
                                TenSanNha = obj.TenSanNha
                            });

            return query.AsNoTracking().ToList();
        }

        internal IEnumerable<DTO_DoiBong> TraCuuDoiBongTheoTranDau(IEnumerable<DTO_DoiBong> danhSachDoiBong,
                                                                   IEnumerable<DTO_TranDau>? danhSachTranDau)
        {
            var result = danhSachDoiBong;
                
            if(danhSachTranDau is not null)
            {
                var maDoiBong = danhSachTranDau.SelectMany(entity => new[] { entity.MaDoi1, entity.MaDoi2 }).ToHashSet();
                result = result.Where(entity => maDoiBong.Contains(entity.MaDoiBong));
            }

            return result;            
        }

        internal IEnumerable<DTO_DoiBong> TraCuuDoiBongTheoSoLuongCauThu(IEnumerable<DTO_DoiBong> danhSachDoiBong,
                                                                         int? startSoLuong, int? endSoLuong)
        {
            var result = danhSachDoiBong;

            if (startSoLuong is not null)
                result = result.Where(entity => entity.CacCauThu?.Count >= startSoLuong);
            if (endSoLuong is not null)
                result = result.Where(entity => entity.CacCauThu?.Count <= endSoLuong);

            return result;
        }

        private void KiemTraNhapLieu(IEnumerable<DTO_DoiBong> danhSachKiemTra)
        {
            foreach(var entity in danhSachKiemTra)
            {
                if (string.IsNullOrEmpty(entity.TenDoiBong))
                    throw new Exception("Tên đội bóng không được để trống");
                if (string.IsNullOrEmpty(entity.TenSanNha))
                    throw new Exception("Tên sân nhà không được để trống");
            }
        }

        internal IEnumerable<DTO_DoiBong> TraCuuDoiBongTheoMaDoiBong(IEnumerable<DTO_DoiBong> danhSachDoiBong, string maDoiBong)
        {
            var result = danhSachDoiBong;

            if (string.IsNullOrEmpty(maDoiBong) == false)
                result = result.Where(entity => entity.MaDoiBong == maDoiBong);

            return result;
        }

        internal IEnumerable<DTO_DoiBong> TraCuuDoiBongTheoTranDau(IEnumerable<DTO_DoiBong> danhSachDoiBong, DTO_TranDau? tranDau)
        {
            var result = danhSachDoiBong;

            if (tranDau is not null)
            {
                result = result.Where(entity => entity.MaDoiBong == tranDau.MaDoi1 || entity.MaDoiBong == tranDau.MaDoi2);
            }

            return result;
        }
    }
}
