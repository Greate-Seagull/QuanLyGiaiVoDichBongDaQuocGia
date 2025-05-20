using System.ComponentModel.DataAnnotations;

namespace QuanLyGiaiVoDichBongDaQuocGia.DTO
{
    public class DTO_ThamSo
    {
        [Key]
        public int MaThamSo { get; set; } = 0;
        public int TuoiCauThuToiThieu { get; set; }
        public int TuoiCauThuToiDa { get; set; }
        public int SoLuongCauThuToiThieu { get; set; }
        public int SoLuongCauThuToiDa { get; set; }
        public int ThoiDiemGhiBanToiThieu { get; set; }
        public int ThoiDiemGhiBanToiDa { get; set; }
        public int DiemThang { get; set; }
        public int DiemHoa { get; set; }
        public int DiemThua { get; set; }
    }
}
