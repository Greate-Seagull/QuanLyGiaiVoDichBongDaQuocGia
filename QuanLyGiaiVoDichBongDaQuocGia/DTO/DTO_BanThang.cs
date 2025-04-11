using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.DTO
{
    class DTO_BanThang
    {
        private string maBanThang;
        private DTO_TranDau tranDau;
        private DTO_CauThu cauThu;
        private DTO_LoaiBanThang loaiBanThang;
        private TimeOnly thoiDiemGhiBan;

        public DTO_BanThang(string maBanThang, DTO_TranDau tranDau, DTO_CauThu cauThu, DTO_LoaiBanThang loaiBanThang, TimeOnly thoiDiemGhiBan)
        {
            this.MaBanThang = maBanThang;
            this.TranDau = tranDau;
            this.CauThu = cauThu;
            this.LoaiBanThang = loaiBanThang;
            this.ThoiDiemGhiBan = thoiDiemGhiBan;
        }

        public string MaBanThang { get => maBanThang; set => maBanThang = value; }
        public DTO_TranDau TranDau { get => tranDau; set => tranDau = value; }
        public DTO_CauThu CauThu { get => cauThu; set => cauThu = value; }
        public TimeOnly ThoiDiemGhiBan { get => thoiDiemGhiBan; set => thoiDiemGhiBan = value; }
        internal DTO_LoaiBanThang LoaiBanThang { get => loaiBanThang; set => loaiBanThang = value; }

        public override string ToString()
        {
            return $"{CauThu} - {CauThu.DoiBong} - {TranDau} - {LoaiBanThang} - {ThoiDiemGhiBan}";
        }
    }
}
