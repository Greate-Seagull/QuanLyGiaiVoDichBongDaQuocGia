using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.Manager;
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

        private readonly string THAMSO = "THAMSO";

        public DTO_ThamSo LayThamSo()
        {
            return CacheManager.GetOrLoad(THAMSO, () => DAL_thamSo.LayThamSo());
        }
    }
}
