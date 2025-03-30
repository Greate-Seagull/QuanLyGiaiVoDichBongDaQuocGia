using QuanLyGiaiVoDichBongDaQuocGia.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace QuanLyGiaiVoDichBongDaQuocGia.BUS
{
    class BUS_VongDau
    {
        BUS_TranDau BUS_tranDau = new BUS_TranDau();
        DAL_VongDau DAL_vongDau = new DAL_VongDau();

        public string LayMaVongDauMoi()
        {
            return DAL_vongDau.LayMaVongDauMoi();
        }

        public bool LapLichThiDau(DTO_VongDau vongDau, Manager<DTO_TranDau> danhSachTranDau, DTO_ThamSo thamSo)
        {
            this.KiemTraNhapLieu(vongDau);
            this.KiemTraSoLuongTranDauToiThieu(danhSachTranDau);

            using(var transaction = new TransactionScope())
            {
                this.LuuThongTin(vongDau);
                BUS_tranDau.LapTranDau(danhSachTranDau);

                transaction.Complete();
                return true;
            }
        }

        private void KiemTraSoLuongTranDauToiThieu(Manager<DTO_TranDau> danhSachTranDau)
        {
            if (danhSachTranDau.CountActive < 1)
                throw new Exception($"Vi phạm số trận đấu tối thiểu {danhSachTranDau.CountActive} < 1");
        }

        private void KiemTraNhapLieu(DTO_VongDau vongDau)
        {
            if (string.IsNullOrEmpty(vongDau.TenVongDau))
                throw new Exception("Tên vòng đấu không được để trống");
        }

        public bool LuuThongTin(DTO_VongDau vongDau)
        {
            return DAL_vongDau.LuuThongTin(vongDau);
        }
    }
}
