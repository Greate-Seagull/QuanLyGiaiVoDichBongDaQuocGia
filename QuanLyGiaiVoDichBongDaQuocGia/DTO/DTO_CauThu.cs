using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.DTO
{
    public class DTO_CauThu
    {
        public string? MaCauThu { get; set; }
        public string? TenCauThu { get; set; }
        public DateTime NgaySinh { get; set; }
        public string? MaLoaiCauThu { get; set; }
        public string? GhiChu { get; set; }
        internal DTO_DoiBong? DoiBong { get; set; }
        internal DTO_LoaiCauThu? LoaiCauThu { get; set; }

        public override string ToString()
        {
            return TenCauThu;
        }
    }
}
