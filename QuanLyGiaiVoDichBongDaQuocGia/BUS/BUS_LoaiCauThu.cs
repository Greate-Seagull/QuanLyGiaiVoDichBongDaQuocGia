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

        internal List<DTO_LoaiCauThu> LayDanhSachLoaiCauThuThayDoiQuiDinh()
        {
            var query = _DAL.GetAll()
                            .Select(entity => new DTO_LoaiCauThu
                            {
                                MaLoaiCauThu = entity.MaLoaiCauThu,
                                TenLoaiCauThu = entity.TenLoaiCauThu,
                                SoLuongCauThuToiDaTheoLoaiCauThu = entity.SoLuongCauThuToiDaTheoLoaiCauThu
                            });

            return query.AsNoTracking().ToList();
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

        internal List<DTO_LoaiCauThu> LayDanhSachLoaiCauThuTraCuu()
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
       
        internal bool ThayDoiQuiDinh(DTO_LoaiCauThu loaiCauThuThayDoi)
        {
            var trackedEntity = _DAL.GetAll().FirstOrDefault(entity => entity.MaLoaiCauThu == loaiCauThuThayDoi.MaLoaiCauThu);

            if (trackedEntity is null)
            {
                return false;
            }
            
            trackedEntity.SoLuongCauThuToiDaTheoLoaiCauThu = loaiCauThuThayDoi.SoLuongCauThuToiDaTheoLoaiCauThu;
            _DAL.SaveChanges();
            _DAL.Context.ChangeTracker.Clear();
            return true;
        }

        internal IEnumerable<DTO_LoaiCauThu> TraCuuLoaiCauThuTheoMaLoaiCauThu(IEnumerable<DTO_LoaiCauThu> danhSachLoaiCauThu, string maLoaiCauThu)
        {
            var result = danhSachLoaiCauThu;

            if (string.IsNullOrEmpty(maLoaiCauThu) == false)
                result = result.Where(entity => entity.MaLoaiCauThu == maLoaiCauThu);

            return result;
        }

        internal IEnumerable<DTO_LoaiCauThu> TraCuuLoaiCauThuTheoSoLuongCauThuToiDa(IEnumerable<DTO_LoaiCauThu> danhSachLoaiCauThu, 
                                                                                    int? startSoLuong, int? endSoLuong)
        {
            var result = danhSachLoaiCauThu;

            if (startSoLuong is not null)
                result = result.Where(entity => entity.SoLuongCauThuToiDaTheoLoaiCauThu >= startSoLuong);
            if (endSoLuong is not null)
                result = result.Where(entity => entity.SoLuongCauThuToiDaTheoLoaiCauThu <= endSoLuong);

            return result;
        }
    }
}
