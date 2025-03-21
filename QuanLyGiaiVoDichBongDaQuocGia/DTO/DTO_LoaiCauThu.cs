using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.DTO
{
    public class DTO_LoaiCauThu
    {
        private string maLoaiCauThu;
        private string tenLoaiCauThu;
        private int soLuongCauThuToiDaTheoLoaiCauThu;

        public DTO_LoaiCauThu(string maLoaiCauThu, string tenLoaiCauThu, int soLuongCauThuToiDaTheoLoaiCauThu)
        {
            this.MaLoaiCauThu = maLoaiCauThu;
            this.TenLoaiCauThu = tenLoaiCauThu;
            this.SoLuongCauThuToiDaTheoLoaiCauThu = soLuongCauThuToiDaTheoLoaiCauThu;
        }

        public string MaLoaiCauThu { get => maLoaiCauThu; set => maLoaiCauThu = value; }
        public string TenLoaiCauThu { get => tenLoaiCauThu; set => tenLoaiCauThu = value; }
        public int SoLuongCauThuToiDaTheoLoaiCauThu { get => soLuongCauThuToiDaTheoLoaiCauThu; set => soLuongCauThuToiDaTheoLoaiCauThu = value; }
    }
}
