using QuanLyGiaiVoDichBongDaQuocGia.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.DTO
{
    public class DTO_VongDau
    {
        public string? MaVongDau { get; set; }
        public string? TenVongDau { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }

        public override string ToString()
        {
            return TenVongDau;
        }
    }

    public enum VongDauColumn
    {
        MaVongDau,
        TenVongDau,
        NgayBatDau,
        NgayKetThuc
    }

    public class VongDauConverter: ColumnConverter<VongDauColumn, DTO_VongDau>
    {
        private static readonly VongDauConverter _instance = new();
        public static VongDauConverter Instance => _instance;

        private readonly Dictionary<VongDauColumn, Func<DTO_VongDau, object>> columns = new()
        {
            { VongDauColumn.MaVongDau, storer => storer.MaVongDau},
            { VongDauColumn.TenVongDau, storer => storer.TenVongDau },
            { VongDauColumn.NgayBatDau, storer => storer.NgayBatDau },
            { VongDauColumn.NgayKetThuc, storer => storer.NgayKetThuc }
        };

        public Func<DTO_VongDau, object> this[VongDauColumn col] => columns[col];
    }
}
