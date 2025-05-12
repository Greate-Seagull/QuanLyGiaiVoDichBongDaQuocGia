using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.DTO
{
    public class DTO_TranDau
    {
        public string? MaTranDau { get; set; }
        public DateTime NgayGio { get; set; }
        public DTO_DoiBong? DoiBong1 { get; set; }
        public DTO_DoiBong? DoiBong2 { get; set; }
        public DTO_VongDau? VongDau { get; set; }
        public int TiSoDoi1 { get; set; }
        public int TiSoDoi2 { get; set; }

        public override string ToString()
        {
            return $"{DoiBong1} - {DoiBong2}";
        }
    }
}
