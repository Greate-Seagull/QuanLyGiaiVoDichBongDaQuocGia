using DevExpress.XtraGrid.Views.Grid;
using QuanLyGiaiVoDichBongDaQuocGia.BUS;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyGiaiVoDichBongDaQuocGia.GUI
{
    public partial class GUI_LapDanhSachCauThuGhiBan : Form
    {
        //Dependencies
        private readonly BUS_CauThu _BUS_CauThu;
        private readonly BUS_TranDau _BUS_TranDau;

        Dictionary<string, DTO_CauThu> danhSachCauThu;
        Dictionary<string, DTO_TranDau> danhSachTranDau;

        List<VM_CauThu> danhSachCauThuHienThi;

        public GUI_LapDanhSachCauThuGhiBan(BUS_CauThu bUS_CauThu, BUS_TranDau bUS_TranDau)
        {
            InitializeComponent();

            //Dependencies
            _BUS_CauThu = bUS_CauThu;
            _BUS_TranDau = bUS_TranDau;
        }

        private void GUI_LapDanhSachCauThuGhiBan_Load(object sender, EventArgs e)
        {
            LayDanhSachCauThu();
            LayDanhSachTranDau();

            TaoDanhSachCauThuHienThi();
        }

        private void TaoDanhSachCauThuHienThi()
        {
            danhSachCauThuHienThi = _BUS_CauThu.TaoDanhSachCauThuHienThi(danhSachCauThu.Values);
        }

        private void LayDanhSachTranDau()
        {
            danhSachTranDau = _BUS_TranDau.LayDanhSachTranDauXepHangCauThu().ToDictionary(entity => entity.MaTranDau);
        }

        private void LayDanhSachCauThu()
        {
            danhSachCauThu = _BUS_CauThu.LayDanhSachCauThuXepHang().ToDictionary(entity => entity.MaCauThu);
        }

        private void dtpNgayLap_ValueChanged(object sender, EventArgs e)
        {
            var dtp = sender as DateTimePicker;
            var ngayLap = dtp.Value;

            var ketQuaTimKiemTranDau = _BUS_TranDau.TraCuuTranDauTheoNgay(danhSachTranDau.Values, null, ngayLap);
            gcDanhSachCauThu.DataSource = _BUS_CauThu.LapBangXepHangCauThuTheoTranDau(danhSachCauThuHienThi, ketQuaTimKiemTranDau); ;
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
