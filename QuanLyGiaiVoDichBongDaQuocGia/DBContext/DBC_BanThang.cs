using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;

namespace QuanLyGiaiVoDichBongDaQuocGia.DBContext
{
    public class DBC_BanThang : DbContext
    {
        public DBC_BanThang(DbContextOptions options) : base(options)
        {
        }

        public DbSet<DTO_BanThang> LocalRepository { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DTO_BanThang>(entity =>
            {
                entity.HasKey(obj => obj.MaBanThang);
                entity.ToTable("BANTHANG");

                entity.HasOne(obj => obj.TranDau)
                      .WithMany()
                      .HasForeignKey(obj => obj.MaTranDau);

                entity.HasOne(obj => obj.CauThu)
                      .WithMany()
                      .HasForeignKey(obj => obj.MaCauThu);

                entity.HasOne(obj => obj.LoaiBanThang)
                      .WithMany()
                      .HasForeignKey(obj => obj.MaLoaiBanThang);

                entity.Property(obj => obj.ThoiDiemGhiBan);
            });
        }
    }
}
