using QuanLyGiaiVoDichBongDaQuocGia.BUS;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.Helper
{
    public interface ColumnConverter<Column, DTO>
        where Column: Enum
    {
        Func<DTO, object> this[Column col] { get; }
    }   
}
