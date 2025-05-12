using QuanLyGiaiVoDichBongDaQuocGia.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.Manager;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyGiaiVoDichBongDaQuocGia.BUS
{
    public enum BanThangColumn
    {
        MaBanThang,
        MaTranDau,
        MaCauThu,
        MaLoaiBanThang,
        ThoiDiemGhiBan
    }
    public class BUS_BanThang
    {
        DAL_BanThang DAL_banThang = new DAL_BanThang();

        private readonly string READ_BANTHANG = "READ_BANTHANG";
        private readonly string WRITE_BANTHANG = "WRITE_BANTHANG";

        public DataManager<DTO_BanThang> LayDanhSachNhap()
        {
            DataManager<DTO_BanThang> danhSachNhap = CacheManager.Get<DataManager<DTO_BanThang>>(WRITE_BANTHANG);

            if (danhSachNhap == null)
            {
                danhSachNhap = new DataManager<DTO_BanThang>();
                CacheManager.Add(WRITE_BANTHANG, danhSachNhap);
            }

            return danhSachNhap;
        }

        public DataManager<DTO_BanThang> LayDanhSach(string? filters = default, params BanThangColumn[] columns)
        {
            var hashed = columns.ToHashSet();
            hashed.Add(BanThangColumn.MaBanThang);

            return CacheManager.GetOrLoad(READ_BANTHANG,
                                          () => new DataManager<DTO_BanThang>(DAL_banThang.LayDanhSach(hashed, filters),
                                                                             banThang => banThang.MaBanThang
                                                                             )
                                          );
        }

        public string LayMaBanThangHienTai()
        {
            return DAL_banThang.LayMaBanThangHienTai();
        }

        public bool GhiNhanBanThang()
        {
            return LuuThongTin(BanThangColumn.MaBanThang, BanThangColumn.MaCauThu, BanThangColumn.MaLoaiBanThang, BanThangColumn.ThoiDiemGhiBan);
        }

        public bool LuuThongTin(params BanThangColumn[] columns)
        {
            DataManager<DTO_BanThang> danhSachBanThang = this.LayDanhSachNhap();

            DTO_BanThang banThang;
            List<DTO_BanThang> upsert = new List<DTO_BanThang>();
            List<DTO_BanThang> delete = new List<DTO_BanThang>();

            foreach (var item in danhSachBanThang.ProcessingData)
            {
                banThang = item.Data;

                switch (item.State)
                {
                    case DataState.New:
                        upsert.Add(banThang);
                        break;
                    case DataState.Modified:
                        upsert.Add(banThang);
                        break;
                    case DataState.Deleting:
                        delete.Add(banThang);
                        break;
                }
            }

            if (upsert.Count > 0) DAL_banThang.LuuDanhSach(upsert, columns.ToHashSet());
            if (delete.Count > 0) DAL_banThang.XoaDanhSachBanThang(delete);

            return true;
        }
    }
}
