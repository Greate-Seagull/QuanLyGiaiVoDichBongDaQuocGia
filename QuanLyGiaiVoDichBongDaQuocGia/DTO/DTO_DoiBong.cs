using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.DTO
{
    public class DTO_DoiBong
    {
        private string maDoiBong;
        private string tenDoiBong;
        private string tenSanNha;

        public DTO_DoiBong(string maDoiBong, string tenDoiBong, string tenSanNha)
        {
            this.maDoiBong = maDoiBong;
            this.tenDoiBong = tenDoiBong;
            this.tenSanNha = tenSanNha;
        }

        public string MaDoiBong { get => maDoiBong; set => maDoiBong = value; }
        public string TenDoiBong { get => tenDoiBong; set => tenDoiBong = value; }
        public string TenSanNha { get => tenSanNha; set => tenSanNha = value; }
    }
}
