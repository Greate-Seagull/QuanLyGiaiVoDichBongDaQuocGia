using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;

namespace QuanLyGiaiVoDichBongDaQuocGia.DBContext
{
    public class DBC_LoaiCauThu : DbContext
    {
        public DBC_LoaiCauThu(DbContextOptions options) : base(options)
        {
        }

        public DbSet<DTO_LoaiCauThu> LocalRepository { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DTO_LoaiCauThu>(entity =>
            {
                entity.HasKey(obj => obj.MaLoaiCauThu);
                entity.ToTable("LOAICAUTHU");

                entity.Property(obj => obj.TenLoaiCauThu);
                entity.Property(obj => obj.SoLuongCauThuToiDaTheoLoaiCauThu);
            });
        }
    }
}
