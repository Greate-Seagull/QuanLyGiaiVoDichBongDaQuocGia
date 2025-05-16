using QuanLyGiaiVoDichBongDaQuocGia.DTO;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    interface ICauThuRepository: IRepository<DTO_CauThu>
    {
        string GetLastID();
    }
}
