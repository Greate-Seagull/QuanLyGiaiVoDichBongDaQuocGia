using Mysqlx.Crud;
using QuanLyGiaiVoDichBongDaQuocGia.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.BUS
{
    class BUS_TranDau
    {
        DAL_TranDau DAL_tranDau = new DAL_TranDau();

        private readonly string READ_TRANDAU = "READ_TRANDAU";
        private readonly string WRITE_TRANDAU = "WRITE_TRANDAU";

        public DataManager<DTO_TranDau> LayDanhSachNhap()
        {
            DataManager<DTO_TranDau> danhSachNhapTranDau = CacheManager.Get<DataManager<DTO_TranDau>>(WRITE_TRANDAU);

            if (danhSachNhapTranDau == null)
            {
                danhSachNhapTranDau = new Manager.DataManager<DTO_TranDau>();
                Manager.CacheManager.Add(WRITE_TRANDAU, danhSachNhapTranDau);
            }

            return danhSachNhapTranDau;
        }

        public DataManager<DTO_TranDau> LayDanhSachCapDauLoaiTru(DTO_VongDau vongDauXuLy)
        {
            return CacheManager.GetOrLoad(READ_TRANDAU,
                                          () => new DataManager<DTO_TranDau>(DAL_tranDau.LayDanhSachCapDauLoaiTru(vongDauXuLy),
                                                                             tranDau => tranDau.MaTranDau
                                                                             )
                                          );
        }

        public string LayMaTranDauHienTai()
        {
            return DAL_tranDau.LayMaTranDauHienTai();
        }

        public bool LapTranDau()
        {
            KiemTraNhapLieu();
            return LuuThongTin();
        }

        public bool LuuThongTin()
        {
            DataManager<DTO_TranDau> danhSachTranDau = this.LayDanhSachNhap();

            DTO_TranDau tranDau;
            List<DTO_TranDau> upsert = new List<DTO_TranDau>();
            List<DTO_TranDau> delete = new List<DTO_TranDau>();

            foreach(var item in danhSachTranDau.ProcessingData)
            {
                tranDau = item.Data;

                switch(item.State)
                {
                    case DataState.New:
                        upsert.Add(tranDau);
                        break;
                    case DataState.Modified:
                        upsert.Add(tranDau);
                        break;
                    case DataState.Deleting:
                        delete.Add(tranDau);
                        break;
                }
            }

            if (upsert.Count > 0) DAL_tranDau.LuuDanhSachTranDau(upsert);
            if (delete.Count > 0) DAL_tranDau.XoaDanhSachTranDau(delete);

            return true;
        }

        private void KiemTraNhapLieu()
        {
            DataManager<DTO_TranDau> danhSachTranDau = this.LayDanhSachNhap();

            foreach (var item in danhSachTranDau.ActiveData)
            {
                DTO_TranDau tranDau = item.Data;
                if (string.IsNullOrEmpty(tranDau.DoiBong1.MaDoiBong))
                    throw new Exception($"Đội bóng 1 chưa được chọn cho trận đấu {tranDau.MaTranDau}");
                if (string.IsNullOrEmpty(tranDau.DoiBong2.MaDoiBong))
                    throw new Exception($"Đội bóng 2 chưa được chọn cho trận đấu {tranDau.MaTranDau}");
            }
        }

        internal void KiemTraSoLuongTranDauToiThieu()
        {
            DataManager<DTO_TranDau> danhSachTranDau = this.LayDanhSachNhap();

            if (danhSachTranDau.CountActive < 1)
                throw new Exception($"Vi phạm số trận đấu tối thiểu {danhSachTranDau.CountActive} < 1");
        }
    }
}
