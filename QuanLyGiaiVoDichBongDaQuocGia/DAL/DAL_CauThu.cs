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
    class DAL_CauThu
    {
        DatabaseHelper databaseHelper = new DatabaseHelper();

        public string LayMaCauThuHienTai()
        {
            string query = "SELECT MaCauThu FROM CAUTHU ORDER BY MaCauThu DESC LIMIT 1";
            DataTable result = databaseHelper.ExecuteQuery(query);

            if(result.Rows.Count == 0)
            {
                return "CT000";
            }

            return result.Rows[0]["MaCauThu"].ToString();
        }

        public bool LuuDanhSachCauThuMoi(List<DTO_CauThu> insertList)
        {
            string query = "INSERT INTO CAUTHU (MaCauThu, TenCauThu, NgaySinh, GhiChu, MaDoiBong, MaLoaiCauThu) " +
                           "VALUES ";

            query += string.Join(", ", insertList.Select(cauThu =>
                                $"('{cauThu.MaCauThu}', '{cauThu.TenCauThu}', '{cauThu.NgaySinh.Date.ToString(DataFormat.DataFormat.DateFormat)}', " +
                                $"'{cauThu.GhiChu}', '{cauThu.DoiBong.MaDoiBong}', '{cauThu.MaLoaiCauThu}')"
                            ));

            query += "ON DUPLICATE KEY UPDATE " +
                    "TenCauThu = VALUES(TenCauThu)," +
                    "NgaySinh = VALUES(NgaySinh)," +
                    "GhiChu = VALUES(GhiChu)," +
                    "MaLoaiCauThu = VALUES(MaLoaiCauThu); ";

            return databaseHelper.ExecuteNonQuery(query) > 0;
        }

        public bool XoaDanhSachCauThu(List<DTO_CauThu> deleteList)
        {
            string query = "";

            foreach (DTO.DTO_CauThu cauThu in deleteList)
            {
                query += "UPDATE CAUTHU " +
                        $"SET Deleted = 1 " +
                        $"WHERE MaCauThu = '{cauThu.MaCauThu}'; ";
            }

            return databaseHelper.ExecuteNonQuery(query) > 0;
        }

    }
}
