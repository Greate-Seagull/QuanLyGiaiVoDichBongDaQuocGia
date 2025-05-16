using QuanLyGiaiVoDichBongDaQuocGia.DTO;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    interface ILoaiCauThuRepository: IRepository<DTO_LoaiCauThu>
    {
        string GetLastID();
    }
}
