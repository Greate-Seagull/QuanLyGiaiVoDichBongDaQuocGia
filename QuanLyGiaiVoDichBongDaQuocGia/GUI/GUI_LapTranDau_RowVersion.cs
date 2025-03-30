using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyGiaiVoDichBongDaQuocGia.Manager;
using QuanLyGiaiVoDichBongDaQuocGia.DTO;

namespace QuanLyGiaiVoDichBongDaQuocGia.GUI
{
    public partial class GUI_LapTranDau_RowVersion : UserControl
    {
        //Input
        GUI_LapLichThiDau lichThiDau;

        //Output
        ManagedItem<DTO_TranDau> output;

        public ManagedItem<DTO_TranDau> Output { get => output; }
        public DTO_TranDau TranDau { get => output.Data; }
        public DataState State { get => output.State; }

        //Xu ly UI
        private DTO_DoiBong cbTenDoi1_oldSelectedItem;
        private DTO_DoiBong cbTenDoi2_oldSelectedItem;

        public GUI_LapTranDau_RowVersion(GUI_LapLichThiDau lichThiDau)
        {
            //UI
            InitializeComponent();

            cbTenDoi1.BindingContext = new BindingContext();
            cbTenDoi2.BindingContext = new BindingContext();

            cbTenDoi1_oldSelectedItem = lichThiDau.cbTenDoi_DefaultItem;
            cbTenDoi2_oldSelectedItem = lichThiDau.cbTenDoi_DefaultItem;

            //Data
            this.lichThiDau = lichThiDau;

            TaoTranDau();
        }

        private void TaoTranDau()
        {
            DTO_TranDau tranDau = new DTO_TranDau(txtMaTranDau.Text,
                                                  (DTO_DoiBong)cbTenDoi1.SelectedItem,
                                                  (DTO_DoiBong)cbTenDoi2.SelectedItem,
                                                  lichThiDau.VongDau,
                                                  dtpNgay.Value.Date + dtpGio.Value.TimeOfDay);

            output = new ManagedItem<DTO_TranDau>(tranDau);
        }

        private void GUI_LapTranDau_RowVersion_Load(object sender, EventArgs e)
        {
            CapNhatDanhSachDoiBong();

            UI_Load();
        }

        private void UI_Load()
        {
            this.Dock = DockStyle.Top;
        }

        public void CapNhatDanhSachDoiBong()
        {
            //Tat SelectedIndexChanged
            cbTenDoi1.SelectedIndexChanged -= cbTenDoi1_SelectedIndexChanged;
            cbTenDoi2.SelectedIndexChanged -= cbTenDoi2_SelectedIndexChanged;

            //Cap nhat danh sach
            cbTenDoi1.DataSource = lichThiDau.DanhSachDoiBong.GetOwnableData(cbTenDoi1);
            cbTenDoi2.DataSource = lichThiDau.DanhSachDoiBong.GetOwnableData(cbTenDoi2);

            //Chon lai SelectedItem
            cbTenDoi1.SelectedItem = cbTenDoi1_oldSelectedItem;
            cbTenDoi2.SelectedItem = cbTenDoi2_oldSelectedItem;

            //Bat SelectedIndexChanged
            cbTenDoi1.SelectedIndexChanged += cbTenDoi1_SelectedIndexChanged;
            cbTenDoi2.SelectedIndexChanged += cbTenDoi2_SelectedIndexChanged;
        }

        public void CapNhatThongTinTranDau()
        {
            TranDau.MaTranDau = txtMaTranDau.Text;
            TranDau.DoiBong1 = cbTenDoi1.SelectedItem as DTO_DoiBong;
            TranDau.DoiBong2 = cbTenDoi2.SelectedItem as DTO_DoiBong;
            TranDau.NgayGio = dtpNgay.Value.Date + dtpGio.Value.TimeOfDay;
            TranDau.VongDau = lichThiDau.VongDau;
        }

        public void CapNhatSTT(int stt)
        {
            lblSTT.Text = stt.ToString();
        }

        public void CapNhatMaTranDau(string v)
        {
            txtMaTranDau.Text = v;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            lichThiDau.XoaTranDau(this);

            //Remove Owner from Owner manager
            lichThiDau.DanhSachDoiBong.RemoveOwner(cbTenDoi1_oldSelectedItem, cbTenDoi1);
            lichThiDau.DanhSachDoiBong.RemoveOwner(cbTenDoi2_oldSelectedItem, cbTenDoi2);

            if(cbTenDoi1_oldSelectedItem != lichThiDau.cbTenDoi_DefaultItem ||
               cbTenDoi2_oldSelectedItem != lichThiDau.cbTenDoi_DefaultItem)
            {
                lichThiDau.CapNhatCacDoiThamGiaThiDau();
            }

            this.Dispose();
        }

        public int LaySTT()
        {
            return int.Parse(lblSTT.Text);
        }

        public string LayMaTranDau()
        {
            return txtMaTranDau.Text;
        }

        private void cbTenDoi1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            DTO_DoiBong doi1 = cb.SelectedItem as DTO_DoiBong;

            if (cbTenDoi1_oldSelectedItem != doi1)
            {
                //Cap nhat trang thai du lieu
                if (Output.State == DataState.Unchanged)
                {
                    Output.State = DataState.Modified;
                }

                //Condition: San nha phai la san cua Doi 1
                txtTenSan.Text = doi1.TenSanNha;

                //Condition: Moi doi bong chi xuat hien dung 1 lan
                //recover va selected dam bao moi combobox chi su dung 1 doi bong
                lichThiDau.DanhSachDoiBong.RemoveOwner(cbTenDoi1_oldSelectedItem, cb); //recover
                lichThiDau.DanhSachDoiBong.AddOwner(doi1, cb); //mark selected

                cbTenDoi1_oldSelectedItem = doi1;

                lichThiDau.CapNhatCacDoiThamGiaThiDau(); //Cap nhat cho cac tran
            }
        }

        private void cbTenDoi2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            DTO_DoiBong doi2 = cb.SelectedItem as DTO_DoiBong;

            if (cbTenDoi2_oldSelectedItem != doi2)
            {
                if (Output.State == DataState.Unchanged)
                {
                    Output.State = DataState.Modified;
                }

                //Condition: Moi doi bong chi xuat hien dung 1 lan
                lichThiDau.DanhSachDoiBong.RemoveOwner(cbTenDoi2_oldSelectedItem, cb);
                lichThiDau.DanhSachDoiBong.AddOwner(doi2, cb);

                cbTenDoi2_oldSelectedItem = doi2;

                lichThiDau.CapNhatCacDoiThamGiaThiDau();
            }

        }

        private void dtpNgay_ValueChanged(object sender, EventArgs e)
        {
            if(Output.State == DataState.Unchanged)
            {
                Output.State = DataState.Modified;
            }
        }

        private void dtpGio_ValueChanged(object sender, EventArgs e)
        {
            if (Output.State == DataState.Unchanged)
            {
                Output.State = DataState.Modified;
            }
        }
    }
}
