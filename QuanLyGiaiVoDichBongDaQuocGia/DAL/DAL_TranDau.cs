using QuanLyDaiLy.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.BUS;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    class DAL_TranDau
    {
        DatabaseHelper databaseHelper = new DatabaseHelper();

        public string LayMaTranDauHienTai()
        {
            string query = "SELECT MaTranDau FROM TRANDAU ORDER BY MaTranDau DESC LIMIT 1";
            DataTable result = databaseHelper.ExecuteQuery(query);

            if(result.Rows.Count == 0)
            {
                return "TD000";
            }

            return result.Rows[0]["MaTranDau"].ToString();
        }

        internal List<DTO_TranDau> LayDanhSachCapDauLoaiTru(DTO_VongDau vongDauXuLy)
        {
            //Load from database
            string query = "SELECT MaTranDau, MaDoi1, MaDoi2 " +
                           "FROM TRANDAU " +
                           "WHERE Deleted = 0 AND " +
                                $"MaVongDau != '{vongDauXuLy.MaVongDau}'; ";
            DataTable result = databaseHelper.ExecuteQuery(query);

            //Load from cache
            BUS_DoiBong BUS_doiBong = new BUS_DoiBong();
            Manager.DataManager<DTO_DoiBong> danhSachDoiBong = BUS_doiBong.LayDanhSachDoiBong();
            List<DTO_TranDau> danhSachCapDau = new List<DTO_TranDau>();
            foreach (DataRow row in result.Rows)
            {
                danhSachCapDau.Add(new DTO_TranDau(row["MaTranDau"].ToString(),
                                                   danhSachDoiBong.GetReadData(row["MaDoi1"].ToString()),
                                                   danhSachDoiBong.GetReadData(row["MaDoi2"].ToString()),
                                                   default, default
                                                   )
                                   );
            }

            return danhSachCapDau;
        }

        public bool LuuDanhSachTranDau(List<DTO_TranDau> upsert)
        {
            string query = "INSERT INTO TRANDAU (MaTranDau, MaVongDau, MaDoi1, MaDoi2, NgayGio) VALUES ";

            query += string.Join(", ", upsert.Select(tranDau => $"('{tranDau.MaTranDau}', '{tranDau.VongDau.MaVongDau}', " +
                                                                $"'{tranDau.DoiBong1.MaDoiBong}', '{tranDau.DoiBong2.MaDoiBong}', " +
                                                                $"'{tranDau.NgayGio.ToString(DataFormat.DataFormat.DateTimeFormat)}') "));

            query += "ON DUPLICATE KEY UPDATE " +
                     "MaDoi1 = VALUES(MaDoi1), " +
                     "MaDoi2 = VALUES(MaDoi2), " +
                     "NgayGio = VALUES(NgayGio); ";

            return databaseHelper.ExecuteNonQuery(query) > 0;
        }

        public bool XoaDanhSachTranDau(List<DTO_TranDau> delete)
        {
            string query = "";

            foreach(var tranDau in delete)
            {
                query += "UPDATE TRANDAU " +
                         "SET Deleted = 1 " +
                        $"WHERE MaTranDau = '{tranDau.MaTranDau}'; ";
            }

            return databaseHelper.ExecuteNonQuery(query) > 0;
        }        
    }
}
