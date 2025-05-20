using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyGiaiVoDichBongDaQuocGia.DTO
{
    public class DTO_DoiBong
    {
        [Key, MaxLength(5)]
        public string MaDoiBong { get; set; }

        [Required, MaxLength(50)]
        public string? TenDoiBong { get; set; }

        [Required, MaxLength(50)]
        public string? TenSanNha { get; set; }
        public bool Deleted { get; set; } = false;

        [InverseProperty("DoiBong")]
        public List<DTO_CauThu>? CacCauThu { get; set; }        
    }
}
