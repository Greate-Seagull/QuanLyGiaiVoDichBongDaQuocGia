using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;

namespace QuanLyGiaiVoDichBongDaQuocGia.DBContext
{
    public class DBC_VongDau : DbContext
    {
        public DBC_VongDau(DbContextOptions options) : base(options)
        {
        }

        public DbSet<DTO_VongDau> LocalRepository { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DTO_VongDau>(entity =>
            {
                entity.HasKey(obj => obj.MaVongDau);
                entity.ToTable("VONGDAU");

                entity.Property(obj => obj.TenVongDau);
                entity.Property(obj => obj.NgayBatDau);
                entity.Property(obj => obj.NgayKetThuc);
            });
        }
    }
}
