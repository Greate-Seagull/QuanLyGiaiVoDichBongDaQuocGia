using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.DTO
{
    public class DTO_BanThang
    {   
        public string? MaBanThang { get; set; }
        public DTO_TranDau? TranDau { get; set; }
        public DTO_CauThu? CauThu { get; set; }
        public int ThoiDiemGhiBan { get; set; }
        internal DTO_LoaiBanThang? LoaiBanThang { get; set; }

        public override string ToString()
        {
            return $"{CauThu} - {CauThu?.DoiBong} - {TranDau} - {LoaiBanThang} - {ThoiDiemGhiBan}";
        }
    }
}
