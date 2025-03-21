
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.Helper
{
    static public class CauThuHelper
    {
        static public string XemTruocMaCauThu(string maCauThuHienTai)
        {
            int soMoi = int.Parse(maCauThuHienTai.Substring(2)) + 1;
            return "CT" + soMoi.ToString("D3");
        }
    }
}
