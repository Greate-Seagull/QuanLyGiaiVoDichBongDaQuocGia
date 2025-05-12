using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.DTO
{
    public class DTO_LoaiBanThang
    {
        public string? MaLoaiBanThang { get; set; }
        public string? TenLoaiBanThang { get; set; }

        public override string ToString()
        {
            return TenLoaiBanThang;
        }
    }

    public enum LoaiBanThangColumn
    {
        MaLoaiBanThang,
        TenLoaiBanThang
    }
}
