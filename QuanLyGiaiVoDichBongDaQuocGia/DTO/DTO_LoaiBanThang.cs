using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyGiaiVoDichBongDaQuocGia.DTO
{
    public class DTO_LoaiBanThang
    {
        [Key, MaxLength(5)]
        public string MaLoaiBanThang { get; set; }

        [Required, MaxLength(5)]
        public string? TenLoaiBanThang { get; set; }

        [InverseProperty("LoaiBanThang")]
        public List<DTO_BanThang>? CacBanThang { get; set; }
    }
}
