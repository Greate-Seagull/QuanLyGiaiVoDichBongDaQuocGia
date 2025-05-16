using System.ComponentModel.DataAnnotations;

namespace QuanLyGiaiVoDichBongDaQuocGia.DTO
{
    public class DTO_DoiBong
    {
        [Key, MaxLength(5)]
        public string? MaDoiBong { get; set; }

        [Required, MaxLength(50)]
        public string? TenDoiBong { get; set; }

        [Required, MaxLength(50)]
        public string? TenSanNha { get; set; }
        public bool Deleted { get; set; } = false;
        public override string ToString()
        {
            return TenDoiBong;
        }
    }
}
