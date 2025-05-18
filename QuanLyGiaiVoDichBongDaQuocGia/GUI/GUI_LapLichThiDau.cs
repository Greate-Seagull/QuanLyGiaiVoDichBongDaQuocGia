using QuanLyGiaiVoDichBongDaQuocGia.BUS;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.Manager;
using System.ComponentModel;

namespace QuanLyGiaiVoDichBongDaQuocGia.GUI
{
    public partial class GUI_LapLichThiDau : Form
    {
        private readonly BUS_VongDau _BUS_VongDau;
        private readonly BUS_TranDau _BUS_TranDau;
        private readonly BUS_DoiBong _BUS_DoiBong;

        //Xu ly
        DTO_VongDau vongDau;
        List<DTO_TranDau> danhSachTranDauLapLich;
        BindingList<DTO_TranDau> danhSachTranDauHienThi;

        //KiemTra
        List<DTO_TranDau> danhSachCapDau;
        OwnerManager<DTO_DoiBong, ComboBox> danhSachDoiBong;

        //Quan ly
        IDManager maVongDau;
        IDManager maTranDauQuanLy;       

        //UI
        public DTO_DoiBong cbTenDoi_DefaultItem = new DTO_DoiBong { TenDoiBong = "Chọn đội bóng" };

        public GUI_LapLichThiDau(BUS_VongDau bUS_VongDau, BUS_TranDau bUS_TranDau, BUS_DoiBong bUS_DoiBong)
        {
            InitializeComponent();

            //Dependencies
            _BUS_VongDau = bUS_VongDau;
            _BUS_TranDau = bUS_TranDau;
            _BUS_DoiBong = bUS_DoiBong;
        }

        private void GUI_LapLichThiDau_Load(object sender, EventArgs e)
        {                                    
            TaoVongDau();
            TaoDanhSachTranDau();
            LayDanhSachDoiBong();
            LayDanhSachCapDau();

            UILoad();
        }

        private void UILoad()
        {
            danhSachTranDauHienThi = new();
            dgDanhSachTranDau.DataSource = danhSachTranDauHienThi;
        }

        private void LayDanhSachCapDau()
        {
            danhSachCapDau = _BUS_TranDau.LayDanhSachCapDauNgoaiTruVongDau(vongDau.MaVongDau);
        }

        private void LayDanhSachDoiBong()
        {
            danhSachDoiBong.AddData(cbTenDoi_DefaultItem, 100);
        }

        private void TaoDanhSachTranDau()
        {
            maTranDauQuanLy = new(_BUS_TranDau.LayMaMoiNhat());
            danhSachTranDauLapLich = new();
        }

        private void TaoVongDau()
        {
            maVongDau = new(_BUS_VongDau.LayMaMoiNhat());
            txtMaVongDau.Text = maVongDau.GetNewID().ToString();
            vongDau = new DTO_VongDau { MaVongDau = maVongDau.GetCurrentID().ToString() };
        }

        private void btnLapLichThiDau_Click(object sender, EventArgs e)
        {
            LayThongTinVongDau();

            try
            {
                if (_BUS_VongDau.LapLichThiDau(vongDau, danhSachTranDauLapLich))
                {
                    maTranDauQuanLy.Confirm();
                    MessageBox.Show("Lập lịch thi đấu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LayThongTinVongDau()
        {
            vongDau.MaVongDau = txtMaVongDau.Text;
            vongDau.TenVongDau = txtVongThiDau.Text;
        }

        private void btnThemTranDau_Click(object sender, EventArgs e)
        {
            var tranDauMoi = new DTO_TranDau
            {
                MaTranDau = maTranDauQuanLy.CreateID(danhSachTranDauLapLich.Count + 1).ToString(),
                MaVongDau = vongDau.MaVongDau
            };

            danhSachTranDauLapLich.Add(tranDauMoi);

            danhSachTranDauHienThi.Add(tranDauMoi);
        }

        private void CapNhatMaTranDau()
        {
            int iDOffset = 1;
            foreach (var entity in danhSachTranDauLapLich)
            {
                entity.MaTranDau = maTranDauQuanLy.CreateID(iDOffset++).ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
