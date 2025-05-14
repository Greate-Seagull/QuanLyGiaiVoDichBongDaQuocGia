using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;

namespace QuanLyGiaiVoDichBongDaQuocGia.DBContext
{
    public class DBC_DoiBong : DbContext
    {
        public DBC_DoiBong(DbContextOptions options) : base(options)
        {
        }

        public DbSet<DTO_DoiBong> LocalRepository { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DTO_DoiBong>(entity =>
            {
                entity.HasKey(obj => obj.MaDoiBong);
                entity.ToTable("DOIBONG");

                entity.Property(obj => obj.TenDoiBong);
                entity.Property(obj => obj.TenSanNha);
            });
        }
    }
}
