using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.BUS
{    
    public class BUS_LoaiBanThang
    {
        private readonly DAL_LoaiBanThang _DAL;

        public BUS_LoaiBanThang(DAL_LoaiBanThang dAL)
        {
            _DAL = dAL;
        }

        internal List<DTO_LoaiBanThang> LayDanhSachLoaiBanThangGhiNhanKetQua()
        {
            var query = _DAL.GetAll()
                            .Select(obj => new DTO_LoaiBanThang
                            {
                                MaLoaiBanThang = obj.MaLoaiBanThang,
                                TenLoaiBanThang = obj.TenLoaiBanThang
                            });

            return query.AsNoTracking().ToList();
        }

        internal List<DTO_LoaiBanThang> LayDanhSachLoaiBanThangTraCuu()
        {
            var query = _DAL.GetAll()
                            .Select(obj => new DTO_LoaiBanThang
                            {
                                MaLoaiBanThang = obj.MaLoaiBanThang,
                                TenLoaiBanThang = obj.TenLoaiBanThang
                            });

            return query.AsNoTracking().ToList();
        }
    }
}
