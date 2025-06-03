using Microsoft.Extensions.DependencyInjection;
using QuanLyGiaiVoDichBongDaQuocGia.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyGiaiVoDichBongDaQuocGia.GUI
{
    public partial class GUI_Dashboard : Form
    {
        private readonly IServiceProvider provider;
        private readonly FormNavigator navigator;

        public GUI_Dashboard(IServiceProvider provider, FormNavigator navigator)
        {
            InitializeComponent();

            //Dependencies
            this.provider = provider;
            this.navigator = navigator;
        }

        private void GUI_Dashboard_Load(object sender, EventArgs e)
        {
            navigator.SetContainer(pFormContainer);

            btnBangXepHangDoiBong_Click(btnBangXepHangCauThu, EventArgs.Empty);
        }

        private void btnBangXepHangDoiBong_Click(object sender, EventArgs e)
        {
            navigator.Navigate(provider.GetRequiredService<GUI_LapBangXepHang>());
        }

        private void btnBangXepHangCauThu_Click(object sender, EventArgs e)
        {
            navigator.Navigate(provider.GetRequiredService<GUI_LapDanhSachCauThuGhiBan>());
        }

        private void btnTiepNhanDoiBong_Click(object sender, EventArgs e)
        {
            navigator.Navigate(provider.GetRequiredService<GUI_TiepNhanDoiBong>());
        }

        private void btnLapLichThiDau_Click(object sender, EventArgs e)
        {
            navigator.Navigate(provider.GetRequiredService<GUI_LapLichThiDau>());
        }

        private void btnGhiNhanKetQua_Click(object sender, EventArgs e)
        {
            navigator.Navigate(provider.GetRequiredService<GUI_GhiNhanKetQua>());
        }

        private void btnTraCuuCauThu_Click(object sender, EventArgs e)
        {
            navigator.Navigate(provider.GetRequiredService<GUI_TraCuuCauThu>());
        }

        private void btnThayDoiQuiDinh_Click(object sender, EventArgs e)
        {
            navigator.Navigate(provider.GetRequiredService<GUI_ThayDoiQuiDinh>());
        }
    }
}
