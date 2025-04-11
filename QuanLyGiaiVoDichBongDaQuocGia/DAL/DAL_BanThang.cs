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
    class DAL_BanThang
    {
        DatabaseHelper databaseHelper = new DatabaseHelper();
        public string LayMaBanThangHienTai()
        {
            string query = "SELECT MaBanThang FROM BANTHANG ORDER BY MaBanThang DESC LIMIT 1";
            DataTable result = databaseHelper.ExecuteQuery(query);

            if (result.Rows.Count == 0)
            {
                return "BT000";
            }

            return result.Rows[0]["MaBanThang"].ToString();
        }

        public bool LuuDanhSachBanThang(List<DTO_BanThang> upsertList)
        {
            string query = "INSERT INTO BANTHANG (MaBanThang, MaTranDau, MaCauThu, MaLoaiBanThang, ThoiDiem) VALUES ";

            query += string.Join(", ", upsertList.Select(banThang =>
                                 $"('{banThang.MaBanThang}', '{banThang.TranDau.MaTranDau}', '{banThang.CauThu.MaCauThu}', " +
                                 $"'{banThang.LoaiBanThang.MaLoaiBanThang}', '{banThang.ThoiDiemGhiBan}')"));

            query += "ON DUPLICATE KEY UPDATE " +
                     "MaTranDau = VALUES(MaTranDau), " +
                     "MaCauThu = VALUES(MaCauThu), " +
                     "MaLoaiBanThang = VALUES(MaLoaiBanThang), " +
                     "ThoiDiem = VALUES(ThoiDiem); ";

            return databaseHelper.ExecuteNonQuery(query) > 0;
        }

        public bool XoaDanhSachBanThang(List<DTO_BanThang> deleteList)
        {
            string query = "UPDATE BANTHANG " +
                           "SET Deleted = 1 " +
                           "WHERE MaBanThang IN ( ";

            query += string.Join(", ", deleteList.Select(banThang => $"'{banThang.MaBanThang}'"));

            query += "); ";

            return databaseHelper.ExecuteNonQuery(query) > 0;
        }
    }
}
