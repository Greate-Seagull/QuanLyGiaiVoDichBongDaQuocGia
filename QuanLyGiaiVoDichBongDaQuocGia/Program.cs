using Microsoft.EntityFrameworkCore;
using QuanLyGiaiVoDichBongDaQuocGia.BUS;
using QuanLyGiaiVoDichBongDaQuocGia.DAL;
using QuanLyGiaiVoDichBongDaQuocGia.DBContext;
using QuanLyGiaiVoDichBongDaQuocGia.GUI;
using System.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuanLyGiaiVoDichBongDaQuocGia.Manager;

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

            var services = new ServiceCollection();
            ConfigureServices(services);

            var provider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();
            Application.Run(provider.GetRequiredService<GUI_Dashboard>());
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            //Read connection string
            var connectionString = ConfigurationManager.ConnectionStrings["MySQlConnection"].ConnectionString;

            //Register DbContext
            //var options = new DbContextOptionsBuilder<MySqlDbContext>().UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)).Options;
            services.AddDbContext<MySqlDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            //Register DALs
            services.AddScoped<DAL_ThamSo>();
            services.AddScoped<DAL_CauThu>();
            services.AddScoped<DAL_DoiBong>();
            services.AddScoped<DAL_LoaiCauThu>();
            services.AddScoped<DAL_BanThang>();
            services.AddScoped<DAL_TranDau>();
            services.AddScoped<DAL_VongDau>();
            services.AddScoped<DAL_LoaiBanThang>();

            //Register BUSs
            services.AddScoped<BUS_ThamSo>();
            services.AddScoped<BUS_CauThu>();
            services.AddScoped<BUS_DoiBong>();
            services.AddScoped<BUS_LoaiCauThu>();
            services.AddScoped<BUS_BanThang>();
            services.AddScoped<BUS_TranDau>();
            services.AddScoped<BUS_VongDau>();
            services.AddScoped<BUS_LoaiBanThang>();

            //Register Forms
            services.AddTransient<GUI_TiepNhanDoiBong>();
            services.AddTransient<GUI_LapLichThiDau>();
            services.AddTransient<GUI_GhiNhanKetQua>();
            services.AddTransient<GUI_ThayDoiQuiDinh>();
            services.AddScoped<GUI_TraCuuCauThu>();
            services.AddScoped<GUI_LapDanhSachCauThuGhiBan>();
            services.AddScoped<GUI_LapBangXepHang>();
            services.AddScoped<GUI_Dashboard>();

            //Register navigator
            services.AddScoped<FormNavigator>();
        }
    }
}