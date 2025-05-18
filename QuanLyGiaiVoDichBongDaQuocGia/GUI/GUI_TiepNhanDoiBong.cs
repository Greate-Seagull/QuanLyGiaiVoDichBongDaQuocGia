using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraExport.Helpers;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using QuanLyGiaiVoDichBongDaQuocGia.BUS;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.Manager;
using System.ComponentModel;
using System.Data;

namespace QuanLyGiaiVoDichBongDaQuocGia.GUI
{
    public partial class GUI_TiepNhanDoiBong : Form
    {
        private readonly BUS_ThamSo _BUS_ThamSo;
        private readonly BUS_DoiBong _BUS_DoiBong;
        private readonly BUS_CauThu _BUS_CauThu;
        private readonly BUS_LoaiCauThu _BUS_LoaiCauThu;

        //Xu ly
        DTO_DoiBong doiBongTiepNhan;

        //Restricter
        DTO_ThamSo thamSo;
        DateTime minDate;
        DateTime maxDate;

        List<DTO_LoaiCauThu> danhSachLoaiCauThu;

        //Quan ly
        IDManager maDoiBong;
        IDManager maCauThuQuanLy;
        
        //Hien thi
        BindingList<DTO_CauThu> danhSachCauThuHienThi;

        public GUI_TiepNhanDoiBong(BUS_ThamSo bUS_ThamSo, BUS_DoiBong bUS_DoiBong, BUS_CauThu bUS_CauThu, BUS_LoaiCauThu bUS_LoaiCauThu)
        {
            InitializeComponent();

            //Dependencies
            _BUS_ThamSo = bUS_ThamSo;
            _BUS_DoiBong = bUS_DoiBong;
            _BUS_CauThu = bUS_CauThu;
            _BUS_LoaiCauThu = bUS_LoaiCauThu;
        }

        private void GUI_TiepNhanDoiBong_Load(object sender, EventArgs e)
        {
            //Get all needed data
            LayThamSo();
            LayDanhSachLoaiCauThu();

            //Create processing data
            TaoDoiBong();
            TaoDanhSachCauThu();

            //Configure UI
            UILoad();
        }

        private void UILoad()
        {
            //Configure GridControl    
            gcDanhSachCauThu.DataSource = danhSachCauThuHienThi;

            //Configure column TenLoaiCauThu on GridView
            var lkTenLoaiCauThu = gccLoaiCauThu.ColumnEdit as RepositoryItemLookUpEdit;
            lkTenLoaiCauThu.DataSource = danhSachLoaiCauThu;
            lkTenLoaiCauThu.DisplayMember = "TenLoaiCauThu";
            lkTenLoaiCauThu.ValueMember = "MaLoaiCauThu";
            lkTenLoaiCauThu.NullText = "Chọn loại cầu thủ";

            //Configure column NgaySinh on GridView
            var deNgaySinh = gccNgaySinh.ColumnEdit as RepositoryItemDateEdit;
            //Use MinValue, MaxValue to restrict both calendar and typing
            deNgaySinh.MinValue = minDate;
            deNgaySinh.MaxValue = maxDate;
        }

        private void LayThamSo()
        {
            thamSo = _BUS_ThamSo.LayThamSoTiepNhanDoiBong();
            minDate = new DateTime(DateTime.Now.Year - thamSo.TuoiCauThuToiDa, DateTime.Now.Month, DateTime.Now.Day);
            maxDate = new DateTime(DateTime.Now.Year - thamSo.TuoiCauThuToiThieu, DateTime.Now.Month, DateTime.Now.Day);
        }

        private void TaoDanhSachCauThu()
        {
            maCauThuQuanLy = new(_BUS_CauThu.LayMaMoiNhat());

            doiBongTiepNhan.CacCauThu = new();
            danhSachCauThuHienThi = new();
            for (int i = 0; i < thamSo.SoLuongCauThuToiThieu; i++)
            {
                var entity = TaoCauThu();
                doiBongTiepNhan.CacCauThu.Add(entity);
                danhSachCauThuHienThi.Add(entity);
            }
        }

        private DTO_CauThu TaoCauThu()
        {
            var cauThuMoi = new DTO_CauThu
            {
                MaCauThu = maCauThuQuanLy.GetNewID().ToString(),
                MaDoiBong = doiBongTiepNhan.MaDoiBong,
                MaLoaiCauThu = danhSachLoaiCauThu[0].MaLoaiCauThu,
                NgaySinh = maxDate
            };

            return cauThuMoi;
        }

        private void TaoDoiBong()
        {
            maDoiBong = new(_BUS_DoiBong.LayMaMoiNhat());
            txtMaDoiBong.Text = maDoiBong.GetNewID().ToString();
            doiBongTiepNhan = new DTO_DoiBong { MaDoiBong = maDoiBong.GetCurrentID().ToString() };
        }

        private void LayDanhSachLoaiCauThu()
        {
            danhSachLoaiCauThu = _BUS_LoaiCauThu.LayDanhSachLoaiCauThuTiepNhanDoiBong()
                                                .ToList();
        }
        private void CapNhatThongTinDoiBong()
        {
            doiBongTiepNhan.TenDoiBong = txtTenDoiBong.Text;
            doiBongTiepNhan.TenSanNha = txtTenSanNha.Text;
        }

        private void CapNhatMaCauThu(int index)
        {
            for (int i = index; i < doiBongTiepNhan.CacCauThu.Count; i++)
            {
                if (maCauThuQuanLy.GetID(i) != null)
                    doiBongTiepNhan.CacCauThu[i].MaCauThu = maCauThuQuanLy.GetID(i).ToString();
            }
        }

        //Main function: Insert or update or delete DoiBong and CauThus to database
        private void btnTiepNhanDoiBong_Click(object sender, EventArgs e)
        {
            CapNhatThongTinDoiBong();

            try
            {
                if (_BUS_DoiBong.TiepNhanDoiBong(doiBongTiepNhan))
                {
                    maCauThuQuanLy.Confirm();

                    MessageBox.Show("Tiếp nhận đội bóng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }        

        //Function: Add new CauThu
        private void btnThemCauThu_Click(object sender, EventArgs e)
        {
            if (danhSachCauThuHienThi.Count < thamSo.SoLuongCauThuToiDa)
            {
                var cauThuMoi = TaoCauThu();

                //Add to list processed by BUS
                doiBongTiepNhan.CacCauThu.Add(cauThuMoi);

                //Add to list displayed on GridView
                danhSachCauThuHienThi.Add(cauThuMoi);
            }
        }

        //Function: Close form
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        //Function: multiple rows deleting using key delete
        private void gvcDanhSachCauThu_RowDeleting(object sender, DevExpress.Data.RowDeletingEventArgs e)
        {
            if (doiBongTiepNhan.CacCauThu.Count <= thamSo.SoLuongCauThuToiThieu)
            {
                e.Cancel = true;
            }
        }

        private void gvcDanhSachCauThu_RowDeleted(object sender, DevExpress.Data.RowDeletedEventArgs e)
        {
            var cauThu = e.Row as DTO_CauThu;

            cauThu.Deleted = true;

            int index = doiBongTiepNhan.CacCauThu.IndexOf(cauThu);

            if (maCauThuQuanLy.CancelID(index)) //Are next Ids changable?
            {
                doiBongTiepNhan.CacCauThu.RemoveAt(index);
                CapNhatMaCauThu(index);
            }
        }

        private void gcDanhSachCauThu_KeyDown(object sender, KeyEventArgs e)
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
       
        //Showing serial number
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
