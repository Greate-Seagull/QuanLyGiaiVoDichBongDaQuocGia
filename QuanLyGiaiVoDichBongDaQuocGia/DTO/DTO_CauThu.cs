using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.DTO
{
    public class DTO_CauThu
    {
        private string maCauThu;
        private string tenCauThu;
        private DateTime ngaySinh;
        private string ghiChu;
        private DTO_DoiBong doiBong;
        private DTO_LoaiCauThu loaiCauThu;

        public DTO_CauThu(string maCauThu, string tenCauThu, DateTime ngaySinh, string ghiChu, DTO_DoiBong doiBong, DTO_LoaiCauThu loaiCauThu)
        {
            this.MaCauThu = maCauThu;
            this.TenCauThu = tenCauThu;
            this.NgaySinh = ngaySinh;
            this.GhiChu = ghiChu;
            this.DoiBong = doiBong;
            this.LoaiCauThu = loaiCauThu;
        }

        public string MaCauThu { get => maCauThu; set => maCauThu = value; }
        public string TenCauThu { get => tenCauThu; set => tenCauThu = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
        internal DTO_DoiBong DoiBong { get => doiBong; set => doiBong = value; }
        internal DTO_LoaiCauThu LoaiCauThu { get => loaiCauThu; set => loaiCauThu = value; }
    }
}
