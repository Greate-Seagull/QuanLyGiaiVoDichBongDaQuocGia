using DevExpress.Internal.WinApi.Windows.UI.Notifications;
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

            var doiBongBindingSource = new BindingList<DTO_DoiBong>(danhSachDoiBong.Values.ToList());
            doiBongBindingSource.Insert(0, defaultDoiBong);
            cbDoiBong.DataSource = doiBongBindingSource;
            cbDoiBong.DisplayMember = "TenDoiBong";

            cbSanNha.DataSource = cbDoiBong.DataSource;
            cbSanNha.DisplayMember = "TenSanNha";

            var vongDauBindingSource = new BindingList<DTO_VongDau>(danhSachVongDau.Values.ToList());
            vongDauBindingSource.Insert(0, defaultVongDau);
            cbVongDau.DataSource = vongDauBindingSource;
            cbVongDau.DisplayMember = "TenVongDau";

            var tranDauBindingSource = new BindingList<DTO_TranDau>(danhSachTranDau.Values.ToList());
            tranDauBindingSource.Insert(0, defaultTranDau);
            cbTranDau.DataSource = tranDauBindingSource;
            cbTranDau.DisplayMember = "CapDau";

            var banThangBindingSource = new BindingList<DTO_BanThang>(danhSachBanThang.Values.ToList());
            banThangBindingSource.Insert(0, defaultBanThang);
            cbBanThang.DataSource = banThangBindingSource;
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
            _BUS_BanThang.DienThongTin(danhSachBanThang, danhSachTranDau, danhSachCauThu, danhSachLoaiBanThang);
        }

        private void LayDanhSachTranDau()
        {
            danhSachTranDau = _BUS_TranDau.LayDanhSachTranDauTraCuu().ToDictionary(obj => obj.MaTranDau);
            _BUS_TranDau.DienThongTin(danhSachTranDau, danhSachDoiBong, danhSachVongDau);
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
            var cb = sender as ComboBox;
            var loaiCauThu = cb?.SelectedItem as DTO_LoaiCauThu;

            if (loaiCauThu == defaultLoaiCauThu)
                return;

            nudSoLuongCauThuTheoLoaiFrom.Value = Convert.ToDecimal(loaiCauThu?.SoLuongCauThuToiDaTheoLoaiCauThu);
            nudSoLuongCauThuTheoLoaiTo.Value = nudSoLuongCauThuTheoLoaiFrom.Value;
        }

        private void cbDoiBong_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cb = sender as ComboBox;
            var doiBong = cb?.SelectedItem as DTO_DoiBong;

            if (doiBong == defaultDoiBong)
                return;

            nudSoLuongCauThuFrom.Value = Convert.ToDecimal(doiBong?.CacCauThu?.Count);
            nudSoLuongCauThuTo.Value = nudSoLuongCauThuFrom.Value;
        }

        private void cbVongDau_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cb = sender as ComboBox;
            var vongDau = cb?.SelectedItem as DTO_VongDau;

            if (vongDau == defaultVongDau)
                return;

            dtpNgayBatDauFrom.Value = vongDau?.NgayBatDau ?? dtpGioTranDauFrom.MinDate;
            dtpNgayBatDauTo.Value = vongDau?.NgayBatDau ?? dtpNgayBatDauTo.MaxDate;

            dtpNgayKetThucFrom.Value = vongDau?.NgayKetThuc ?? dtpNgayKetThucFrom.MinDate;
            dtpNgayKetThucTo.Value = vongDau?.NgayKetThuc ?? dtpNgayKetThucTo.MaxDate;
        }

        private void cbTranDau_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cb = sender as ComboBox;
            var tranDau = cb?.SelectedItem as DTO_TranDau;

            if (tranDau == defaultTranDau)
                return;

            nudTiSoDoi1.Value = Convert.ToDecimal(tranDau?.TiSoDoi1);
            nudTiSoDoi2.Value = Convert.ToDecimal(tranDau?.TiSoDoi2);

            dtpNgayTranDauFrom.Value = tranDau?.NgayGio ?? dtpNgayTranDauFrom.MinDate;
            dtpNgayTranDauTo.Value = tranDau?.NgayGio ?? dtpNgayTranDauTo.MaxDate;

            dtpGioTranDauFrom.Value = tranDau?.NgayGio ?? dtpGioTranDauFrom.MinDate;
            dtpGioTranDauTo.Value = tranDau?.NgayGio ?? dtpGioTranDauTo.MaxDate;
        }

        private void cbBanThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cb = sender as ComboBox;
            var banThang = cb?.SelectedItem as DTO_BanThang;

            if (banThang == defaultBanThang)
                return;

            cbLoaiBanThang.SelectedItem = banThang?.LoaiBanThang;

            nudThoiDiemGhiBanFrom.Value = Convert.ToDecimal(banThang?.ThoiDiemGhiBan);
            nudThoiDiemGhiBanTo.Value = nudThoiDiemGhiBanFrom.Value;
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
        /// <summary>
        /// Do splitting TraCuu method into smaller methods
        /// Do searching based on SoBanThang
        /// Do filtering ComboBox's DataSource based on another ComboBox
        /// </summary>
        /// <param name="ketQuaTimKiemLoaiCauThu"></param>
        /// <param name="ketQuaTimKiemDoiBong"></param>
        /// <param name="ketQuaTimKiemBanThang"></param>
        /// <returns></returns>


        private IEnumerable<DTO_CauThu> TimKiemCauThu(IEnumerable<DTO_LoaiCauThu>? ketQuaTimKiemLoaiCauThu, IEnumerable<DTO_DoiBong>? ketQuaTimKiemDoiBong, IEnumerable<DTO_BanThang>? ketQuaTimKiemBanThang)
        {
            var maCauThu = txtMaCauThu.Text;
            var tenCauThu = txtTenCauThu.Text;
            DateTime? startNgaySinh = dtpNgaySinhFrom.Enabled ? dtpNgaySinhFrom.Value : null;
            DateTime? endNgaySinh = dtpNgaySinhTo.Enabled ? dtpNgaySinhTo.Value : null;
            int? startSoBanThang = nudSoBanThangFrom.Enabled ? (int)nudSoBanThangFrom.Value : null;
            int? endSoBanThang = nudSoBanThangTo.Enabled ? (int)nudSoBanThangTo.Value : null;

            var ketQuaTimKiem = _BUS_CauThu.TraCuuCauThu(danhSachCauThu.Values, maCauThu, tenCauThu);
            ketQuaTimKiem = _BUS_CauThu.TraCuuCauThu(ketQuaTimKiem, startNgaySinh, endNgaySinh);
            return _BUS_CauThu.TraCuuCauThu(ketQuaTimKiem, ketQuaTimKiemLoaiCauThu, ketQuaTimKiemDoiBong, ketQuaTimKiemBanThang);
        }

        private IEnumerable<DTO_BanThang>? TimKiemBanThang(IEnumerable<DTO_TranDau>? ketQuaTimKiemTranDau)
        {
            var banThang = cbBanThang.SelectedItem as DTO_BanThang;
            IEnumerable<DTO_BanThang>? ketQuaTimKiemBanThang = null;

            if (banThang == defaultBanThang)
            {
                DTO_LoaiBanThang? loaiBanThang = cbLoaiBanThang.SelectedItem as DTO_LoaiBanThang;
                loaiBanThang = loaiBanThang != defaultLoaiBanThang ? loaiBanThang : null;
                int? startThoiDiemGhiBan = nudThoiDiemGhiBanFrom.Enabled ? (int)nudThoiDiemGhiBanFrom.Value : null;
                int? endThoiDiemGhiBan = nudThoiDiemGhiBanTo.Enabled ? (int)nudThoiDiemGhiBanTo.Value : null;

                if(loaiBanThang is null &&
                   startThoiDiemGhiBan is null &&
                   endThoiDiemGhiBan is null)
                {
                    return null;
                }

                ketQuaTimKiemBanThang = _BUS_BanThang.TraCuuBanThang(danhSachBanThang.Values,
                                                                         ketQuaTimKiemTranDau,
                                                                         loaiBanThang,
                                                                         startThoiDiemGhiBan, endThoiDiemGhiBan);
            }
            else
            {
                ketQuaTimKiemBanThang = new List<DTO_BanThang> { banThang };
                ketQuaTimKiemBanThang = _BUS_BanThang.TraCuuBanThang(ketQuaTimKiemBanThang,
                                                                    ketQuaTimKiemTranDau,
                                                                    null,
                                                                    null, null);
            }

            return ketQuaTimKiemBanThang;
        }

        private IEnumerable<DTO_DoiBong>? TimKiemDoiBong(IEnumerable<DTO_TranDau>? ketQuaTimKiemTranDau)
        {
            var doiBong = cbDoiBong.SelectedItem as DTO_DoiBong;
            IEnumerable<DTO_DoiBong>? ketQuaTimKiemDoiBong = null;

            if (doiBong == defaultDoiBong)
            {
                int? startSoLuongCauThu = nudSoLuongCauThuFrom.Enabled ? (int)nudSoLuongCauThuFrom.Value : null;
                int? endSoLuongCauThu = nudSoLuongCauThuTo.Enabled ? (int)nudSoLuongCauThuTo.Value : null;
                ketQuaTimKiemDoiBong = _BUS_DoiBong.TraCuuDoiBong(danhSachDoiBong.Values,
                                                                      ketQuaTimKiemTranDau,
                                                                      startSoLuongCauThu,
                                                                      endSoLuongCauThu);
            }
            else
            {
                ketQuaTimKiemDoiBong = new List<DTO_DoiBong> { doiBong };
                ketQuaTimKiemDoiBong = _BUS_DoiBong.TraCuuDoiBong(ketQuaTimKiemDoiBong,
                                                                ketQuaTimKiemTranDau,
                                                                null, null);
            }

            return ketQuaTimKiemDoiBong;
        }

        private IEnumerable<DTO_TranDau>? TimKiemTranDau(IEnumerable<DTO_VongDau>? ketQuaTimKiemVongDau)
        {
            var tranDau = cbTranDau.SelectedItem as DTO_TranDau;
            IEnumerable<DTO_TranDau>? ketQuaTimKiemTranDau = null;

            if (tranDau == defaultTranDau)
            {
                int? tiSo1 = nudTiSoDoi1.Enabled ? (int)nudTiSoDoi1.Value : null;
                int? tiSo2 = nudTiSoDoi2.Enabled ? (int)nudTiSoDoi2.Value : null;
                DateTime? startNgayTranDau = dtpNgayTranDauFrom.Enabled ? dtpNgayTranDauFrom.Value : null;
                DateTime? endNgayTranDau = dtpNgayTranDauTo.Enabled ? dtpNgayTranDauTo.Value : null;
                DateTime? startGioTranDau = dtpGioTranDauFrom.Enabled ? dtpGioTranDauFrom.Value : null;
                DateTime? endGioTranDau = dtpGioTranDauTo.Enabled ? dtpGioTranDauTo.Value : null;
                ketQuaTimKiemTranDau = _BUS_TranDau.TraCuuTranDau(danhSachTranDau.Values,
                                                                ketQuaTimKiemVongDau,
                                                                tiSo1, tiSo2,
                                                                startNgayTranDau, endNgayTranDau,
                                                                startGioTranDau, endGioTranDau);
            }
            else
            {
                ketQuaTimKiemTranDau = new List<DTO_TranDau> { tranDau };
                ketQuaTimKiemTranDau = _BUS_TranDau.TraCuuTranDau(ketQuaTimKiemTranDau,
                                                                ketQuaTimKiemVongDau,
                                                                null, null,
                                                                null, null,
                                                                null, null);
            }

            return ketQuaTimKiemTranDau;
        }

        private IEnumerable<DTO_VongDau>? TimKiemVongDau()
        {
            var vongDau = cbVongDau.SelectedItem as DTO_VongDau;
            IEnumerable<DTO_VongDau>? ketQuaTimKiemVongDau = null;

            if (vongDau == defaultVongDau)
            {
                DateTime? startNgayBatDau = dtpNgayBatDauFrom.Enabled ? dtpNgayBatDauFrom.Value : null;
                DateTime? endNgayBatDau = dtpNgayBatDauTo.Enabled ? dtpNgayBatDauTo.Value : null;
                DateTime? startNgayKetThuc = dtpNgayKetThucFrom.Enabled ? dtpNgayKetThucFrom.Value : null;
                DateTime? endNgayKetThuc = dtpNgayKetThucTo.Enabled ? dtpNgayKetThucTo.Value : null;
                ketQuaTimKiemVongDau = _BUS_VongDau.TraCuuVongDau(danhSachVongDau.Values,
                                                                startNgayBatDau, endNgayBatDau,
                                                                startNgayKetThuc, endNgayKetThuc);
            }
            else
            {
                ketQuaTimKiemVongDau = new List<DTO_VongDau> { vongDau };
            }

            return ketQuaTimKiemVongDau;
        }

        private IEnumerable<DTO_LoaiCauThu>? TimKiemLoaiCauThu()
        {
            var loaiCauThu = cbLoaiCauThu.SelectedItem as DTO_LoaiCauThu;
            IEnumerable<DTO_LoaiCauThu>? ketQuaTimKiemLoaiCauThu = null;

            if (loaiCauThu == defaultLoaiCauThu)
            {
                int? startSoLuongCauThuTheoLoai = nudSoLuongCauThuTheoLoaiFrom.Enabled ? (int)nudSoLuongCauThuTheoLoaiFrom.Value : null;
                int? endSoLuongCauThuTheoLoai = nudSoLuongCauThuTheoLoaiTo.Enabled ? (int)nudSoLuongCauThuTheoLoaiTo.Value : null;
                ketQuaTimKiemLoaiCauThu = _BUS_LoaiCauThu.TraCuuLoaiCauThu(danhSachLoaiCauThu.Values,
                                                                            startSoLuongCauThuTheoLoai,
                                                                            endSoLuongCauThuTheoLoai);
            }
            else
            {
                ketQuaTimKiemLoaiCauThu = new List<DTO_LoaiCauThu> { loaiCauThu };
            }

            return ketQuaTimKiemLoaiCauThu;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
