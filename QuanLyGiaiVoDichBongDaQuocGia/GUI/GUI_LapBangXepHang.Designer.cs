
using DevExpress.XtraGrid.Views.Grid;

namespace QuanLyGiaiVoDichBongDaQuocGia.GUI
{
    partial class GUI_LapBangXepHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tlpFrame = new TableLayoutPanel();
            btnThoat = new Button();
            dtpNgayLap = new DateTimePicker();
            lblNgayLap = new Label();
            gcDanhSachDoiBong = new DevExpress.XtraGrid.GridControl();
            gvcDanhSachDoiBong = new DevExpress.XtraGrid.Views.Grid.GridView();
            gccTenDoiBong = new DevExpress.XtraGrid.Columns.GridColumn();
            gccSoTranThang = new DevExpress.XtraGrid.Columns.GridColumn();
            gccSoTranHoa = new DevExpress.XtraGrid.Columns.GridColumn();
            gccSoTranThua = new DevExpress.XtraGrid.Columns.GridColumn();
            gccHieuSo = new DevExpress.XtraGrid.Columns.GridColumn();
            gccHang = new DevExpress.XtraGrid.Columns.GridColumn();
            tlpFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gcDanhSachDoiBong).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvcDanhSachDoiBong).BeginInit();
            SuspendLayout();
            // 
            // tlpFrame
            // 
            tlpFrame.ColumnCount = 8;
            tlpFrame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpFrame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpFrame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpFrame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpFrame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpFrame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpFrame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpFrame.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tlpFrame.Controls.Add(btnThoat, 7, 3);
            tlpFrame.Controls.Add(dtpNgayLap, 3, 1);
            tlpFrame.Controls.Add(lblNgayLap, 3, 0);
            tlpFrame.Controls.Add(gcDanhSachDoiBong, 0, 2);
            tlpFrame.Dock = DockStyle.Fill;
            tlpFrame.Location = new Point(0, 0);
            tlpFrame.Margin = new Padding(0);
            tlpFrame.Name = "tlpFrame";
            tlpFrame.Padding = new Padding(10);
            tlpFrame.RowCount = 3;
            tlpFrame.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tlpFrame.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tlpFrame.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tlpFrame.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tlpFrame.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpFrame.Size = new Size(1418, 507);
            tlpFrame.TabIndex = 4;
            // 
            // btnThoat
            // 
            btnThoat.Dock = DockStyle.Bottom;
            btnThoat.Font = new Font("Segoe UI", 8F);
            btnThoat.Location = new Point(1238, 456);
            btnThoat.Margin = new Padding(10, 10, 10, 0);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(160, 41);
            btnThoat.TabIndex = 23;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // dtpNgayLap
            // 
            tlpFrame.SetColumnSpan(dtpNgayLap, 2);
            dtpNgayLap.CustomFormat = "dd/MM/yyyy";
            dtpNgayLap.Dock = DockStyle.Fill;
            dtpNgayLap.Format = DateTimePickerFormat.Custom;
            dtpNgayLap.Location = new Point(542, 68);
            dtpNgayLap.Margin = new Padding(10);
            dtpNgayLap.Name = "dtpNgayLap";
            dtpNgayLap.Size = new Size(328, 31);
            dtpNgayLap.TabIndex = 22;
            dtpNgayLap.ValueChanged += dtpNgayLap_ValueChanged;
            // 
            // lblNgayLap
            // 
            lblNgayLap.AutoSize = true;
            tlpFrame.SetColumnSpan(lblNgayLap, 2);
            lblNgayLap.Dock = DockStyle.Fill;
            lblNgayLap.Location = new Point(542, 20);
            lblNgayLap.Margin = new Padding(10);
            lblNgayLap.Name = "lblNgayLap";
            lblNgayLap.Size = new Size(328, 28);
            lblNgayLap.TabIndex = 2;
            lblNgayLap.Text = "Ngày lập";
            lblNgayLap.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gcDanhSachDoiBong
            // 
            tlpFrame.SetColumnSpan(gcDanhSachDoiBong, 8);
            gcDanhSachDoiBong.Dock = DockStyle.Fill;
            gcDanhSachDoiBong.Location = new Point(20, 116);
            gcDanhSachDoiBong.MainView = gvcDanhSachDoiBong;
            gcDanhSachDoiBong.Margin = new Padding(10);
            gcDanhSachDoiBong.Name = "gcDanhSachDoiBong";
            gcDanhSachDoiBong.Size = new Size(1378, 320);
            gcDanhSachDoiBong.TabIndex = 9;
            gcDanhSachDoiBong.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvcDanhSachDoiBong });
            // 
            // gvcDanhSachDoiBong
            // 
            gvcDanhSachDoiBong.Appearance.HeaderPanel.FontStyleDelta = FontStyle.Bold;
            gvcDanhSachDoiBong.Appearance.HeaderPanel.Options.UseFont = true;
            gvcDanhSachDoiBong.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gvcDanhSachDoiBong.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvcDanhSachDoiBong.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gvcDanhSachDoiBong.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { gccTenDoiBong, gccSoTranThang, gccSoTranHoa, gccSoTranThua, gccHieuSo, gccHang });
            gvcDanhSachDoiBong.GridControl = gcDanhSachDoiBong;
            gvcDanhSachDoiBong.Name = "gvcDanhSachDoiBong";
            gvcDanhSachDoiBong.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            gvcDanhSachDoiBong.OptionsNavigation.AutoFocusNewRow = true;
            gvcDanhSachDoiBong.OptionsNavigation.EnterMoveNextColumn = true;
            gvcDanhSachDoiBong.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvcDanhSachDoiBong.OptionsSelection.MultiSelect = true;
            gvcDanhSachDoiBong.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            gvcDanhSachDoiBong.OptionsView.ShowAutoFilterRow = true;
            gvcDanhSachDoiBong.OptionsView.ShowViewCaption = true;
            gvcDanhSachDoiBong.ViewCaption = "Bảng xếp hạng";
            gvcDanhSachDoiBong.CustomDrawRowIndicator += this.gvcDanhSachDoiBong_CustomDrawRowIndicator;
            // 
            // gccTenDoiBong
            // 
            gccTenDoiBong.Caption = "Đội bóng";
            gccTenDoiBong.FieldName = "TenDoiBong";
            gccTenDoiBong.MinWidth = 30;
            gccTenDoiBong.Name = "gccTenDoiBong";
            gccTenDoiBong.OptionsColumn.ReadOnly = true;
            gccTenDoiBong.Visible = true;
            gccTenDoiBong.VisibleIndex = 0;
            gccTenDoiBong.Width = 112;
            // 
            // gccSoTranThang
            // 
            gccSoTranThang.Caption = "Thắng";
            gccSoTranThang.FieldName = "SoTranThang";
            gccSoTranThang.MinWidth = 30;
            gccSoTranThang.Name = "gccSoTranThang";
            gccSoTranThang.OptionsColumn.ReadOnly = true;
            gccSoTranThang.Visible = true;
            gccSoTranThang.VisibleIndex = 1;
            gccSoTranThang.Width = 112;
            // 
            // gccSoTranHoa
            // 
            gccSoTranHoa.Caption = "Hòa";
            gccSoTranHoa.FieldName = "SoTranHoa";
            gccSoTranHoa.MinWidth = 30;
            gccSoTranHoa.Name = "gccSoTranHoa";
            gccSoTranHoa.OptionsColumn.ReadOnly = true;
            gccSoTranHoa.Visible = true;
            gccSoTranHoa.VisibleIndex = 2;
            gccSoTranHoa.Width = 112;
            // 
            // gccSoTranThua
            // 
            gccSoTranThua.Caption = "Thua";
            gccSoTranThua.FieldName = "SoTranThua";
            gccSoTranThua.MinWidth = 30;
            gccSoTranThua.Name = "gccSoTranThua";
            gccSoTranThua.OptionsColumn.ReadOnly = true;
            gccSoTranThua.Visible = true;
            gccSoTranThua.VisibleIndex = 3;
            gccSoTranThua.Width = 112;
            // 
            // gccHieuSo
            // 
            gccHieuSo.Caption = "Hiệu số";
            gccHieuSo.FieldName = "HieuSo";
            gccHieuSo.MinWidth = 30;
            gccHieuSo.Name = "gccHieuSo";
            gccHieuSo.OptionsColumn.ReadOnly = true;
            gccHieuSo.Visible = true;
            gccHieuSo.VisibleIndex = 4;
            gccHieuSo.Width = 112;
            // 
            // gccHang
            // 
            gccHang.Caption = "Hạng";
            gccHang.FieldName = "Hang";
            gccHang.MinWidth = 30;
            gccHang.Name = "gccHang";
            gccHang.OptionsColumn.ReadOnly = true;
            gccHang.Visible = true;
            gccHang.VisibleIndex = 5;
            gccHang.Width = 112;
            // 
            // GUI_LapBangXepHang
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1418, 507);
            Controls.Add(tlpFrame);
            Name = "GUI_LapBangXepHang";
            Text = "Lập bảng xếp hạng";
            Load += GUI_LapBanXepHang_Load;
            tlpFrame.ResumeLayout(false);
            tlpFrame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gcDanhSachDoiBong).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvcDanhSachDoiBong).EndInit();
            ResumeLayout(false);
        }        

        #endregion

        private TableLayoutPanel tlpFrame;
        private Label lblNgayLap;
        private DevExpress.XtraGrid.GridControl gcDanhSachDoiBong;
        private DevExpress.XtraGrid.Views.Grid.GridView gvcDanhSachDoiBong;
        private DevExpress.XtraGrid.Columns.GridColumn gccTenDoiBong;
        private DevExpress.XtraGrid.Columns.GridColumn gccSoTranThang;
        private DevExpress.XtraGrid.Columns.GridColumn gccSoTranHoa;
        private DevExpress.XtraGrid.Columns.GridColumn gccSoTranThua;
        private DevExpress.XtraGrid.Columns.GridColumn gccHieuSo;
        private DateTimePicker dtpNgayLap;
        private DevExpress.XtraGrid.Columns.GridColumn gccHang;
        private Button btnThoat;
    }
}