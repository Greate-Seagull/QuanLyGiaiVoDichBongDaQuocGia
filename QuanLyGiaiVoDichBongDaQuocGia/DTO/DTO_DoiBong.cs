using QuanLyGiaiVoDichBongDaQuocGia.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.DTO
{
    public class DTO_DoiBong
    {
        public string? MaDoiBong { get; set; }
        public string? TenDoiBong { get; set; }
        public string? TenSanNha { get; set; }

        public override string ToString()
        {
            return TenDoiBong;
        }
    }

    public enum DoiBongColumn
    {
        MaDoiBong,
        TenDoiBong,
        TenSanNha
    }

    public class DoiBongConverter: ColumnConverter<DoiBongColumn, DTO_DoiBong>
    {
        private static readonly DoiBongConverter _instance = new();
        public static DoiBongConverter Instance => _instance;

        private readonly Dictionary<DoiBongColumn, Func<DTO_DoiBong, object>> columns = new()
        {
            { DoiBongColumn.MaDoiBong, storer => storer.MaDoiBong},
            { DoiBongColumn.TenDoiBong, storer => storer.TenDoiBong },
            { DoiBongColumn.TenSanNha, storer => storer.TenSanNha }
        };

        public Func<DTO_DoiBong, object> this[DoiBongColumn col] => columns[col];
    }
}
