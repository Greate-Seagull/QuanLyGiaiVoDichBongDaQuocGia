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
    class DAL_DoiBong
    {
        DatabaseHelper databaseHelper = new DatabaseHelper();

        public string LayMaDoiBongMoi()
        {
            string query = "SELECT MaDoiBong FROM DOIBONG ORDER BY MaDoiBong DESC LIMIT 1";
            DataTable result = databaseHelper.ExecuteQuery(query);
            
            if(result.Rows.Count == 0)
            {
                return "DB001";
            }

            string maDoiBong_prev = result.Rows[0]["MaDoiBong"].ToString();
            int soMoi = int.Parse(maDoiBong_prev.Substring(2)) + 1;
            return "DB" + soMoi.ToString("D3");
        }

        public bool LuuDoiBong(DTO_DoiBong doiBong)
        {
            string query = "INSERT INTO DOIBONG (MaDoiBong, TenDoiBong, TenSanNha) " +
                          $"VALUES ('{doiBong.MaDoiBong}', '{doiBong.TenDoiBong}', '{doiBong.TenSanNha}') " +
                           "ON DUPLICATE KEY UPDATE " +
                           "TenDoiBong = VALUES(TenDoiBong), " +
                           "TenSanNha = VALUES(TenSanNha); ";
            
            return databaseHelper.ExecuteNonQuery(query) > 0;
        }

        public List<DTO_DoiBong> LayDanhSachDoiBong()
        {
            string query = "SELECT MaDoiBong, TenDoiBong, TenSanNha " +
                           "FROM DOIBONG " +
                           "WHERE Deleted = 0 ";

            DataTable result = databaseHelper.ExecuteQuery(query);

            List<DTO_DoiBong> danhSachDoiBong = new List<DTO_DoiBong>();

            foreach(DataRow row in result.Rows)
            {
                string maDoiBong = row["MaDoiBong"].ToString();
                string tenDoiBong = row["TenDoiBong"].ToString();
                string tenSan = row["TenSanNha"].ToString();

                danhSachDoiBong.Add(new DTO_DoiBong(maDoiBong, tenDoiBong, tenSan));
            }

            return danhSachDoiBong;
        }
    }
}
