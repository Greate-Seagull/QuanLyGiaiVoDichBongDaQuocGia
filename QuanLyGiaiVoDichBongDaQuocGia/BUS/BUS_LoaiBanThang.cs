using QuanLyGiaiVoDichBongDaQuocGia.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.BUS
{    
    class BUS_LoaiBanThang
    {
        private readonly DAL_LoaiBanThang _DAL;

        public BUS_LoaiBanThang(DAL_LoaiBanThang dAL)
        {
            _DAL = dAL;
        }

        public List<DTO_LoaiBanThang> LayDanhSach(Expression<Func<DTO_LoaiBanThang, DTO_LoaiBanThang>>? selector = default, Expression<Func<DTO_LoaiBanThang, bool>>? filter = default, bool isTracking = false)
        {
            return _DAL.LayDanhSach(selector, filter, isTracking);
        }
    }
}
