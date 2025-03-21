using Org.BouncyCastle.Bcpg.OpenPgp;
using QuanLyDaiLy.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace QuanLyGiaiVoDichBongDaQuocGia.BUS
{
    class BUS_DoiBong
    {
        DAL.DAL_DoiBong DAL_doiBong = new DAL.DAL_DoiBong();        

        BUS_CauThu BUS_cauThu = new BUS_CauThu();
        BUS_LoaiCauThu BUS_loaiCauThu = new BUS_LoaiCauThu();
        BUS_ThamSo BUS_thamSo = new BUS_ThamSo();

        public string LayMaDoiBongMoi()
        {
            return DAL_doiBong.LayMaDoiBongMoi();
        }

        public bool ThemDoiBongMoi(DTO_DoiBong doiBong, List<DTO_CauThu> danhSachCauThu, DTO_ThamSo thamSo)
        {
            this.KiemTraNhapLieu(doiBong);

            this.KiemTraSoLuongCauThuToiThieu(danhSachCauThu, thamSo);
            this.KiemTraSoLuongCauThuToiDa(danhSachCauThu, thamSo);
            BUS_loaiCauThu.KiemTraSoLuongCauThuToiDa(danhSachCauThu);

            using (var transaction = new TransactionScope())
            {
                DAL_doiBong.ThemDoiBongMoi(doiBong);
                
                foreach(DTO_CauThu cauThu in danhSachCauThu)
                {
                    BUS_cauThu.ThemCauThuMoi(cauThu);
                }

                transaction.Complete();
                return true;
            }
        }

        private void KiemTraSoLuongCauThuToiDa(List<DTO_CauThu> danhSachCauThu, DTO_ThamSo thamSo)
        {
            if (danhSachCauThu.Count > thamSo.SoLuongCauThuToiDa)
                throw new Exception("Vi phạm số lượng cầu thủ tối đa");
        }

        private void KiemTraSoLuongCauThuToiThieu(List<DTO_CauThu> danhSachCauThu, DTO_ThamSo thamSo)
        {
            if (danhSachCauThu.Count < thamSo.SoLuongCauThuToiThieu)
                throw new Exception("Vi phạm số lượng cầu thủ tối thiểu");
        }

        private void KiemTraNhapLieu(DTO_DoiBong doiBong)
        {
            if (string.IsNullOrEmpty(doiBong.TenDoiBong))
                throw new Exception("Tên đội bóng không được để trống");
            if (string.IsNullOrEmpty(doiBong.TenSanNha))
                throw new Exception("Tên sân nhà không được để trống");
        }
    }
}
