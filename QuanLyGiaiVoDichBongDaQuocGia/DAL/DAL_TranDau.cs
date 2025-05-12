using MySql.Data.MySqlClient;
using QuanLyDaiLy.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.BUS;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.FilterHelper;
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

        //For lazy retrieve
        Dictionary<TranDauColumn, Action<DTO_TranDau, string, object>> columnsLoader = new Dictionary<TranDauColumn, Action<DTO_TranDau, string, object>>
        {
            { TranDauColumn.MaTranDau, (storer, filters, value) => storer.MaTranDau = value.ToString() },
            { TranDauColumn.MaVongDau, (storer, filters, value) => storer.VongDau = new BUS_VongDau().LayDanhSach(filters).GetReadData(value.ToString()) },
            { TranDauColumn.MaDoi1, (storer, filters, value) => storer.DoiBong1 = new BUS_DoiBong().LayDanhSach(filters).GetReadData(value.ToString()) },
            { TranDauColumn.MaDoi2, (storer, filters, value) => storer.DoiBong2 = new BUS_DoiBong().LayDanhSach(filters).GetReadData(value.ToString()) },
            { TranDauColumn.NgayGio, (storer, filters, value) => storer.NgayGio = (DateTime)value },
            { TranDauColumn.TiSoDoi1, (storer, filters, value) => storer.TiSoDoi1 = (int)value },
            { TranDauColumn.TiSoDoi2, (storer, filters, value) => storer.TiSoDoi2 = (int)value }
        };

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

        internal List<DTO_TranDau> LayDanhSach(HashSet<TranDauColumn> columns, string? filters) //Use hashset to prevent duplicates automatically
        {
            //Make query
            string query = $"SELECT {string.Join(", ", columns)} " +
                            "FROM TRANDAU " +
                            "WHERE Deleted = 0 ";

            if (string.IsNullOrEmpty(filters) == false)
                query += "AND " + filters;

            //Prepare for main action
            var result = databaseHelper.ExecuteQuery(query);

            //Filter for retrieving object from cache
            var filtersForColumns = new Dictionary<TranDauColumn, string>();

            if (columns.Contains(TranDauColumn.MaVongDau))
            {
                filtersForColumns[TranDauColumn.MaVongDau] = FilterBuilder<VongDauColumn>
                    .Where(VongDauColumn.MaVongDau).In(result.AsEnumerable().Select(row => row.Field<string>("MaVongDau")).ToHashSet()).Build();
            }
            if (columns.Contains(TranDauColumn.MaDoi1))
            {
                filtersForColumns[TranDauColumn.MaDoi1] = FilterBuilder<DoiBongColumn>
                    .Where(DoiBongColumn.MaDoiBong).In(result.AsEnumerable().Select(row => row.Field<string>("MaDoi1")).ToHashSet()).Build();
            }
            if (columns.Contains(TranDauColumn.MaDoi2))
            {
                filtersForColumns[TranDauColumn.MaDoi2] = FilterBuilder<DoiBongColumn>
                    .Where(DoiBongColumn.MaDoiBong).In(result.AsEnumerable().Select(row => row.Field<string>("MaDoi2")).ToHashSet()).Build();
            }

            //Load into DTO
            var finalResult = new List<DTO_TranDau>();

            foreach (DataRow row in result.Rows)
            {
                DTO_TranDau obj = new DTO_TranDau();
                finalResult.Add(obj);

                foreach (var col in columns)
                {
                    columnsLoader[col](obj, filtersForColumns.GetValueOrDefault(col), row[col.ToString()]);
                }
            }

            return finalResult;
        }

        public bool XoaDanhSach(List<DTO_TranDau> delete)
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

        public bool LuuDanhSach(List<DTO_TranDau> upsertList, HashSet<TranDauColumn> columns)
        {
            var queryBuilder = new StringBuilder();
            var parameters = new List<MySqlParameter>();

            string selectedColumnsBuild = string.Join(", ", columns);
            queryBuilder.Append($"INSERT INTO TRANDAU ({selectedColumnsBuild}) VALUES ");

            int paramCounter = 0;
            foreach (var row in upsertList)
            {
                var paramStringBuilder = new List<string>();

                foreach (var col in columns)
                {
                    string parameter = $"{col}{paramCounter}";
                    paramStringBuilder.Add(parameter);
                    parameters.Add(new MySqlParameter(parameter, TranDauConverter.Instance[col](row)));
                }

                queryBuilder.Append($"({string.Join(", ", paramStringBuilder)})");
                paramCounter++;
            }

            queryBuilder.Append("ON DUPLICATE KEY UPDATE " + string.Join(", ", columns.Select(col => $"{col} = VALUES({col})")));

            string query = queryBuilder.ToString();

            return databaseHelper.ExecuteNonQuery(query, parameters.ToArray()) > 0;
        }
    }
}
