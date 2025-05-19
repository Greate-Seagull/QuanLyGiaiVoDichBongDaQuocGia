using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.BUS;
using QuanLyGiaiVoDichBongDaQuocGia.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using QuanLyGiaiVoDichBongDaQuocGia.GUI;
using System.Configuration;

namespace QuanLyGiaiVoDichBongDaQuocGia
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            //Register Syncfusion<sup style="font-size:70%">&reg;</sup> license
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NNaF5cXmBCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdmWXpfdnVURmhZWEFwXkRWYUA=");

            var connectionString = ConfigurationManager.ConnectionStrings["MySQlConnection"].ConnectionString;

            var options = new DbContextOptionsBuilder<MySqlDbContext>().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)).Options;

            MySqlDbContext dbContext = new(options);

            DAL_ThamSo _DAL_ThamSo = new(dbContext);
            DAL_CauThu _DAL_CauThu = new(dbContext);
            DAL_DoiBong _DAL_DoiBong = new(dbContext);
            DAL_LoaiCauThu _DAL_LoaiCauThu = new(dbContext);
            DAL_BanThang _DAL_BanThang = new(dbContext);
            DAL_TranDau _DAL_TranDau = new(dbContext);
            DAL_VongDau _DAL_VongDau = new(dbContext);
            DAL_LoaiBanThang _DAL_LoaiBanThang = new(dbContext);

            BUS_ThamSo _BUS_ThamSo = new(_DAL_ThamSo);
            BUS_CauThu _BUS_CauThu = new(_DAL_CauThu);
            BUS_DoiBong _BUS_DoiBong = new(_DAL_DoiBong, _BUS_CauThu);
            BUS_LoaiCauThu _BUS_LoaiCauThu = new(_DAL_LoaiCauThu);
            BUS_BanThang _BUS_BanThang = new(_DAL_BanThang);
            BUS_TranDau _BUS_TranDau = new(_DAL_TranDau, _BUS_BanThang);
            BUS_VongDau _BUS_VongDau = new(_DAL_VongDau, _BUS_TranDau);
            BUS_LoaiBanThang _BUS_LoaiBanThang = new(_DAL_LoaiBanThang);

            ApplicationConfiguration.Initialize();
            Application.Run(new GUI_TraCuuCauThu(_BUS_CauThu, _BUS_DoiBong, _BUS_LoaiCauThu, _BUS_VongDau, _BUS_TranDau, _BUS_LoaiBanThang, _BUS_BanThang));
        }
    }
}