using QuanLyGiaiVoDichBongDaQuocGia.BUS;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.Manager;
using QuanLyGiaiVoDichBongDaQuocGia.ViewModel;
using System.ComponentModel;
using System.Data;

namespace QuanLyGiaiVoDichBongDaQuocGia.GUI
{
    public partial class GUI_ThayDoiQuiDinh : Form
    {
        //Dependencies
        private readonly BUS_ThamSo _BUS_ThamSo;
        private readonly BUS_LoaiCauThu _BUS_LoaiCauThu;
        private readonly BUS_LoaiBanThang _BUS_LoaiBanThang;

        DTO_ThamSo thamSoThayDoi;
        DTO_LoaiCauThu loaiCauThuThayDoi;
        DTO_LoaiBanThang loaiBanThangThayDoi;

        IDManager maLoaiBanThangQuanLy;
        Dictionary<string, DTO_LoaiCauThu> danhSachLoaiCauThu;
        Dictionary<string, DTO_LoaiBanThang> danhSachLoaiBanThang;

        BindingList<VM_LoaiCauThu> danhSachLoaiCauThuHienThi;
        BindingList<VM_LoaiBanThang> danhSachLoaiBanThangHienThi;

        //UI
        VM_LoaiBanThang addBanThangOption = new VM_LoaiBanThang { MaLoaiBanThang = null, TenLoaiBanThang = "Thêm loại bàn thắng" };

        public GUI_ThayDoiQuiDinh(BUS_ThamSo bUS_ThamSo, BUS_LoaiCauThu bUS_LoaiCauThu, BUS_LoaiBanThang bUS_LoaiBanThang)
        {
            InitializeComponent();

            //Dependencies
            _BUS_ThamSo = bUS_ThamSo;
            _BUS_LoaiCauThu = bUS_LoaiCauThu;
            _BUS_LoaiBanThang = bUS_LoaiBanThang;
        }

        private void nudTuoiToiThieu_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            nudTuoiToiDa.Minimum = nud.Value;
        }

        private void nudTuoiToiDa_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            nudTuoiToiThieu.Maximum = nud.Value;
        }

        private void nudSoLuongCauThuToiThieu_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            nudSoLuongCauThuToiDa.Minimum = nud.Value;
        }

        private void nudSoLuongCauThuToiDa_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            nudSoLuongCauThuToiThieu.Maximum = nud.Value;
        }

        private void cbLoaiCauThu_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cb = sender as ComboBox;
            var item = cb.SelectedItem as VM_LoaiCauThu;
            nudSoLuongCauThuToiDaTheoLoai.Value = item.SoLuongCauThuToiDaTheoLoaiCauThu;
        }

        private void cbLoaiBanThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cb = sender as ComboBox;
            var item = cb.SelectedItem as VM_LoaiBanThang;

            if (item.TenLoaiBanThang.Length > txtTenLoaiBanThang.MaxLength)
                return;    
            
            txtTenLoaiBanThang.Text = item.TenLoaiBanThang;
        }

        private void nudDiemThang_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            nudDiemHoa.Maximum = nud.Value - 1 > 0 ? nud.Value - 1 : 0;
        }

        private void nudDiemHoa_ValueChanged(object sender, EventArgs e)
        {
            var nud = sender as NumericUpDown;
            nudDiemThua.Maximum = nud.Value - 1 > 0 ? nud.Value - 1 : 0;
        }

        private void GUI_ThayDoiQuiDinh_Load(object sender, EventArgs e)
        {
            LayThamSo();
            LayDanhSachLoaiCauThu();
            LayDanhSachLoaiBanThang();
            LayMaLoaiBanThangMoi();

            UILoad();
        }

        private void LayMaLoaiBanThangMoi()
        {
            maLoaiBanThangQuanLy = new(_BUS_LoaiBanThang.LayMaMoiNhat());
        }

        private void UILoad()
        {
            Reset();
        }

        private void LayDanhSachLoaiBanThang()
        {
            danhSachLoaiBanThang = _BUS_LoaiBanThang.LayDanhSachLoaiBanThangThayDoiQuiDinh().ToDictionary(entity => entity.MaLoaiBanThang);
        }

        private void TaoDanhSachLoaiBanThangHienThi()
        {
            danhSachLoaiBanThangHienThi = new(danhSachLoaiBanThang.Values.Where(entity => entity.Deleted == false)
                                                                         .Select(entity => new VM_LoaiBanThang { MaLoaiBanThang = entity.MaLoaiBanThang, TenLoaiBanThang = entity.TenLoaiBanThang })
                                                                         .ToList());
            danhSachLoaiBanThangHienThi.Add(addBanThangOption);
        }

        private void LayDanhSachLoaiCauThu()
        {
            danhSachLoaiCauThu = _BUS_LoaiCauThu.LayDanhSachLoaiCauThuThayDoiQuiDinh().ToDictionary(entity => entity.MaLoaiCauThu);
        }

        private void TaoDanhSachLoaiCauThuHienThi()
        {
            danhSachLoaiCauThuHienThi = new(danhSachLoaiCauThu.Values.Select(entity => new VM_LoaiCauThu
            {
                MaLoaiCauThu = entity.MaLoaiCauThu,
                TenLoaiCauThu = entity.TenLoaiCauThu,
                SoLuongCauThuToiDaTheoLoaiCauThu = entity.SoLuongCauThuToiDaTheoLoaiCauThu ?? 0
            })
                                                                      .ToList()
                                            );
        }

        private void LayThamSo()
        {
            thamSoThayDoi = _BUS_ThamSo.LayThamSoThayDoiQuiDinh();
        }

        private void btnXoaLoaiBanThang_Click(object sender, EventArgs e)
        {
            var entity = cbLoaiBanThang.SelectedItem as VM_LoaiBanThang;

            if (entity.Equals(addBanThangOption))
                return;

            danhSachLoaiBanThangHienThi.Remove(entity);
            cbLoaiBanThang.SelectedIndex = 0;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            nudTuoiToiThieu.Value = (decimal)thamSoThayDoi.TuoiCauThuToiThieu;
            nudTuoiToiDa.Value = (decimal)thamSoThayDoi.TuoiCauThuToiDa;
            nudSoLuongCauThuToiThieu.Value = (decimal)thamSoThayDoi.SoLuongCauThuToiThieu;
            nudSoLuongCauThuToiDa.Value = (decimal)thamSoThayDoi.SoLuongCauThuToiDa;

            TaoDanhSachLoaiCauThuHienThi();
            cbLoaiCauThu.DataSource = danhSachLoaiCauThuHienThi;
            cbLoaiCauThu.DisplayMember = "TenLoaiCauThu";

            nudThoiDiemGhiBanToiDa.Value = (decimal)thamSoThayDoi.ThoiDiemGhiBanToiDa;

            TaoDanhSachLoaiBanThangHienThi();
            cbLoaiBanThang.DataSource = danhSachLoaiBanThangHienThi;
            cbLoaiBanThang.DisplayMember = "TenLoaiBanThang";

            nudDiemThang.Value = (decimal)thamSoThayDoi.DiemThang;
            nudDiemHoa.Value = (decimal)thamSoThayDoi.DiemHoa;
            nudDiemThua.Value = (decimal)thamSoThayDoi.DiemThua;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            CapNhatThongTinThamSo();
            CapNhatThongTinLoaiCauThu();
            CapNhatThongTinLoaiBanThang();

            try
            {
                if (_BUS_ThamSo.ThayDoiQuiDinh(thamSoThayDoi) &&
                    _BUS_LoaiCauThu.ThayDoiQuiDinh(loaiCauThuThayDoi) &&
                    _BUS_LoaiBanThang.ThayDoiQuiDinh(danhSachLoaiBanThang.Values.ToList()))
                {
                    Reset();
                    maLoaiBanThangQuanLy.Confirm();
                    MessageBox.Show("Thay đổi qui định thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CapNhatThongTinLoaiBanThang()
        {
            var loaiBanThangView = cbLoaiBanThang.SelectedItem as VM_LoaiBanThang;
            DTO_LoaiBanThang loaiBanThang;
            var tenLoaiCauThu = txtTenLoaiBanThang.Text;

            foreach(var entity in danhSachLoaiBanThang.Values)
            {
                entity.Deleted = true;
            }            

            foreach (var entityView in danhSachLoaiBanThangHienThi)
            {
                if (entityView.Equals(addBanThangOption) == false)
                    danhSachLoaiBanThang[entityView.MaLoaiBanThang].Deleted = false;
            }

            if(loaiBanThangView.Equals(addBanThangOption))
            {
                var maLoaiBanThang = maLoaiBanThangQuanLy.GetNewID().ToString();
                loaiBanThangThayDoi = new DTO_LoaiBanThang
                {
                    MaLoaiBanThang = maLoaiBanThang,
                    TenLoaiBanThang = tenLoaiCauThu
                };

                danhSachLoaiBanThang.Add(maLoaiBanThang, loaiBanThangThayDoi);
            }
            else
            {
                loaiBanThangThayDoi = danhSachLoaiBanThang[loaiBanThangView.MaLoaiBanThang];
                loaiBanThangThayDoi.TenLoaiBanThang = tenLoaiCauThu;
            }
        }

        private void CapNhatThongTinLoaiCauThu()
        {
            var loaiCauThuView = cbLoaiCauThu.SelectedItem as VM_LoaiCauThu;

            if(danhSachLoaiCauThu.TryGetValue(loaiCauThuView.MaLoaiCauThu, out loaiCauThuThayDoi))
            {
                loaiCauThuThayDoi.SoLuongCauThuToiDaTheoLoaiCauThu = (int)nudSoLuongCauThuToiDaTheoLoai.Value;
            }
        }

        private void CapNhatThongTinThamSo()
        {
            thamSoThayDoi.TuoiCauThuToiThieu = (int)nudTuoiToiThieu.Value;
            thamSoThayDoi.TuoiCauThuToiDa = (int)nudTuoiToiDa.Value;
            thamSoThayDoi.SoLuongCauThuToiThieu = (int)nudSoLuongCauThuToiThieu.Value;
            thamSoThayDoi.SoLuongCauThuToiDa = (int)nudSoLuongCauThuToiDa.Value;
            thamSoThayDoi.ThoiDiemGhiBanToiDa = (int)nudThoiDiemGhiBanToiDa.Value;
            thamSoThayDoi.DiemThang = (int)nudDiemThang.Value;
            thamSoThayDoi.DiemHoa = (int)nudDiemHoa.Value;
            thamSoThayDoi.DiemThua = (int)nudDiemThua.Value;
        }
    }
}
