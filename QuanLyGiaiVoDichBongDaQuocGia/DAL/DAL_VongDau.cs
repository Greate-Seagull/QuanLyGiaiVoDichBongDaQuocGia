using QuanLyDaiLy.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    class DAL_VongDau
    {
        DatabaseHelper databaseHelper = new DatabaseHelper();

        public string LayMaVongDauMoi()
        {
            string query = "SELECT MaVongDau FROM VONGDAU ORDER BY MaVongDau DESC LIMIT 1";
            DataTable result = databaseHelper.ExecuteQuery(query);

            if(result.Rows.Count == 0)
            {
                return "VD001";
            }

            string maHienTai = result.Rows[0]["MaVongDau"].ToString();
            int soMoi = int.Parse(maHienTai.Substring(2)) + 1;

            return "VD" + soMoi.ToString("D3");
        }

        public bool LuuThongTin(DTO_VongDau vongDau)
        {
            string query = "INSERT INTO VONGDAU (MaVongDau, TenVongDau) " +
                          $"VALUES('{vongDau.MaVongDau}', '{vongDau.TenVongDau}') " +
                          $"ON DUPLICATE KEY UPDATE " +
                          $"MaVongDau = VALUES(MaVongDau), " +
                          $"TenVongDau = VALUES(TenVongDau); ";

            return databaseHelper.ExecuteNonQuery(query) > 0;
        }
    }
}
