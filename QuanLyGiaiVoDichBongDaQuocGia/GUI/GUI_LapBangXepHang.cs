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
    public partial class GUI_LapBangXepHang : Form
    {
        //Dependencies
        private readonly BUS_ThamSo _BUS_ThamSo;
        private readonly BUS_DoiBong _BUS_DoiBong;
        private readonly BUS_TranDau _BUS_TranDau;

        //Restricter
        DTO_ThamSo thamSo;
        Dictionary<string, DTO_DoiBong> danhSachDoiBong;
        List<DTO_TranDau> danhSachTranDau;

        public GUI_LapBangXepHang(BUS_ThamSo bUS_ThamSo, BUS_DoiBong bUS_DoiBong, BUS_TranDau bUS_TranDau)
        {
            InitializeComponent();

            //Dependencies
            _BUS_ThamSo = bUS_ThamSo;
            _BUS_DoiBong = bUS_DoiBong;
            _BUS_TranDau = bUS_TranDau;
        }

        private void GUI_LapBanXepHang_Load(object sender, EventArgs e)
        {
            LayThamSo();
            LayDanhSachDoiBong();
            LayDanhSachTranDau();
        }

        private void LayDanhSachTranDau()
        {
            danhSachTranDau = _BUS_TranDau.LayDanhSachTranDauXepHang();
            _BUS_TranDau.DienThongTinDoiBong(danhSachTranDau.ToDictionary(obj => obj.MaTranDau),
                                             danhSachDoiBong);
        }

        private void LayDanhSachDoiBong()
        {
            danhSachDoiBong = _BUS_DoiBong.LayDanhSachDoiBongXepHang().ToDictionary(obj => obj.MaDoiBong);
        }

        private void LayThamSo()
        {
            thamSo = _BUS_ThamSo.LayThamSoLapBanXepHang();
        }

        private void dtpNgayLap_ValueChanged(object sender, EventArgs e)
        {
            var dtp = sender as DateTimePicker;
            DateTime ngayLap = dtp.Value;

            var ketQuaTimKiemTranDau = _BUS_TranDau.TraCuuTranDauTheoNgay(danhSachTranDau, null, ngayLap);
            var bangXepHang = _BUS_DoiBong.LapBangXepHangTheoTranDau(ketQuaTimKiemTranDau, thamSo);
            _BUS_DoiBong.DienThongTinHienThi(bangXepHang, danhSachDoiBong);

            gcDanhSachDoiBong.DataSource = bangXepHang;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void gvcDanhSachDoiBong_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
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
