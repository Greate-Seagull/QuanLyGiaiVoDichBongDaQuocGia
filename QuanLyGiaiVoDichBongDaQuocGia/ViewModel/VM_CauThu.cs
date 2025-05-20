using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.ViewModel
{
    internal class VM_CauThu
    {
        public string MaCauThu { get; set; }
        public string? TenCauThu { get; set; }
        public string? TenDoiBong { get; set; }
        public string? TenLoaiCauThu { get; set; }
        public int SoBanThang { get; set; } = 0;
    }
}
