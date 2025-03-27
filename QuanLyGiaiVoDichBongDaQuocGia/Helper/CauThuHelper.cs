
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.Helper
{
    static public class CauThuHelper
    {
        static public string TaoMaCauThu(string maCauThuHienTai, int offset)
        {
            int soMoi = int.Parse(maCauThuHienTai.Substring(2)) + offset;
            return "CT" + soMoi.ToString("D3");
        }
    }
}
