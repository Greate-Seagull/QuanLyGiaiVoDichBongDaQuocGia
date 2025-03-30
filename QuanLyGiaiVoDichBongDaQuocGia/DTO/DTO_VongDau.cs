using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.DTO
{
    public class DTO_VongDau
    {
        private string maVongDau;
        private string tenVongDau;

        public DTO_VongDau(string maVongDau, string tenVongDau)
        {
            this.MaVongDau = maVongDau;
            this.TenVongDau = tenVongDau;
        }

        public string MaVongDau { get => maVongDau; set => maVongDau = value; }
        public string TenVongDau { get => tenVongDau; set => tenVongDau = value; }

        public override string ToString()
        {
            return TenVongDau;
        }
    }
}
