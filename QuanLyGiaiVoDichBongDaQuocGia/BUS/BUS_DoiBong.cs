using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.DAL;
using System.Transactions;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.BUS
{
    class BUS_DoiBong
    {
        private readonly DAL_DoiBong _DAL;
        private readonly BUS_CauThu _BUS_CauThu;

        public BUS_DoiBong(DAL_DoiBong dAL, BUS_CauThu bUS_CauThu)
        {
            _DAL = dAL;
            _BUS_CauThu = bUS_CauThu;
        }

        internal List<DTO_DoiBong> LayDanhSach(Expression<Func<DTO_DoiBong, DTO_DoiBong>>? selector = default, Expression<Func<DTO_DoiBong, bool>>? filter = default, bool isTracking = false)
        {
            return _DAL.LayDanhSach(selector, filter, isTracking);
        }

        public DTO_DoiBong? LayMaMoiNhat()
        {
            return _DAL.LayMaMoiNhat();
        }

        public bool TiepNhanDoiBong(DTO_DoiBong doiBongTiepNhan, List<DTO_CauThu> danhSachCauThuTiepNhan)
        {
            var danhSachTam = new List<DTO_DoiBong>(){ doiBongTiepNhan };

            this.KiemTraNhapLieu(danhSachTam);

            using (var transaction = new TransactionScope())
            {
                this.LuuThongTin(danhSachTam);
                _BUS_CauThu.TiepNhanCauThu(danhSachCauThuTiepNhan);
                transaction.Complete();
                return true;
            }            
        }

        public bool LuuThongTin(List<DTO_DoiBong> danhSachLuu)
        {
            _DAL.LuuDanhSach(danhSachLuu);
            return true;
        }

        private void KiemTraNhapLieu(List<DTO_DoiBong> danhSachKiemTra)
        {
            foreach(var entity in danhSachKiemTra)
            {
                if (string.IsNullOrEmpty(entity.TenDoiBong))
                    throw new Exception("Tên đội bóng không được để trống");
                if (string.IsNullOrEmpty(entity.TenSanNha))
                    throw new Exception("Tên sân nhà không được để trống");
            }
        }        
    }
}
