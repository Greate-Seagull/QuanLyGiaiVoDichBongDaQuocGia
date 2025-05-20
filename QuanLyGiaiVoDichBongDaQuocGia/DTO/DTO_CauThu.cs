using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyGiaiVoDichBongDaQuocGia.DTO
{
    public class DTO_CauThu
    {
        [Key, MaxLength(5)]
        public string MaCauThu { get; set; }

        [Required, MaxLength(50)]
        public string? TenCauThu { get; set; }

        [Required]
        public DateTime? NgaySinh { get; set; }

        [Required, MaxLength(5)]
        public string? MaLoaiCauThu { get; set; }

        [ForeignKey(nameof(MaLoaiCauThu))]
        public DTO_LoaiCauThu? LoaiCauThu { get; set; }

        [Required, MaxLength(5)]
        public string? MaDoiBong { get; set; }

        [ForeignKey(nameof(MaDoiBong))]
        public DTO_DoiBong? DoiBong { get; set; }

        [MaxLength(300)]
        public string? GhiChu { get; set; }
        public bool Deleted { get; set; } = false;

        [InverseProperty("CauThu")]
        public List<DTO_BanThang>? CacBanThang { get; set; }

        //For debugging and displaying
        [NotMapped]
        public string TenLoaiCauThu => LoaiCauThu?.TenLoaiCauThu ?? string.Empty;
        [NotMapped]
        public string TenDoiBong => DoiBong?.TenDoiBong ?? string.Empty;
    }
}
