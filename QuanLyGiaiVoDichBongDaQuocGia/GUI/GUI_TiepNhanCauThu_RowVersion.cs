﻿using System;
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

namespace QuanLyGiaiVoDichBongDaQuocGia.GUI
{
    public partial class GUI_TiepNhanCauThu_RowVersion : UserControl
    {
        //Input
        GUI_TiepNhanDoiBong hoSoDoiBong;

        //Output
        ManagedItem<DTO.DTO_CauThu> output;

        public DTO.DTO_CauThu CauThu { get => Output.Data; }
        public DataState State { get => Output.State; set => Output.State = value; }
        public ManagedItem<DTO_CauThu> Output { get => output; }

        public GUI_TiepNhanCauThu_RowVersion(GUI_TiepNhanDoiBong hoSoDoiBong)
        {                        
            InitializeComponent();

            this.hoSoDoiBong = hoSoDoiBong;
            TaoCauThuMoi();

            Load();
        }
        public void Load()
        {            
            CapNhatDanhSachLoaiCauThu();
            CaiDatNgaySinh();

            UI_Load();
        }

        public void CapNhatSTT(int STT)
        {
            lblSTT.Text = STT.ToString();
        }

        private void UI_Load()
        {
            this.Dock = DockStyle.Top;
        }

        private void TaoCauThuMoi()
        {

            DTO.DTO_CauThu cauThu = new DTO_CauThu(txtMaCauThu.Text, txtTenCauThu.Text,
                                        dtpNgaySinh.Value, txtGhiChu.Text, hoSoDoiBong.DoiBong,
                                        (DTO.DTO_LoaiCauThu)cbLoaiCauThu.SelectedItem);

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
            hoSoDoiBong.XoaCauThu(this);
            this.Dispose();
        }

        public void CapNhatMaCauThu(string maCauThu)
        {
            txtMaCauThu.Text = maCauThu;
        }

        public string LayMaCauThu()
        {
            return txtMaCauThu.Text;
        }

        private void txtTenCauThu_TextChanged(object sender, EventArgs e)
        {
            if (State == DataState.Unmodified)
            {
                State = DataState.Modified;
                CapNhatMauSac();
            }
        }

        private void cbLoaiCauThu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (State == DataState.Unmodified)
            {
                State = DataState.Modified;
                CapNhatMauSac();
            }
        }

        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e)
        {
            if (State == DataState.Unmodified)
            {
                State = DataState.Modified;
                CapNhatMauSac();
            }
        }

        private void txtGhiChu_TextChanged(object sender, EventArgs e)
        {
            if (State == DataState.Unmodified)
            {
                State = DataState.Modified;
                CapNhatMauSac();
            }
        }

        public void CapNhatMauSac()
        {
            switch(State)
            {
                case DataState.New:
                    this.BackColor = SystemColors.ControlLightLight;
                    break;
                case DataState.Modified:
                    this.BackColor = SystemColors.ControlLight;
                    break;
                case DataState.Unmodified:
                    this.BackColor = SystemColors.Control;
                    break;
            }
        }

        internal int LaySTT()
        {
            return int.Parse(lblSTT.Text);
        }
    }
}
