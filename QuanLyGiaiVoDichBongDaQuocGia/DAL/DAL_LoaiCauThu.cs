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
    public class DAL_LoaiCauThu
    {
        DatabaseHelper databaseHelper = new DatabaseHelper();

        //For lazy retrieve
        Dictionary<LoaiCauThuColumn, Action<DTO_LoaiCauThu, string?, object>> columnsLoader = new Dictionary<LoaiCauThuColumn, Action<DTO_LoaiCauThu, string?, object>>
        {
            { LoaiCauThuColumn.MaLoaiCauThu, (storer, filters, value) => storer.MaLoaiCauThu = value.ToString() },
            { LoaiCauThuColumn.TenLoaiCauThu, (storer, filters, value) => storer.TenLoaiCauThu = value.ToString() },
            { LoaiCauThuColumn.SoLuongCauThuToiDaTheoLoaiCauThu, (storer, filters, value) => storer.SoLuongCauThuToiDaTheoLoaiCauThu = (int)value }
        };

        internal List<DTO_LoaiCauThu> LayDanhSach(HashSet<LoaiCauThuColumn> columns, string? filters) //Use hashset to prevent duplicates automatically
        {
            //Make query
            string query = $"SELECT {string.Join(", ", columns)} " +
                            "FROM LOAICAUTHU " +
                            "WHERE 1 = 1 ";

            if (string.IsNullOrEmpty(filters) == false)
                query += "AND " + filters;

            //Prepare for main action
            var result = databaseHelper.ExecuteQuery(query);

            //Load into DTO
            var finalResult = new List<DTO_LoaiCauThu>();

            foreach (DataRow row in result.Rows)
            {
                DTO_LoaiCauThu obj = new DTO_LoaiCauThu();
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
