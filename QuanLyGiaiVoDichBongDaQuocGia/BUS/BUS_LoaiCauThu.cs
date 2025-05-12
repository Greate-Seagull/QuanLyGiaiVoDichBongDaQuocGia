using QuanLyGiaiVoDichBongDaQuocGia.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.BUS
{
    public enum LoaiCauThuColumn
    {
        MaLoaiCauThu,
        TenLoaiCauThu,
        SoLuongCauThuToiDaTheoLoaiCauThu
    }
    public class BUS_LoaiCauThu
    {
        DAL_LoaiCauThu DAL_loaiCauThu = new DAL_LoaiCauThu();

        BUS_CauThu BUS_cauThu = new BUS_CauThu();

        public Manager.DataManager<DTO_LoaiCauThu> LayDanhSach(string? filters = default, params LoaiCauThuColumn[] columns)
        {
            var hashed = columns.ToHashSet();
            hashed.Add(LoaiCauThuColumn.MaLoaiCauThu);

            return Manager.CacheManager.GetOrLoad("LOAICAUTHU",
                                                  () => new Manager.DataManager<DTO_LoaiCauThu>(DAL_loaiCauThu.LayDanhSach(hashed, filters),
                                                                                                loaiCauThu => loaiCauThu.MaLoaiCauThu)
                                                 );

        }

        public void KiemTraSoLuongCauThuToiDa()
        {
            DataManager<DTO_CauThu> danhSachCauThu = BUS_cauThu.LayDanhSachNhap();
            Dictionary<DTO_LoaiCauThu, int> counter = new Dictionary<DTO_LoaiCauThu, int>();

            foreach(var item in danhSachCauThu.ActiveData)
            {
                var cauThu = item.Data;

                if (counter.ContainsKey(cauThu.LoaiCauThu))
                {
                    counter[cauThu.LoaiCauThu]++;
                }
                else
                {
                    counter.Add(cauThu.LoaiCauThu, 1);
                }
            }

            foreach(DTO_LoaiCauThu loaiCauThu in counter.Keys)
            {                
                if (counter[loaiCauThu] > loaiCauThu.SoLuongCauThuToiDaTheoLoaiCauThu)
                    throw new Exception($"Vi phạm qui định số lượng cầu thủ tối đa theo loại cầu thủ {loaiCauThu.TenLoaiCauThu}");
            }
        }
    }
}
