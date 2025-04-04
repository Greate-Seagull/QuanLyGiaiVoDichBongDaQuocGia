using Org.BouncyCastle.Cms;
using QuanLyDaiLy.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.Manager;
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

        internal List<DTO_VongDau> LayDanhSachVongDau()
        {
            string query = "SELECT MaVongDau, TenVongDau " +
                           "FROM VONGDAU " +
                           "WHERE Deleted = 0; ";
            DataTable result = databaseHelper.ExecuteQuery(query);

            List<DTO_VongDau> danhSachVongDau = new List<DTO_VongDau>();
            foreach(DataRow row in result.Rows)
            {
                danhSachVongDau.Add(new DTO_VongDau(row["MaVongDau"].ToString(),
                                                    row["TenVongDau"].ToString()));
            }

            return danhSachVongDau;
        }

        internal bool LuuDanhSachTranDau(List<DTO_VongDau> upsert)
        {
            string query = "INSERT INTO VONGDAU (MaVongDau, TenVongDau) VALUES ";

            query += string.Join(", ", upsert.Select(vongDau =>
                                $"('{vongDau.MaVongDau}', '{vongDau.TenVongDau}')"
                                ));
            
            query += $"ON DUPLICATE KEY UPDATE " +
                     $"MaVongDau = VALUES(MaVongDau), " +
                     $"TenVongDau = VALUES(TenVongDau); ";

            return databaseHelper.ExecuteNonQuery(query) > 0;
        }

        internal bool XoaDanhSachTranDau(List<DTO_VongDau> delete)
        {
            string query = "";

            foreach (var vongDau in delete)
            {
                query += "UPDATE VONGDAU " +
                        $"SET Deleted = 1 " +
                        $"WHERE MaVongDau = '{vongDau.MaVongDau}'; ";
            }

            return databaseHelper.ExecuteNonQuery(query) > 0;
        }
    }
}
