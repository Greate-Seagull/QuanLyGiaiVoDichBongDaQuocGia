using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.Manager
{
    public class IDManager
    {
        string ma;
        int incrementer;
        int placeholder;

        public IDManager(string iD)
        {
            ma = iD;
            incrementer = 0;
            placeholder = 0;
        }

        public string LayID()
        {
            return this.TaoID(ma, placeholder + incrementer);
        }

        private string TaoID(string iD, int v)
        {
            string kyTu = Regex.Replace(iD, "[^A-Za-z]", "");
            string so = Regex.Replace(iD, "[^0-9]", "");
            int soMoi = int.Parse(so) + v;
            int soLuongKyTuSo = iD.Length - kyTu.Length;
            return kyTu + soMoi.ToString($"D{soLuongKyTuSo}");
        }

        public void TangDonViDem()
        {
            incrementer++;
        }

        public void GiamDonViDem()
        {
            if(incrementer >= 0)
            {
                incrementer--;
            }
        }

        public void XacNhanMaDaSuDung()
        {
            placeholder += incrementer;
            incrementer = 0;
        }
    }
}
