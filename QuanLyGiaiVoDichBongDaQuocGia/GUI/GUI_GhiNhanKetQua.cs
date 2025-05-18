using QuanLyGiaiVoDichBongDaQuocGia.BUS;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.Manager;
using System.ComponentModel;
using System.Data;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.GUI
{
    public partial class GUI_GhiNhanKetQua : Form
    {
        private readonly BUS_TranDau _BUS_TranDau;
        private readonly BUS_DoiBong _BUS_DoiBong;
        private readonly BUS_CauThu _BUS_CauThu;
        private readonly BUS_LoaiBanThang _BUS_LoaiBanThang;
        private readonly BUS_BanThang _BUS_BanThang;

        //Xu ly
        //DTO_TranDau tranDau;
        List<DTO_BanThang> danhSachBanThangGhiNhan;
        BindingList<DTO_BanThang> danhSachBanThangHienThi;

        //Quan ly
        IDManager maBanThangQuanLy;

        List<DTO_CauThu> danhSachCauThuThuocHaiDoi;
        List<DTO_LoaiBanThang> danhSachLoaiBanThang;

        public GUI_GhiNhanKetQua(BUS_BanThang bUS_BanThang, BUS_TranDau bUS_TranDau, BUS_CauThu bUS_CauThu, BUS_LoaiBanThang bUS_LoaiBanThang, BUS_DoiBong bUS_DoiBong)
        {
            InitializeComponent();

            //Dependencies
            _BUS_TranDau = bUS_TranDau;
            _BUS_DoiBong = bUS_DoiBong;
            _BUS_CauThu = bUS_CauThu;
            _BUS_LoaiBanThang = bUS_LoaiBanThang;
            _BUS_BanThang = bUS_BanThang;
        }

        private void GUI_GhiNhanKetQua_Load(object sender, EventArgs e)
        {
            TaoDanhSachBanThang();
            LayDanhSachTranDau();
            LayDanhSachLoaiBanThang();
            CapNhatTiSo();
        }

        private void LayDanhSachLoaiBanThang()
        {
            danhSachLoaiBanThang = _BUS_LoaiBanThang.LayDanhSachLoaiBanThangGhiNhanKetQua();
        }

        private void LayDanhSachCauThuThuocHaiDoi(string maDoi1, string maDoi2)
        {
            danhSachCauThuThuocHaiDoi = _BUS_CauThu.LayDanhSachCauThuThuocHaiDoi(maDoi1, maDoi2);
        }

        private void LayDanhSachTranDau()
        {
            cbTranDau.DataSource = _BUS_TranDau.LayDanhSachTranDauGhiNhanKetQua();
        }

        private void TaoDanhSachBanThang()
        {
            maBanThangQuanLy = new(_BUS_BanThang.LayMaMoiNhat());
            danhSachBanThangGhiNhan = new();
        }

        private void cbTranDau_SelectedIndexChanged(object sender, EventArgs e)
        {
            //ComboBox cb = sender as ComboBox;
            //DTO_TranDau tranDauDuocChon = cb.SelectedItem as DTO_TranDau;

            //txtNgayGio.Text = tranDauDuocChon.NgayGio.ToString(DataFormat.DataFormat.DateTimeFormat);

            //LayDanhSachCauThuThuocHaiDoi(tranDauDuocChon.MaDoi1, tranDauDuocChon.MaDoi2);
            //LayDoiBongChuNha(new List<string>{ tranDauDuocChon.MaDoi1});

            //txtTenSan.Text = danhSachDoiBongThamGiaTranDau[tra]
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGhiNhanKetQua_Click(object sender, EventArgs e)
        {
            //LayDanhSachThongTinBanThang();

            //try
            //{
            //    if (_BUS_TranDau.GhiNhanKetQua(danhSachBanThangGhiNhan))
            //    {
            //        MessageBox.Show("Ghi nhận kết quả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception err)
            //{
            //    MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
        }

        private void btnThemBanThang_Click(object sender, EventArgs e)
        {
            //pDanhSachBanThang.SuspendLayout();

            //GUI_GhiNhanBanThang_RowVersion banThangRow = new GUI_GhiNhanBanThang_RowVersion(this);
            //pDanhSachBanThang.Controls.Add(banThangRow);

            //pDanhSachBanThang.ResumeLayout();
        }

        private void CapNhatMaBanThang()
        {
            //foreach (var row in pDanhSachBanThang.Controls)
            //{
            //    if (row is GUI_GhiNhanBanThang_RowVersion banThang)
            //    {
            //        banThang.CapNhatMaBanThang();
            //    }
            //}
        }

        internal void CapNhatTiSo()
        {
            //TranDau.TiSoDoi1 = TranDau.TiSoDoi2 = 0;

            //foreach (var row in pDanhSachBanThang.Controls)
            //{
            //    if(row is GUI_GhiNhanBanThang_RowVersion banThang)
            //    {
            //        if (banThang.DoiBong == TranDau.DoiBong1)
            //            TranDau.TiSoDoi1++;
            //        else
            //            TranDau.TiSoDoi2++;
            //    }
            //}

            //txtTiSo.Text = $"{TranDau.TiSoDoi1} - {TranDau.TiSoDoi2}";
        }
    }
}
