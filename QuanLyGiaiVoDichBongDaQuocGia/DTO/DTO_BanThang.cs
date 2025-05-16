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

        [Required, MaxLength(5)]
        public string? MaCauThu { get; set; }

        [Required, MaxLength(5)]
        public string? MaLoaiBanThang { get; set; }

        public int ThoiDiemGhiBan { get; set; }
        public bool Deleted { get; set; } = false;
    }
}
