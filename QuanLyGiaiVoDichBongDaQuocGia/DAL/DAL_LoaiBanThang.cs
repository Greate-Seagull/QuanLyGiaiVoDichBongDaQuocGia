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
    class DAL_LoaiBanThang
    {
        DatabaseHelper databaseHelper = new DatabaseHelper();

        public List<DTO_LoaiBanThang> LayDanhSachLoaiBanThang()
        {
            string query = "SELECT MaLoaiBanThang, TenLoaiBanThang " +
                           "FROM LOAIBANTHANG; ";
            DataTable result = databaseHelper.ExecuteQuery(query);
            
            List<DTO_LoaiBanThang> danhSachLoaiBanThang = new List<DTO_LoaiBanThang>();
            foreach(DataRow row in result.Rows)
            {
                danhSachLoaiBanThang.Add(new DTO_LoaiBanThang(row["MaLoaiBanThang"].ToString(), 
                                                              row["TenLoaiBanThang"].ToString()
                                                              )
                                        );
            }

            return danhSachLoaiBanThang;
        }
    }
}
