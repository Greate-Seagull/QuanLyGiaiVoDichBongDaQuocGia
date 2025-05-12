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
    class BUS_LoaiBanThang
    {
        DAL_LoaiBanThang DAL_loaiBanThang = new DAL_LoaiBanThang();

        private readonly string READ_LOAIBANTHANG = "READ_LOAIBANTHANG";
        private readonly string WRITE_LOAIBANTHANG = "WRITE_LOAIBANTHANG";

        public DataManager<DTO_LoaiBanThang> LayDanhSachNhap()
        {
            DataManager<DTO_LoaiBanThang> danhSachNhap = CacheManager.Get<DataManager<DTO_LoaiBanThang>>(WRITE_LOAIBANTHANG);

            if (danhSachNhap == null)
            {
                danhSachNhap = new DataManager<DTO_LoaiBanThang>();
                CacheManager.Add(WRITE_LOAIBANTHANG, danhSachNhap);
            }

            return danhSachNhap;
        }

        public DataManager<DTO_LoaiBanThang> LayDanhSach(string? filters = default, params LoaiBanThangColumn[] columns)
        {
            var hashed = columns.ToHashSet();
            hashed.Add(LoaiBanThangColumn.MaLoaiBanThang);

            return CacheManager.GetOrLoad(READ_LOAIBANTHANG,
                                          () => new DataManager<DTO_LoaiBanThang>(DAL_loaiBanThang.LayDanhSach(hashed, filters),
                                                                                 loaiBanThang => loaiBanThang.MaLoaiBanThang
                                                                                 )
                                          );
        }
    }
}
