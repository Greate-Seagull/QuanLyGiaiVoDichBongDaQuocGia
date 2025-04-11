using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.DTO
{
    class DTO_LoaiBanThang
    {
        private string maLoaiBanThang;
        private string tenLoaiBanThang;

        public DTO_LoaiBanThang(string maLoaiBanThang, string tenLoaiBanThang)
        {
            this.MaLoaiBanThang = maLoaiBanThang;
            this.TenLoaiBanThang = tenLoaiBanThang;
        }

        public string MaLoaiBanThang { get => maLoaiBanThang; set => maLoaiBanThang = value; }
        public string TenLoaiBanThang { get => tenLoaiBanThang; set => tenLoaiBanThang = value; }

        public override string ToString()
        {
            return TenLoaiBanThang;
        }
    }
}
