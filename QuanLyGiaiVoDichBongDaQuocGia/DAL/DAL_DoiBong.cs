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

        public bool ThemDoiBongMoi(DTO_DoiBong doiBong)
        {
            string query = "INSERT INTO DOIBONG (MaDoiBong, TenDoiBong, TenSanNha) " +
                          $"VALUES ('{doiBong.MaDoiBong}', '{doiBong.TenDoiBong}', '{doiBong.TenSanNha}')";
            
            return databaseHelper.ExecuteNonQuery(query) > 0;
        }
    }
}
