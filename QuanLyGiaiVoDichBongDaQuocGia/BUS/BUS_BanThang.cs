using QuanLyGiaiVoDichBongDaQuocGia.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.BUS
{
    class BUS_BanThang
    {
        DAL_BanThang DAL_banThang = new DAL_BanThang();

        internal string LayMaBanThangHienTai()
        {
            return DAL_banThang.LayMaBanThangHienTai();
        }
    }
}
