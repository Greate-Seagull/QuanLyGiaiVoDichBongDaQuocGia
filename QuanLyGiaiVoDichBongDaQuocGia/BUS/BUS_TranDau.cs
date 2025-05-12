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
        DAL_TranDau DAL = new DAL_TranDau();        

        private readonly string READ_TRANDAU = "READ_TRANDAU";
        private readonly string WRITE_TRANDAU = "WRITE_TRANDAU";

        public DataManager<DTO_TranDau> LayDanhSachNhap()
        {
            DataManager<DTO_TranDau> danhSachNhap = CacheManager.Get<DataManager<DTO_TranDau>>(WRITE_TRANDAU);

            if (danhSachNhap == null)
            {
                danhSachNhap = new DataManager<DTO_TranDau>();
                CacheManager.Add(WRITE_TRANDAU, danhSachNhap);
            }

            return danhSachNhap;
        }

        public DataManager<DTO_TranDau> LayDanhSach(string? filters = default, params TranDauColumn[] columns)
        {
            var hashed = columns.ToHashSet();
            hashed.Add(TranDauColumn.MaTranDau);

            var cachedRepository = CacheManager.Get<DataManager<DTO_TranDau>>(READ_TRANDAU);
            var loadedData = cachedRepository.Filter(dt => dt.)


            return CacheManager.GetOrLoad(READ_TRANDAU,
                                          () => new DataManager<DTO_TranDau>(DAL.LayDanhSach(hashed, filters),
                                                                             tranDau => tranDau.MaTranDau
                                                                             )
                                          );
        }

        public string LayMaTranDauHienTai()
        {
            return DAL.LayMaTranDauHienTai();
        }

        public bool LapTranDau()
        {
            KiemTraNhapLieu();
            return LuuThongTin(TranDauColumn.MaTranDau, TranDauColumn.MaVongDau, TranDauColumn.MaDoi1, TranDauColumn.MaDoi2, TranDauColumn.NgayGio);
        }

        public bool LuuThongTin(params TranDauColumn[] columns)
        {
            var danhSachNhap = this.LayDanhSachNhap();

            var upsert = danhSachNhap.UpsertData;
            var delete = danhSachNhap.DeleteData;

            if (upsert.Count > 0) DAL.LuuDanhSach(upsert, columns.ToHashSet());
            if (delete.Count > 0) DAL.XoaDanhSach(delete);

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

        internal bool GhiNhanKetQua()
        {
            new BUS_BanThang().GhiNhanBanThang();
            return LuuThongTin(TranDauColumn.MaTranDau, TranDauColumn.TiSoDoi1, TranDauColumn.TiSoDoi2);
        }
    }
}
