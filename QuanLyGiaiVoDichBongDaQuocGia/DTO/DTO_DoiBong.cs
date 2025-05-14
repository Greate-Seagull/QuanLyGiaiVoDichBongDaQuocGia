using QuanLyGiaiVoDichBongDaQuocGia.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.DTO
{
    public class DTO_DoiBong
    {
        public string? MaDoiBong { get; set; }
        public string? TenDoiBong { get; set; }
        public string? TenSanNha { get; set; }
        public bool IsDeleted { get; set; }
        public override string ToString()
        {
            return TenDoiBong;
        }
    }
}
