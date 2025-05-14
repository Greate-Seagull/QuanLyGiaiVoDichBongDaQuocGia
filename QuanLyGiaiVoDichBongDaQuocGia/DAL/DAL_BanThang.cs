using MySql.Data.MySqlClient;
using QuanLyDaiLy.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.BUS;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.FilterHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    class DAL_BanThang
    {
        DatabaseHelper databaseHelper = new DatabaseHelper();

        //For lazy retrieve
        Dictionary<BanThangColumn, Action<DTO_BanThang, string, object>> columnsLoader = new Dictionary<BanThangColumn, Action<DTO_BanThang, string, object>>
        {
            { BanThangColumn.MaBanThang, (storer, filters, value) => storer.MaBanThang = value.ToString() },
            { BanThangColumn.MaTranDau, (storer, filters, value) => storer.TranDau = new BUS_TranDau().LayDanhSach(filters).GetReadData(value.ToString()) },
            { BanThangColumn.MaCauThu, (storer, filters, value) => storer.CauThu = new BUS_CauThu().LayDanhSach(filters).GetReadData(value.ToString()) },
            { BanThangColumn.MaLoaiBanThang, (storer, filters, value) => storer.LoaiBanThang = new BUS_LoaiBanThang().LayDanhSach(filters).GetReadData(value.ToString()) },
            { BanThangColumn.ThoiDiemGhiBan, (storer, filters, value) => storer.ThoiDiemGhiBan = (int)value }
        };

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
        public List<DTO_BanThang> LayDanhSach(HashSet<BanThangColumn> columns, string? filters)
        {
            //Make query
            string query = $"SELECT {string.Join(", ", columns)} " +
                            "FROM BANTHANG " +
                            "WHERE Deleted = 0 ";

            if (string.IsNullOrEmpty(filters) == false)
                query += "AND " + filters;

            //Retrieve from database
            var result = databaseHelper.ExecuteQuery(query);

            //Filter for retrieving object from cache
            var filtersForColumns = new Dictionary<BanThangColumn, string>();

            if (columns.Contains(BanThangColumn.MaTranDau))
            {
                filtersForColumns[BanThangColumn.MaTranDau] = FilterBuilder<TranDauColumn>
                    .Where(TranDauColumn.MaTranDau).In( result.AsEnumerable().Select(row => row.Field<string>("MaTranDau")).ToHashSet() ).Build();
            }
            if (columns.Contains(BanThangColumn.MaCauThu))
            {
                filtersForColumns[BanThangColumn.MaCauThu] = FilterBuilder<CauThuColumn>
                    .Where(CauThuColumn.MaCauThu).In( result.AsEnumerable().Select(row => row.Field<string>("MaCauThu")).ToHashSet() ).Build();
            }
            if (columns.Contains(BanThangColumn.MaLoaiBanThang))
            {
                filtersForColumns[BanThangColumn.MaLoaiBanThang] = FilterBuilder<LoaiBanThangColumn>
                    .Where(LoaiBanThangColumn.MaLoaiBanThang).In( result.AsEnumerable().Select(row => row.Field<string>("MaLoaiBanThang") ).ToHashSet()).Build();
            }

            //Load into DTO
            var finalResult = new List<DTO_BanThang>();

            foreach (DataRow row in result.Rows)
            {
                DTO_BanThang obj = new DTO_BanThang();
                finalResult.Add(obj);
                
                foreach(var col in columns)
                {
                    columnsLoader[col](obj, filtersForColumns[col], row[col.ToString()]);
                }
            }

            return finalResult;
        }

        public bool LuuDanhSach(List<DTO_BanThang> upsertList, HashSet<BanThangColumn> columns)
        {
            var queryBuilder = new StringBuilder();
            var parameters = new List<MySqlParameter>();

            string selectedColumnsBuild = string.Join(", ", columns);
            queryBuilder.Append($"INSERT INTO BANTHANG ({selectedColumnsBuild}) VALUES ");

            int paramCounter = 0;
            foreach(var row in upsertList)
            {
                var paramStringBuilder = new List<string>();

                foreach(var col in columns)
                {
                    string parameter = $"{col}{paramCounter}";
                    paramStringBuilder.Add(parameter);
                    parameters.Add(new MySqlParameter(parameter, BanThangConverter.Instance[col](row)));
                }

                queryBuilder.Append($"({string.Join(", ", paramStringBuilder)})");
                paramCounter++;
            }

            queryBuilder.Append("ON DUPLICATE KEY UPDATE " + string.Join(", ", columns.Select(col => $"{col} = VALUES({col})")));

            string query = queryBuilder.ToString();

            return databaseHelper.ExecuteNonQuery(query, parameters.ToArray()) > 0;
        }

        public bool XoaDanhSach(List<DTO_BanThang> deleteList)
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
