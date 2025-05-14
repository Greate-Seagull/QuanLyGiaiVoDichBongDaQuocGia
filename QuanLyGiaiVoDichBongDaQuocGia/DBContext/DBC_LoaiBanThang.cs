using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;

namespace QuanLyGiaiVoDichBongDaQuocGia.DBContext
{
    public class DBC_LoaiBanThang : DbContext
    {
        public DBC_LoaiBanThang(DbContextOptions options) : base(options)
        {
        }

        public DbSet<DTO_LoaiBanThang> LocalRepository { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DTO_LoaiBanThang>(entity =>
            {
                entity.HasKey(obj => obj.MaLoaiBanThang);
                entity.ToTable("LOAIBANTHANG");

                entity.Property(obj => obj.TenLoaiBanThang);
            });
        }
    }
}
