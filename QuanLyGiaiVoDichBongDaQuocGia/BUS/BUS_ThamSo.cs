using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyGiaiVoDichBongDaQuocGia.BUS
{
    class BUS_ThamSo
    {
        DAL.DAL_ThamSo DAL_thamSo = new DAL.DAL_ThamSo();

        public DTO_ThamSo LayThamSo()
        {
            return DAL_thamSo.LayThamSo();
        }
    }
}
