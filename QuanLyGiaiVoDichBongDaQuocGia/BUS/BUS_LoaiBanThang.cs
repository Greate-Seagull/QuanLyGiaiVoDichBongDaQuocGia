using DevExpress.XtraEditors.TextEditController.Win32;
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

        internal List<DTO_LoaiBanThang> LayDanhSachLoaiBanThangThayDoiQuiDinh()
        {
            var query = _DAL.GetAll()
                            .Select(entity => new DTO_LoaiBanThang
                            {
                                MaLoaiBanThang = entity.MaLoaiBanThang,
                                TenLoaiBanThang = entity.TenLoaiBanThang
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

        internal string LayMaMoiNhat()
        {
            var query = _DAL.GetAll()
                            .IgnoreQueryFilters()
                            .AsNoTracking()
                            .OrderByDescending(obj => obj.MaLoaiBanThang);

            var result = query.FirstOrDefault();

            if (result != null)
                return result.MaLoaiBanThang;
            else
                return "LBT00";
        }

        internal bool ThayDoiQuiDinh(DTO_LoaiBanThang loaiBanThangThayDoi)
        {
            var trackedEntity = _DAL.GetAll().FirstOrDefault(entity => entity.MaLoaiBanThang == loaiBanThangThayDoi.MaLoaiBanThang);

            if (trackedEntity is null)
            {
                _DAL.Add(loaiBanThangThayDoi);
            }
            else
            {
                trackedEntity.TenLoaiBanThang = loaiBanThangThayDoi.TenLoaiBanThang;
            }

            _DAL.SaveChanges();

            return true;
        }

        internal bool ThayDoiQuiDinh(List<DTO_LoaiBanThang> cacLoaiBanThang)
        {
            using(var transaction = _DAL.Context.Database.BeginTransaction())
            {
                try
                {
                    var maLoaiBanThang = cacLoaiBanThang.Select(entity => entity.MaLoaiBanThang);
                    var trackedEntities = _DAL.GetAll().IgnoreQueryFilters().Where(entity => maLoaiBanThang.Contains(entity.MaLoaiBanThang)).ToDictionary(entity => entity.MaLoaiBanThang);

                    foreach (var loaiBanThang in cacLoaiBanThang)
                    {
                        if (trackedEntities.ContainsKey(loaiBanThang.MaLoaiBanThang))
                        {
                            trackedEntities[loaiBanThang.MaLoaiBanThang].TenLoaiBanThang = loaiBanThang.TenLoaiBanThang;
                            trackedEntities[loaiBanThang.MaLoaiBanThang].Deleted = loaiBanThang.Deleted;
                        }
                        else
                        {
                            _DAL.Add(loaiBanThang);
                        }
                    }

                    _DAL.SaveChanges();
                    _DAL.Context.ChangeTracker.Clear();
                    transaction.Commit();
                }
                catch (Exception err)
                {
                    transaction.Rollback();
                    MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }               
            }            

            return true;
        }
    }
}
