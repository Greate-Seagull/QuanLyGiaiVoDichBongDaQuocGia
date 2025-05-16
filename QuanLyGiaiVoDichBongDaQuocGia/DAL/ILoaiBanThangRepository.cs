using QuanLyGiaiVoDichBongDaQuocGia.DTO;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    interface ILoaiBanThangRepository: IRepository<DTO_LoaiBanThang>
    {
        string GetLastID();
    }
}
