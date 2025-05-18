using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.BUS
{
    public class BUS_BanThang
    {
        private readonly DAL_BanThang _DAL;

        public BUS_BanThang(DAL_BanThang DAL)
        {
            _DAL = DAL;
        }

        public string LayMaMoiNhat()
        {
            var query = _DAL.GetAll()
                            .IgnoreQueryFilters()
                            .AsNoTracking()
                            .OrderByDescending(obj => obj.MaBanThang);

            var result = query.FirstOrDefault();

            if (result != null)
                return result.MaBanThang;
            else
                return "BT000";
        }

        public void GhiNhanBanThang(IEnumerable<DTO_BanThang> danhSachGhiNhan)
        {
            _DAL.AddRange(danhSachGhiNhan);
        }
    }
}
