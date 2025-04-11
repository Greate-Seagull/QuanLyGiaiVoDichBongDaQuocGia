using QuanLyGiaiVoDichBongDaQuocGia.BUS;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyGiaiVoDichBongDaQuocGia.GUI
{
    public partial class GUI_LapLichThiDau : Form
    {
        BUS_VongDau BUS_vongDau = new BUS_VongDau();
        BUS_TranDau BUS_tranDau = new BUS_TranDau();
        BUS_DoiBong BUS_doiBong = new BUS_DoiBong();

        //Xu ly
        DTO_VongDau vongDau;
        DataManager<DTO_TranDau> danhSachTranDau;

        //KiemTra
        List<DTO_TranDau> danhSachCapDau;
        OwnerManager<DTO_DoiBong, ComboBox> danhSachDoiBong;

        //Quan ly
        IDManager stt;
        IDManager maTranDau;       

        //UI
        public DTO_DoiBong cbTenDoi_DefaultItem = new DTO_DoiBong(default, "Chọn đội bóng", default);

        public DTO_VongDau VongDau { get => vongDau; set => vongDau = value; }
        public OwnerManager<DTO_DoiBong, ComboBox> DanhSachDoiBong { get => danhSachDoiBong; set => danhSachDoiBong = value; }
        public List<DTO_TranDau> DanhSachCapDau { get => danhSachCapDau; set => danhSachCapDau = value; }
        public IDManager MaTranDau { get => maTranDau; set => maTranDau = value; }
        public IDManager STT { get => stt; set => stt = value; }

        public GUI_LapLichThiDau()
        {
            InitializeComponent();
        }

        private void GUI_LapLichThiDau_Load(object sender, EventArgs e)
        {            
            LayMaVongDauMoi();
            TaoSTT();
            TaoMaTranDau();
            TaoVongDau();
            TaoDanhSachTranDau();
            LayDanhSachDoiBong();
            LayDanhSachCapDau();
        }

        private void TaoSTT()
        {
            stt = new IDManager("0");
        }

        private void LayDanhSachCapDau()
        {
            danhSachCapDau = BUS_tranDau.LayDanhSachCapDauLoaiTru(vongDau).GetReadData();
        }

        private void LayDanhSachDoiBong()
        {
            danhSachDoiBong = new OwnerManager<DTO_DoiBong, ComboBox>(BUS_doiBong.LayDanhSachDoiBong());
            danhSachDoiBong.AddData(cbTenDoi_DefaultItem, 100);
        }

        private void TaoDanhSachTranDau()
        {            
            danhSachTranDau = BUS_tranDau.LayDanhSachNhap();
        }

        private void TaoVongDau()
        {
            VongDau = new DTO_VongDau(txtMaVongDau.Text, txtVongThiDau.Text);

            DataManager<DTO_VongDau> danhSachNhapVongDau = BUS_vongDau.LayDanhSachNhap();
            danhSachNhapVongDau.Add(VongDau.MaVongDau, VongDau);
        }

        private void TaoMaTranDau()
        {
            MaTranDau = new IDManager(BUS_tranDau.LayMaTranDauHienTai());
        }

        private void LayMaVongDauMoi()
        {
            txtMaVongDau.Text = BUS_vongDau.LayMaVongDauMoi();
        }

        private void btnLapLichThiDau_Click(object sender, EventArgs e)
        {
            LayThongTinVongDau();
            LayDanhSachThongTinTranDau();

            try
            {
                if (BUS_vongDau.LapLichThiDau())
                {
                    MaTranDau.XacNhan();
                    danhSachTranDau.CapNhatTrangThaiDuLieu();                    
                    MessageBox.Show("Lập lịch thi đấu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LayDanhSachThongTinTranDau()
        {
            foreach (GUI_LapTranDau_RowVersion row in pDanhSachTranDau.Controls)
            {
                row.CapNhatThongTinTranDau();
                danhSachTranDau.AddOrUpdate(row.TranDau.MaTranDau, row.Output);
            }
        }

        private void LayThongTinVongDau()
        {
            VongDau.MaVongDau = txtMaVongDau.Text;
            VongDau.TenVongDau = txtVongThiDau.Text;
        }

        private void btnThemTranDau_Click(object sender, EventArgs e)
        {
            pDanhSachTranDau.SuspendLayout();
            
            //Main logic
            GUI_LapTranDau_RowVersion tranDauRow = new GUI_LapTranDau_RowVersion(this);
            pDanhSachTranDau.Controls.Add(tranDauRow);

            pDanhSachTranDau.ResumeLayout();
        }

        internal void XoaTranDau(GUI_LapTranDau_RowVersion GUI_lapTranDau_RowVersion)
        {
            pDanhSachTranDau.SuspendLayout();

            pDanhSachTranDau.Controls.Remove(GUI_lapTranDau_RowVersion);           
            danhSachTranDau.Delete(GUI_lapTranDau_RowVersion.TranDau.MaTranDau);
            CapNhatSTT();
            CapNhatMaTranDau();

            pDanhSachTranDau.ResumeLayout();
        }

        private void CapNhatMaTranDau()
        {
            pDanhSachTranDau.SuspendLayout();

            foreach (var row in pDanhSachTranDau.Controls)
            {
                if (row is GUI_LapTranDau_RowVersion tranDau)
                {
                    tranDau.CapNhatMaTranDau();
                }
            }

            pDanhSachTranDau.ResumeLayout();
        }

        private void CapNhatSTT()
        {
            pDanhSachTranDau.SuspendLayout();

            foreach (var row in pDanhSachTranDau.Controls)
            {
                if(row is GUI_LapTranDau_RowVersion tranDau)
                {
                    tranDau.CapNhatSTT();
                }
            }

            pDanhSachTranDau.ResumeLayout();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        internal void CapNhatCacDoiThamGiaThiDau()
        {
            foreach(GUI_LapTranDau_RowVersion row in pDanhSachTranDau.Controls)
            {
                row.CapNhatDanhSachDoiBong();
            }
        }
    }
}
