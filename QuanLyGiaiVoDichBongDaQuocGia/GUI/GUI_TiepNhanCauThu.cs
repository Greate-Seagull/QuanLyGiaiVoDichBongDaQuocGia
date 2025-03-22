using QuanLyGiaiVoDichBongDaQuocGia.BUS;
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
    public partial class GUI_TiepNhanCauThu : Form
    {        
        //Input
        private DTO.DTO_ThamSo thamSo;
        private DTO.DTO_DoiBong doiBong;
        private List<DTO.DTO_LoaiCauThu> danhSachLoaiCauThu;
        private string maCauThuMoi;

        private DTO.DTO_CauThu cauThu;           

        public DTO.DTO_CauThu CauThu { get => cauThu; set => cauThu = value; }

        public GUI_TiepNhanCauThu(DTO.DTO_DoiBong newDoiBong, DTO.DTO_ThamSo thamSo, List<DTO.DTO_LoaiCauThu> danhSachLoaiCauThu, string maCauThuMoi,
                                  DTO.DTO_CauThu cauThu = null)
        {
            InitializeComponent();

            this.thamSo = thamSo;
            this.doiBong = newDoiBong;
            this.danhSachLoaiCauThu = danhSachLoaiCauThu;
            this.maCauThuMoi = maCauThuMoi;
            this.cauThu = cauThu;
        }
        private void GUI_TiepNhanCauThu_Load(object sender, EventArgs e)
        {
            //Load data
            //...

            TaoMaCauThuMoi();
            LayDanhSachLoaiCauThu();
            CaiDatNgaySinh();
            
            if (cauThu != null)
            {
                HienThiThongTinCauThu();
            }
        }

        private void HienThiThongTinCauThu()
        {
            txtMaCauThu.Text = cauThu.MaCauThu;
            txtTenCauThu.Text = cauThu.TenCauThu;
            dtpNgaySinh.Value = cauThu.NgaySinh;
            cbLoaiCauThu.SelectedItem = cauThu.LoaiCauThu;
            txtGhiChu.Text = cauThu.GhiChu;
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
            cbLoaiCauThu.DataSource = danhSachLoaiCauThu;
            cbLoaiCauThu.DisplayMember = "TenLoaiCauThu";
        }

        private void btnTiepNhanCauThu_Click(object sender, EventArgs e)
        {
            if(cauThu == null)
            {
                cauThu = new DTO.DTO_CauThu(txtMaCauThu.Text, txtTenCauThu.Text,
                                            dtpNgaySinh.Value, txtGhiChu.Text,
                                            doiBong, (DTO.DTO_LoaiCauThu)cbLoaiCauThu.SelectedItem);
            }
            else
            {
                cauThu.TenCauThu = txtTenCauThu.Text;
                cauThu.NgaySinh = dtpNgaySinh.Value;
                cauThu.LoaiCauThu = (DTO.DTO_LoaiCauThu)cbLoaiCauThu.SelectedItem;
                cauThu.GhiChu = txtGhiChu.Text;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
