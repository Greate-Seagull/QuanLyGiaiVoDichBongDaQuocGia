using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyGiaiVoDichBongDaQuocGia.DTO
{
    public class DTO_LoaiCauThu
    {
        [Key, MaxLength(5)]
        public string MaLoaiCauThu { get; set; }

        [Required, MaxLength(50)]
        public string? TenLoaiCauThu { get; set; }
        public int? SoLuongCauThuToiDaTheoLoaiCauThu { get; set; }

        [InverseProperty("LoaiCauThu")]
        public List<DTO_CauThu>? CacCauThu { get; set; }
    }
}
