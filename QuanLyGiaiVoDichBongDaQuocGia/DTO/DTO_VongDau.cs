using QuanLyGiaiVoDichBongDaQuocGia.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.DTO
{
    public class DTO_VongDau
    {
        public string? MaVongDau { get; set; }
        public string? TenVongDau { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public bool IsDeleted { get; set; }
        public override string ToString()
        {
            return TenVongDau;
        }
    }
}
