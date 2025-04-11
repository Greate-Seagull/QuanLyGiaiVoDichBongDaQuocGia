using QuanLyDaiLy.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.BUS;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.Manager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.WebSockets;
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

        internal List<DTO_TranDau> LayDanhSachTranDau(HashSet<string> columns) //Use hashset to prevent duplicates automatically
        {
            //Make query
            string query = "SELECT MaTranDau ";

            if (columns.Any())
                query += ", " + string.Join(", ", columns);

            query += " FROM TRANDAU " +
                     " WHERE Deleted = 0; ";
            
            //Prepare for main action
            var result = databaseHelper.ExecuteQuery(query);

            var columnActions = new List<Action<DataRow, DTO_TranDau>>();
            var danhSachTranDau = new List<DTO_TranDau>();

            //(Lazy) Get necessary action and load from cache
            if (columns.Contains("MaVongDau"))
            {
                var danhSachVongDau = new BUS_VongDau().LayDanhSachVongDau();
                columnActions.Add((row, tranDau) => tranDau.VongDau = danhSachVongDau.GetReadData(row["MaVongDau"].ToString()));
            }
            if(columns.Contains("MaDoi1") || columns.Contains("MaDoi2"))
            {
                var danhSachDoiBong = new BUS_DoiBong().LayDanhSachDoiBong();
                if (columns.Contains("MaDoi1"))
                    columnActions.Add((row, tranDau) => tranDau.DoiBong1 = danhSachDoiBong.GetReadData(row["MaDoi1"].ToString()));
                if (columns.Contains("MaDoi2"))
                    columnActions.Add((row, tranDau) => tranDau.DoiBong2 = danhSachDoiBong.GetReadData(row["MaDoi2"].ToString()));
            }
            if (columns.Contains("NgayGio"))
                columnActions.Add((row, tranDau) => tranDau.NgayGio = (DateTime)row["NgayGio"]);
            if (columns.Contains("TiSoDoi1"))
                columnActions.Add((row, tranDau) => tranDau.TiSoDoi1 = (int)row["TiSoDoi1"]);
            if (columns.Contains("TiSoDoi2"))
                columnActions.Add((row, tranDau) => tranDau.TiSoDoi1 = (int)row["TiSoDoi2"]);
            
            //Load into DTO
            foreach (DataRow row in result.Rows)
            {
                DTO_TranDau tranDau = new DTO_TranDau(row["MaTranDau"].ToString());
                danhSachTranDau.Add(tranDau);

                foreach(var action in columnActions)
                {
                    action(row, tranDau);
                }
            }

            //--------------------
            return danhSachTranDau;
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
