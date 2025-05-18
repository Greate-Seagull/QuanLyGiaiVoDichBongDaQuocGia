using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyGiaiVoDichBongDaQuocGia.DTO
{
    public class DTO_BanThang
    {
        [Key, MaxLength(5)]
        public string? MaBanThang { get; set; }

        [Required, MaxLength(5)]
        public string? MaTranDau { get; set; }

        [ForeignKey(nameof(MaTranDau))]
        public DTO_TranDau? TranDau { get; set; }

        [Required, MaxLength(5)]
        public string? MaCauThu { get; set; }

        [ForeignKey(nameof(MaCauThu))]
        public DTO_CauThu? CauThu { get; set; }

        [Required, MaxLength(5)]
        public string? MaLoaiBanThang { get; set; }

        [ForeignKey(nameof(MaLoaiBanThang))]
        public DTO_LoaiBanThang? LoaiBanThang { get; set; }

        public int? ThoiDiemGhiBan { get; set; }
        public bool Deleted { get; set; } = false;
    }
}
