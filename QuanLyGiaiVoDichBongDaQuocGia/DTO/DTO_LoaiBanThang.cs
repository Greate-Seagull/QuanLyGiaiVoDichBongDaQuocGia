using System.ComponentModel.DataAnnotations;

namespace QuanLyGiaiVoDichBongDaQuocGia.DTO
{
    public class DTO_LoaiBanThang
    {
        [Key, MaxLength(5)]
        public string? MaLoaiBanThang { get; set; }

        [Required, MaxLength(5)]
        public string? TenLoaiBanThang { get; set; }

        public List<DTO_BanThang>? CacBanThang { get; set; }
    }
}
