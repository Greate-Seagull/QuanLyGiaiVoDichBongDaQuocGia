using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        internal IEnumerable<DTO_LoaiCauThu> LayDanhSachLoaiCauThuTiepNhanDoiBong()
        {
            var query = _DAL.GetAll()
                            .Select(obj => new DTO_LoaiCauThu
                            {
                                MaLoaiCauThu = obj.MaLoaiCauThu,
                                TenLoaiCauThu = obj.TenLoaiCauThu,
                                SoLuongCauThuToiDaTheoLoaiCauThu = obj.SoLuongCauThuToiDaTheoLoaiCauThu
                            });

            return query.AsNoTracking().ToList();
        }
    }
}
