using QuanLyGiaiVoDichBongDaQuocGia.DTO;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    interface IBanThangRepository: IRepository<DTO_BanThang>
    {
        string GetLastID();
    }
}
