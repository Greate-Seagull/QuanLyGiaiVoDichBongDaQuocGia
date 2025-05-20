using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.ViewModel
{
    public class VM_LoaiCauThu
    {
        public string MaLoaiCauThu { get; set; }
        public string? TenLoaiCauThu { get; set; }
        public int SoLuongCauThuToiDaTheoLoaiCauThu { get; set; } = 0;

        public bool Disalbled { get; set; } = false;
    }
}
