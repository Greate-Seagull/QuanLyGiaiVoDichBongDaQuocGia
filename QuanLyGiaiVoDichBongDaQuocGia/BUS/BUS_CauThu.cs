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
    class BUS_CauThu
    {
        DAL_CauThu DAL = new DAL_CauThu();

        BUS_ThamSo BUS_thamSo = new BUS_ThamSo();

        private readonly string READ_CAUTHU = "READ_CAUTHU";
        private readonly string WRITE_CAUTHU = "WRITE_CAUTHU";

        internal DataManager<DTO_CauThu> LayDanhSachNhap()
        {
            DataManager<DTO_CauThu> danhSachNhap = CacheManager.Get<DataManager<DTO_CauThu>>(WRITE_CAUTHU);

            if (danhSachNhap == null)
            {
                danhSachNhap = new Manager.DataManager<DTO_CauThu>();
                Manager.CacheManager.Add(WRITE_CAUTHU, danhSachNhap);
            }

            return danhSachNhap;
        }

        public DataManager<DTO_CauThu> LayDanhSach(string? filters = default, params CauThuColumn[] columns)
        {
            var hashed = columns.ToHashSet();
            hashed.Add(CauThuColumn.MaCauThu);

            return CacheManager.GetOrLoad(READ_CAUTHU,
                                          () => new DataManager<DTO_CauThu>(DAL.LayDanhSach(hashed, filters),
                                                                             cauThu => cauThu.MaCauThu
                                                                             )
                                          );
        }

        public string LayMaCauThuHienTai()
        {
            return DAL.LayMaCauThuHienTai();
        }

        public bool TiepNhanCauThu()
        {
            this.KiemTraNhapLieu();
            return LuuCauThu(CauThuColumn.MaCauThu, CauThuColumn.TenCauThu, CauThuColumn.MaLoaiCauThu, CauThuColumn.NgaySinh, CauThuColumn.GhiChu);
        }

        public bool LuuCauThu(params CauThuColumn[] columns)
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
