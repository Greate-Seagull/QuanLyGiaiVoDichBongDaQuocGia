using QuanLyGiaiVoDichBongDaQuocGia.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.BUS
{    
    class BUS_ThamSo
    {
        private readonly DAL_ThamSo _DAL;

        public BUS_ThamSo(DAL_ThamSo dAL)
        {
            _DAL = dAL;
        }

        public DTO_ThamSo? LayThamSo(Expression<Func<DTO_ThamSo, DTO_ThamSo>>? selector = default)
        {
            return _DAL.LayDanhSach(selector);
        }
    }
}
