using QuanLyGiaiVoDichBongDaQuocGia.DAL;
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
    public enum VongDauColumn
    {
        MaVongDau,
        TenVongDau,
        NgayBatDau,
        NgayKetThuc
    }       

    class BUS_VongDau
    {        
        DAL_VongDau DAL_vongDau = new DAL_VongDau();

        private readonly string READ_VONGDAU = "READ_VONGDAU";
        private readonly string WRITE_VONGDAU = "WRITE_VONGDAU";

        public DataManager<DTO_VongDau> LayDanhSachNhap()
        {
            DataManager<DTO_VongDau> danhSachNhap = CacheManager.Get<DataManager<DTO_VongDau>>(WRITE_VONGDAU);

            if(danhSachNhap == null)
            {
                danhSachNhap = new Manager.DataManager<DTO_VongDau>();
                Manager.CacheManager.Add(WRITE_VONGDAU, danhSachNhap);
            }

            return danhSachNhap;
        }

        public DataManager<DTO_VongDau> LayDanhSach(string? filters = default, params VongDauColumn[] columns)
        {
            var hashed = columns.ToHashSet();
            hashed.Add(VongDauColumn.MaVongDau);

            return CacheManager.GetOrLoad(READ_VONGDAU, () => new DataManager<DTO_VongDau>(DAL_vongDau.LayDanhSach(hashed, filters),
                                                                                           vongDau => vongDau.MaVongDau)
                                         );

        }

        public string LayMaVongDauMoi()
        {
            return DAL_vongDau.LayMaVongDauMoi();
        }

        public bool LapLichThiDau()
        {
            BUS_TranDau BUS_tranDau = new BUS_TranDau();

            this.KiemTraNhapLieu();
            BUS_tranDau.KiemTraSoLuongTranDauToiThieu();

            using(var transaction = new TransactionScope())
            {
                this.LuuThongTin(VongDauColumn.MaVongDau, VongDauColumn.TenVongDau);
                BUS_tranDau.LapTranDau();

                transaction.Complete();
                return true;
            }
        }

        private bool LuuThongTin(params VongDauColumn[] columns)
        {
            DataManager<DTO_VongDau> danhSachVongDau = this.LayDanhSachNhap();
            DTO_VongDau vongDau;
            List<DTO_VongDau> upsert = new List<DTO_VongDau>();
            List<DTO_VongDau> delete = new List<DTO_VongDau>();

            foreach (var item in danhSachVongDau.ProcessingData)
            {
                vongDau = item.Data;

                switch (item.State)
                {
                    case DataState.New:
                        upsert.Add(vongDau);
                        break;
                    case DataState.Modified:
                        upsert.Add(vongDau);
                        break;
                    case DataState.Deleting:
                        delete.Add(vongDau);
                        break;
                }
            }

            if (upsert.Count > 0) DAL_vongDau.LuuDanhSach(upsert, columns.ToHashSet());
            if (delete.Count > 0) DAL_vongDau.XoaDanhSachTranDau(delete);

            return true;
        }

        private void KiemTraNhapLieu()
        {
            DataManager<DTO_VongDau> danhSachVongDau = this.LayDanhSachNhap();

            foreach (var item in danhSachVongDau.ActiveData)
            {
                DTO_VongDau vongDau = item.Data;
                if (string.IsNullOrEmpty(vongDau.TenVongDau))
                    throw new Exception("Tên vòng đấu không được để trống");
            }
        }
    }
}
