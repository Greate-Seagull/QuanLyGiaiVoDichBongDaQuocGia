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

        internal List<DTO_VongDau> LayDanhSachVongDauTraCuu()
        {
            var query = _DAL.GetAll()
                            .Select(obj => new DTO_VongDau
                            {
                                MaVongDau = obj.MaVongDau,
                                TenVongDau = obj.TenVongDau,
                                NgayBatDau = obj.NgayBatDau,
                                NgayKetThuc = obj.NgayKetThuc
                            });

            return query.AsNoTracking().ToList();
        }

        internal IEnumerable<DTO_VongDau> TraCuuVongDauTheoMaVongDau(IEnumerable<DTO_VongDau> danhSachVongDau, string maVongDau)
        {
            var result = danhSachVongDau;

            if (string.IsNullOrEmpty(maVongDau) == false)
                result = result.Where(entity => entity.MaVongDau == maVongDau);

            return result;
        }

        internal IEnumerable<DTO_VongDau> TraCuuVongDauTheoNgayBatDau(IEnumerable<DTO_VongDau> danhSachVongDau, 
                                                                      DateTime? startNgayBatDau, DateTime? endNgayBatDau)
        {
            var result = danhSachVongDau;

            if (startNgayBatDau is not null)
                result = result.Where(entity => entity.NgayBatDau >= startNgayBatDau);
            if (endNgayBatDau is not null)
                result = result.Where(entity => entity.NgayBatDau <= endNgayBatDau);

            return result;
        }

        internal IEnumerable<DTO_VongDau> TraCuuVongDauTheoNgayKetThuc(IEnumerable<DTO_VongDau> danhSachVongDau,
                                                                       DateTime? startNgayKetThuc, DateTime? endNgayKetThuc)
        {
            var result = danhSachVongDau;

            if (startNgayKetThuc is not null)
                result = result.Where(entity => entity.NgayKetThuc >= startNgayKetThuc);
            if (endNgayKetThuc is not null)
                result = result.Where(entity => entity.NgayKetThuc <= endNgayKetThuc);

            return result;
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
