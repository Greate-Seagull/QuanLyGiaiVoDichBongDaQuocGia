using DevExpress.DirectX.Common;
using Microsoft.EntityFrameworkCore;
using MySqlX.XDevAPI.Common;
using QuanLyGiaiVoDichBongDaQuocGia.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.ComponentModel;
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
                            .Where(obj => obj.MaDoiBong == maDoi1 || obj.MaDoiBong == maDoi2)
                            .Select(obj => new DTO_CauThu
                            {
                                MaCauThu = obj.MaCauThu,
                                TenCauThu = obj.TenCauThu
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
    }
}
