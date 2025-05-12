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
    class DAL_CauThu
    {
        DatabaseHelper databaseHelper = new DatabaseHelper();

        //For lazy retrieve
        Dictionary<CauThuColumn, Action<DTO_CauThu, string, object>> columnsLoader = new Dictionary<CauThuColumn, Action<DTO_CauThu, string, object>>
        {
            { CauThuColumn.MaCauThu, (storer, filters, value) => storer.MaCauThu = value.ToString() },
            { CauThuColumn.TenCauThu, (storer, filters, value) => storer.TenCauThu = value.ToString() },
            { CauThuColumn.MaLoaiCauThu, (storer, filters, value) => storer.LoaiCauThu = new BUS_LoaiCauThu().LayDanhSach(filters).GetReadData(value.ToString()) },
            { CauThuColumn.MaDoiBong, (storer, filters, value) => storer.DoiBong = new BUS_DoiBong().LayDanhSach(filters).GetReadData(value.ToString()) },
            { CauThuColumn.NgaySinh, (storer, filters, value) => storer.NgaySinh = (DateTime)value },
            { CauThuColumn.GhiChu, (storer, filters, value) => storer.GhiChu = value.ToString() }
        };

        //For lazy insert
        Dictionary<CauThuColumn, Func<DTO_CauThu, object>> columnsInserter = new Dictionary<CauThuColumn, Func<DTO_CauThu, object>>
        {
            { CauThuColumn.MaCauThu, storer => storer.MaCauThu },
            { CauThuColumn.TenCauThu, storer => storer.TenCauThu },
            { CauThuColumn.MaLoaiCauThu, storer => storer.LoaiCauThu.MaLoaiCauThu },
            { CauThuColumn.MaDoiBong, storer => storer.DoiBong.MaDoiBong },
            { CauThuColumn.NgaySinh, storer => storer.NgaySinh },
            { CauThuColumn.GhiChu, storer => storer.GhiChu }
        };

        public string LayMaCauThuHienTai()
        {
            string query = "SELECT MaCauThu FROM CAUTHU ORDER BY MaCauThu DESC LIMIT 1";
            DataTable result = databaseHelper.ExecuteQuery(query);

            if(result.Rows.Count == 0)
            {
                return "CT000";
            }

            return result.Rows[0]["MaCauThu"].ToString();
        }

        public bool LuuDanhSach(List<DTO_CauThu> upsertList, HashSet<CauThuColumn> columns)
        {
            var queryBuilder = new StringBuilder();
            var parameters = new List<MySqlParameter>();

            string selectedColumnsBuilder = string.Join(", ", columns);
            queryBuilder.Append($"INSERT INTO CAUTHU ({selectedColumnsBuilder}) VALUES ");

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

        public bool XoaDanhSach(List<DTO_CauThu> deleteList)
        {
            string query = "";

            foreach (DTO.DTO_CauThu cauThu in deleteList)
            {
                query += "UPDATE CAUTHU " +
                        $"SET Deleted = 1 " +
                        $"WHERE MaCauThu = '{cauThu.MaCauThu}'; ";
            }

            return databaseHelper.ExecuteNonQuery(query) > 0;
        }

        internal List<DTO_CauThu> LayDanhSach(HashSet<CauThuColumn> columns, string? filters)
        {
            //Make query
            string query = $"SELECT {string.Join(", ", columns)} " +
                            "FROM CAUTHU " +
                            "WHERE Deleted = 0 ";

            if (string.IsNullOrEmpty(filters) == false)
                query += "AND " + filters;

            //Prepare for main action
            var result = databaseHelper.ExecuteQuery(query);

            //(Lazy) Get necessary action and load from cache
            var filtersForColumns = new Dictionary<CauThuColumn, string>();

            if (columns.Contains(CauThuColumn.MaDoiBong))
            {
                filtersForColumns[CauThuColumn.MaDoiBong] = FilterBuilder<DoiBongColumn>
                    .Where(DoiBongColumn.MaDoiBong).In(result.AsEnumerable().Select(row => row.Field<string>("MaDoiBong")).ToHashSet())
                    .Build();
            }

            //Load into DTO
            var finalResult = new List<DTO_CauThu>();

            foreach (DataRow row in result.Rows)
            {
                DTO_CauThu obj = new DTO_CauThu();
                finalResult.Add(obj);

                foreach (var col in columns)
                {
                    columnsLoader[col](obj, filtersForColumns.GetValueOrDefault(col), row[col.ToString()]);
                }
            }

            return finalResult;
        }
    }
}
