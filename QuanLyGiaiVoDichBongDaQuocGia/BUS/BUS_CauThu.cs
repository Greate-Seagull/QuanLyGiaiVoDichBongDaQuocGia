using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace QuanLyGiaiVoDichBongDaQuocGia.BUS
{
    class BUS_CauThu
    {
        DAL.DAL_CauThu DAL_cauThu = new DAL.DAL_CauThu();

        public string LayMaCauThuMoi()
        {
            return DAL_cauThu.LayMaCauThuMoi();
        }

        public bool LuuCauThu(DTO_CauThu cauThu)
        {
            this.KiemTraNhapLieu(cauThu);

            return DAL_cauThu.LuuCauThu(cauThu);
        }

        private void KiemTraNhapLieu(DTO_CauThu cauThu)
        {
            if (string.IsNullOrEmpty(cauThu.TenCauThu))
                throw new Exception("Tên cầu thủ không được bỏ trống");                      
        }

        public bool LuuCauThu(Manager.Manager<DTO.DTO_CauThu> danhSachCauThu)
        {
            DTO.DTO_CauThu cauThu;
            List<DTO.DTO_CauThu> upsertList = new List<DTO_CauThu>();
            List<DTO.DTO_CauThu> deleteList = new List<DTO_CauThu>();

            foreach (var item in danhSachCauThu.Items.Values)
            {
                cauThu = item.Data;

                this.KiemTraNhapLieu(cauThu);

                switch (item.Operation)
                {
                    case Manager.OperationType.Upsert:
                        upsertList.Add(cauThu);
                        break;
                    case Manager.OperationType.Delete:
                        deleteList.Add(cauThu);
                        break;
                }
            }

            if (upsertList.Count > 0) DAL_cauThu.LuuDanhSachCauThuMoi(upsertList);
            if (deleteList.Count > 0) DAL_cauThu.XoaDanhSachCauThu(deleteList);

            return true;
        }
    }
}
