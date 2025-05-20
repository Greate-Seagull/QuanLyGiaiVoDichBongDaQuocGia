using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;

namespace QuanLyGiaiVoDichBongDaQuocGia.DBContext
{
    public class MySqlDbContext : DbContext
    {
        public MySqlDbContext(DbContextOptions options) : base(options) { }

        public DbSet<DTO_BanThang> BanThangRepository { get; set; }
        public DbSet<DTO_CauThu> CauThuRepository { get; set; }
        public DbSet<DTO_DoiBong> DoiBongRepository { get; set; }
        public DbSet<DTO_LoaiBanThang> LoaiBanThangRepository { get; set; }
        public DbSet<DTO_LoaiCauThu> LoaiCauThuRepository { get; set; }
        public DbSet<DTO_ThamSo> ThamSoRepository { get; set; }
        public DbSet<DTO_TranDau> TranDauRepository { get; set; }
        public DbSet<DTO_VongDau> VongDauRepository { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Configure ThamSo entity
            modelBuilder.Entity<DTO_ThamSo>(entity =>
            {
                entity.ToTable("THAMSO");
            });

            //Configure BanThang entity
            modelBuilder.Entity<DTO_BanThang>(entity =>
            {
                entity.ToTable("BANTHANG");
                entity.HasQueryFilter(obj => obj.Deleted == false);
            });

            //Configure CauThu entity
            modelBuilder.Entity<DTO_CauThu>(entity =>
            {
                entity.ToTable("CAUTHU");
                entity.HasQueryFilter(obj => obj.Deleted == false);
            });

            //Configure DoiBong entity
            modelBuilder.Entity<DTO_DoiBong>(entity =>
            {
                entity.ToTable("DOIBONG");
                entity.HasQueryFilter(obj => obj.Deleted == false);
            });

            //Configure LoaiBanThang entity
            modelBuilder.Entity<DTO_LoaiBanThang>(entity =>
            {
                entity.ToTable("LOAIBANTHANG");
                entity.HasQueryFilter(obj => obj.Deleted == false);
            });

            //Configure LoaiCauThu entity
            modelBuilder.Entity<DTO_LoaiCauThu>(entity =>
            {
                entity.ToTable("LOAICAUTHU");
            });            

            //Configure TranDau entity
            modelBuilder.Entity<DTO_TranDau>(entity =>
            {
                entity.ToTable("TRANDAU");
                entity.HasQueryFilter(obj => obj.Deleted == false);
            });

            //Configure VongDau entity
            modelBuilder.Entity<DTO_VongDau>(entity =>
            {
                entity.ToTable("VONGDAU");
                entity.HasQueryFilter(obj => obj.Deleted == false);
            });
        }
    }
}
