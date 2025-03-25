using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.Helper;
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
    public partial class GUI_TiepNhanDoiBong : Form
    {
        BUS.BUS_ThamSo BUS_thamSo = new BUS.BUS_ThamSo();
        BUS.BUS_DoiBong BUS_doiBong = new BUS.BUS_DoiBong();
        BUS.BUS_CauThu BUS_cauThu = new BUS.BUS_CauThu();
        BUS.BUS_LoaiCauThu BUS_loaiCauThu = new BUS.BUS_LoaiCauThu();

        //GUI_TiepNhanCauThu tiepNhanCauThu;

        DTO_ThamSo thamSo;
        DTO_DoiBong doiBong;
        Manager.Manager<DTO.DTO_CauThu> danhSachCauThu;
        List<DTO.DTO_LoaiCauThu> danhSachLoaiCauThu;

        string maCauThu;

        public DTO_ThamSo ThamSo { get => thamSo; }
        public DTO_DoiBong DoiBong { get => doiBong; }
        public Manager<DTO_CauThu> DanhSachCauThu { get => danhSachCauThu; }
        public List<DTO_LoaiCauThu> DanhSachLoaiCauThu { get => danhSachLoaiCauThu; }
        public string MaCauThu { get => maCauThu; }

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
            LayDanhLoaiCauThu();
            ThamSo.SoLuongCauThuToiThieu = 0;

            doiBong = new DTO_DoiBong(txtMaDoiBong.Text, null, null);
            danhSachCauThu = new Manager.Manager<DTO.DTO_CauThu>();
        }

        private void LayDanhLoaiCauThu()
        {
            danhSachLoaiCauThu = BUS_loaiCauThu.LayDanhSachLoaiCauThu();
        }

        private void LayMaCauThuMoi()
        {
            maCauThu = BUS_cauThu.LayMaCauThuMoi();
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
            LayThongTinDoiBong();
            LayDanhSachThongTinCauThu();

            try
            {
                if (BUS_doiBong.TiepNhanDoiBongMoi(DoiBong, DanhSachCauThu, ThamSo))
                {
                    MessageBox.Show("Tiếp nhận đội bóng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LayDanhSachThongTinCauThu()
        {
            DTO_CauThu cauThu;

            foreach (GUI_TiepNhanCauThu_RowVersion cauThuRow in pDanhSachCauThu.Controls)
            {
                cauThu = cauThuRow.LayThongTinCauThu();
                DanhSachCauThu.Add(cauThu.MaCauThu, cauThu);
            }
        }

        private void LayThongTinDoiBong()
        {
            DoiBong.TenDoiBong = txtTenDoiBong.Text;
            DoiBong.TenSanNha = txtTenSanNha.Text;
        }

        private void btnThemCauThu_Click(object sender, EventArgs e)
        {
            GUI_TiepNhanCauThu_RowVersion newRow = new GUI_TiepNhanCauThu_RowVersion(this);

            pDanhSachCauThu.Controls.Add(newRow);

            newRow.CapNhatSTT(pDanhSachCauThu.Controls.Count);

            CapNhatMaCauThuXemTruoc();
        }

        private void CapNhatMaCauThuXemTruoc()
        {
            maCauThu = CauThuHelper.XemTruocMaCauThu(MaCauThu);
        }
        
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        internal void XoaCauThu(GUI_TiepNhanCauThu_RowVersion GUI_tiepNhanCauThu_RowVersion)
        {
            danhSachCauThu.Delete(GUI_tiepNhanCauThu_RowVersion.CauThu.MaCauThu);
            pDanhSachCauThu.Controls.Remove(GUI_tiepNhanCauThu_RowVersion);
            CaiDatSTT();
        }

        private void CaiDatSTT()
        {            
            for(int i = 0; i < pDanhSachCauThu.Controls.Count; i++)
            {
                if (pDanhSachCauThu.Controls[i] is GUI_TiepNhanCauThu_RowVersion row)
                {
                    row.CapNhatSTT(i + 1);
                }
            }
        }

        //private void btnCapNhatCauThu_Click(object sender, EventArgs e)
        //{
        //    if (dgvDanhSachCauThu.SelectedCells.Count > 0)
        //    {
        //        List<DTO_CauThu> danhSachCauThuHienTai = dgvDanhSachCauThu.DataSource as List<DTO_CauThu>;
        //        int index = dgvDanhSachCauThu.SelectedCells[0].RowIndex;

        //        tiepNhanCauThu = new GUI_TiepNhanCauThu(doiBong, thamSo, danhSachLoaiCauThu, maCauThuMoi, danhSachCauThuHienTai[index]);

        //        if (tiepNhanCauThu.ShowDialog() == DialogResult.OK)
        //        {
        //            MessageBox.Show("Cập nhật cầu thủ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //            LayDanhSachCauThu();
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Chọn cầu thủ trong bảng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

        //private void btnXoaCauThu_Click(object sender, EventArgs e)
        //{
        //    if (dgvDanhSachCauThu.SelectedCells.Count > 0)
        //    {
        //        List<DTO_CauThu> danhSachCauThuHienTai = dgvDanhSachCauThu.DataSource as List<DTO_CauThu>;
        //        int index = dgvDanhSachCauThu.SelectedCells[0].RowIndex;

        //        danhSachCauThu.Delete(danhSachCauThuHienTai[index].MaCauThu);

        //        //MessageBox.Show("Xóa cầu thủ thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        LayDanhSachCauThu();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Chọn cầu thủ trong bảng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}        
    }
}
