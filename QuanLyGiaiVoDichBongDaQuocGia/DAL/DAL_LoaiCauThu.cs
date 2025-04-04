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
    public class DAL_LoaiCauThu
    {
        DatabaseHelper databaseHelper = new DatabaseHelper();

        public List<DTO.DTO_LoaiCauThu> LayDanhSachLoaiCauThu()
        {
            string query = "SELECT MaLoaiCauThu, TenLoaiCauThu, SoLuongCauThuToiDaTheoLoaiCauThu FROM LOAICAUTHU";
            DataTable result = databaseHelper.ExecuteQuery(query);

            List<DTO_LoaiCauThu> danhSachLoaiCauThu = new List<DTO_LoaiCauThu>();
            foreach (DataRow row in result.Rows)
            {
                danhSachLoaiCauThu.Add(new DTO_LoaiCauThu(row["MaLoaiCauThu"].ToString(), row["TenLoaiCauThu"].ToString(),
                                                          int.Parse(row["SoLuongCauThuToiDaTheoLoaiCauThu"].ToString())
                                                          )
                                       );
            }

            return danhSachLoaiCauThu;
        }
    }
}
