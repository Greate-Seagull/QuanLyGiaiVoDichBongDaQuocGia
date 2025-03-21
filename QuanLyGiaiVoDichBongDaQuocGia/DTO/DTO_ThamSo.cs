using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.DTO
{
    public class DTO_ThamSo
    {
        private int tuoiCauThuToiThieu;
        private int tuoiCauThuToiDa;
        private int soLuongCauThuToiThieu;
        private int soLuongCauThuToiDa;

        public DTO_ThamSo(int tuoiCauThuToiThieu, int tuoiCauThuToiDa, int soLuongCauThuToiThieu, int soLuongCauThuToiDa)
        {
            this.tuoiCauThuToiThieu = tuoiCauThuToiThieu;
            this.tuoiCauThuToiDa = tuoiCauThuToiDa;
            this.soLuongCauThuToiThieu = soLuongCauThuToiThieu;
            this.soLuongCauThuToiDa = soLuongCauThuToiDa;
        }

        public int TuoiCauThuToiThieu { get => tuoiCauThuToiThieu; set => tuoiCauThuToiThieu = value; }
        public int TuoiCauThuToiDa { get => tuoiCauThuToiDa; set => tuoiCauThuToiDa = value; }
        public int SoLuongCauThuToiThieu { get => soLuongCauThuToiThieu; set => soLuongCauThuToiThieu = value; }
        public int SoLuongCauThuToiDa { get => soLuongCauThuToiDa; set => soLuongCauThuToiDa = value; }
    }
}
