using QuanLyGiaiVoDichBongDaQuocGia.BUS;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.Manager;

namespace QuanLyGiaiVoDichBongDaQuocGia.GUI
{
    public partial class GUI_LapLichThiDau : Form
    {
        private readonly BUS_VongDau _BUS_VongDau;
        private readonly BUS_TranDau _BUS_TranDau;
        private readonly BUS_DoiBong _BUS_DoiBong;

        //Xu ly
        DTO_VongDau vongDau;
        List<DTO_TranDau> danhSachTranDau;

        //KiemTra
        List<DTO_TranDau> danhSachCapDau;
        OwnerManager<DTO_DoiBong, ComboBox> danhSachDoiBong;

        //Quan ly
        IDManager stt;
        IDManager maTranDau;       

        //UI
        public DTO_DoiBong cbTenDoi_DefaultItem = new DTO_DoiBong { TenDoiBong = "Chọn đội bóng" };

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
            danhSachCapDau = _BUS_TranDau.LayDanhSach();
        }

        private void LayDanhSachDoiBong()
        {
            danhSachDoiBong.AddData(cbTenDoi_DefaultItem, 100);
        }

        private void TaoDanhSachTranDau()
        {            
            danhSachTranDau = new();
        }

        private void TaoVongDau()
        {
            LayMaVongDauMoi();

            VongDau = new DTO_VongDau { MaVongDau = txtMaVongDau.Text };
        }

        private void TaoMaTranDau()
        {
            MaTranDau = new IDManager(_BUS_TranDau.LayMaMoiNhat().MaTranDau);
        }

        private void LayMaVongDauMoi()
        {
            txtMaVongDau.Text = _BUS_VongDau.LayMaMoiNhat().MaVongDau;
        }

        private void btnLapLichThiDau_Click(object sender, EventArgs e)
        {
            LayThongTinVongDau();
            LayDanhSachThongTinTranDau();

            try
            {
                if (_BUS_VongDau.LapLichThiDau(vongDau, danhSachTranDau))
                {
                    MaTranDau.Confirm();
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
            CapNhatSTT();
            CapNhatMaTranDau();

            pDanhSachTranDau.ResumeLayout();
        }

        private void CapNhatMaTranDau()
        {
            foreach (var row in pDanhSachTranDau.Controls)
            {
                if (row is GUI_LapTranDau_RowVersion tranDau)
                {
                    tranDau.CapNhatMaTranDau();
                }
            }
        }

        private void CapNhatSTT()
        {
            foreach (var row in pDanhSachTranDau.Controls)
            {
                if(row is GUI_LapTranDau_RowVersion tranDau)
                {
                    tranDau.CapNhatSTT();
                }
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
