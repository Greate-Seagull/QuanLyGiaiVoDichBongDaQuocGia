using System.ComponentModel.DataAnnotations;

namespace QuanLyGiaiVoDichBongDaQuocGia.DTO
{
    public class DTO_LoaiCauThu
    {
        [Key, MaxLength(5)]
        public string? MaLoaiCauThu { get; set; }

        [Required, MaxLength(50)]
        public string? TenLoaiCauThu { get; set; }
        public int SoLuongCauThuToiDaTheoLoaiCauThu { get; set; }

        public List<DTO_CauThu> CacCauThu { get; set; }

        public override string ToString()
        {
            return TenLoaiCauThu;
        }
    }
}
