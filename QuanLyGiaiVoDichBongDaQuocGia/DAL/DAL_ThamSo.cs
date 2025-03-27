using QuanLyDaiLy.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
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

        public DTO_ThamSo LayThamSo()
        {
            string query = "SELECT TuoiCauThuToiThieu, TuoiCauThuToiDa, SoLuongCauThuToiThieu, SoLuongCauThuToiDa FROM THAMSO LIMIT 1";
            DataTable result = databaseHelper.ExecuteQuery(query);

            if(result.Rows.Count == 0)
            {
                return null;
            }

            int tuoiCauThuToiThieu = int.Parse(result.Rows[0]["TuoiCauThuToiThieu"].ToString());
            int tuoiCauThuToiDa = int.Parse(result.Rows[0]["TuoiCauThuToiDa"].ToString());
            int soLuongCauThuToiThieu = int.Parse(result.Rows[0]["SoLuongCauThuToiThieu"].ToString());
            int soLuongCauThuToiDa = int.Parse(result.Rows[0]["SoLuongCauThuToiDa"].ToString());

            return new DTO_ThamSo(tuoiCauThuToiThieu, tuoiCauThuToiDa, soLuongCauThuToiThieu, soLuongCauThuToiDa);
        }
    }
}
