using QuanLyGiaiVoDichBongDaQuocGia.BUS;
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
        BUS_ThamSo busThamSo = new BUS_ThamSo();
        BUS_DoiBong busDoiBong = new BUS_DoiBong();
        BUS_CauThu busCauThu = new BUS_CauThu();
        BUS_LoaiCauThu busLoaiCauThu = new BUS_LoaiCauThu();

        //Xu ly
        DTO_DoiBong doiBong;
        DataManager<DTO_CauThu> danhSachCauThu;

        //Hien thi
        DTO_ThamSo thamSo;
        List<DTO_LoaiCauThu> danhSachLoaiCauThu;

        //Quan ly
        IDManager stt;
        IDManager maCauThu;

        public DTO_ThamSo ThamSo { get => thamSo; set => thamSo = value; }
        public DTO_DoiBong DoiBong { get => doiBong; }
        public List<DTO_LoaiCauThu> DanhSachLoaiCauThu { get => danhSachLoaiCauThu; }
        public IDManager STT { get => stt; set => stt = value; }
        public IDManager MaCauThu { get => maCauThu; set => maCauThu = value; }

        public GUI_TiepNhanDoiBong()
        {
            InitializeComponent();
        }

        private void GUI_TiepNhanDoiBong_Load(object sender, EventArgs e)
        {
            LayThamSo();            
            TaoSTT();     
            TaoDoiBong();
            TaoDanhSachCauThu();
            LayDanhSachLoaiCauThu();
        }

        private void TaoSTT()
        {
            stt = new IDManager("0");
        }

        private void LayThamSo()
        {
            ThamSo = busThamSo.LayThamSo();
        }

        private void TaoDanhSachCauThu()
        {
            TaoMaCauThu();
            danhSachCauThu = busCauThu.LayDanhSachNhap();
        }

        private void TaoDoiBong()
        {
            LayMaDoiBongMoi();

            doiBong = new DTO_DoiBong { MaDoiBong = txtMaDoiBong.Text };

            DataManager<DTO_DoiBong> danhSachDoiBong = busDoiBong.LayDanhSachNhap();
            danhSachDoiBong.Add(doiBong.MaDoiBong, doiBong);
        }

        private void TaoMaCauThu()
        {
            maCauThu = new IDManager(busCauThu.LayMaCauThuHienTai());
        }

        private void LayDanhSachLoaiCauThu()
        {
            danhSachLoaiCauThu = busLoaiCauThu.LayDanhSach(default, LoaiCauThuColumn.TenLoaiCauThu, LoaiCauThuColumn.SoLuongCauThuToiDaTheoLoaiCauThu).GetReadData();
        }

        private void LayMaDoiBongMoi()
        {
            txtMaDoiBong.Text = busDoiBong.LayMaDoiBongMoi();
        }

        private void btnTiepNhanDoiBong_Click(object sender, EventArgs e)
        {
            LayThongTinDoiBong();
            LayDanhSachThongTinCauThu();

            try
            {
                if (busDoiBong.TiepNhanDoiBong())
                {
                    maCauThu.XacNhan();
                    danhSachCauThu.UpdateDataState();                    
                    CapNhatMauSacDong();

                    MessageBox.Show("Tiếp nhận đội bóng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception err)
            {
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
                danhSachCauThu.AddOrUpdate(cauThuRow.CauThu.MaCauThu, cauThuRow.Output);
            }
        }

        private void LayThongTinDoiBong()
        {
            doiBong.MaDoiBong = txtMaDoiBong.Text;
            doiBong.TenDoiBong = txtTenDoiBong.Text;
            doiBong.TenSanNha = txtTenSanNha.Text;
        }

        private void btnThemCauThu_Click(object sender, EventArgs e)
        {
            pDanhSachCauThu.SuspendLayout();

            if (pDanhSachCauThu.Controls.Count < ThamSo.SoLuongCauThuToiDa)
            {
                GUI_TiepNhanCauThu_RowVersion newRow = new GUI_TiepNhanCauThu_RowVersion(this);
                pDanhSachCauThu.Controls.Add(newRow);                
            }

            pDanhSachCauThu.ResumeLayout();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        internal void XoaCauThu(GUI_TiepNhanCauThu_RowVersion row)
        {
            pDanhSachCauThu.SuspendLayout();

            danhSachCauThu.Delete(row.CauThu.MaCauThu);
            pDanhSachCauThu.Controls.Remove(row);
            CapNhatSTT();
            CapNhatMaCauThu();

            pDanhSachCauThu.ResumeLayout();
        }

        private void CapNhatSTT()
        {
            pDanhSachCauThu.SuspendLayout();

            foreach (var row in pDanhSachCauThu.Controls)
            {
                if(row is GUI_TiepNhanCauThu_RowVersion cauThu)
                {
                    cauThu.CapNhatSTT();
                }
            }

            pDanhSachCauThu.ResumeLayout();
        }

        private void CapNhatMaCauThu()
        {
            pDanhSachCauThu.SuspendLayout();

            foreach (var row in pDanhSachCauThu.Controls)
            {
                if (row is GUI_TiepNhanCauThu_RowVersion cauThu)
                {
                    cauThu.CapNhatMaCauThu();
                }
            }

            pDanhSachCauThu.ResumeLayout();
        }
    }
}
