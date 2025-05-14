using QuanLyGiaiVoDichBongDaQuocGia.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.Manager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.BUS
{    
    public class BUS_LoaiCauThu
    {
        private readonly DAL_LoaiCauThu _DAL;

        public BUS_LoaiCauThu(DAL_LoaiCauThu dAL)
        {
            _DAL = dAL;
        }

        public List<DTO_LoaiCauThu> LayDanhSach(Expression<Func<DTO_LoaiCauThu, DTO_LoaiCauThu>>? selector = default, Expression<Func<DTO_LoaiCauThu, bool>>? filter = default, bool isTracking = false)
        {
            return _DAL.LayDanhSach(selector, filter, isTracking);
        }
    }
}
