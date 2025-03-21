using QuanLyGiaiVoDichBongDaQuocGia.BUS;
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
    public partial class GUI_TiepNhanCauThu : Form
    {        
        private BUS.BUS_LoaiCauThu BUS_loaiCauThu = new BUS.BUS_LoaiCauThu();

        private DTO.DTO_ThamSo thamSo;
        private DTO.DTO_DoiBong doiBong;

        private DTO.DTO_CauThu cauThu;        

        private string maCauThuMoi;

        public DTO.DTO_CauThu CauThu { get => cauThu; set => cauThu = value; }

        public GUI_TiepNhanCauThu(DTO.DTO_DoiBong newDoiBong, DTO.DTO_ThamSo thamSo, string maCauThuMoi)
        {
            InitializeComponent();

            this.thamSo = thamSo;
            this.doiBong = newDoiBong;
            this.maCauThuMoi = maCauThuMoi;
        }

        private void GUI_TiepNhanCauThu_Load(object sender, EventArgs e)
        {
            //Load data
            //...
            TaoMaCauThuMoi();
            LayDanhSachLoaiCauThu();
            CaiDatNgaySinh();
        }

        private void CaiDatNgaySinh()
        {
            dtpNgaySinh.MaxDate = new DateTime(DateTime.Now.Year - thamSo.TuoiCauThuToiDa, DateTime.Now.Month, DateTime.Now.Day);
            dtpNgaySinh.MaxDate = new DateTime(DateTime.Now.Year - thamSo.TuoiCauThuToiThieu, DateTime.Now.Month, DateTime.Now.Day);
        }

        private void TaoMaCauThuMoi()
        {
            txtMaCauThu.Text = maCauThuMoi;
        }

        private void LayDanhSachLoaiCauThu()
        {
            cbLoaiCauThu.DataSource = BUS_loaiCauThu.LayDanhSachLoaiCauThu();
            cbLoaiCauThu.DisplayMember = "TenLoaiCauThu";
        }

        private void btnTiepNhanCauThu_Click(object sender, EventArgs e)
        {
            cauThu = new DTO.DTO_CauThu(txtMaCauThu.Text, txtTenCauThu.Text,
                                                          dtpNgaySinh.Value, txtGhiChu.Text,
                                                          doiBong, (DTO.DTO_LoaiCauThu)cbLoaiCauThu.SelectedItem);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
