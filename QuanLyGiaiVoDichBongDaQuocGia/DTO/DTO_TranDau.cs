using QuanLyGiaiVoDichBongDaQuocGia.Helper;
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

    public enum TranDauColumn
    {
        MaTranDau,
        MaVongDau,
        MaDoi1,
        MaDoi2,
        NgayGio,
        TiSoDoi1,
        TiSoDoi2
    }

    public class TranDauConverter: ColumnConverter<TranDauColumn, DTO_TranDau>
    {
        private static readonly TranDauConverter _instance = new();
        public static TranDauConverter Instance => _instance;

        private readonly Dictionary<TranDauColumn, Func<DTO_TranDau, object>> columns = new()
        {
            { TranDauColumn.MaTranDau, storer => storer.MaTranDau},
            { TranDauColumn.MaVongDau, storer => storer.VongDau.MaVongDau },
            { TranDauColumn.MaDoi1, storer => storer.DoiBong1.MaDoiBong },
            { TranDauColumn.MaDoi2, storer => storer.DoiBong2.MaDoiBong},
            { TranDauColumn.NgayGio, storer => storer.NgayGio },
            { TranDauColumn.TiSoDoi1, storer => storer.TiSoDoi1 },
            { TranDauColumn.TiSoDoi2, storer => storer.TiSoDoi2 }
        };

        public Func<DTO_TranDau, object> this[TranDauColumn col] => columns[col];
    }
}
