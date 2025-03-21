using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.BUS
{
    class BUS_CauThu
    {
        DAL.DAL_CauThu DAL_cauThu = new DAL.DAL_CauThu();

        public string LayMaCauThuMoi()
        {
            return DAL_cauThu.LayMaCauThuMoi();
        }

        public bool ThemCauThuMoi(DTO_CauThu cauThu)
        {
            this.KiemTraNhapLieu(cauThu);

            return DAL_cauThu.ThemCauThuMoi(cauThu);
        }

        private void KiemTraNhapLieu(DTO_CauThu cauThu)
        {
            if (string.IsNullOrEmpty(cauThu.TenCauThu))
                throw new Exception("Tên cầu thủ không được bỏ trống");                      
        }
    }
}
