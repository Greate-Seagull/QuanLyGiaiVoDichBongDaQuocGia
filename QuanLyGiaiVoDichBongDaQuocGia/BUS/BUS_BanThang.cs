using QuanLyGiaiVoDichBongDaQuocGia.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.Manager;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyGiaiVoDichBongDaQuocGia.BUS
{
    public class BUS_BanThang
    {
        DAL_BanThang DAL = new DAL_BanThang();

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
                                          () => new DataManager<DTO_BanThang>(DAL.LayDanhSach(hashed, filters),
                                                                             banThang => banThang.MaBanThang
                                                                             )
                                          );
        }

        public string LayMaBanThangHienTai()
        {
            return DAL.LayMaBanThangHienTai();
        }

        public bool GhiNhanBanThang()
        {
            return LuuThongTin(BanThangColumn.MaBanThang, BanThangColumn.MaCauThu, BanThangColumn.MaLoaiBanThang, BanThangColumn.ThoiDiemGhiBan);
        }

        public bool LuuThongTin(params BanThangColumn[] columns)
        {
            var danhSachNhap = this.LayDanhSachNhap();

            var upsert = danhSachNhap.UpsertData;
            var delete = danhSachNhap.DeleteData;

            if (upsert.Count > 0) DAL.LuuDanhSach(upsert, columns.ToHashSet());
            if (delete.Count > 0) DAL.XoaDanhSach(delete);

            return true;
        }
    }
}
