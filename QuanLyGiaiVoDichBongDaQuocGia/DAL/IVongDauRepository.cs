using QuanLyGiaiVoDichBongDaQuocGia.DTO;

namespace QuanLyGiaiVoDichBongDaQuocGia.DAL
{
    interface IVongDauRepository: IRepository<DTO_VongDau>
    {
        string GetLastID();
    }
}
