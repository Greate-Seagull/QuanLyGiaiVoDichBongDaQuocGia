using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using MySql.Data.MySqlClient;

namespace QuanLyGiaiVoDichBongDaQuocGia.GUI
{
    public partial class GUI_TiepNhanCauThu_RowVersion : UserControl
    {
        //Input
        //private DTO.DTO_ThamSo thamSo;
        //private DTO.DTO_DoiBong doiBong;
        //private List<DTO.DTO_LoaiCauThu> danhSachLoaiCauThu;
        //private string maCauThuMoi;
        GUI_TiepNhanDoiBong hoSoDoiBong;

        //Output
        private DTO.DTO_CauThu cauThu;

        public DTO.DTO_CauThu CauThu { get => cauThu; set => cauThu = value; }
        public string MaCauThu { get; set; }

        public GUI_TiepNhanCauThu_RowVersion(GUI_TiepNhanDoiBong hoSoDoiBong)
        {
            InitializeComponent();

            this.hoSoDoiBong = hoSoDoiBong;

            Load();
        }
        public void Load()
        {
            CapNhatMaCauThu();
            CapNhatDanhSachLoaiCauThu();
            CaiDatNgaySinh();
            TaoCauThuMoi();

            UI_Load();
        }

        public void CapNhatSTT(int STT)
        {
            lblSTT.Text = STT.ToString();
        }

        private void UI_Load()
        {
            this.Dock = DockStyle.Top;

            this.Parent?.Controls.SetChildIndex(this, this.Parent.Controls.Count - 1);
        }

        private void TaoCauThuMoi()
        {
            this.cauThu = new DTO_CauThu(txtMaCauThu.Text, txtTenCauThu.Text,
                                        dtpNgaySinh.Value, txtGhiChu.Text, hoSoDoiBong.DoiBong,
                                        (DTO.DTO_LoaiCauThu)cbLoaiCauThu.SelectedItem);
        }

        private void CaiDatNgaySinh()
        {
            dtpNgaySinh.MinDate = new DateTime(DateTime.Now.Year - hoSoDoiBong.ThamSo.TuoiCauThuToiDa, DateTime.Now.Month, DateTime.Now.Day);
            dtpNgaySinh.MaxDate = new DateTime(DateTime.Now.Year - hoSoDoiBong.ThamSo.TuoiCauThuToiThieu, DateTime.Now.Month, DateTime.Now.Day);
        }

        private void CapNhatDanhSachLoaiCauThu()
        {
            cbLoaiCauThu.DataSource = hoSoDoiBong.DanhSachLoaiCauThu;
            cbLoaiCauThu.DisplayMember = "TenLoaiCauThu";            
        }

        public void CapNhatMaCauThu()
        {
            txtMaCauThu.Text = hoSoDoiBong.MaCauThu;
        }

        public DTO_CauThu LayThongTinCauThu()
        {
            cauThu.MaCauThu = txtMaCauThu.Text;
            cauThu.TenCauThu = txtTenCauThu.Text;
            cauThu.NgaySinh = dtpNgaySinh.Value;
            cauThu.GhiChu = txtGhiChu.Text;
            cauThu.LoaiCauThu = cbLoaiCauThu.SelectedItem as DTO.DTO_LoaiCauThu;
            cauThu.DoiBong = hoSoDoiBong.DoiBong;

            return cauThu;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            hoSoDoiBong.XoaCauThu(this);
            this.Dispose();
        }
    }
}
