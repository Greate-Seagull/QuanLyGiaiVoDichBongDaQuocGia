using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyGiaiVoDichBongDaQuocGia.DTO
{
    public class DTO_TranDau
    {
        [Key, MaxLength(5)]
        public string? MaTranDau { get; set; }

        public DateTime? NgayGio { get; set; }

        [Required, MaxLength(5)]
        public string? MaDoi1 { get; set; }

        [ForeignKey(nameof(MaDoi1))]
        public DTO_DoiBong? DoiBong1 { get; set; }

        [Required, MaxLength(5)]
        public string? MaDoi2 { get; set; }

        [ForeignKey(nameof(MaDoi2))]
        public DTO_DoiBong? DoiBong2 { get; set; }

        [Required, MaxLength(5)]
        public string? MaVongDau { get; set; }

        [ForeignKey(nameof(MaVongDau))]
        public DTO_VongDau? VongDau { get; set; }
        public int? TiSoDoi1 { get; set; } = 0;
        public int? TiSoDoi2 { get; set; } = 0;
        public bool Deleted { get; set; } = false;

        //TranDau is already in database and is tracked in EF Core when loading them, this property for inserting BanThang
        public List<DTO_BanThang>? CacBanThang { get; set; }

        //For debugging and displaying
        public string TiSo => $"{TiSoDoi1 ?? 0} - {TiSoDoi2 ?? 0}";
        public string CapDau => $"{DoiBong1?.TenDoiBong ?? string.Empty} - {DoiBong2?.TenDoiBong ?? string.Empty}";
    }
}
