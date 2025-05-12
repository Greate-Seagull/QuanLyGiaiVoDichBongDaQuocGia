using QuanLyGiaiVoDichBongDaQuocGia.BUS;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.Manager;
using QuanLyGiaiVoDichBongDaQuocGia.FilterHelper;
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
    public partial class GUI_GhiNhanKetQua : Form
    {
        BUS_BanThang busBanThang = new BUS_BanThang();
        BUS_TranDau busTranDau = new BUS_TranDau();
        BUS_CauThu busCauThu = new BUS_CauThu();
        BUS_LoaiBanThang busLoaiBanThang = new BUS_LoaiBanThang();

        //Xu ly
        //DTO_TranDau tranDau;
        DataManager<DTO_BanThang> danhSachBanThang;

        //Quan ly
        IDManager stt;
        IDManager maBanThang;

        List<DTO_CauThu> danhSachCauThuThuocHaiDoi;
        List<DTO_LoaiBanThang> danhSachLoaiBanThang;

        public IDManager STT { get => stt; set => stt = value; }
        public IDManager MaBanThang { get => maBanThang; set => maBanThang = value; }
        public List<DTO_CauThu> DanhSachCauThuThuocHaiDoi { get => danhSachCauThuThuocHaiDoi; set => danhSachCauThuThuocHaiDoi = value; }
        public List<DTO_LoaiBanThang> DanhSachLoaiBanThang { get => danhSachLoaiBanThang; set => danhSachLoaiBanThang = value; }
        public DTO_TranDau TranDau { get => cbTranDau.SelectedItem as DTO_TranDau; }

        public GUI_GhiNhanKetQua()
        {
            InitializeComponent();
        }

        private void GUI_GhiNhanKetQua_Load(object sender, EventArgs e)
        {
            TaoSTT();
            TaoMaBanThang();
            LayDanhSachTranDau();
            TaoDanhSachBanThang();
            LayDanhSachLoaiBanThang();
            CapNhatTiSo();
        }

        private void LayDanhSachLoaiBanThang()
        {
            DanhSachLoaiBanThang = busLoaiBanThang.LayDanhSach(default, LoaiBanThangColumn.TenLoaiBanThang).GetReadData();
        }

        private void LayDanhSachCauThuThuocHaiDoi()
        {
            var filters = FilterBuilder<CauThuColumn>
                .Where(CauThuColumn.MaDoiBong).In(TranDau.DoiBong1.MaDoiBong, TranDau.DoiBong2.MaDoiBong)
                .Build();

            danhSachCauThuThuocHaiDoi = busCauThu.LayDanhSach(filters, CauThuColumn.TenCauThu, CauThuColumn.MaDoiBong).GetReadData();
        }

        private void TaoDanhSachBanThang()
        {
            danhSachBanThang = busBanThang.LayDanhSachNhap();
        }

        private void LayDanhSachTranDau()
        {
            cbTranDau.DataSource = busTranDau.LayDanhSach(default, TranDauColumn.MaDoi1, TranDauColumn.MaDoi2, TranDauColumn.NgayGio).GetReadData();
        }

        private void TaoMaBanThang()
        {
            MaBanThang = new IDManager(busBanThang.LayMaBanThangHienTai());
        }

        private void TaoSTT()
        {
            stt = new IDManager("0");
        }

        private void cbTranDau_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            DTO_TranDau tranDauDuocChon = cb.SelectedItem as DTO_TranDau;

            txtTenSan.Text = tranDauDuocChon.DoiBong1.TenSanNha;
            txtNgayGio.Text = tranDauDuocChon.NgayGio.ToString("dd/MM/yyyy hh:mm");

            LayDanhSachCauThuThuocHaiDoi();
            CapNhatDoiBongChoDong();
        }

        private void CapNhatDoiBongChoDong()
        {
            foreach(var row in pDanhSachBanThang.Controls)
            {
                if(row is GUI_GhiNhanBanThang_RowVersion banThangRow)
                    banThangRow.CapNhatDanhSachDoiBong();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGhiNhanKetQua_Click(object sender, EventArgs e)
        {
            LayDanhSachThongTinBanThang();

            try
            {
                if (busTranDau.GhiNhanKetQua())
                {
                    danhSachBanThang.UpdateDataState();
                    MessageBox.Show("Ghi nhận kết quả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LayDanhSachThongTinBanThang()
        {
            foreach (GUI_GhiNhanBanThang_RowVersion row in pDanhSachBanThang.Controls)
            {
                row.CapNhatThongTinBanThang();
                danhSachBanThang.AddOrUpdate(row.BanThang.MaBanThang, row.Output);
            }
        }

        private void btnThemBanThang_Click(object sender, EventArgs e)
        {
            pDanhSachBanThang.SuspendLayout();

            GUI_GhiNhanBanThang_RowVersion banThangRow = new GUI_GhiNhanBanThang_RowVersion(this);
            pDanhSachBanThang.Controls.Add(banThangRow);

            pDanhSachBanThang.ResumeLayout();
        }

        internal void XoaBanThang(GUI_GhiNhanBanThang_RowVersion GUI_ghiNhanBanThang_RowVersion)
        {
            pDanhSachBanThang.SuspendLayout();

            pDanhSachBanThang.Controls.Remove(GUI_ghiNhanBanThang_RowVersion);
            danhSachBanThang.Delete(GUI_ghiNhanBanThang_RowVersion.BanThang.MaBanThang);
            CapNhatSTT();
            CapNhatMaBanThang();

            pDanhSachBanThang.ResumeLayout();
        }

        private void CapNhatMaBanThang()
        {
            foreach (var row in pDanhSachBanThang.Controls)
            {
                if (row is GUI_GhiNhanBanThang_RowVersion banThang)
                {
                    banThang.CapNhatMaBanThang();
                }
            }
        }

        private void CapNhatSTT()
        {
            foreach (var row in pDanhSachBanThang.Controls)
            {
                if (row is GUI_GhiNhanBanThang_RowVersion banThang)
                {
                    banThang.CapNhatSTT();
                }
            }
        }
        internal void CapNhatTiSo()
        {
            TranDau.TiSoDoi1 = TranDau.TiSoDoi2 = 0;

            foreach (var row in pDanhSachBanThang.Controls)
            {
                if(row is GUI_GhiNhanBanThang_RowVersion banThang)
                {
                    if (banThang.DoiBong == TranDau.DoiBong1)
                        TranDau.TiSoDoi1++;
                    else
                        TranDau.TiSoDoi2++;
                }
            }

            txtTiSo.Text = $"{TranDau.TiSoDoi1} - {TranDau.TiSoDoi2}";
        }
    }
}
