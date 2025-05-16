using QuanLyGiaiVoDichBongDaQuocGia.DTO;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    interface IDoiBongRepository: IRepository<DTO_DoiBong>
    {
        string GetLastID();
    }
}
