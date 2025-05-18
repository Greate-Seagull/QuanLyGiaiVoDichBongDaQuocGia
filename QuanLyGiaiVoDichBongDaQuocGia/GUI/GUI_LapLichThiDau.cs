using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using QuanLyGiaiVoDichBongDaQuocGia.BUS;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.Manager;
using System.ComponentModel;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraRichEdit.Import.Rtf;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using DevExpress.Utils.Extensions;
using Microsoft.VisualBasic;

namespace QuanLyGiaiVoDichBongDaQuocGia.GUI
{
    public partial class GUI_LapLichThiDau : Form
    {
        private readonly BUS_VongDau _BUS_VongDau;
        private readonly BUS_TranDau _BUS_TranDau;
        private readonly BUS_DoiBong _BUS_DoiBong;

        //Xu ly
        DTO_VongDau vongDau;

        //Resrticter
        List<DTO_TranDau> danhSachCapDau;
        List<DTO_DoiBong> danhSachDoiBong;

        //Quan ly
        IDManager maTranDauQuanLy;

        //UI
        public DTO_DoiBong defaultItem = new DTO_DoiBong { TenDoiBong = "Chọn đội bóng" };
        BindingList<DTO_TranDau> danhSachTranDauHienThi;

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
            LayDanhSachDoiBong();
            LayDanhSachCapDau();

            TaoVongDau();
            TaoDanhSachTranDau();

            UILoad();
        }

        private void UILoad()
        {
            //Configure GridControl
            gcDanhSachTranDau.DataSource = danhSachTranDauHienThi;

            //Assign a base DataSource so the grid can display values when not editing
            glkMaDoi1.DataSource = danhSachDoiBong;
            glkMaDoi2.DataSource = danhSachDoiBong;
        }

        private void LayDanhSachCapDau()
        {
            danhSachCapDau = _BUS_TranDau.LayDanhSachCapDau();
        }

        private void LayDanhSachDoiBong()
        {
            danhSachDoiBong = _BUS_DoiBong.LayDanhSachDoiBongLapLich();
        }

        private void TaoDanhSachTranDau()
        {
            maTranDauQuanLy = new(_BUS_TranDau.LayMaMoiNhat());

            vongDau.CacTranDau = new();
            danhSachTranDauHienThi = new();
        }

        private void TaoVongDau()
        {
            vongDau = new();
        }

        private void btnLapLichThiDau_Click(object sender, EventArgs e)
        {
            CapNhatThongTinVongDau();

            try
            {
                if (_BUS_VongDau.LapLichThiDau(vongDau))
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

        private void CapNhatThongTinVongDau()
        {
            vongDau.MaVongDau = txtMaVongDau.Text;
            vongDau.TenVongDau = txtVongThiDau.Text;

            foreach (var entity in vongDau.CacTranDau)
                entity.MaVongDau = vongDau.MaVongDau;
        }

        private void btnThemTranDau_Click(object sender, EventArgs e)
        {
            var tranDauMoi = TaoTranDau();

            vongDau.CacTranDau.Add(tranDauMoi);

            danhSachTranDauHienThi.Add(tranDauMoi);
        }

        private DTO_TranDau TaoTranDau()
        {
            return new DTO_TranDau
            {
                MaTranDau = maTranDauQuanLy.GetNewID().ToString(),
                //MaVongDau = vongDau.MaVongDau
            };
        }

        private void CapNhatMaTranDau(int index)
        {
            for (int i = index; i < vongDau.CacTranDau.Count; i++)
            {
                if (maTranDauQuanLy.GetID(i) != null)
                    vongDau.CacTranDau[i].MaTranDau = maTranDauQuanLy.GetID(i).ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void gvcDanhSachTranDau_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            var entity = e.Row as DTO_TranDau;

            entity.Deleted = true;

            int index = vongDau.CacTranDau.IndexOf(entity);

            if (maTranDauQuanLy.CancelID(index)) //Are next Ids changable?
            {
                vongDau.CacTranDau.RemoveAt(index);
                CapNhatMaTranDau(index);
            }
        }

        private void gcDanhSachTranDau_KeyDown(object sender, KeyEventArgs e)
        {
            var gc = sender as GridControl;
            var gv = gc.MainView as GridView;

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

        private void gvcDanhSachTranDau_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
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

        private void txtMaVongDau_TextChanged(object sender, EventArgs e)
        {
            txtVongThiDau.Text = txtMaVongDau.Text;
        }

        //Filter DataSource of LookUpEdit
        private void gvcDanhSachTranDau_ShownEditor(object sender, EventArgs e)
        {
            var view = sender as GridView;

            if (view.FocusedColumn.FieldName == "MaDoi1")
            {
                var lk = view.ActiveEditor as LookUpEdit;

                //Set null on this column to include the current option choosed in LookUpEdit
                gvcDanhSachTranDau.SetFocusedRowCellValue("MaDoi1", null);

                //Filter on DataSource
                var danhSachMaDoiBongDangLapLich = _BUS_TranDau.LayDanhSachMaDoiBongDaThiDau(vongDau.CacTranDau);
                var danhSachDoiBongHopLe = _BUS_DoiBong.LayDanhSachDoiBongThiDauHopLe(
                    danhSachDoiBong,
                    danhSachMaDoiBongDangLapLich,
                    new()
                );

                //Always include DefaultItem
                danhSachDoiBongHopLe.Add(defaultItem);
                lk.Properties.DataSource = danhSachDoiBongHopLe;
            }
            else if (view.FocusedColumn.FieldName == "MaDoi2")
            {
                var lk = view.ActiveEditor as LookUpEdit;
                var maDoi1Obj = view.GetFocusedRowCellValue("MaDoi1");

                if (maDoi1Obj is null) //When MaDoi1 columns is not chosen yet => Require MaDoi1 choosing first
                {
                    //Always include DefaultItem
                    lk.Properties.DataSource = new List<DTO_DoiBong> { defaultItem };
                    return;
                }

                var maDoi1 = maDoi1Obj.ToString();

                //Set null on this column to include the current option choosed in LookUpEdit
                gvcDanhSachTranDau.SetFocusedRowCellValue("MaDoi2", null);

                //Filter on DataSource
                var danhSachMaDoiBongDangLapLich = _BUS_TranDau.LayDanhSachMaDoiBongDaThiDau(vongDau.CacTranDau);
                var danhSachMaDoiBongDaLapLich = _BUS_TranDau.LayDanhSachMaDoiBongDaThiDauVoi(maDoi1, danhSachCapDau);
                var danhSachDoiBongHopLe = _BUS_DoiBong.LayDanhSachDoiBongThiDauHopLe(
                    danhSachDoiBong,
                    danhSachMaDoiBongDangLapLich,
                    danhSachMaDoiBongDaLapLich
                );

                //Always include DefaultItem
                danhSachDoiBongHopLe.Add(defaultItem);
                lk.Properties.DataSource = danhSachDoiBongHopLe;
            }
        }

        //Set null before opening LookUpEdit on Column MaDoi2 to avoid invalid team 2
        private void glkMaDoi1_EditValueChanged(object sender, EventArgs e)
        {
            gvcDanhSachTranDau.SetFocusedRowCellValue("MaDoi2", null);
        }

        //Set TenSanNha
        private void gvcDanhSachTranDau_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            if (e.Column.FieldName == "TenSanNha")
            {
                var row = e.Row as DTO_TranDau;
                var doiBong = danhSachDoiBong.FirstOrDefault(d => d.MaDoiBong == row.MaDoi1);
                e.Value = doiBong?.TenSanNha ?? string.Empty;
            }
        }

        //Auto update NgayBatDau, NgayKetThuc based on TranDau.NgayGio
        private void gvcDanhSachTranDau_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            var view = sender as GridView;

            if (e.Column.FieldName == "NgayGio")
            {
                var ngayGio = (DateTime)e.Value;
                if (vongDau.NgayBatDau is null || vongDau.NgayBatDau > ngayGio)
                    vongDau.NgayBatDau = ngayGio;

                if (vongDau.NgayKetThuc is null || vongDau.NgayKetThuc < ngayGio)
                    vongDau.NgayKetThuc = ngayGio;

                txtNgayBatDau.Text = vongDau.NgayBatDau?.ToString("G") ?? string.Empty;
                txtNgayKetThuc.Text = vongDau.NgayKetThuc?.ToString("G") ?? string.Empty;
            }
        }
    }
}
