using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.Manager;
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

        BUS_ThamSo BUS_thamSo = new BUS_ThamSo();

        private readonly string READ_CAUTHU = "READ_CAUTHU";
        private readonly string WRITE_CAUTHU = "WRITE_CAUTHU";

        internal DataManager<DTO_CauThu> LayDanhSachNhap()
        {
            DataManager<DTO_CauThu> danhSachNhapCauThu = CacheManager.Get<DataManager<DTO_CauThu>>(WRITE_CAUTHU);

            if (danhSachNhapCauThu == null)
            {
                danhSachNhapCauThu = new Manager.DataManager<DTO_CauThu>();
                Manager.CacheManager.Add(WRITE_CAUTHU, danhSachNhapCauThu);
            }

            return danhSachNhapCauThu;
        }

        public string LayMaCauThuHienTai()
        {
            return DAL_cauThu.LayMaCauThuHienTai();
        }

        public bool TiepNhanCauThu()
        {
            this.KiemTraNhapLieu();
            return LuuCauThu();
        }

        public bool LuuCauThu()
        {
            DataManager<DTO_CauThu> danhSachCauThu = this.LayDanhSachNhap();
            DTO.DTO_CauThu cauThu;
            List<DTO.DTO_CauThu> upsertList = new List<DTO_CauThu>();
            List<DTO.DTO_CauThu> deleteList = new List<DTO_CauThu>();

            foreach (var item in danhSachCauThu.ProcessingData)
            {
                cauThu = item.Data;

                switch (item.State)
                {
                    case Manager.DataState.New:
                        upsertList.Add(cauThu);
                        break;
                    case Manager.DataState.Modified:
                        upsertList.Add(cauThu);
                        break;
                    case Manager.DataState.Deleting:
                        deleteList.Add(cauThu);
                        break;
                }
            }

            if (upsertList.Count > 0) DAL_cauThu.LuuDanhSachCauThuMoi(upsertList);
            if (deleteList.Count > 0) DAL_cauThu.XoaDanhSachCauThu(deleteList);

            return true;
        }

        private void KiemTraNhapLieu()
        {
            DataManager<DTO_CauThu> danhSachCauThu = this.LayDanhSachNhap();
            foreach(var item in danhSachCauThu.ActiveData)
            {
                DTO_CauThu cauThu = item.Data;
                if (string.IsNullOrEmpty(cauThu.TenCauThu))
                    throw new Exception("Tên cầu thủ không được bỏ trống");
            }
        }

        internal void KiemTraSoLuongCauThuToiThieu()
        {
            DataManager<DTO_CauThu> danhSachCauThu = this.LayDanhSachNhap();
            DTO_ThamSo thamSo = BUS_thamSo.LayThamSo();
            if (danhSachCauThu.CountActive > thamSo.SoLuongCauThuToiDa)
                throw new Exception($"Vi phạm số lượng cầu thủ tối đa {danhSachCauThu.CountActive} > {thamSo.SoLuongCauThuToiDa}");
        }

        internal void KiemTraSoLuongCauThuToiDa()
        {
            DataManager<DTO_CauThu> danhSachCauThu = this.LayDanhSachNhap();
            DTO_ThamSo thamSo = BUS_thamSo.LayThamSo();
            if (danhSachCauThu.CountActive < thamSo.SoLuongCauThuToiThieu)
                throw new Exception($"Vi phạm số lượng cầu thủ tối thiểu {danhSachCauThu.CountActive} < {thamSo.SoLuongCauThuToiThieu}");
        }      
    }
}
