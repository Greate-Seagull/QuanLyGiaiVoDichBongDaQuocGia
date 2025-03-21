using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.Helper;
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
    public partial class GUI_TiepNhanDoiBong : Form
    {
        BUS.BUS_ThamSo BUS_thamSo = new BUS.BUS_ThamSo();
        BUS.BUS_DoiBong BUS_doiBong = new BUS.BUS_DoiBong();
        BUS.BUS_CauThu BUS_cauThu = new BUS.BUS_CauThu();

        GUI_TiepNhanCauThu tiepNhanCauThu;

        DTO_ThamSo thamSo;
        DTO_DoiBong doiBong;
        List<DTO_CauThu> danhSachCauThu;

        string maCauThuMoi;
        public GUI_TiepNhanDoiBong()
        {
            InitializeComponent();
        }

        private void GUI_TiepNhanDoiBong_Load(object sender, EventArgs e)
        {
            //Load data
            //...
            LayThamSo();
            LayMaDoiBongMoi();
            LayMaCauThuMoi();
            thamSo.SoLuongCauThuToiThieu = 0;

            doiBong = new DTO_DoiBong(txtMaDoiBong.Text, null, null);
            danhSachCauThu = new List<DTO_CauThu>();
        }

        private void LayMaCauThuMoi()
        {
            maCauThuMoi = BUS_cauThu.LayMaCauThuMoi();
        }

        private void LayThamSo()
        {
            thamSo = BUS_thamSo.LayThamSo();
        }

        private void LayMaDoiBongMoi()
        {
            txtMaDoiBong.Text = BUS_doiBong.LayMaDoiBongMoi();
        }

        private void btnTiepNhanDoiBong_Click(object sender, EventArgs e)
        {
            doiBong.TenDoiBong = txtTenDoiBong.Text;
            doiBong.TenSanNha = txtTenSanNha.Text;

            try
            {
                if(BUS_doiBong.ThemDoiBongMoi(doiBong, danhSachCauThu, thamSo))
                {
                    MessageBox.Show("Tiếp nhận đội bóng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThemCauThu_Click(object sender, EventArgs e)
        {
            tiepNhanCauThu = new GUI_TiepNhanCauThu(doiBong, thamSo, maCauThuMoi);

            if (tiepNhanCauThu.ShowDialog() == DialogResult.OK)
            {
                danhSachCauThu.Add(tiepNhanCauThu.CauThu);                

                MessageBox.Show("Thêm cầu thủ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LayDanhSachCauThu();
                CapNhatMaCauThuXemTruoc();
            }            
        }

        private void CapNhatMaCauThuXemTruoc()
        {
            maCauThuMoi = CauThuHelper.XemTruocMaCauThu(maCauThuMoi);
        }

        private void LayDanhSachCauThu()
        {
            dgvDanhSachCauThu.DataSource = null;
            dgvDanhSachCauThu.DataSource = danhSachCauThu;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
