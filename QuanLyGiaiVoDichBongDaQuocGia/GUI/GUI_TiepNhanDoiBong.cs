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

        DTO_ThamSo thamSo;
        DTO_DoiBong doiBong;
        Manager.Manager<DTO.DTO_CauThu> danhSachCauThuDaTiepNhan;
        List<DTO.DTO_LoaiCauThu> danhSachLoaiCauThu;

        string maCauThu;
        int soLuongCauThuMoi;

        public DTO_ThamSo ThamSo { get => thamSo; }
        public DTO_DoiBong DoiBong { get => doiBong; }
        public Manager<DTO_CauThu> DanhSachCauThu { get => danhSachCauThuDaTiepNhan; }
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
            LayMaCauThuHienTai();
            LayDanhLoaiCauThu();
            CapNhatSoLuongCauThuMoi();

            doiBong = new DTO_DoiBong(txtMaDoiBong.Text, null, null);
            danhSachCauThuDaTiepNhan = new Manager.Manager<DTO.DTO_CauThu>();            
        }

        private void LayMaCauThuHienTai()
        {
            maCauThu = BUS_cauThu.LayMaCauThuHienTai();
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
                    CapNhatThaoTacDanhSachCauThu();
                    CapNhatMauSacChoDong();
                    CapNhatSoLuongCauThuMoi();
                    MessageBox.Show("Tiếp nhận đội bóng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void CapNhatMauSacChoDong()
        {
            foreach(GUI_TiepNhanCauThu_RowVersion row in pDanhSachCauThu.Controls)
            {
                row.CapNhatMauSac();
            }
        }

        private void CapNhatSoLuongCauThuMoi()
        {
            soLuongCauThuMoi = 0;
        }

        private void CapNhatThaoTacDanhSachCauThu()
        {
            foreach (var cauThu in danhSachCauThuDaTiepNhan.Items.Values)
            {
                if (cauThu.Operation == OperationType.Delete)
                {
                    danhSachCauThuDaTiepNhan.Delete(cauThu.Data.MaCauThu, true);
                }
                else
                {
                    cauThu.Operation = OperationType.None;
                }
            }
        }

        private void LayDanhSachThongTinCauThu()
        {
            foreach (GUI_TiepNhanCauThu_RowVersion cauThuRow in pDanhSachCauThu.Controls)
            {
                cauThuRow.CapNhatThongTinCauThu();

                DanhSachCauThu.Add(cauThuRow.CauThu.MaCauThu, cauThuRow.Output);                
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
                soLuongCauThuMoi++;

                newRow.CapNhatSTT(pDanhSachCauThu.Controls.Count);
                newRow.CapNhatMaCauThu(CauThuHelper.TaoMaCauThu(MaCauThu, danhSachCauThuDaTiepNhan.Count + soLuongCauThuMoi));
            }            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        internal void XoaCauThu(GUI_TiepNhanCauThu_RowVersion GUI_tiepNhanCauThu_RowVersion)
        {
            danhSachCauThuDaTiepNhan.Delete(GUI_tiepNhanCauThu_RowVersion.CauThu.MaCauThu);

            int index = pDanhSachCauThu.Controls.IndexOf(GUI_tiepNhanCauThu_RowVersion);
            pDanhSachCauThu.Controls.RemoveAt(index);

            CaiDatSTT(index);

            if (GUI_tiepNhanCauThu_RowVersion.Operation == OperationType.Insert)
            {
                soLuongCauThuMoi--;
                CaiDatMaCauThu();
            }
        }

        private void CaiDatMaCauThu()
        {
            int soLuongCauThuChuaTiepNhan = 0;
            foreach(GUI_TiepNhanCauThu_RowVersion row in pDanhSachCauThu.Controls)
            {
                if(row.Operation == OperationType.Insert)
                {
                    soLuongCauThuChuaTiepNhan++;
                    row.CapNhatMaCauThu(CauThuHelper.TaoMaCauThu(MaCauThu, danhSachCauThuDaTiepNhan.Count + soLuongCauThuChuaTiepNhan));
                }
            }
        }

        private void CaiDatSTT(int index = 0)
        {
            for (int i = index; i < pDanhSachCauThu.Controls.Count; i++)
            {
                if (pDanhSachCauThu.Controls[i] is GUI_TiepNhanCauThu_RowVersion row)
                {
                    row.CapNhatSTT(i + 1);
                }
            }
        }
    }
}
