using QuanLyGiaiVoDichBongDaQuocGia.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.DTO
{
    public class DTO_BanThang
    {   
        public string? MaBanThang { get; set; }
        public DTO_TranDau? TranDau { get; set; }
        public DTO_CauThu? CauThu { get; set; }
        public DTO_LoaiBanThang? LoaiBanThang { get; set; }
        public int ThoiDiemGhiBan { get; set; }

        public override string ToString()
        {
            return $"{CauThu} - {CauThu?.DoiBong} - {TranDau} - {LoaiBanThang} - {ThoiDiemGhiBan}";
        }
    }

    public enum BanThangColumn
    {
        MaBanThang,
        MaTranDau,
        MaCauThu,
        MaLoaiBanThang,
        ThoiDiemGhiBan
    }

    public class BanThangConverter: ColumnConverter<BanThangColumn, DTO_BanThang>
    {
        private static readonly BanThangConverter _instance = new BanThangConverter();

        public static BanThangConverter Instance => _instance;

        private readonly Dictionary<BanThangColumn, Func<DTO_BanThang, object>> columns = new()
        {
            { BanThangColumn.MaBanThang, storer => storer.MaBanThang},
            { BanThangColumn.MaTranDau, storer => storer.TranDau.MaTranDau },
            { BanThangColumn.MaCauThu, storer => storer.CauThu.MaCauThu },
            { BanThangColumn.MaLoaiBanThang, storer => storer.LoaiBanThang.MaLoaiBanThang },
            { BanThangColumn.ThoiDiemGhiBan, storer => storer.ThoiDiemGhiBan }
        };
        
        public Func<DTO_BanThang, object> this[BanThangColumn col] => columns[col];
    }
}
