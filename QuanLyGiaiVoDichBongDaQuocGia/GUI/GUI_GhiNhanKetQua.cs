using QuanLyGiaiVoDichBongDaQuocGia.BUS;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.Manager;
using System.Data;
using System.Linq.Expressions;

namespace QuanLyGiaiVoDichBongDaQuocGia.GUI
{
    public partial class GUI_GhiNhanKetQua : Form
    {
        private readonly BUS_BanThang _BUS_BanThang;
        private readonly BUS_TranDau _BUS_TranDau;
        private readonly BUS_CauThu _BUS_CauThu;
        private readonly BUS_LoaiBanThang _BUS_LoaiBanThang;

        //Xu ly
        //DTO_TranDau tranDau;
        List<DTO_BanThang> danhSachBanThang;

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
            LayDanhSachLoaiBanThang();
            CapNhatTiSo();
        }

        private void LayDanhSachLoaiBanThang()
        {
            DanhSachLoaiBanThang = _BUS_LoaiBanThang.LayDanhSach();
        }

        private void LayDanhSachCauThuThuocHaiDoi()
        {
            danhSachCauThuThuocHaiDoi = _BUS_CauThu.LayDanhSach();
        }

        private void LayDanhSachTranDau()
        {
            cbTranDau.DataSource = _BUS_TranDau.LayDanhSach();
        }

        private void TaoMaBanThang()
        {
            MaBanThang = new IDManager(_BUS_BanThang.LayMaMoiNhat().MaBanThang);
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
                if (_BUS_TranDau.GhiNhanKetQua(danhSachBanThang))
                {
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
