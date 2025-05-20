using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.ViewModel
{
    public class VM_LoaiBanThang
    {
        public string MaLoaiBanThang { get; set; }
        public string TenLoaiBanThang { get; set; } = string.Empty;

        public bool Disabled { get; set; } = false;
    }
}
