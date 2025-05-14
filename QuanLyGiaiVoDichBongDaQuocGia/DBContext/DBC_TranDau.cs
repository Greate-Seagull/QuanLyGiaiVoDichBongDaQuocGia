using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;

namespace QuanLyGiaiVoDichBongDaQuocGia.DBContext
{
    public class DBC_TranDau: DbContext
    {
        public DBC_TranDau(DbContextOptions options) : base(options)
        {
        }

        public DbSet<DTO_TranDau> LocalRepository { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DTO_TranDau>(entity =>
            {
                entity.HasKey(obj => obj.MaTranDau);
                entity.ToTable("TRANDAU");

                entity.Property(obj => obj.NgayGio);

                entity.HasOne(x => x.DoiBong1)
                      .WithMany()
                      .HasForeignKey(x => x.MaDoi1);

                entity.HasOne(x => x.DoiBong2)
                      .WithMany()
                      .HasForeignKey(x => x.MaDoi2);

                entity.Property(x => x.TiSoDoi1);
                entity.Property(x => x.TiSoDoi2);
            }
            );
        }
    }
}
