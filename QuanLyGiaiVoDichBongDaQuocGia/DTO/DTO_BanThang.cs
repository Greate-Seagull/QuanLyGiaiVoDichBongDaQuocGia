using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuanLyGiaiVoDichBongDaQuocGia.DTO
{
    public class DTO_BanThang
    {
        [Key, MaxLength(5)]
        public string MaBanThang { get; set; }

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

        //For displaying
        public string ThongTin
        {
            get
            {
                if (MaBanThang == "Tất cả")
                    return MaBanThang;

                DTO_DoiBong? doiBong;
                if (CauThu?.MaDoiBong == TranDau?.MaDoi1)
                    doiBong = TranDau?.DoiBong2;
                else if (CauThu?.MaDoiBong == TranDau?.MaDoi2)
                    doiBong = TranDau?.DoiBong1;
                else
                    doiBong = default;

                return $"{CauThu?.TenCauThu ?? "Error"} ghi bàn vào lưới {doiBong?.TenDoiBong ?? "Error"} phút {ThoiDiemGhiBan ?? 0}";
            }
        }
    }
}
