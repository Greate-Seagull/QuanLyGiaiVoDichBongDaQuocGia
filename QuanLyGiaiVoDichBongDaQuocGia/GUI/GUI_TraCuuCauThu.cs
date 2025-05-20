using DevExpress.Internal.WinApi.Windows.UI.Notifications;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraRichEdit.Layout.Export;
using Microsoft.EntityFrameworkCore.Query.Internal;
using QuanLyGiaiVoDichBongDaQuocGia.BUS;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using System.Collections.Generic;
using System.ComponentModel;

namespace QuanLyGiaiVoDichBongDaQuocGia.GUI
{
    public partial class GUI_TraCuuCauThu : Form
    {
        //Dependencies
        private readonly BUS_CauThu _BUS_CauThu;
        private readonly BUS_DoiBong _BUS_DoiBong;
        private readonly BUS_LoaiCauThu _BUS_LoaiCauThu;
        private readonly BUS_VongDau _BUS_VongDau;
        private readonly BUS_TranDau _BUS_TranDau;
        private readonly BUS_LoaiBanThang _BUS_LoaiBanThang;
        private readonly BUS_BanThang _BUS_BanThang;

        //Cache
        Dictionary<string, DTO_CauThu> danhSachCauThu;
        Dictionary<string, DTO_DoiBong> danhSachDoiBong;
        Dictionary<string, DTO_LoaiCauThu> danhSachLoaiCauThu;
        Dictionary<string, DTO_VongDau> danhSachVongDau;
        Dictionary<string, DTO_TranDau> danhSachTranDau;
        Dictionary<string, DTO_BanThang> danhSachBanThang;
        Dictionary<string, DTO_LoaiBanThang> danhSachLoaiBanThang;

        //UI
        DTO_LoaiCauThu defaultLoaiCauThu = new DTO_LoaiCauThu { TenLoaiCauThu = "Tất cả" };
        DTO_DoiBong defaultDoiBong = new DTO_DoiBong { TenDoiBong = "Tất cả", TenSanNha = "Tất cả" };
        DTO_VongDau defaultVongDau = new DTO_VongDau { TenVongDau = "Tất cả" };
        DTO_TranDau defaultTranDau = new DTO_TranDau { MaTranDau = "Tất cả" };
        DTO_BanThang defaultBanThang = new DTO_BanThang { MaBanThang = "Tất cả" };
        DTO_LoaiBanThang defaultLoaiBanThang = new DTO_LoaiBanThang { TenLoaiBanThang = "Tất cả" };

        List<DTO_TranDau> filteredDanhSachTranDau;
        List<DTO_DoiBong> filteredDanhSachDoiBong;
        List<DTO_BanThang> filteredDanhSachBanThang;

        bool anyLoaiCauThuFiltersApplied;
        bool anyDoiBongFiltersApplied;
        bool anyVongDauFiltersApplied;
        bool anyTranDauFiltersApplied;
        bool anyBanThangFiltersApplied;

        public GUI_TraCuuCauThu(BUS_CauThu bUS_CauThu, BUS_DoiBong bUS_DoiBong, BUS_LoaiCauThu bUS_LoaiCauThu, BUS_VongDau bUS_VongDau, BUS_TranDau bUS_TranDau, BUS_LoaiBanThang bUS_LoaiBanThang, BUS_BanThang bUS_BanThang)
        {
            InitializeComponent();

            //Dependencies
            _BUS_CauThu = bUS_CauThu;
            _BUS_DoiBong = bUS_DoiBong;
            _BUS_LoaiCauThu = bUS_LoaiCauThu;
            _BUS_VongDau = bUS_VongDau;
            _BUS_TranDau = bUS_TranDau;
            _BUS_LoaiBanThang = bUS_LoaiBanThang;
            _BUS_BanThang = bUS_BanThang;
        }

        private void GUI_TraCuuCauThu_Load(object sender, EventArgs e)
        {
            //Non-foreign key is loaded first
            LayDanhSachLoaiCauThu();
            LayDanhSachLoaiBanThang();
            LayDanhSachDoiBong();
            LayDanhSachVongDau();

            //Foreign key is loaded second
            LayDanhSachCauThu();
            LayDanhSachTranDau();
            LayDanhSachBanThang();

            UILoad();
        }

        private void LayDanhSachCauThu()
        {
            danhSachCauThu = _BUS_CauThu.LayDanhSachCauThuTraCuu().ToDictionary(obj => obj.MaCauThu);
            _BUS_CauThu.DienThongTin(danhSachCauThu, danhSachDoiBong, danhSachLoaiCauThu);

            _BUS_DoiBong.DienDanhSach(danhSachDoiBong, danhSachCauThu);
        }

        private void UILoad()
        {
            var loaiCauThuBindingSource = new BindingList<DTO_LoaiCauThu>(danhSachLoaiCauThu.Values.ToList());
            loaiCauThuBindingSource.Insert(0, defaultLoaiCauThu);
            cbLoaiCauThu.DataSource = loaiCauThuBindingSource;
            cbLoaiCauThu.DisplayMember = "TenLoaiCauThu";

            filteredDanhSachDoiBong = danhSachDoiBong.Values.ToList();
            filteredDanhSachDoiBong.Insert(0, defaultDoiBong);
            cbDoiBong.DataSource = filteredDanhSachDoiBong;
            cbDoiBong.DisplayMember = "TenDoiBong";

            cbSanNha.DataSource = cbDoiBong.DataSource;
            cbSanNha.DisplayMember = "TenSanNha";

            var vongDauBindingSource = new BindingList<DTO_VongDau>(danhSachVongDau.Values.ToList());
            vongDauBindingSource.Insert(0, defaultVongDau);
            cbVongDau.DataSource = vongDauBindingSource;
            cbVongDau.DisplayMember = "TenVongDau";

            filteredDanhSachTranDau = danhSachTranDau.Values.ToList();
            filteredDanhSachTranDau.Insert(0, defaultTranDau);
            cbTranDau.DataSource = filteredDanhSachTranDau;
            cbTranDau.DisplayMember = "CapDau";

            filteredDanhSachBanThang = danhSachBanThang.Values.ToList();
            filteredDanhSachBanThang.Insert(0, defaultBanThang);
            cbBanThang.DataSource = filteredDanhSachBanThang;
            cbBanThang.DisplayMember = "ThongTin";

            var loaiBanThangBindingSource = new BindingList<DTO_LoaiBanThang>(danhSachLoaiBanThang.Values.ToList());
            loaiBanThangBindingSource.Insert(0, defaultLoaiBanThang);
            cbLoaiBanThang.DataSource = loaiBanThangBindingSource;
            cbLoaiBanThang.DisplayMember = "TenLoaiBanThang";

            cNgaySinh_CheckedChanged(cNgaySinh, EventArgs.Empty);
            cSoBanThang_CheckedChanged(cSoBanThang, EventArgs.Empty);
            cSoLuongCauThuTheoLoai_CheckedChanged(cSoLuongCauThuTheoLoai, EventArgs.Empty);
            cSoLuongCauThu_CheckedChanged(cSoLuongCauThu, EventArgs.Empty);
            cNgayBatDau_CheckedChanged(cNgayBatDau, EventArgs.Empty);
            cNgayKetThuc_CheckedChanged(cNgayKetThuc, EventArgs.Empty);
            cNgayTranDau_CheckedChanged(cNgayTranDau, EventArgs.Empty);
            cGioTranDau_CheckedChanged(cGioTranDau, EventArgs.Empty);
            cTiSo_CheckedChanged(cTiSo, EventArgs.Empty);
            cThoiDiemGhiBan_CheckedChanged(cThoiDiemGhiBan, EventArgs.Empty);
        }

        private void LayDanhSachLoaiBanThang()
        {
            danhSachLoaiBanThang = _BUS_LoaiBanThang.LayDanhSachLoaiBanThangTraCuu().ToDictionary(obj => obj.MaLoaiBanThang);
        }

        private void LayDanhSachBanThang()
        {
            danhSachBanThang = _BUS_BanThang.LayDanhSachBanThangTraCuu().ToDictionary(obj => obj.MaBanThang);
            _BUS_BanThang.DienThongTinTranDau(danhSachBanThang, danhSachTranDau);
            _BUS_BanThang.DienThongTinCauThu(danhSachBanThang, danhSachCauThu);
            _BUS_BanThang.DienThongTinLoaiBanThang(danhSachBanThang, danhSachLoaiBanThang);

            _BUS_CauThu.DienThongTinBanThang(danhSachCauThu, danhSachBanThang);
        }

        private void LayDanhSachTranDau()
        {
            danhSachTranDau = _BUS_TranDau.LayDanhSachTranDauTraCuu().ToDictionary(obj => obj.MaTranDau);
            _BUS_TranDau.DienThongTinDoiBong(danhSachTranDau, danhSachDoiBong);
            _BUS_TranDau.DienThongTinVongDau(danhSachTranDau, danhSachVongDau);
        }

        private void LayDanhSachVongDau()
        {
            danhSachVongDau = _BUS_VongDau.LayDanhSachVongDauTraCuu().ToDictionary(obj => obj.MaVongDau);
        }

        private void LayDanhSachDoiBong()
        {
            danhSachDoiBong = _BUS_DoiBong.LayDanhSachDoiBongTraCuu().ToDictionary(obj => obj.MaDoiBong);
        }

        private void LayDanhSachLoaiCauThu()
        {
            danhSachLoaiCauThu = _BUS_LoaiCauThu.LayDanhSachLoaiCauThuTraCuu().ToDictionary(obj => obj.MaLoaiCauThu);
        }

        private void cbLoaiCauThu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is not ComboBox cb || cb.SelectedItem is not DTO_LoaiCauThu loaiCauThu)
                return;

            bool isDefault = loaiCauThu.Equals(defaultLoaiCauThu);

            if (isDefault == false)
            {
                nudSoLuongCauThuTheoLoaiFrom.Value = Convert.ToDecimal(loaiCauThu?.SoLuongCauThuToiDaTheoLoaiCauThu);
                nudSoLuongCauThuTheoLoaiTo.Value = nudSoLuongCauThuTheoLoaiFrom.Value;
            }
        }

        private void cbDoiBong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is not ComboBox cb || cb.SelectedItem is not DTO_DoiBong doiBong)
                return;

            bool isDefault = doiBong.Equals(defaultDoiBong);

            if (isDefault == false)
            {
                nudSoLuongCauThuFrom.Value = Convert.ToDecimal(doiBong?.CacCauThu?.Count);
                nudSoLuongCauThuTo.Value = nudSoLuongCauThuFrom.Value;
            }
        }

        private void cbVongDau_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is not ComboBox cb || cb.SelectedItem is not DTO_VongDau vongDau)
                return;

            bool isDefault = vongDau.Equals(defaultBanThang);

            //Update TranDau
            filteredDanhSachTranDau = isDefault
                ? danhSachTranDau.Values.ToList()
                : _BUS_TranDau.TraCuuTranDauTheoVongDau(danhSachTranDau.Values, vongDau).ToList();

            filteredDanhSachTranDau.Insert(0, defaultTranDau);
            cbTranDau.DataSource = filteredDanhSachTranDau;

            if (isDefault == false)
            {
                //Update NgayBatDau
                DateTime vongDauNgayBatDau = vongDau.NgayBatDau ?? DateTime.Today;
                dtpNgayBatDauFrom.Value = vongDauNgayBatDau;
                dtpNgayBatDauTo.Value = vongDauNgayBatDau;

                //Update NgayKetThuc
                DateTime vongDauNgayKetThuc = vongDau.NgayBatDau ?? DateTime.Today;
                dtpNgayKetThucFrom.Value = vongDauNgayKetThuc;
                dtpNgayKetThucTo.Value = vongDauNgayKetThuc;
            }
        }

        private void cbTranDau_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is not ComboBox cb || cb.SelectedItem is not DTO_TranDau tranDau)
                return;

            bool isDefault = tranDau.Equals(defaultTranDau);

            //Update DoiBong
            filteredDanhSachDoiBong = isDefault
                ? danhSachDoiBong.Values.ToList()
                : _BUS_DoiBong.TraCuuDoiBongTheoTranDau(danhSachDoiBong.Values, tranDau).ToList();

            filteredDanhSachDoiBong.Insert(0, defaultDoiBong);
            cbDoiBong.DataSource = filteredDanhSachDoiBong;
            cbSanNha.DataSource = filteredDanhSachDoiBong;

            //Update BanThang
            filteredDanhSachBanThang = isDefault
                ? danhSachBanThang.Values.ToList()
                : _BUS_BanThang.TraCuuBanThangTheoTranDau(danhSachBanThang.Values, tranDau).ToList();

            filteredDanhSachBanThang.Insert(0, defaultBanThang);
            cbBanThang.DataSource = filteredDanhSachBanThang;

            if (isDefault == false)
            {
                //Update TiSo
                nudTiSoDoi1.Value = Convert.ToDecimal(tranDau?.TiSoDoi1);
                nudTiSoDoi2.Value = Convert.ToDecimal(tranDau?.TiSoDoi2);

                //Update NgayGio
                DateTime matchDateTime = tranDau.NgayGio ?? DateTime.Now;

                dtpNgayTranDauFrom.Value = matchDateTime;
                dtpNgayTranDauTo.Value = matchDateTime;

                dtpGioTranDauFrom.Value = matchDateTime;
                dtpGioTranDauTo.Value = matchDateTime;
            }
        }

        private void cbBanThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender is not ComboBox cb || cb.SelectedItem is not DTO_BanThang banThang)
                return;

            if (banThang.Equals(defaultBanThang) == false)
            {
                //Update LoaiBanThang
                cbLoaiBanThang.SelectedItem = banThang?.LoaiBanThang;

                //Update ThoiDiemGhiBan
                nudThoiDiemGhiBanFrom.Value = Convert.ToDecimal(banThang?.ThoiDiemGhiBan);
                nudThoiDiemGhiBanTo.Value = nudThoiDiemGhiBanFrom.Value;
            }
        }

        private void cNgaySinh_CheckedChanged(object sender, EventArgs e)
        {
            var c = sender as CheckBox;
            dtpNgaySinhFrom.Enabled = c.Checked;
            dtpNgaySinhTo.Enabled = c.Checked;
        }

        private void cSoBanThang_CheckedChanged(object sender, EventArgs e)
        {
            var c = sender as CheckBox;
            nudSoBanThangFrom.Enabled = c.Checked;
            nudSoBanThangTo.Enabled = c.Checked;
        }

        private void cSoLuongCauThuTheoLoai_CheckedChanged(object sender, EventArgs e)
        {
            var c = sender as CheckBox;
            nudSoLuongCauThuTheoLoaiFrom.Enabled = c.Checked;
            nudSoLuongCauThuTheoLoaiTo.Enabled = c.Checked;
        }

        private void cSoLuongCauThu_CheckedChanged(object sender, EventArgs e)
        {
            var c = sender as CheckBox;
            nudSoLuongCauThuFrom.Enabled = c.Checked;
            nudSoLuongCauThuTo.Enabled = c.Checked;
        }

        private void cNgayBatDau_CheckedChanged(object sender, EventArgs e)
        {
            var c = sender as CheckBox;
            dtpNgayBatDauFrom.Enabled = c.Checked;
            dtpNgayBatDauTo.Enabled = c.Checked;
        }

        private void cNgayKetThuc_CheckedChanged(object sender, EventArgs e)
        {
            var c = sender as CheckBox;
            dtpNgayKetThucFrom.Enabled = c.Checked;
            dtpNgayKetThucTo.Enabled = c.Checked;
        }

        private void cTiSo_CheckedChanged(object sender, EventArgs e)
        {
            var c = sender as CheckBox;
            nudTiSoDoi1.Enabled = c.Checked;
            nudTiSoDoi2.Enabled = c.Checked;
        }

        private void cNgayTranDau_CheckedChanged(object sender, EventArgs e)
        {
            var c = sender as CheckBox;
            dtpNgayTranDauFrom.Enabled = c.Checked;
            dtpNgayTranDauTo.Enabled = c.Checked;
        }

        private void cGioTranDau_CheckedChanged(object sender, EventArgs e)
        {
            var c = sender as CheckBox;
            dtpGioTranDauFrom.Enabled = c.Checked;
            dtpGioTranDauTo.Enabled = c.Checked;
        }

        private void cThoiDiemGhiBan_CheckedChanged(object sender, EventArgs e)
        {
            var c = sender as CheckBox;
            nudThoiDiemGhiBanFrom.Enabled = c.Checked;
            nudThoiDiemGhiBanTo.Enabled = c.Checked;
        }

        private void btnTraCuuCauThu_Click(object sender, EventArgs e)
        {
            var ketQuaTimKiemLoaiCauThu = TimKiemLoaiCauThu();
            var ketQuaTimKiemVongDau = TimKiemVongDau();
            var ketQuaTimKiemTranDau = TimKiemTranDau(ketQuaTimKiemVongDau);
            var ketQuaTimKiemDoiBong = TimKiemDoiBong(ketQuaTimKiemTranDau);
            var ketQuaTimKiemBanThang = TimKiemBanThang(ketQuaTimKiemTranDau);
            var ketQuaTimKiemCauThu = TimKiemCauThu(ketQuaTimKiemLoaiCauThu, ketQuaTimKiemDoiBong, ketQuaTimKiemBanThang);
            gcDanhSachCauThu.DataSource = ketQuaTimKiemCauThu.ToList();
        }

        private IEnumerable<DTO_CauThu> TimKiemCauThu(IEnumerable<DTO_LoaiCauThu>? ketQuaTimKiemLoaiCauThu, IEnumerable<DTO_DoiBong>? ketQuaTimKiemDoiBong, IEnumerable<DTO_BanThang>? ketQuaTimKiemBanThang)
        {
            var ketQuaTimKiem = _BUS_CauThu.TraCuuCauThu(danhSachCauThu.Values, txtMaCauThu.Text, txtTenCauThu.Text);

            if (cNgaySinh.Checked)
                ketQuaTimKiem = _BUS_CauThu.TraCuuCauThu(ketQuaTimKiem, dtpNgaySinhFrom.Value, dtpNgaySinhTo.Value);

            if (cSoBanThang.Checked)
                ketQuaTimKiem = _BUS_CauThu.TraCuuCauThu(ketQuaTimKiem, (int)nudSoBanThangFrom.Value, (int)nudSoBanThangTo.Value);

            if (anyLoaiCauThuFiltersApplied)
                ketQuaTimKiem = _BUS_CauThu.TraCuuCauThu(ketQuaTimKiem, ketQuaTimKiemLoaiCauThu);

            if (anyDoiBongFiltersApplied)
                ketQuaTimKiem = _BUS_CauThu.TraCuuCauThu(ketQuaTimKiem, ketQuaTimKiemDoiBong);

            if (anyBanThangFiltersApplied)
                ketQuaTimKiem = _BUS_CauThu.TraCuuCauThu(ketQuaTimKiem, ketQuaTimKiemBanThang);

            return ketQuaTimKiem;
        }

        private IEnumerable<DTO_BanThang>? TimKiemBanThang(IEnumerable<DTO_TranDau>? ketQuaTimKiemTranDau)
        {
            var banThang = cbBanThang.SelectedItem as DTO_BanThang;
            IEnumerable<DTO_BanThang>? ketQuaTimKiemBanThang = filteredDanhSachBanThang;

            anyBanThangFiltersApplied = banThang.Equals(defaultBanThang) == false;

            if (anyBanThangFiltersApplied)
            {
                ketQuaTimKiemBanThang = _BUS_BanThang.TraCuuBanThangTheoMaBanThang(ketQuaTimKiemBanThang, banThang.MaBanThang);
            }
            else
            {
                DTO_LoaiBanThang? loaiBanThang = cbLoaiBanThang.SelectedItem as DTO_LoaiBanThang;
                if (loaiBanThang.Equals(defaultLoaiBanThang) == false)
                {
                    ketQuaTimKiemBanThang = _BUS_BanThang.TraCuuBanThangTheoLoaiBanThang(ketQuaTimKiemBanThang, loaiBanThang);
                    anyBanThangFiltersApplied = true;
                }

                if (cThoiDiemGhiBan.Checked)
                {
                    ketQuaTimKiemBanThang = _BUS_BanThang.TraCuuBanThangTheoThoiDiemGhiBan(ketQuaTimKiemBanThang, (int)nudThoiDiemGhiBanFrom.Value, (int)nudThoiDiemGhiBanTo.Value);
                    anyBanThangFiltersApplied = true;
                }
            }

            //Prevent searching path ... TranDau -> BanThang -> CauThu ...
            if (anyTranDauFiltersApplied && anyBanThangFiltersApplied)
                ketQuaTimKiemBanThang = _BUS_BanThang.TraCuuBanThangTheoTranDau(ketQuaTimKiemBanThang, ketQuaTimKiemTranDau);

            return ketQuaTimKiemBanThang;
        }

        private IEnumerable<DTO_DoiBong>? TimKiemDoiBong(IEnumerable<DTO_TranDau>? ketQuaTimKiemTranDau)
        {
            var doiBong = cbDoiBong.SelectedItem as DTO_DoiBong;
            IEnumerable<DTO_DoiBong>? ketQuaTimKiemDoiBong = filteredDanhSachDoiBong;

            anyDoiBongFiltersApplied = doiBong.Equals(defaultDoiBong) == false;

            if (anyDoiBongFiltersApplied)
            {
                ketQuaTimKiemDoiBong = _BUS_DoiBong.TraCuuDoiBongTheoMaDoiBong(ketQuaTimKiemDoiBong, doiBong.MaDoiBong);
            }
            else
            {
                if (cSoLuongCauThu.Checked)
                {
                    ketQuaTimKiemDoiBong = _BUS_DoiBong.TraCuuDoiBongTheoSoLuongCauThu(ketQuaTimKiemDoiBong, (int)nudSoLuongCauThuFrom.Value, (int)nudSoLuongCauThuTo.Value);
                    anyDoiBongFiltersApplied = true;
                }
            }

            //Allow searching path ... TranDau -> DoiBong -> CauThu ...
            if (anyTranDauFiltersApplied)
            {
                ketQuaTimKiemDoiBong = _BUS_DoiBong.TraCuuDoiBongTheoTranDau(ketQuaTimKiemDoiBong, ketQuaTimKiemTranDau);
                anyDoiBongFiltersApplied = true;
            }

            return ketQuaTimKiemDoiBong;
        }

        private IEnumerable<DTO_TranDau>? TimKiemTranDau(IEnumerable<DTO_VongDau>? ketQuaTimKiemVongDau)
        {
            var tranDau = cbTranDau.SelectedItem as DTO_TranDau;
            IEnumerable<DTO_TranDau>? ketQuaTimKiemTranDau = filteredDanhSachTranDau;

            anyTranDauFiltersApplied = tranDau.Equals(defaultTranDau) == false;

            if (anyTranDauFiltersApplied)
            {
                ketQuaTimKiemTranDau = _BUS_TranDau.TraCuuTranDauTheoMaTranDau(ketQuaTimKiemTranDau, tranDau.MaTranDau);
            }
            else
            {
                if (cTiSo.Checked)
                {
                    ketQuaTimKiemTranDau = _BUS_TranDau.TraCuuTranDauTheoTiSo(ketQuaTimKiemTranDau, (int)nudTiSoDoi1.Value, (int)nudTiSoDoi2.Value);
                    anyTranDauFiltersApplied = true;
                }

                if (cNgayTranDau.Checked)
                {
                    ketQuaTimKiemTranDau = _BUS_TranDau.TraCuuTranDauTheoNgay(ketQuaTimKiemTranDau, dtpNgayTranDauFrom.Value, dtpNgayTranDauTo.Value);
                    anyTranDauFiltersApplied = true;
                }

                if (cGioTranDau.Checked)
                {
                    ketQuaTimKiemTranDau = _BUS_TranDau.TraCuuTranDauTheoGio(ketQuaTimKiemTranDau, dtpGioTranDauFrom.Value, dtpGioTranDauTo.Value);
                    anyTranDauFiltersApplied = true;
                }
            }

            if (anyVongDauFiltersApplied)
                ketQuaTimKiemTranDau = _BUS_TranDau.TraCuuTranDauTheoVongDau(ketQuaTimKiemTranDau, ketQuaTimKiemVongDau);

            return ketQuaTimKiemTranDau;
        }

        private IEnumerable<DTO_VongDau>? TimKiemVongDau()
        {
            var vongDau = cbVongDau.SelectedItem as DTO_VongDau;
            IEnumerable<DTO_VongDau>? ketQuaTimKiemVongDau = danhSachVongDau.Values.AsEnumerable();

            anyVongDauFiltersApplied = vongDau.Equals(defaultVongDau) == false;

            if (anyVongDauFiltersApplied)
            {
                ketQuaTimKiemVongDau = _BUS_VongDau.TraCuuVongDauTheoMaVongDau(ketQuaTimKiemVongDau, vongDau.MaVongDau);
            }
            else
            {
                if (cNgayBatDau.Checked)
                {
                    ketQuaTimKiemVongDau = _BUS_VongDau.TraCuuVongDauTheoNgayBatDau(ketQuaTimKiemVongDau, dtpNgayBatDauFrom.Value, dtpNgayBatDauTo.Value);
                    anyVongDauFiltersApplied = true;
                }

                if (cNgayKetThuc.Checked)
                {
                    ketQuaTimKiemVongDau = _BUS_VongDau.TraCuuVongDauTheoNgayKetThuc(ketQuaTimKiemVongDau, dtpNgayKetThucFrom.Value, dtpNgayKetThucTo.Value);
                    anyVongDauFiltersApplied = true;
                }
            }

            return ketQuaTimKiemVongDau;
        }

        private IEnumerable<DTO_LoaiCauThu>? TimKiemLoaiCauThu()
        {
            var loaiCauThu = cbLoaiCauThu.SelectedItem as DTO_LoaiCauThu;
            IEnumerable<DTO_LoaiCauThu>? ketQuaTimKiemLoaiCauThu = danhSachLoaiCauThu.Values.AsEnumerable();

            anyLoaiCauThuFiltersApplied = loaiCauThu.Equals(defaultLoaiCauThu) == false;

            if (anyLoaiCauThuFiltersApplied)
            {
                ketQuaTimKiemLoaiCauThu = _BUS_LoaiCauThu.TraCuuLoaiCauThuTheoMaLoaiCauThu(ketQuaTimKiemLoaiCauThu, loaiCauThu.MaLoaiCauThu);
            }
            else
            {
                if (cSoLuongCauThuTheoLoai.Checked)
                {
                    ketQuaTimKiemLoaiCauThu = _BUS_LoaiCauThu.TraCuuLoaiCauThuTheoSoLuongCauThuToiDa(ketQuaTimKiemLoaiCauThu, (int)nudSoLuongCauThuTheoLoaiFrom.Value, (int)nudSoLuongCauThuTheoLoaiTo.Value);
                    anyLoaiCauThuFiltersApplied = true;
                }
            }

            return ketQuaTimKiemLoaiCauThu;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void gvcDanhSachCauThu_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            var gv = sender as GridView;

            if (!gv.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
            {
                if (e.Info.IsRowIndicator) //Nếu là dòng Indicator
                {
                    if (e.RowHandle < 0)
                    {
                        e.Info.ImageIndex = 0;
                        e.Info.DisplayText = string.Empty;
                    }
                    else
                    {
                        e.Info.ImageIndex = -1; //Không hiển thị hình
                        e.Info.DisplayText = (e.RowHandle + 1).ToString(); //Số thứ tự tăng dần
                    }
                    SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lấy kích thước của vùng hiển thị Text
                    Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                    BeginInvoke(new MethodInvoker(delegate { cal(_Width, gv); })); //Tăng kích thước nếu Text vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1)); //Nhân -1 để đánh lại số thứ tự tăng dần
                SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, gv); }));
            }
        }

        bool cal(Int32 _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }
    }
}
