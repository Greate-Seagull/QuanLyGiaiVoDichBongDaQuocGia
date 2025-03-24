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

        public string LayMaCauThuMoi()
        {
            string query = "SELECT MaCauThu FROM CAUTHU ORDER BY MaCauThu DESC LIMIT 1";
            DataTable result = databaseHelper.ExecuteQuery(query);

            if(result.Rows.Count == 0)
            {
                return "CT001";
            }

            string maCauThu_prev = result.Rows[0]["MaCauThu"].ToString();
            int soMoi = int.Parse(maCauThu_prev.Substring(2)) + 1;
            return "CT" + soMoi.ToString("D3");
        }

        internal bool LuuCauThu(DTO_CauThu cauThu)
        {
            string query = "INSERT INTO CAUTHU (MaCauThu, TenCauThu, NgaySinh, GhiChu, MaDoiBong, MaLoaiCauThu) " +
                          $"VALUES ('{cauThu.MaCauThu}', '{cauThu.TenCauThu}', '{cauThu.NgaySinh.Date.ToString(DataFormat.DataFormat.DateFormat)}', '{cauThu.GhiChu}', '{cauThu.DoiBong.MaDoiBong}', '{cauThu.MaLoaiCauThu}') " +
                           "ON DUPLICATE KEY UPDATE " +
                           "TenCauThu = VALUES(TenCauThu)," +
                           "NgaySinh = VALUES(NgaySinh)," +
                           "GhiChu = VALUES(GhiChu)," +
                           "MaLoaiCauThu = VALUES(MaLoaiCauThu); ";

            return databaseHelper.ExecuteNonQuery(query) > 0;
        }

        public bool XoaCauThu(DTO_CauThu cauThu)
        {
            string query = "UPDATE CAUTHU " +
                          $"SET Deleted = 1 " +
                          $"WHERE MaCauThu = '{cauThu.MaCauThu}'";

            return databaseHelper.ExecuteNonQuery(query) > 0;
        }

        public bool LuuDanhSachCauThuMoi(List<DTO_CauThu> insertList)
        {
            string query = "";
            
            foreach(DTO.DTO_CauThu cauThu in insertList)
            {
                query += "INSERT INTO CAUTHU (MaCauThu, TenCauThu, NgaySinh, GhiChu, MaDoiBong, MaLoaiCauThu) " +
                        $"VALUES ('{cauThu.MaCauThu}', '{cauThu.TenCauThu}', '{cauThu.NgaySinh.Date.ToString(DataFormat.DataFormat.DateFormat)}', '{cauThu.GhiChu}', '{cauThu.DoiBong.MaDoiBong}', '{cauThu.MaLoaiCauThu}') " +
                        "ON DUPLICATE KEY UPDATE " +
                        "TenCauThu = VALUES(TenCauThu)," +
                        "NgaySinh = VALUES(NgaySinh)," +
                        "GhiChu = VALUES(GhiChu)," +
                        "MaLoaiCauThu = VALUES(MaLoaiCauThu); ";
            }

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
