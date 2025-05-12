using MySql.Data.MySqlClient;
using Org.BouncyCastle.Cms;
using QuanLyDaiLy.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.BUS;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.FilterHelper;
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

        //For lazy retrieve
        Dictionary<VongDauColumn, Action<DTO_VongDau, string, object>> columnsLoader = new Dictionary<VongDauColumn, Action<DTO_VongDau, string, object>>
        {
            { VongDauColumn.MaVongDau, (storer, filters, value) => storer.MaVongDau = value.ToString() },
            { VongDauColumn.TenVongDau, (storer, filters, value) => storer.TenVongDau = value.ToString() },
            { VongDauColumn.NgayBatDau, (storer, filters, value) => storer.NgayBatDau = (DateTime)value },
            { VongDauColumn.NgayKetThuc, (storer, filters, value) => storer.NgayKetThuc = (DateTime)value }
        };

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

        internal List<DTO_VongDau> LayDanhSach(HashSet<VongDauColumn> columns, string? filters)
        {
            //Make query
            string query = $"SELECT {string.Join(", ", columns)} " +
                            "FROM VONGDAU " +
                            "WHERE Deleted = 0 ";

            if (string.IsNullOrEmpty(filters) == false)
                query += "AND " + filters;

            //Prepare for main action
            var result = databaseHelper.ExecuteQuery(query);           

            //Load into DTO
            var finalResult = new List<DTO_VongDau>();

            foreach (DataRow row in result.Rows)
            {
                DTO_VongDau obj = new DTO_VongDau();
                finalResult.Add(obj);

                foreach (var col in columns)
                {
                    columnsLoader[col](obj, default, row[col.ToString()]);
                }
            }

            return finalResult;
        }

        internal bool LuuDanhSach(List<DTO_VongDau> upsertList, HashSet<VongDauColumn> columns)
        {
            var queryBuilder = new StringBuilder();
            var parameters = new List<MySqlParameter>();

            string selectedColumnsBuild = string.Join(", ", columns);
            queryBuilder.Append($"INSERT INTO VONGDAU ({selectedColumnsBuild}) VALUES ");

            int paramCounter = 0;
            foreach (var row in upsertList)
            {
                var paramStringBuilder = new List<string>();

                foreach (var col in columns)
                {
                    string parameter = $"{col}{paramCounter}";
                    paramStringBuilder.Add(parameter);
                    parameters.Add(new MySqlParameter(parameter, VongDauConverter.Instance[col](row)));
                }

                queryBuilder.Append($"({string.Join(", ", paramStringBuilder)})");
                paramCounter++;
            }

            queryBuilder.Append("ON DUPLICATE KEY UPDATE " + string.Join(", ", columns.Select(col => $"{col} = VALUES({col})")));

            string query = queryBuilder.ToString();

            return databaseHelper.ExecuteNonQuery(query, parameters.ToArray()) > 0;
        }

        internal bool XoaDanhSach(List<DTO_VongDau> delete)
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
