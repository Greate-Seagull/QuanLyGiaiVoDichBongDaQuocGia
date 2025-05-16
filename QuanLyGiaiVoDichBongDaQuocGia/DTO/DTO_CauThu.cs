using System.ComponentModel.DataAnnotations;

namespace QuanLyGiaiVoDichBongDaQuocGia.DTO
{
    public class DTO_CauThu
    {
        [Key, MaxLength(5)]
        public string? MaCauThu { get; set; }

        [Required, MaxLength(50)]
        public string? TenCauThu { get; set; }

        [Required]
        public DateTime NgaySinh { get; set; }

        [Required, MaxLength(5)]
        public string? MaLoaiCauThu { get; set; }

        [Required, MaxLength(5)]
        public string? MaDoiBong { get; set; }

        [MaxLength(300)]
        public string? GhiChu { get; set; }
        public bool Deleted { get; set; } = false;
        public override string ToString()
        {
            return TenCauThu;
        }
    }
}
