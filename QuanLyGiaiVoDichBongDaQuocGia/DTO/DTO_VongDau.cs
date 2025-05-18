using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyGiaiVoDichBongDaQuocGia.DTO
{
    public class DTO_VongDau
    {
        [Key, MaxLength(5)]
        public string? MaVongDau { get; set; }

        [Required, MaxLength(5)]
        public string? TenVongDau { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public bool Deleted { get; set; } = false;

        public List<DTO_TranDau> CacTranDau { get; set; }
    }
}
