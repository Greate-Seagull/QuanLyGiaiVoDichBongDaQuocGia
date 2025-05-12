using MySql.Data.MySqlClient;
using QuanLyDaiLy.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.BUS;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.FilterHelper;
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

        //For lazy retrieve
        Dictionary<DoiBongColumn, Action<DTO_DoiBong, string, object>> columnsLoader = new Dictionary<DoiBongColumn, Action<DTO_DoiBong, string, object>>
        {
            { DoiBongColumn.MaDoiBong, (storer, filters, value) => storer.MaDoiBong = value.ToString() },
            { DoiBongColumn.TenDoiBong, (storer, filters, value) => storer.TenDoiBong = value.ToString() },
            { DoiBongColumn.TenSanNha, (storer, filters, value) => storer.TenSanNha = value.ToString() }
        };

        //For lazy insert
        Dictionary<DoiBongColumn, Func<DTO_DoiBong, object>> columnsInserter = new Dictionary<DoiBongColumn, Func<DTO_DoiBong, object>>
        {
            { DoiBongColumn.MaDoiBong, storer => storer.MaDoiBong},
            { DoiBongColumn.TenDoiBong, storer => storer.TenDoiBong },
            { DoiBongColumn.TenSanNha, storer => storer.TenSanNha }
        };

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

        internal List<DTO_DoiBong> LayDanhSach(HashSet<DoiBongColumn> columns, string? filters) //Use hashset to prevent duplicates automatically
        {
            //Make query
            string query = $"SELECT {string.Join(", ", columns)} " +
                            "FROM DOIBONG " +
                            "WHERE Deleted = 0 ";

            if (string.IsNullOrEmpty(filters) == false)
                query += "AND " + filters;

            //Prepare for main action
            var result = databaseHelper.ExecuteQuery(query);

            //Load into DTO
            var finalResult = new List<DTO_DoiBong>();

            foreach (DataRow row in result.Rows)
            {
                DTO_DoiBong obj = new DTO_DoiBong();
                finalResult.Add(obj);

                foreach (var col in columns)
                {
                    columnsLoader[col](obj, default, row[col.ToString()]);
                }
            }

            return finalResult;
        }

        internal bool LuuDanhSach(List<DTO_DoiBong> upsertList, HashSet<DoiBongColumn> columns)
        {
            var queryBuilder = new StringBuilder();
            var parameters = new List<MySqlParameter>();

            string selectedColumnsBuild = string.Join(", ", columns);
            queryBuilder.Append($"INSERT INTO DOIBONG ({selectedColumnsBuild}) VALUES ");

            int paramCounter = 0;
            foreach (var row in upsertList)
            {
                var paramStringBuilder = new List<string>();

                foreach (var col in columns)
                {
                    string parameter = $"{col}{paramCounter}";
                    paramStringBuilder.Add(parameter);
                    parameters.Add(new MySqlParameter(parameter, columnsInserter[col](row)));
                }

                queryBuilder.Append($"({string.Join(", ", paramStringBuilder)})");
                paramCounter++;
            }

            queryBuilder.Append("ON DUPLICATE KEY UPDATE " + string.Join(", ", columns.Select(col => $"{col} = VALUES({col})")));

            string query = queryBuilder.ToString();

            return databaseHelper.ExecuteNonQuery(query, parameters.ToArray()) > 0;
        }

        internal bool XoaDanhSach(List<DTO_DoiBong> delete)
        {
            string query = "";

            foreach (var doiBong in delete)
            {
                query += "UPDATE DOIBONG " +
                        $"SET Deleted = 1 " +
                        $"WHERE MaDoiBong = '{doiBong.MaDoiBong}'; ";
            }

            return databaseHelper.ExecuteNonQuery(query) > 0;
        }
    }
}
