using DevExpress.Utils.Extensions;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraTreeList;
using QuanLyGiaiVoDichBongDaQuocGia.BUS;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.Manager;
using System.ComponentModel;
using System.Data;
using System.Linq.Expressions;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraRichEdit.Import.Html;

namespace QuanLyGiaiVoDichBongDaQuocGia.GUI
{
    public partial class GUI_GhiNhanKetQua : Form
    {
        private readonly BUS_TranDau _BUS_TranDau;
        private readonly BUS_CauThu _BUS_CauThu;
        private readonly BUS_LoaiBanThang _BUS_LoaiBanThang;
        private readonly BUS_BanThang _BUS_BanThang;
        private readonly BUS_ThamSo _BUS_ThamSo;

        //Xu ly
        DTO_TranDau tranDauGhiNhan;
        BindingList<DTO_BanThang> danhSachBanThangHienThi;

        //Restricter
        DTO_ThamSo thamSo;

        //Quan ly
        IDManager maBanThangQuanLy;

        List<DTO_CauThu> danhSachCauThuThuocHaiDoi;
        List<DTO_LoaiBanThang> danhSachLoaiBanThang;

        public GUI_GhiNhanKetQua(BUS_BanThang bUS_BanThang, BUS_TranDau bUS_TranDau, BUS_CauThu bUS_CauThu, BUS_LoaiBanThang bUS_LoaiBanThang, BUS_ThamSo bUS_ThamSo)
        {
            InitializeComponent();

            //Dependencies
            _BUS_TranDau = bUS_TranDau;
            _BUS_ThamSo = bUS_ThamSo;
            _BUS_CauThu = bUS_CauThu;
            _BUS_LoaiBanThang = bUS_LoaiBanThang;
            _BUS_BanThang = bUS_BanThang;
        }

        private void GUI_GhiNhanKetQua_Load(object sender, EventArgs e)
        {
            LayThamSo();
            LayDanhSachLoaiBanThang();

            TaoDanhSachBanThang();

            UILoad();
        }

        private void LayThamSo()
        {
            thamSo = _BUS_ThamSo.LayThamSoGhiNhanKetQua();
        }

        private void UILoad()
        {
            cbTranDau.DataSource = _BUS_TranDau.LayDanhSachTranDauGhiNhanKetQua();
            cbTranDau.DisplayMember = "CapDau";

            //Configure DataView
            gcDanhSachBanThang.DataSource = danhSachBanThangHienThi;

            //Configure MaCauThu column
            lkMaCauThu.DisplayMember = "TenCauThu";
            lkMaCauThu.ValueMember = "MaCauThu";
            lkMaCauThu.NullText = "Chọn cầu thủ";

            //Configure MaLoaiBanThang column
            lkMaLoaiBanThang.DataSource = danhSachLoaiBanThang;
            lkMaLoaiBanThang.DisplayMember = "TenLoaiBanThang";
            lkMaLoaiBanThang.ValueMember = "MaLoaiBanThang";
            lkMaLoaiBanThang.NullText = "Chọn loại bàn thắng";

            //Configure ThoiDiemGhiBan column
            spThoiDiemGhiBan.MaxValue = (Decimal)thamSo.ThoiDiemGhiBanToiDa;
            spThoiDiemGhiBan.MinValue = (Decimal)thamSo.ThoiDiemGhiBanToiThieu;
            spThoiDiemGhiBan.Increment = 1;
        }

        private void LayDanhSachLoaiBanThang()
        {
            danhSachLoaiBanThang = _BUS_LoaiBanThang.LayDanhSachLoaiBanThangGhiNhanKetQua();
        }

        private void TaoDanhSachBanThang()
        {
            maBanThangQuanLy = new(_BUS_BanThang.LayMaMoiNhat());
        }

        private void cbTranDau_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            tranDauGhiNhan = cb.SelectedItem as DTO_TranDau;

            txtTiSo.Text = tranDauGhiNhan.TiSo;
            txtTenSan.Text = tranDauGhiNhan.DoiBong1?.TenSanNha;
            txtNgayGio.Text = tranDauGhiNhan.NgayGio?.ToString("G") ?? string.Empty;

            if (danhSachBanThangHienThi is null)
                danhSachBanThangHienThi = new();
            else
                danhSachBanThangHienThi.Clear();
            foreach (var entity in tranDauGhiNhan.CacBanThang) danhSachBanThangHienThi.Add(entity);

            danhSachCauThuThuocHaiDoi = _BUS_CauThu.LayDanhSachCauThuThuocHaiDoi(tranDauGhiNhan.MaDoi1, tranDauGhiNhan.MaDoi2);
            lkMaCauThu.DataSource = danhSachCauThuThuocHaiDoi;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnGhiNhanKetQua_Click(object sender, EventArgs e)
        {
            try
            {
                if (_BUS_TranDau.GhiNhanKetQua(tranDauGhiNhan))
                {
                    maBanThangQuanLy.Confirm();
                    MessageBox.Show("Ghi nhận kết quả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnThemBanThang_Click(object sender, EventArgs e)
        {
            var banThangMoi = TaoBanThang();

            if (tranDauGhiNhan.CacBanThang is null)
                tranDauGhiNhan.CacBanThang = new();

            tranDauGhiNhan.CacBanThang.Add(banThangMoi);

            danhSachBanThangHienThi.Add(banThangMoi);
        }

        private DTO_BanThang TaoBanThang()
        {
            return new DTO_BanThang
            {
                MaBanThang = maBanThangQuanLy.GetNewID().ToString(),
                MaTranDau = tranDauGhiNhan.MaTranDau,
                ThoiDiemGhiBan = thamSo.ThoiDiemGhiBanToiDa
            };
        }

        private void gvcDanhSachBanThang_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e) //Not working as expected
        {
            var entity = e.Row as DTO_BanThang;

            entity.Deleted = true;

            int index = tranDauGhiNhan.CacBanThang.IndexOf(entity);

            if (maBanThangQuanLy.CancelID(index)) //Are next Ids changable?
            {
                tranDauGhiNhan.CacBanThang.RemoveAt(index);
                CapNhatMaBanThang(index);
            }
        }

        private void CapNhatMaBanThang(int index)
        {
            for (int i = index; i < tranDauGhiNhan.CacBanThang.Count; i++)
            {
                if (maBanThangQuanLy.GetID(i) != null)
                    tranDauGhiNhan.CacBanThang[i].MaTranDau = maBanThangQuanLy.GetID(i).ToString();
            }
        }

        private void gvcDanhSachBanThang_KeyDown(object sender, KeyEventArgs e)
        {
            var gv = sender as GridView;

            if (e.KeyCode == Keys.Delete)
            {
                var selectedRows = gv.GetSelectedRows();
                for (int i = selectedRows.Length - 1; i > -1; i--)
                {
                    gv.DeleteRow(selectedRows[i]);
                }
            }

            e.Handled = true;
        }

        private void gvcDanhSachBanThang_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
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

        private void gvcDanhSachBanThang_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "MaDoiBong")
            {
                var row = e.Row as DTO_BanThang;
                var cauThu = danhSachCauThuThuocHaiDoi.FirstOrDefault(obj => obj.MaCauThu == row.MaCauThu);
                e.Value = cauThu?.DoiBong?.TenDoiBong ?? string.Empty;
            }
        }

        private void gvcDanhSachBanThang_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var view = sender as GridView;

            if (e.Column.FieldName == "MaCauThu")
            {
                _BUS_TranDau.CapNhatTiSo(tranDauGhiNhan, danhSachCauThuThuocHaiDoi);
                txtTiSo.Text = tranDauGhiNhan.TiSo;
            }
        }
    }
}
