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

        public string LayMaDoiBongMoi()
        {
            return DAL_doiBong.LayMaDoiBongMoi();
        }

        public bool TiepNhanDoiBongMoi(DTO_DoiBong doiBong, Manager.Manager<DTO.DTO_CauThu> danhSachCauThu, DTO_ThamSo thamSo)
        {
            this.KiemTraNhapLieu(doiBong);
            this.KiemTraSoLuongCauThuToiThieu(danhSachCauThu, thamSo);
            this.KiemTraSoLuongCauThuToiDa(danhSachCauThu, thamSo);
            BUS_loaiCauThu.KiemTraSoLuongCauThuToiDa(danhSachCauThu);

            using (var transaction = new TransactionScope())
            {
                this.LuuDoiBong(doiBong);
                BUS_cauThu.LuuCauThu(danhSachCauThu);
                transaction.Complete();
                return true;
            }            
        }

        private void LuuDoiBong(DTO_DoiBong doiBong)
        {
            DAL_doiBong.LuuDoiBong(doiBong);
        }

        private void KiemTraSoLuongCauThuToiDa(Manager.Manager<DTO.DTO_CauThu> danhSachCauThu, DTO_ThamSo thamSo)
        {
            if (danhSachCauThu.CountActive > thamSo.SoLuongCauThuToiDa)
                throw new Exception($"Vi phạm số lượng cầu thủ tối đa {danhSachCauThu.CountActive} > {thamSo.SoLuongCauThuToiDa}");
        }

        private void KiemTraSoLuongCauThuToiThieu(Manager.Manager<DTO.DTO_CauThu> danhSachCauThu, DTO_ThamSo thamSo)
        {
            if (danhSachCauThu.CountActive < thamSo.SoLuongCauThuToiThieu)
                throw new Exception($"Vi phạm số lượng cầu thủ tối thiểu {danhSachCauThu.CountActive} < {thamSo.SoLuongCauThuToiThieu}");
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
