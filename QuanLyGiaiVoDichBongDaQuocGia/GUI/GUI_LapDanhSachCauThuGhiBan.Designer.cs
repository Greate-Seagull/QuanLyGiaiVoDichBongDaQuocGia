namespace QuanLyGiaiVoDichBongDaQuocGia.GUI
{
    partial class GUI_LapDanhSachCauThuGhiBan
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
            gcDanhSachCauThu = new DevExpress.XtraGrid.GridControl();
            gvcDanhSachCauThu = new DevExpress.XtraGrid.Views.Grid.GridView();
            gccTenCauThu = new DevExpress.XtraGrid.Columns.GridColumn();
            gccTenDoiBong = new DevExpress.XtraGrid.Columns.GridColumn();
            gccTenLoaiCauThu = new DevExpress.XtraGrid.Columns.GridColumn();
            gccSoBanThang = new DevExpress.XtraGrid.Columns.GridColumn();
            tlpFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gcDanhSachCauThu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvcDanhSachCauThu).BeginInit();
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
            tlpFrame.Controls.Add(gcDanhSachCauThu, 0, 2);
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
            tlpFrame.TabIndex = 5;
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
            // gcDanhSachCauThu
            // 
            tlpFrame.SetColumnSpan(gcDanhSachCauThu, 8);
            gcDanhSachCauThu.Dock = DockStyle.Fill;
            gcDanhSachCauThu.Location = new Point(20, 116);
            gcDanhSachCauThu.MainView = gvcDanhSachCauThu;
            gcDanhSachCauThu.Margin = new Padding(10);
            gcDanhSachCauThu.Name = "gcDanhSachCauThu";
            gcDanhSachCauThu.Size = new Size(1378, 320);
            gcDanhSachCauThu.TabIndex = 9;
            gcDanhSachCauThu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvcDanhSachCauThu });
            // 
            // gvcDanhSachCauThu
            // 
            gvcDanhSachCauThu.Appearance.HeaderPanel.FontStyleDelta = FontStyle.Bold;
            gvcDanhSachCauThu.Appearance.HeaderPanel.Options.UseFont = true;
            gvcDanhSachCauThu.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gvcDanhSachCauThu.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvcDanhSachCauThu.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gvcDanhSachCauThu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { gccTenCauThu, gccTenDoiBong, gccTenLoaiCauThu, gccSoBanThang });
            gvcDanhSachCauThu.GridControl = gcDanhSachCauThu;
            gvcDanhSachCauThu.Name = "gvcDanhSachCauThu";
            gvcDanhSachCauThu.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            gvcDanhSachCauThu.OptionsNavigation.AutoFocusNewRow = true;
            gvcDanhSachCauThu.OptionsNavigation.EnterMoveNextColumn = true;
            gvcDanhSachCauThu.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvcDanhSachCauThu.OptionsSelection.MultiSelect = true;
            gvcDanhSachCauThu.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            gvcDanhSachCauThu.OptionsView.ShowAutoFilterRow = true;
            gvcDanhSachCauThu.OptionsView.ShowViewCaption = true;
            gvcDanhSachCauThu.ViewCaption = "Bảng xếp hạng";
            gvcDanhSachCauThu.CustomDrawRowIndicator += gvcDanhSachCauThu_CustomDrawRowIndicator;
            // 
            // gccTenCauThu
            // 
            gccTenCauThu.Caption = "Họ tên";
            gccTenCauThu.FieldName = "TenCauThu";
            gccTenCauThu.MinWidth = 30;
            gccTenCauThu.Name = "gccTenCauThu";
            gccTenCauThu.OptionsColumn.ReadOnly = true;
            gccTenCauThu.Visible = true;
            gccTenCauThu.VisibleIndex = 0;
            gccTenCauThu.Width = 112;
            // 
            // gccTenDoiBong
            // 
            gccTenDoiBong.Caption = "Đội bóng";
            gccTenDoiBong.FieldName = "TenDoiBong";
            gccTenDoiBong.MinWidth = 30;
            gccTenDoiBong.Name = "gccTenDoiBong";
            gccTenDoiBong.OptionsColumn.ReadOnly = true;
            gccTenDoiBong.Visible = true;
            gccTenDoiBong.VisibleIndex = 1;
            gccTenDoiBong.Width = 112;
            // 
            // gccTenLoaiCauThu
            // 
            gccTenLoaiCauThu.Caption = "Loại cầu thủ";
            gccTenLoaiCauThu.FieldName = "TenLoaiCauThu";
            gccTenLoaiCauThu.MinWidth = 30;
            gccTenLoaiCauThu.Name = "gccTenLoaiCauThu";
            gccTenLoaiCauThu.OptionsColumn.ReadOnly = true;
            gccTenLoaiCauThu.Visible = true;
            gccTenLoaiCauThu.VisibleIndex = 2;
            gccTenLoaiCauThu.Width = 112;
            // 
            // gccSoBanThang
            // 
            gccSoBanThang.Caption = "Số bàn thắng";
            gccSoBanThang.FieldName = "SoBanThang";
            gccSoBanThang.MinWidth = 30;
            gccSoBanThang.Name = "gccSoBanThang";
            gccSoBanThang.OptionsColumn.ReadOnly = true;
            gccSoBanThang.Visible = true;
            gccSoBanThang.VisibleIndex = 3;
            gccSoBanThang.Width = 112;
            // 
            // GUI_LapDanhSachCauThuGhiBan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1418, 507);
            Controls.Add(tlpFrame);
            Name = "GUI_LapDanhSachCauThuGhiBan";
            Text = "GUI_LapDanhSachCauThuGhiBan";
            Load += GUI_LapDanhSachCauThuGhiBan_Load;
            tlpFrame.ResumeLayout(false);
            tlpFrame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gcDanhSachCauThu).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvcDanhSachCauThu).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpFrame;
        private Button btnThoat;
        private DateTimePicker dtpNgayLap;
        private Label lblNgayLap;
        private DevExpress.XtraGrid.GridControl gcDanhSachCauThu;
        private DevExpress.XtraGrid.Views.Grid.GridView gvcDanhSachCauThu;
        private DevExpress.XtraGrid.Columns.GridColumn gccTenCauThu;
        private DevExpress.XtraGrid.Columns.GridColumn gccTenDoiBong;
        private DevExpress.XtraGrid.Columns.GridColumn gccTenLoaiCauThu;
        private DevExpress.XtraGrid.Columns.GridColumn gccSoBanThang;
    }
}