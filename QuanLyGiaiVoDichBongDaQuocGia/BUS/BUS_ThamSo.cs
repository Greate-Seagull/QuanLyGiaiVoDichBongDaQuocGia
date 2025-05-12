using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.BUS
{
    public enum ThamSoColumn
    {
        TuoiCauThuToiThieu,
        TuoiCauThuToiDa,
        SoLuongCauThuToiThieu,
        SoLuongCauThuToiDa,
        SoTranDauToiDaCuaMoiDoiTrongVongDau,
        ThoiDiemGhiBanToiThieu,
        ThoiDiemGhiBanToiDa
    }
    class BUS_ThamSo
    {
        DAL.DAL_ThamSo DAL_thamSo = new DAL.DAL_ThamSo();

        private readonly string THAMSO = "THAMSO";

        public DTO_ThamSo LayThamSo(params ThamSoColumn[] columns)
        {
            return CacheManager.GetOrLoad(THAMSO, () => DAL_thamSo.LayThamSo(columns.ToHashSet()));
        }
    }
}
