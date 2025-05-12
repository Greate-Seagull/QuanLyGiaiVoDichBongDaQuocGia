using QuanLyGiaiVoDichBongDaQuocGia.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace QuanLyGiaiVoDichBongDaQuocGia.DTO
{
    public class DTO_CauThu
    {
        public string? MaCauThu { get; set; }
        public string? TenCauThu { get; set; }
        public DateTime NgaySinh { get; set; }
        public string? MaLoaiCauThu { get; set; }
        public string? GhiChu { get; set; }
        internal DTO_DoiBong? DoiBong { get; set; }
        internal DTO_LoaiCauThu? LoaiCauThu { get; set; }

        public override string ToString()
        {
            return TenCauThu;
        }
    }

    public enum CauThuColumn
    {
        MaCauThu,
        TenCauThu,
        NgaySinh,
        GhiChu,
        MaDoiBong,
        MaLoaiCauThu
    }

    public class CauThuConverter: ColumnConverter<CauThuColumn, DTO_CauThu>
    {
        private static readonly CauThuConverter _instance = new();

        public static CauThuConverter Instance => _instance;

        Dictionary<CauThuColumn, Func<DTO_CauThu, object>> columns = new()
        {
            { CauThuColumn.MaCauThu, storer => storer.MaCauThu },
            { CauThuColumn.TenCauThu, storer => storer.TenCauThu },
            { CauThuColumn.MaLoaiCauThu, storer => storer.LoaiCauThu.MaLoaiCauThu },
            { CauThuColumn.MaDoiBong, storer => storer.DoiBong.MaDoiBong },
            { CauThuColumn.NgaySinh, storer => storer.NgaySinh },
            { CauThuColumn.GhiChu, storer => storer.GhiChu }
        };

        public Func<DTO_CauThu, object> this[CauThuColumn col] => columns[col];
    }
}
