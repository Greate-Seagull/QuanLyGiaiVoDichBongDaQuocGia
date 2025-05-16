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

            var connectionString = ConfigurationManager.ConnectionStrings["MySQlConnection"].ConnectionString;

            var options = new DbContextOptionsBuilder<MySqlDbContext>().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)).Options;

            MySqlDbContext dbContext = new(options);

            DAL_ThamSo _DAL_ThamSo = new(dbContext);
            DAL_CauThu _DAL_CauThu = new(dbContext);
            DAL_DoiBong _DAL_DoiBong = new(dbContext);
            DAL_LoaiCauThu _DAL_LoaiCauThu = new(dbContext);

            BUS_ThamSo _BUS_ThamSo = new(_DAL_ThamSo);
            BUS_CauThu _BUS_CauThu = new(_DAL_CauThu);
            BUS_DoiBong _BUS_DoiBong = new(_DAL_DoiBong, _BUS_CauThu);
            BUS_LoaiCauThu _BUS_LoaiCauThu = new(_DAL_LoaiCauThu);

            ApplicationConfiguration.Initialize();
            Application.Run(new GUI_TiepNhanDoiBong(_BUS_ThamSo, _BUS_DoiBong, _BUS_CauThu, _BUS_LoaiCauThu));
        }
    }
}