using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.BUS
{    
    public class BUS_ThamSo
    {
        private readonly DAL_ThamSo _DAL;

        public BUS_ThamSo(DAL_ThamSo dAL)
        {
            _DAL = dAL;
        }

        internal DTO_ThamSo LayThamSoGhiNhanKetQua()
        {
            var query = _DAL.GetAll()
                            .Select(entity => new DTO_ThamSo
                            {
                                ThoiDiemGhiBanToiDa = entity.ThoiDiemGhiBanToiDa,
                                ThoiDiemGhiBanToiThieu = entity.ThoiDiemGhiBanToiThieu
                            });

            return query.AsNoTracking().First();
        }

        internal DTO_ThamSo LayThamSoLapBanXepHang()
        {
            var query = _DAL.GetAll()
                            .Select(entity => new DTO_ThamSo
                            {
                                DiemThang = entity.DiemThang,
                                DiemHoa = entity.DiemHoa,
                                DiemThua = entity.DiemThua
                            });

            return query.AsNoTracking().First();
        }

        internal DTO_ThamSo LayThamSoTiepNhanDoiBong()
        {
            var query = _DAL.GetAll()
                            .Select(entity => new DTO_ThamSo
                            {
                                TuoiCauThuToiDa = entity.TuoiCauThuToiDa,
                                TuoiCauThuToiThieu = entity.TuoiCauThuToiThieu,
                                SoLuongCauThuToiDa = entity.SoLuongCauThuToiDa,
                                SoLuongCauThuToiThieu = entity.SoLuongCauThuToiThieu
                            });

            return query.AsNoTracking().First();
        }
    }
}
