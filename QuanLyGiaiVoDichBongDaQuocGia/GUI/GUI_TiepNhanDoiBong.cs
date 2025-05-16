using QuanLyGiaiVoDichBongDaQuocGia.BUS;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.Manager;
using Syncfusion.WinForms.DataGrid;
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
        private readonly BUS_ThamSo _BUS_ThamSo;
        private readonly BUS_DoiBong _BUS_DoiBong;
        private readonly BUS_CauThu _BUS_CauThu;
        private readonly BUS_LoaiCauThu _BUS_LoaiCauThu;

        //Xu ly
        DTO_DoiBong doiBongTiepNhan;
        BindingList<DTO_CauThu> danhSachCauThuTiepNhan;

        //Hien thi
        DTO_ThamSo thamSo;
        List<DTO_LoaiCauThu> danhSachLoaiCauThu;

        //Quan ly
        IDManager maDoiBong;
        IDManager maCauThuQuanLy;

        public GUI_TiepNhanDoiBong(BUS_ThamSo bUS_ThamSo, BUS_DoiBong bUS_DoiBong, BUS_CauThu bUS_CauThu, BUS_LoaiCauThu bUS_LoaiCauThu)
        {
            InitializeComponent();

            //Dependencies
            _BUS_ThamSo = bUS_ThamSo;
            _BUS_DoiBong = bUS_DoiBong;
            _BUS_CauThu = bUS_CauThu;
            _BUS_LoaiCauThu = bUS_LoaiCauThu;
        }

        private void GUI_TiepNhanDoiBong_Load(object sender, EventArgs e)
        {
            LayThamSo();
            TaoDoiBong();
            TaoDanhSachCauThu();
            LayDanhSachLoaiCauThu();

            UILoad();
        }

        private void UILoad()
        {
            //Configure DataGrid
            dgDanhSachCauThu.DataSource = danhSachCauThuTiepNhan;

            //Configure column MaLoaiCauThu on DataGrid
            var MaLoaiCauThuCol = dgDanhSachCauThu.Columns["MaLoaiCauThu"] as GridComboBoxColumn;
            MaLoaiCauThuCol.DataSource = danhSachLoaiCauThu;            

            //Configure column NgaySinh on DataGrid
            var NgaySinhCol = dgDanhSachCauThu.Columns["NgaySinh"] as GridDateTimeColumn;
            NgaySinhCol.MinDateTime = new DateTime(DateTime.Now.Year - thamSo.TuoiCauThuToiDa, DateTime.Now.Month, DateTime.Now.Day);
            NgaySinhCol.MaxDateTime = new DateTime(DateTime.Now.Year - thamSo.TuoiCauThuToiThieu, DateTime.Now.Month, DateTime.Now.Day);
        }

        private void LayThamSo()
        {
            thamSo = _BUS_ThamSo.LayThamSo();
        }

        private void TaoDanhSachCauThu()
        {
            TaoMaCauThu();

            danhSachCauThuTiepNhan = new();
            for (int i = 0; i < thamSo.SoLuongCauThuToiThieu; i++)
            {
                danhSachCauThuTiepNhan.Add(new DTO_CauThu{MaDoiBong = doiBongTiepNhan.MaDoiBong});
            }

            CapNhatMaCauThu();
        }

        private void TaoDoiBong()
        {
            LayMaDoiBongMoi();
            CapNhatMaDoiBong();

            doiBongTiepNhan = new DTO_DoiBong { MaDoiBong = maDoiBong.GetCurrentID().ToString() };
        }

        private void CapNhatMaDoiBong()
        {
            txtMaDoiBong.Text = maDoiBong.GetNewID().ToString();
        }

        private void TaoMaCauThu()
        {
            maCauThuQuanLy = new(_BUS_CauThu.LayMaMoiNhat().MaCauThu);
        }

        private void LayDanhSachLoaiCauThu()
        {
            danhSachLoaiCauThu = _BUS_LoaiCauThu.LayDanhSach();
        }

        private void LayMaDoiBongMoi()
        {
            maDoiBong = new(_BUS_DoiBong.LayMaMoiNhat().MaDoiBong);
        }

        private void btnTiepNhanDoiBong_Click(object sender, EventArgs e)
        {
            CapNhatThongTinDoiBong();

            try
            {
                if (_BUS_DoiBong.TiepNhanDoiBong(doiBongTiepNhan, danhSachCauThuTiepNhan.ToList()))
                {
                    maCauThuQuanLy.Confirm();
                    LamMoiDanhSachCauThu();

                    MessageBox.Show("Tiếp nhận đội bóng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void CapNhatThongTinDoiBong()
        {
            if (doiBongTiepNhan.TenDoiBong != txtTenDoiBong.Text) doiBongTiepNhan.TenDoiBong = txtTenDoiBong.Text;
            if (doiBongTiepNhan.TenSanNha != txtTenSanNha.Text) doiBongTiepNhan.TenSanNha = txtTenSanNha.Text;
        }

        private void LamMoiDanhSachCauThu()
        {
            danhSachCauThuTiepNhan.Clear();
        }

        private void btnThemCauThu_Click(object sender, EventArgs e)
        {
            if (danhSachCauThuTiepNhan.Count < thamSo.SoLuongCauThuToiDa)
            {
                danhSachCauThuTiepNhan.Add(new DTO_CauThu
                {
                    MaCauThu = maCauThuQuanLy.CreateID(danhSachCauThuTiepNhan.Count + 1).ToString(),
                    MaDoiBong = doiBongTiepNhan.MaDoiBong
                });
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CapNhatMaCauThu()
        {
            int iDOffset = 1;
            foreach (var entity in danhSachCauThuTiepNhan)
            {
                entity.MaCauThu = maCauThuQuanLy.CreateID(iDOffset++).ToString();
            }
        }

        private void dgDanhSachCauThu_RecordDeleted(object sender, Syncfusion.WinForms.DataGrid.Events.RecordDeletedEventArgs e)
        {
            CapNhatMaCauThu();
        }

        private void dgDanhSachCauThu_RecordDeleting(object sender, Syncfusion.WinForms.DataGrid.Events.RecordDeletingEventArgs e)
        {
            if (danhSachCauThuTiepNhan.Count <= thamSo.SoLuongCauThuToiThieu)
                e.Cancel = true;
        }
    }
}
