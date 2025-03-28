using QuanLyGiaiVoDichBongDaQuocGia.DTO;
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

        DTO_ThamSo thamSo;
        DTO_DoiBong doiBong;
        Manager.Manager<DTO.DTO_CauThu> danhSachCauThuDaTiepNhan;
        List<DTO.DTO_LoaiCauThu> danhSachLoaiCauThu;

        Manager.IDManager maCauThu;

        public DTO_ThamSo ThamSo { get => thamSo; }
        public DTO_DoiBong DoiBong { get => doiBong; }
        public Manager<DTO_CauThu> DanhSachCauThu { get => danhSachCauThuDaTiepNhan; }
        public List<DTO_LoaiCauThu> DanhSachLoaiCauThu { get => danhSachLoaiCauThu; }

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
            LayMaCauThuHienTai();
            LayDanhLoaiCauThu();

            doiBong = new DTO_DoiBong(txtMaDoiBong.Text, null, null);
            danhSachCauThuDaTiepNhan = new Manager.Manager<DTO.DTO_CauThu>();            
        }

        private void LayMaCauThuHienTai()
        {
            maCauThu = new IDManager(BUS_cauThu.LayMaCauThuHienTai());
        }

        private void LayDanhLoaiCauThu()
        {
            danhSachLoaiCauThu = BUS_loaiCauThu.LayDanhSachLoaiCauThu();
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
                    maCauThu.XacNhanMaDaSuDung();
                    danhSachCauThuDaTiepNhan.CapNhatTrangThaiDuLieu();                    
                    CapNhatMauSacDong();

                    MessageBox.Show("Tiếp nhận đội bóng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception err)
            {
                //danhSachCauThuDaTiepNhan.CapNhatDuLieuLoi();

                MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void CapNhatMauSacDong()
        {
            foreach(GUI_TiepNhanCauThu_RowVersion row in pDanhSachCauThu.Controls)
            {
                row.CapNhatMauSac();
            }
        }

        private void LayDanhSachThongTinCauThu()
        {
            foreach (GUI_TiepNhanCauThu_RowVersion cauThuRow in pDanhSachCauThu.Controls)
            {
                cauThuRow.CapNhatThongTinCauThu();
            }
        }

        private void LayThongTinDoiBong()
        {
            DoiBong.TenDoiBong = txtTenDoiBong.Text;
            DoiBong.TenSanNha = txtTenSanNha.Text;
        }

        private void btnThemCauThu_Click(object sender, EventArgs e)
        {
            if(pDanhSachCauThu.Controls.Count < thamSo.SoLuongCauThuToiDa)
            {
                GUI_TiepNhanCauThu_RowVersion newRow = new GUI_TiepNhanCauThu_RowVersion(this);

                pDanhSachCauThu.Controls.Add(newRow);
                danhSachCauThuDaTiepNhan.Add(newRow.Output);
                maCauThu.TangDonViDem();

                newRow.CapNhatSTT(pDanhSachCauThu.Controls.Count);
                newRow.CapNhatMaCauThu(maCauThu.LayID());
            }            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        internal void XoaCauThu(GUI_TiepNhanCauThu_RowVersion GUI_tiepNhanCauThu_RowVersion)
        {
            //Xoa cau thu
            danhSachCauThuDaTiepNhan.Delete(GUI_tiepNhanCauThu_RowVersion.Output);

            //Xoa dong            
            int index = pDanhSachCauThu.Controls.IndexOf(GUI_tiepNhanCauThu_RowVersion);
            CaiDatSTT(index);            

            if (GUI_tiepNhanCauThu_RowVersion.State == DataState.New)
            {
                maCauThu.GiamDonViDem();
                CaiDatMaCauThu(index);
            }

            pDanhSachCauThu.Controls.RemoveAt(index);
        }

        private void CaiDatMaCauThu(int index)
        {
            for(int i = pDanhSachCauThu.Controls.Count - 1; i > index; i--)
            {
                GUI_TiepNhanCauThu_RowVersion row = pDanhSachCauThu.Controls[i] as GUI_TiepNhanCauThu_RowVersion;
                GUI_TiepNhanCauThu_RowVersion rowTruoc = pDanhSachCauThu.Controls[i - 1] as GUI_TiepNhanCauThu_RowVersion;

                row.CapNhatMaCauThu(rowTruoc.LayMaCauThu());
            }
        }

        private void CaiDatSTT(int index = 0)
        {
            for (int i = pDanhSachCauThu.Controls.Count - 1; i > index; i--)
            {
                GUI_TiepNhanCauThu_RowVersion row = pDanhSachCauThu.Controls[i] as GUI_TiepNhanCauThu_RowVersion;
                GUI_TiepNhanCauThu_RowVersion rowTruoc = pDanhSachCauThu.Controls[i - 1] as GUI_TiepNhanCauThu_RowVersion;

                row.CapNhatSTT(rowTruoc.LaySTT());
            }
        }
    }
}
