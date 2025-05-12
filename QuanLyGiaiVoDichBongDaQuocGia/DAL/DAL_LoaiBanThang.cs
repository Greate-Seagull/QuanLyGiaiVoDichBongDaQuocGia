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
    class DAL_LoaiBanThang
    {
        DatabaseHelper databaseHelper = new DatabaseHelper();

        //For lazy retrieve
        Dictionary<LoaiBanThangColumn, Action<DTO_LoaiBanThang, string, object>> columnsLoader = new Dictionary<LoaiBanThangColumn, Action<DTO_LoaiBanThang, string, object>>
        {
            { LoaiBanThangColumn.MaLoaiBanThang, (storer, filters, value) => storer.MaLoaiBanThang = value.ToString() },
            { LoaiBanThangColumn.TenLoaiBanThang, (storer, filters, value) => storer.TenLoaiBanThang = value.ToString() }
        };

        internal List<DTO_LoaiBanThang> LayDanhSach(HashSet<LoaiBanThangColumn> columns, string? filters)
        {
            //Make query
            string query = $"SELECT {string.Join(", ", columns)} " +
                            "FROM LOAIBANTHANG " +
                            "WHERE 1 = 1 ";

            if (string.IsNullOrEmpty(filters) == false)
                query += "AND " + filters;

            //Prepare for main action
            var result = databaseHelper.ExecuteQuery(query);

            //Load into DTO
            var finalResult = new List<DTO_LoaiBanThang>();

            foreach (DataRow row in result.Rows)
            {
                DTO_LoaiBanThang obj = new DTO_LoaiBanThang();
                finalResult.Add(obj);

                foreach (var col in columns)
                {
                    columnsLoader[col](obj, default, row[col.ToString()]);
                }
            }

            return finalResult;
        }
    }
}
