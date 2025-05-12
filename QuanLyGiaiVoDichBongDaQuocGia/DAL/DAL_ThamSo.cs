using QuanLyDaiLy.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.BUS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    class DAL_ThamSo
    {
        DatabaseHelper databaseHelper = new DatabaseHelper();

        //For lazy retrieve
        Dictionary<ThamSoColumn, Action<DTO_ThamSo, string?, object>> columnsLoader = new Dictionary<ThamSoColumn, Action<DTO_ThamSo, string?, object>>
        {
            { ThamSoColumn.TuoiCauThuToiThieu, (storer, filters, value) => storer.TuoiCauThuToiThieu = (int)value },
            { ThamSoColumn.TuoiCauThuToiDa, (storer, filters, value) => storer.TuoiCauThuToiDa = (int)value },
            { ThamSoColumn.SoLuongCauThuToiThieu, (storer, filters, value) => storer.SoLuongCauThuToiThieu = (int)value },
            { ThamSoColumn.SoLuongCauThuToiDa, (storer, filters, value) => storer.SoLuongCauThuToiDa = (int)value },
            //{ ThamSoColumn.SoTranDauToiDaCuaMoiDoiTrongVongDau, (storer, filters, value) => storer.SoTranDauToiDaCuaMoiDoiTrongVongDau = (int)value },
            //{ ThamSoColumn.ThoiDiemGhiBanToiThieu, (storer, filters, value) => storer.ThoiDiemGhiBanToiThieu = (int)value },
            //{ ThamSoColumn.ThoiDiemGhiBanToiDa, (storer, filters, value) => storer.ThoiDiemGhiBanToiDa = (int)value }
        };

        public DTO_ThamSo LayThamSo(HashSet<ThamSoColumn> columns)
        {
            string query = $"SELECT {string.Join(", ", columns)} " +
                            "FROM THAMSO " +
                            "LIMIT 1 ";

            DataTable result = databaseHelper.ExecuteQuery(query);

            if(result.Rows.Count == 0)
            {
                return null;
            }

            //Load into DTO
            var obj = new DTO_ThamSo();

            foreach (var col in columns)
            {
                columnsLoader[col](obj, default, result.Rows[0][col.ToString()]);
            }

            return obj;
        }
    }
}
