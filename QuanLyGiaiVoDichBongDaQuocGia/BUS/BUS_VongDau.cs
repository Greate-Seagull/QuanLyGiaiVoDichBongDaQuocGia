using QuanLyGiaiVoDichBongDaQuocGia.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace QuanLyGiaiVoDichBongDaQuocGia.BUS
{          
    class BUS_VongDau
    {
        private readonly DAL_VongDau _DAL;
        private readonly BUS_TranDau _BUS_TranDau;

        public BUS_VongDau(DAL_VongDau dAL, BUS_TranDau bUS_TranDau)
        {
            _DAL = dAL;
            _BUS_TranDau = bUS_TranDau;
        }

        public List<DTO_VongDau> LayDanhSach(Expression<Func<DTO_VongDau, DTO_VongDau>>? selector = default, Expression<Func<DTO_VongDau, bool>>? filter = default, bool isTracking = false)
        {
            return _DAL.LayDanhSach(selector, filter, isTracking);
        }

        public DTO_VongDau LayMaMoiNhat()
        {
            return _DAL.LayMaMoiNhat();
        }

        public bool LapLichThiDau(DTO_VongDau vongDau, List<DTO_TranDau> danhSachTranDau)
        {
            var danhSachTam = new List<DTO_VongDau> { vongDau };

            this.KiemTraNhapLieu(danhSachTam);

            using(var transaction = new TransactionScope())
            {
                this.LuuThongTin(danhSachTam);
                _BUS_TranDau.LapTranDau(danhSachTranDau);

                transaction.Complete();
                return true;
            }
        }

        private bool LuuThongTin(List<DTO_VongDau> danhSachLuu)
        {
            _DAL.LuuDanhSach(danhSachLuu);
            return true;
        }

        private void KiemTraNhapLieu(List<DTO_VongDau> danhSachKiemTra)
        {
            foreach (var entity in danhSachKiemTra)
            {
                if (string.IsNullOrEmpty(entity.TenVongDau))
                    throw new Exception("Tên vòng đấu không được để trống");
            }
        }
    }
}
