using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.DTO
{
    public class DTO_TranDau
    {
        private string maTranDau;
        private DTO_DoiBong doiBong1;
        private DTO_DoiBong doiBong2;
        private DTO_VongDau vongDau;
        private DateTime ngayGio;

        public DTO_TranDau(string maTranDau, DTO_DoiBong doiBong1, DTO_DoiBong doiBong2, DTO_VongDau vongDau, DateTime ngayGio)
        {
            this.maTranDau = maTranDau;
            this.doiBong1 = doiBong1;
            this.doiBong2 = doiBong2;
            this.vongDau = vongDau;
            this.ngayGio = ngayGio;
        }

        public string MaTranDau { get => maTranDau; set => maTranDau = value; }
        public DateTime NgayGio { get => ngayGio; set => ngayGio = value; }
        public DTO_DoiBong DoiBong1 { get => doiBong1; set => doiBong1 = value; }
        public DTO_DoiBong DoiBong2 { get => doiBong2; set => doiBong2 = value; }
        public DTO_VongDau VongDau { get => vongDau; set => vongDau = value; }

        public override string ToString()
        {
            return $"{doiBong1} - {doiBong2}";
        }
    }
}
