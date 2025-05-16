using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyGiaiVoDichBongDaQuocGia.Manager;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using Org.BouncyCastle.Crypto.Generators;

namespace QuanLyGiaiVoDichBongDaQuocGia.GUI
{
    public partial class GUI_GhiNhanBanThang_RowVersion : UserControl
    {
        //Input
        GUI_GhiNhanKetQua ketQuaTranDau;

        //Output
        ManagedItem<DTO_BanThang> output;

        //Quan ly
        ID stt;
        ID maBanThang;
        public ManagedItem<DTO_BanThang> Output { get => output; set => output = value; }
        public DTO_BanThang BanThang { get => output.Data; }
        public DTO_DoiBong DoiBong { get => cbDoiBong.SelectedItem as DTO_DoiBong; }
        public DataState State { get => output.State; }

        public GUI_GhiNhanBanThang_RowVersion(GUI_GhiNhanKetQua ketQuaTranDau)
        {
            InitializeComponent();

            cbCauThu.BindingContext = new BindingContext();
            cbDoiBong.BindingContext = new BindingContext();
            cbLoaiBanThang.BindingContext = new BindingContext();

            this.ketQuaTranDau = ketQuaTranDau;
        }

        private void GUI_GhiNhanBanThang_RowVersion_Load(object sender, EventArgs e)
        {
            TaoSTT();
            CapNhatSTT();

            TaoBanThang();
            CapNhatDanhSachDoiBong();
            CapNhatDanhSachLoaiBanThang();

            UI_Load();
        }

        private void UI_Load()
        {
            this.Dock = DockStyle.Top;
        }

        public void CapNhatDanhSachDoiBong()
        {
            cbDoiBong.DataSource = new List<DTO_DoiBong> { ketQuaTranDau.TranDau.DoiBong1, ketQuaTranDau.TranDau.DoiBong2 };            
        }

        private void CapNhatDanhSachLoaiBanThang()
        {
            cbLoaiBanThang.DataSource = ketQuaTranDau.DanhSachLoaiBanThang;
        }

        public void CapNhatDanhSachCauThu()
        {
            DTO_DoiBong doiBong = cbDoiBong.SelectedItem as DTO_DoiBong;
            cbCauThu.DataSource = ketQuaTranDau.DanhSachCauThuThuocHaiDoi.Where(ct => ct.DoiBong.MaDoiBong == doiBong.MaDoiBong).ToList();
        }

        private void TaoBanThang()
        {
            TaoMaBanThang();

            CapNhatMaBanThang();

            DTO_BanThang banThang = new DTO_BanThang() { MaBanThang = txtMaBanThang.Text };
            output = new ManagedItem<DTO_BanThang>(banThang);
        }

        public void CapNhatMaBanThang()
        {
            txtMaBanThang.Text = maBanThang.ToString();
        }

        public void CapNhatSTT()
        {
            lblSTT.Text = stt.ToString();
        }

        private void TaoSTT()
        {
            stt = ketQuaTranDau.STT.GetNewID();
        }

        private void TaoMaBanThang()
        {
            maBanThang = ketQuaTranDau.MaBanThang.GetNewID();
        }
        internal void CapNhatThongTinBanThang()
        {
            BanThang.MaBanThang = txtMaBanThang.Text;
            BanThang.TranDau = ketQuaTranDau.TranDau;
            BanThang.CauThu = cbCauThu.SelectedItem as DTO_CauThu;
            BanThang.LoaiBanThang = cbLoaiBanThang.SelectedItem as DTO_LoaiBanThang;
            BanThang.ThoiDiemGhiBan = (int)nudThoiDiemGhiBan.Value;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            ketQuaTranDau.STT.CancelID(stt);
            ketQuaTranDau.MaBanThang.CancelID(maBanThang);
            ketQuaTranDau.XoaBanThang(this);
            this.Dispose();
        }

        private void cbDoiBong_SelectedIndexChanged(object sender, EventArgs e)
        {
            ketQuaTranDau.CapNhatTiSo();
            CapNhatDanhSachCauThu();
        }
    }
}
