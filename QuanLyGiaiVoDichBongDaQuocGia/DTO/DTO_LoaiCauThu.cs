using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.DTO
{
    public class DTO_LoaiCauThu
    {
        public string? MaLoaiCauThu { get; set; }
        public string? TenLoaiCauThu { get; set; }
        public int SoLuongCauThuToiDaTheoLoaiCauThu { get; set; }

        public override string ToString()
        {
            return TenLoaiCauThu;
        }
    }
}
