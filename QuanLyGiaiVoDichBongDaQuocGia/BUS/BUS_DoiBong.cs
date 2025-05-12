using Org.BouncyCastle.Bcpg.OpenPgp;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace QuanLyGiaiVoDichBongDaQuocGia.BUS
{
    public enum DoiBongColumn
    {
        MaDoiBong,
        TenDoiBong,
        TenSanNha
    }
    class BUS_DoiBong
    {
        DAL_DoiBong DAL_doiBong = new DAL.DAL_DoiBong();   

        BUS_CauThu BUS_cauThu = new BUS_CauThu();
        BUS_LoaiCauThu BUS_loaiCauThu = new BUS_LoaiCauThu();

        private readonly string READ_DOIBONG = "READ_DOIBONG";
        private readonly string WRITE_DOIBONG = "WRITE_DOIBONG";

        public DataManager<DTO_DoiBong> LayDanhSachNhap()
        {
            DataManager<DTO_DoiBong> danhSachNhap = CacheManager.Get<DataManager<DTO_DoiBong>>(WRITE_DOIBONG);

            if (danhSachNhap == null)
            {
                danhSachNhap = new Manager.DataManager<DTO_DoiBong>();
                Manager.CacheManager.Add(WRITE_DOIBONG, danhSachNhap);
            }

            return danhSachNhap;
        }

        internal DataManager<DTO_DoiBong> LayDanhSach(string? filters = default, params DoiBongColumn[] columns)
        {
            var hashed = columns.ToHashSet();
            hashed.Add(DoiBongColumn.MaDoiBong);

            return CacheManager.GetOrLoad(READ_DOIBONG,
                                          () => new Manager.DataManager<DTO_DoiBong>(DAL_doiBong.LayDanhSach(hashed, filters),
                                                                                    doiBong => doiBong.MaDoiBong
                                                                                    )
                                         );
        }

        public string LayMaDoiBongMoi()
        {
            return DAL_doiBong.LayMaDoiBongMoi();
        }

        public bool TiepNhanDoiBong()
        {
            this.KiemTraNhapLieu();
            BUS_cauThu.KiemTraSoLuongCauThuToiThieu();
            BUS_cauThu.KiemTraSoLuongCauThuToiDa();
            BUS_loaiCauThu.KiemTraSoLuongCauThuToiDa();

            using (var transaction = new TransactionScope())
            {
                this.LuuThongTin(DoiBongColumn.MaDoiBong, DoiBongColumn.TenDoiBong, DoiBongColumn.TenSanNha);
                BUS_cauThu.TiepNhanCauThu();
                transaction.Complete();
                return true;
            }            
        }

        private bool LuuThongTin(params DoiBongColumn[] columns)
        {
            DataManager<DTO_DoiBong> danhSachDoiBong = this.LayDanhSachNhap();
            DTO_DoiBong doiBong;
            List<DTO_DoiBong> upsert = new List<DTO_DoiBong>();
            List<DTO_DoiBong> delete = new List<DTO_DoiBong>();

            foreach (var item in danhSachDoiBong.ProcessingData)
            {
                doiBong = item.Data;

                switch (item.State)
                {
                    case DataState.New:
                        upsert.Add(doiBong);
                        break;
                    case DataState.Modified:
                        upsert.Add(doiBong);
                        break;
                    case DataState.Deleting:
                        delete.Add(doiBong);
                        break;
                }
            }

            if (upsert.Count > 0) DAL_doiBong.LuuDanhSach(upsert, columns.ToHashSet());
            if (delete.Count > 0) DAL_doiBong.XoaDanhSachDoiBong(delete);

            return true;
        }        

        private void KiemTraNhapLieu()
        {
            DataManager<DTO_DoiBong> danhSachDoiBong = this.LayDanhSachNhap();

            foreach(var item in danhSachDoiBong.ActiveData)
            {
                DTO_DoiBong doiBong = item.Data;
                if (string.IsNullOrEmpty(doiBong.TenDoiBong))
                    throw new Exception("Tên đội bóng không được để trống");
                if (string.IsNullOrEmpty(doiBong.TenSanNha))
                    throw new Exception("Tên sân nhà không được để trống");
            }
        }        
    }
}
