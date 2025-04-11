using QuanLyGiaiVoDichBongDaQuocGia.BUS;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;
using QuanLyGiaiVoDichBongDaQuocGia.Manager;
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
    public partial class GUI_GhiNhanKetQua : Form
    {
        BUS_BanThang BUS_banThang = new BUS_BanThang();
        BUS_TranDau BUS_tranDau = new BUS_TranDau();

        //Xu ly
        DTO_TranDau tranDau;
        DataManager<DTO_BanThang> danhSachBanThang;

        //Quan ly
        IDManager stt;
        IDManager maBanThang;

        public GUI_GhiNhanKetQua()
        {
            InitializeComponent();
        }

        private void GUI_GhiNhanKetQua_Load(object sender, EventArgs e)
        {
            TaoSTT();
            TaoMaBanThang();
            LayDanhSachTranDau();
        }

        private void LayDanhSachTranDau()
        {
            cbTranDau.DataSource = BUS_tranDau.LayDanhSachTranDau(TranDauColumn.MaDoi1, TranDauColumn.MaDoi2).GetReadData();
        }

        private void TaoMaBanThang()
        {
            maBanThang = new IDManager(BUS_banThang.LayMaBanThangHienTai());
        }

        private void TaoSTT()
        {
            stt = new IDManager("0");
        }
    }
}
