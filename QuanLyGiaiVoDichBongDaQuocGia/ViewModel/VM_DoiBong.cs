using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.ViewModel
{
    public class VM_DoiBong
    {
        public string MaDoiBong { get; set; }
        public string? TenDoiBong { get; set; }
        public int SoTranThang { get; set; } = 0;
        public int SoTranHoa { get; set; } = 0;
        public int SoTranThua { get; set; } = 0;
        public int SoBanThang { get; set; } = 0;
        public int SoBanThua { get; set; } = 0;
        public int HieuSo => SoTranThang - SoTranThua;
        public int Diem { get; set; } = 0;
        public int Hang { get; set; } = 0;
    }
}
