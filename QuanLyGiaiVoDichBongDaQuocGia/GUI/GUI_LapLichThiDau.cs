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
        BUS_ThamSo BUS_thamSo = new BUS_ThamSo();
        BUS_VongDau BUS_vongDau = new BUS_VongDau();
        BUS_TranDau BUS_tranDau = new BUS_TranDau();
        BUS_DoiBong BUS_doiBong = new BUS_DoiBong();

        //Xu ly
        DTO_ThamSo thamSo;
        DTO_VongDau vongDau;
        Manager.Manager<DTO_TranDau> danhSachTranDau;

        //Quan ly
        IDManager maTranDau;

        //Khong xu ly
        Manager.OwnerManager<DTO_DoiBong, ComboBox> danhSachDoiBong;

        public DTO_VongDau VongDau { get => vongDau; }
        internal OwnerManager<DTO_DoiBong, ComboBox> DanhSachDoiBong { get => danhSachDoiBong; }

        //UI
        public DTO_DoiBong cbTenDoi_DefaultItem = new DTO_DoiBong(default, "Chọn đội bóng", default);

        public GUI_LapLichThiDau()
        {
            InitializeComponent();

            vongDau = new DTO_VongDau(txtMaVongDau.Text, txtVongThiDau.Text);
            danhSachTranDau = new Manager<DTO_TranDau>();
        }

        private void GUI_LapLichThiDau_Load(object sender, EventArgs e)
        {
            LayThamSo();
            LayMaVongDauMoi();
            LayMaTranDauHienTai();
            LayDanhSachDoiBong();            
        }

        private void LayDanhSachDoiBong()
        {
            danhSachDoiBong = new OwnerManager<DTO_DoiBong, ComboBox>(BUS_doiBong.LayDanhSachDoiBong());
            danhSachDoiBong.AddData(cbTenDoi_DefaultItem, 100);
        }

        private void LayMaTranDauHienTai()
        {
            maTranDau = new IDManager(BUS_tranDau.LayMaTranDauHienTai());
        }

        private void LayMaVongDauMoi()
        {
            txtMaVongDau.Text = BUS_vongDau.LayMaVongDauMoi();
        }

        private void LayThamSo()
        {
            thamSo = BUS_thamSo.LayThamSo();
        }

        private void btnLapLichThiDau_Click(object sender, EventArgs e)
        {
            LayThongTinVongDau();
            LayDanhSachThongTinTranDau();

            try
            {
                if (BUS_vongDau.LapLichThiDau(VongDau, danhSachTranDau, thamSo))
                {
                    maTranDau.XacNhanMaDaSuDung();
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
            }
        }

        private void LayThongTinVongDau()
        {
            VongDau.MaVongDau = txtMaVongDau.Text;
            VongDau.TenVongDau = txtVongThiDau.Text;
        }

        private void btnThemTranDau_Click(object sender, EventArgs e)
        {
            GUI_LapTranDau_RowVersion tranDauRow = new GUI_LapTranDau_RowVersion(this);

            pDanhSachTranDau.Controls.Add(tranDauRow);
            danhSachTranDau.Add(tranDauRow.Output);
            maTranDau.TangDonViDem();

            tranDauRow.CapNhatSTT(pDanhSachTranDau.Controls.Count);
            tranDauRow.CapNhatMaTranDau(maTranDau.LayID());
        }

        internal void XoaTranDau(GUI_LapTranDau_RowVersion GUI_lapTranDau_RowVersion)
        {
            danhSachTranDau.Delete(GUI_lapTranDau_RowVersion.Output);

            int index = pDanhSachTranDau.Controls.IndexOf(GUI_lapTranDau_RowVersion);
            CaiDatSTT(index);

            if (GUI_lapTranDau_RowVersion.State == DataState.New)
            {
                CaiDatMaTranDau(index);
                maTranDau.GiamDonViDem();
            }

            pDanhSachTranDau.Controls.RemoveAt(index);           
        }

        private void CaiDatMaTranDau(int index)
        {
            for (int i = pDanhSachTranDau.Controls.Count - 1; i > index; i--)
            {
                GUI_LapTranDau_RowVersion row = pDanhSachTranDau.Controls[i] as GUI_LapTranDau_RowVersion;
                GUI_LapTranDau_RowVersion rowTruoc = pDanhSachTranDau.Controls[i - 1] as GUI_LapTranDau_RowVersion;

                row.CapNhatMaTranDau(rowTruoc.LayMaTranDau());
            }
        }

        private void CaiDatSTT(int index)
        {
            for (int i = pDanhSachTranDau.Controls.Count - 1; i > index; i--)
            {
                GUI_LapTranDau_RowVersion row = pDanhSachTranDau.Controls[i] as GUI_LapTranDau_RowVersion;
                GUI_LapTranDau_RowVersion rowTruoc = pDanhSachTranDau.Controls[i - 1] as GUI_LapTranDau_RowVersion;

                row.CapNhatSTT(rowTruoc.LaySTT());
            }
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
