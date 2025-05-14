using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;

namespace QuanLyGiaiVoDichBongDaQuocGia.DBContext
{
    internal class DBC_CauThu : DbContext
    {
        public DBC_CauThu(DbContextOptions options) : base(options)
        {
        }

        public DbSet<DTO_CauThu> LocalRepository { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DTO_CauThu>(entity =>
            {
                entity.HasKey(obj => obj.MaCauThu);
                entity.ToTable("CAUTHU");

                entity.Property(obj => obj.TenCauThu);
                entity.Property(obj => obj.NgaySinh);

                entity.HasOne(obj => obj.LoaiCauThu)
                      .WithMany()
                      .HasForeignKey(obj => obj.MaLoaiCauThu);

                entity.HasOne(obj => obj.DoiBong)
                      .WithMany()
                      .HasForeignKey(obj => obj.MaDoiBong);

                entity.Property(obj => obj.GhiChu);
            });
        }
    }
}
