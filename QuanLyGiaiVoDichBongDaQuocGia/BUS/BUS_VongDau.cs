using Microsoft.EntityFrameworkCore;
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
    public class BUS_VongDau
    {
        private readonly DAL_VongDau _DAL;
        private readonly BUS_TranDau _BUS_TranDau;

        public BUS_VongDau(DAL_VongDau dAL, BUS_TranDau bUS_TranDau)
        {
            _DAL = dAL;
            _BUS_TranDau = bUS_TranDau;
        }

        public bool LapLichThiDau(DTO_VongDau vongDau)
        {
            var danhSachTam = new List<DTO_VongDau> { vongDau };

            this.KiemTraNhapLieu(danhSachTam);

            using(var transaction = _DAL.Context.Database.BeginTransaction())
            {
                try
                {
                    _BUS_TranDau.KiemTraNhapLieu(vongDau.CacTranDau);
                    if(_DAL.ExistsLocally(vongDau) == false) _DAL.Add(vongDau);
                    _DAL.SaveChanges();
                    transaction.Commit();
                    return true;
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        private void KiemTraNhapLieu(IEnumerable<DTO_VongDau> danhSachKiemTra)
        {
            foreach (var entity in danhSachKiemTra)
            {
                if (string.IsNullOrEmpty(entity.MaVongDau))
                    throw new Exception("Mã vòng đấu không được để trống");
            }
        }
    }
}
