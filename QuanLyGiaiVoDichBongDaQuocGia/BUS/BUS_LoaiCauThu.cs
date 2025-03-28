using QuanLyGiaiVoDichBongDaQuocGia.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.BUS
{
    public class BUS_LoaiCauThu
    {
        DAL_LoaiCauThu DAL_loaiCauThu = new DAL_LoaiCauThu();

        public List<DTO.DTO_LoaiCauThu> LayDanhSachLoaiCauThu()
        {
            return DAL_loaiCauThu.LayDanhSachLoaiCauThu();
        }

        public void KiemTraSoLuongCauThuToiDa(Manager.Manager<DTO.DTO_CauThu> danhSachCauThu)
        {
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
