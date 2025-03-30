using Mysqlx.Crud;
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
    class BUS_TranDau
    {
        DAL_TranDau DAL_tranDau = new DAL_TranDau();

        public string LayMaTranDauHienTai()
        {
            return DAL_tranDau.LayMaTranDauHienTai();
        }

        public bool LapTranDau(Manager<DTO_TranDau> danhSachTranDau)
        {
            List<ManagedItem<DTO_TranDau>> danhSachTranDauXuLy = danhSachTranDau.ProcessingData;

            if(danhSachTranDauXuLy.Count == 0)
            {
                return false;
            }

            this.KiemTraCapDauDaTonTai(danhSachTranDauXuLy);

            DTO_TranDau tranDau;
            List<DTO_TranDau> upsert = new List<DTO_TranDau>();
            List<DTO_TranDau> delete = new List<DTO_TranDau>();

            foreach(var item in danhSachTranDauXuLy)
            {
                tranDau = item.Data;

                this.KiemTraNhapLieu(tranDau);

                switch(item.State)
                {
                    case DataState.New:
                        upsert.Add(tranDau);
                        break;
                    case DataState.Modified:
                        upsert.Add(tranDau);
                        break;
                    case DataState.Deleting:
                        delete.Add(tranDau);
                        break;
                }
            }

            if (upsert.Count > 0) DAL_tranDau.LuuDanhSachTranDau(upsert);
            if (delete.Count > 0) DAL_tranDau.XoaDanhSachTranDau(delete);

            return true;
        }

        private void KiemTraNhapLieu(DTO_TranDau tranDau)
        {
            if (string.IsNullOrEmpty(tranDau.DoiBong1.MaDoiBong))
                throw new Exception($"Đội bóng 1 chưa được chọn cho trận đấu {tranDau.MaTranDau}");
            if (string.IsNullOrEmpty(tranDau.DoiBong2.MaDoiBong))
                throw new Exception($"Đội bóng 2 chưa được chọn cho trận đấu {tranDau.MaTranDau}");
        }

        private void KiemTraCapDauDaTonTai(List<ManagedItem<DTO_TranDau>> danhSachTranDau)
        {
            var comparer = EqualityComparer<DTO_TranDau>.Create((x, y) =>
                x.DoiBong1.MaDoiBong == y.DoiBong1.MaDoiBong &&
                x.DoiBong2.MaDoiBong == y.DoiBong2.MaDoiBong,
                obj => HashCode.Combine(obj.DoiBong1.MaDoiBong, obj.DoiBong2.MaDoiBong)
            );

            DTO_VongDau vongDauXuLy = danhSachTranDau[0].Data.VongDau;
            HashSet<DTO_TranDau> danhSachTranDauDaLuu = new HashSet<DTO_TranDau>(this.LayDanhSachCapDauLoaiTru(vongDauXuLy), comparer);

            foreach (var item in danhSachTranDau)
            {                
                DTO_TranDau tranDauMoi = item.Data;

                if (danhSachTranDauDaLuu.Contains(tranDauMoi))
                {
                    throw new Exception($"Vi phạm quy định mỗi cặp đấu chỉ thi đấu đúng 2 lần trong cả giải: {tranDauMoi.MaTranDau}");
                }
            }
        }

        private List<DTO_TranDau> LayDanhSachCapDauLoaiTru(DTO_VongDau vongDauXuLy)
        {
            return DAL_tranDau.LayDanhSachCapDauLoaiTru(vongDauXuLy);
        }

        public List<DTO_TranDau> LayDanhSachCapDau()
        {
            return DAL_tranDau.LayDanhSachCapDau();
        }
    }
}
