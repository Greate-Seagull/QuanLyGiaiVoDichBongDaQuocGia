using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;

namespace QuanLyGiaiVoDichBongDaQuocGia.DBContext
{
    public class DBC_ThamSo : DbContext
    {
        public DBC_ThamSo(DbContextOptions options) : base(options)
        {
        }

        public DbSet<DTO_ThamSo> LocalRepository { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DTO_ThamSo>(entity =>
            {
                entity.ToTable("THAMSO");

                entity.Property(obj => obj.TuoiCauThuToiThieu);
                entity.Property(obj => obj.TuoiCauThuToiDa);
                entity.Property(obj => obj.SoLuongCauThuToiThieu);
                entity.Property(obj => obj.SoLuongCauThuToiDa);
            });
        }
    }
}
