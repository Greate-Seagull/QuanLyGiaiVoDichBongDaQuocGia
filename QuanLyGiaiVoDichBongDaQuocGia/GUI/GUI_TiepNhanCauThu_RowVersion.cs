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
using QuanLyGiaiVoDichBongDaQuocGia.Manager;
using QuanLyGiaiVoDichBongDaQuocGia.BUS;

namespace QuanLyGiaiVoDichBongDaQuocGia.GUI
{
    public partial class GUI_TiepNhanCauThu_RowVersion : UserControl
    {
        //Input
        GUI_TiepNhanDoiBong hoSoDoiBong;

        //Output
        ManagedItem<DTO_CauThu> output;

        //Quan ly
        ID stt;
        ID maCauThu;

        public DTO_CauThu CauThu { get => Output.Data; }
        public DataState State { get => Output.State; set => Output.State = value; }
        public ManagedItem<DTO_CauThu> Output { get => output; }

        public GUI_TiepNhanCauThu_RowVersion(GUI_TiepNhanDoiBong hoSoDoiBong)
        {
            InitializeComponent();
            cbLoaiCauThu.BindingContext = new BindingContext();

            this.hoSoDoiBong = hoSoDoiBong;
        }

        private void GUI_TiepNhanCauThu_RowVersion_Load(object sender, EventArgs e)
        {                        
            TaoSTT();
            CapNhatSTT();            
            TaoMaCauThu();
            CapNhatMaCauThu();
            TaoCauThuMoi();
            CapNhatDanhSachLoaiCauThu();
            CaiDatNgaySinh();

            UI_Load();
        }
        public void CapNhatMaCauThu()
        {
            txtMaCauThu.Text = maCauThu.ToString();
        }

        private void TaoMaCauThu()
        {
            maCauThu = hoSoDoiBong.MaCauThu.LayID();
        }

        private void TaoSTT()
        {
            stt = hoSoDoiBong.STT.LayID();
        }

        public void CapNhatSTT()
        {
            lblSTT.Text = stt.ToString();
        }

        private void UI_Load()
        {
            this.Dock = DockStyle.Top;
        }

        private void TaoCauThuMoi()
        {
            //local
            DTO_CauThu cauThu = new DTO_CauThu(maCauThu.ToString(), txtTenCauThu.Text,
                                    dtpNgaySinh.Value, txtGhiChu.Text, hoSoDoiBong.DoiBong,
                                    (DTO_LoaiCauThu)cbLoaiCauThu.SelectedItem);

            output = new ManagedItem<DTO_CauThu>(cauThu);
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

        public void CapNhatThongTinCauThu()
        {
            if (State == DataState.Modified || State == DataState.New)
            {
                CauThu.MaCauThu = txtMaCauThu.Text;
                CauThu.TenCauThu = txtTenCauThu.Text;
                CauThu.NgaySinh = dtpNgaySinh.Value;
                CauThu.GhiChu = txtGhiChu.Text;
                CauThu.LoaiCauThu = cbLoaiCauThu.SelectedItem as DTO.DTO_LoaiCauThu;
                CauThu.DoiBong = hoSoDoiBong.DoiBong;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            hoSoDoiBong.STT.HuyID(stt);
            hoSoDoiBong.MaCauThu.HuyID(maCauThu);
            hoSoDoiBong.XoaCauThu(this);
            this.Dispose();
        }

        private void txtTenCauThu_TextChanged(object sender, EventArgs e)
        {
            output.Modify();
        }

        private void cbLoaiCauThu_SelectedIndexChanged(object sender, EventArgs e)
        {
            output.Modify();
        }

        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e)
        {
            output.Modify();
        }

        private void txtGhiChu_TextChanged(object sender, EventArgs e)
        {
            output.Modify();
        }

        public void CapNhatMauSac()
        {
            switch (State)
            {
                case DataState.New:
                    this.BackColor = SystemColors.ControlLightLight;
                    break;
                case DataState.Modified:
                    this.BackColor = SystemColors.ControlLight;
                    break;
                case DataState.Unchanged:
                    this.BackColor = SystemColors.Control;
                    break;
            }
        }  
    }
}
