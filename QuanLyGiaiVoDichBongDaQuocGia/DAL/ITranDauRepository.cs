using QuanLyGiaiVoDichBongDaQuocGia.DTO;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    interface ITranDauRepository: IRepository<DTO_TranDau>
    {
        string GetLastID();
    }
}
