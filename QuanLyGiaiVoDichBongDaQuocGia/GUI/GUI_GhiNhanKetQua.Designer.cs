namespace QuanLyGiaiVoDichBongDaQuocGia.GUI
{
    partial class GUI_GhiNhanKetQua
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
            gcDanhSachBanThang = new DevExpress.XtraGrid.GridControl();
            gvcDanhSachBanThang = new DevExpress.XtraGrid.Views.Grid.GridView();
            gccMaBanThang = new DevExpress.XtraGrid.Columns.GridColumn();
            gccMaCauThu = new DevExpress.XtraGrid.Columns.GridColumn();
            lkMaCauThu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            gccMaDoiBong = new DevExpress.XtraGrid.Columns.GridColumn();
            gccMaLoaiBanThang = new DevExpress.XtraGrid.Columns.GridColumn();
            lkMaLoaiBanThang = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            gccThoiDiemGhiBan = new DevExpress.XtraGrid.Columns.GridColumn();
            spThoiDiemGhiBan = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            cbTranDau = new ComboBox();
            txtTenSan = new TextBox();
            txtTiSo = new TextBox();
            txtNgayGio = new TextBox();
            lblNgayGio = new Label();
            lblTenSan = new Label();
            btnThemBanThang = new Button();
            btnThoat = new Button();
            lblTiSo = new Label();
            lblTranDau = new Label();
            btnGhiNhanKetQua = new Button();
            tlpFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gcDanhSachBanThang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvcDanhSachBanThang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lkMaCauThu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lkMaLoaiBanThang).BeginInit();
            ((System.ComponentModel.ISupportInitialize)spThoiDiemGhiBan).BeginInit();
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
            tlpFrame.Controls.Add(gcDanhSachBanThang, 0, 2);
            tlpFrame.Controls.Add(cbTranDau, 0, 1);
            tlpFrame.Controls.Add(txtTenSan, 2, 1);
            tlpFrame.Controls.Add(txtTiSo, 1, 1);
            tlpFrame.Controls.Add(txtNgayGio, 3, 1);
            tlpFrame.Controls.Add(lblNgayGio, 3, 0);
            tlpFrame.Controls.Add(lblTenSan, 2, 0);
            tlpFrame.Controls.Add(btnThemBanThang, 1, 3);
            tlpFrame.Controls.Add(btnThoat, 7, 3);
            tlpFrame.Controls.Add(lblTiSo, 1, 0);
            tlpFrame.Controls.Add(lblTranDau, 0, 0);
            tlpFrame.Controls.Add(btnGhiNhanKetQua, 0, 3);
            tlpFrame.Dock = DockStyle.Fill;
            tlpFrame.Location = new Point(0, 0);
            tlpFrame.Margin = new Padding(0);
            tlpFrame.Name = "tlpFrame";
            tlpFrame.Padding = new Padding(10);
            tlpFrame.RowCount = 4;
            tlpFrame.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tlpFrame.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tlpFrame.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tlpFrame.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tlpFrame.Size = new Size(1418, 507);
            tlpFrame.TabIndex = 1;
            // 
            // gcDanhSachBanThang
            // 
            tlpFrame.SetColumnSpan(gcDanhSachBanThang, 8);
            gcDanhSachBanThang.Dock = DockStyle.Fill;
            gcDanhSachBanThang.Location = new Point(20, 116);
            gcDanhSachBanThang.MainView = gvcDanhSachBanThang;
            gcDanhSachBanThang.Margin = new Padding(10);
            gcDanhSachBanThang.Name = "gcDanhSachBanThang";
            gcDanhSachBanThang.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { lkMaCauThu, lkMaLoaiBanThang, spThoiDiemGhiBan });
            gcDanhSachBanThang.Size = new Size(1378, 320);
            gcDanhSachBanThang.TabIndex = 21;
            gcDanhSachBanThang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvcDanhSachBanThang });
            // 
            // gvcDanhSachBanThang
            // 
            gvcDanhSachBanThang.Appearance.HeaderPanel.FontStyleDelta = FontStyle.Bold;
            gvcDanhSachBanThang.Appearance.HeaderPanel.Options.UseFont = true;
            gvcDanhSachBanThang.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gvcDanhSachBanThang.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvcDanhSachBanThang.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gvcDanhSachBanThang.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { gccMaBanThang, gccMaCauThu, gccMaDoiBong, gccMaLoaiBanThang, gccThoiDiemGhiBan });
            gvcDanhSachBanThang.GridControl = gcDanhSachBanThang;
            gvcDanhSachBanThang.Name = "gvcDanhSachBanThang";
            gvcDanhSachBanThang.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            gvcDanhSachBanThang.OptionsNavigation.AutoFocusNewRow = true;
            gvcDanhSachBanThang.OptionsNavigation.EnterMoveNextColumn = true;
            gvcDanhSachBanThang.OptionsSelection.EnableAppearanceFocusedCell = false;
            gvcDanhSachBanThang.OptionsSelection.MultiSelect = true;
            gvcDanhSachBanThang.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            gvcDanhSachBanThang.OptionsView.ShowAutoFilterRow = true;
            gvcDanhSachBanThang.OptionsView.ShowViewCaption = true;
            gvcDanhSachBanThang.ViewCaption = "Danh sách bàn thắng";
            gvcDanhSachBanThang.CustomDrawRowIndicator += gvcDanhSachBanThang_CustomDrawRowIndicator;
            gvcDanhSachBanThang.CellValueChanged += gvcDanhSachBanThang_CellValueChanged;
            gvcDanhSachBanThang.RowDeleted += gvcDanhSachBanThang_RowDeleted;
            gvcDanhSachBanThang.CustomUnboundColumnData += gvcDanhSachBanThang_CustomUnboundColumnData;
            gvcDanhSachBanThang.KeyDown += gvcDanhSachBanThang_KeyDown;
            // 
            // gccMaBanThang
            // 
            gccMaBanThang.Caption = "Mã bàn thắng";
            gccMaBanThang.FieldName = "MaBanThang";
            gccMaBanThang.MinWidth = 30;
            gccMaBanThang.Name = "gccMaBanThang";
            gccMaBanThang.OptionsColumn.ReadOnly = true;
            gccMaBanThang.Visible = true;
            gccMaBanThang.VisibleIndex = 0;
            gccMaBanThang.Width = 112;
            // 
            // gccMaCauThu
            // 
            gccMaCauThu.Caption = "Cầu thủ";
            gccMaCauThu.ColumnEdit = lkMaCauThu;
            gccMaCauThu.FieldName = "MaCauThu";
            gccMaCauThu.MinWidth = 30;
            gccMaCauThu.Name = "gccMaCauThu";
            gccMaCauThu.Visible = true;
            gccMaCauThu.VisibleIndex = 1;
            gccMaCauThu.Width = 112;
            // 
            // lkMaCauThu
            // 
            lkMaCauThu.AutoHeight = false;
            lkMaCauThu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lkMaCauThu.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenCauThu", "Họ tên") });
            lkMaCauThu.Name = "lkMaCauThu";
            // 
            // gccMaDoiBong
            // 
            gccMaDoiBong.Caption = "Đội bóng";
            gccMaDoiBong.FieldName = "MaDoiBong";
            gccMaDoiBong.MinWidth = 30;
            gccMaDoiBong.Name = "gccMaDoiBong";
            gccMaDoiBong.OptionsColumn.ReadOnly = true;
            gccMaDoiBong.UnboundDataType = typeof(string);
            gccMaDoiBong.Visible = true;
            gccMaDoiBong.VisibleIndex = 2;
            gccMaDoiBong.Width = 112;
            // 
            // gccMaLoaiBanThang
            // 
            gccMaLoaiBanThang.Caption = "Loại bàn thắng";
            gccMaLoaiBanThang.ColumnEdit = lkMaLoaiBanThang;
            gccMaLoaiBanThang.FieldName = "MaLoaiBanThang";
            gccMaLoaiBanThang.MinWidth = 30;
            gccMaLoaiBanThang.Name = "gccMaLoaiBanThang";
            gccMaLoaiBanThang.Visible = true;
            gccMaLoaiBanThang.VisibleIndex = 3;
            gccMaLoaiBanThang.Width = 112;
            // 
            // lkMaLoaiBanThang
            // 
            lkMaLoaiBanThang.AutoHeight = false;
            lkMaLoaiBanThang.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lkMaLoaiBanThang.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenLoaiBanThang", "Loại bàn thắng") });
            lkMaLoaiBanThang.Name = "lkMaLoaiBanThang";
            // 
            // gccThoiDiemGhiBan
            // 
            gccThoiDiemGhiBan.Caption = "Thời điểm";
            gccThoiDiemGhiBan.ColumnEdit = spThoiDiemGhiBan;
            gccThoiDiemGhiBan.FieldName = "ThoiDiemGhiBan";
            gccThoiDiemGhiBan.MinWidth = 30;
            gccThoiDiemGhiBan.Name = "gccThoiDiemGhiBan";
            gccThoiDiemGhiBan.Visible = true;
            gccThoiDiemGhiBan.VisibleIndex = 4;
            gccThoiDiemGhiBan.Width = 112;
            // 
            // spThoiDiemGhiBan
            // 
            spThoiDiemGhiBan.AutoHeight = false;
            spThoiDiemGhiBan.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            spThoiDiemGhiBan.Name = "spThoiDiemGhiBan";
            // 
            // cbTranDau
            // 
            tlpFrame.SetColumnSpan(cbTranDau, 2);
            cbTranDau.Dock = DockStyle.Fill;
            cbTranDau.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTranDau.FormattingEnabled = true;
            cbTranDau.Location = new Point(20, 68);
            cbTranDau.Margin = new Padding(10);
            cbTranDau.Name = "cbTranDau";
            cbTranDau.Size = new Size(328, 33);
            cbTranDau.TabIndex = 20;
            cbTranDau.SelectedIndexChanged += cbTranDau_SelectedIndexChanged;
            // 
            // txtTenSan
            // 
            txtTenSan.BorderStyle = BorderStyle.FixedSingle;
            txtTenSan.Dock = DockStyle.Fill;
            txtTenSan.Location = new Point(542, 68);
            txtTenSan.Margin = new Padding(10);
            txtTenSan.Name = "txtTenSan";
            txtTenSan.ReadOnly = true;
            txtTenSan.Size = new Size(154, 31);
            txtTenSan.TabIndex = 19;
            // 
            // txtTiSo
            // 
            txtTiSo.BorderStyle = BorderStyle.FixedSingle;
            txtTiSo.Dock = DockStyle.Fill;
            txtTiSo.Location = new Point(368, 68);
            txtTiSo.Margin = new Padding(10);
            txtTiSo.Name = "txtTiSo";
            txtTiSo.ReadOnly = true;
            txtTiSo.Size = new Size(154, 31);
            txtTiSo.TabIndex = 18;
            // 
            // txtNgayGio
            // 
            txtNgayGio.BorderStyle = BorderStyle.FixedSingle;
            txtNgayGio.Dock = DockStyle.Fill;
            txtNgayGio.Location = new Point(716, 68);
            txtNgayGio.Margin = new Padding(10);
            txtNgayGio.Name = "txtNgayGio";
            txtNgayGio.ReadOnly = true;
            txtNgayGio.Size = new Size(154, 31);
            txtNgayGio.TabIndex = 17;
            // 
            // lblNgayGio
            // 
            lblNgayGio.AutoSize = true;
            lblNgayGio.Dock = DockStyle.Fill;
            lblNgayGio.Location = new Point(716, 20);
            lblNgayGio.Margin = new Padding(10);
            lblNgayGio.Name = "lblNgayGio";
            lblNgayGio.Size = new Size(154, 28);
            lblNgayGio.TabIndex = 16;
            lblNgayGio.Text = "Ngày - Giờ";
            lblNgayGio.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTenSan
            // 
            lblTenSan.AutoSize = true;
            lblTenSan.Dock = DockStyle.Fill;
            lblTenSan.Location = new Point(542, 20);
            lblTenSan.Margin = new Padding(10);
            lblTenSan.Name = "lblTenSan";
            lblTenSan.Size = new Size(154, 28);
            lblTenSan.TabIndex = 15;
            lblTenSan.Text = "Tên sân";
            lblTenSan.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnThemBanThang
            // 
            btnThemBanThang.Dock = DockStyle.Fill;
            btnThemBanThang.Font = new Font("Segoe UI", 8F);
            btnThemBanThang.Location = new Point(194, 456);
            btnThemBanThang.Margin = new Padding(10, 10, 10, 0);
            btnThemBanThang.Name = "btnThemBanThang";
            btnThemBanThang.Size = new Size(154, 41);
            btnThemBanThang.TabIndex = 14;
            btnThemBanThang.Text = "Thêm bàn thắng";
            btnThemBanThang.UseVisualStyleBackColor = true;
            btnThemBanThang.Click += btnThemBanThang_Click;
            // 
            // btnThoat
            // 
            btnThoat.Dock = DockStyle.Fill;
            btnThoat.Font = new Font("Segoe UI", 8F);
            btnThoat.Location = new Point(1238, 456);
            btnThoat.Margin = new Padding(10, 10, 10, 0);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(160, 41);
            btnThoat.TabIndex = 13;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // lblTiSo
            // 
            lblTiSo.AutoSize = true;
            lblTiSo.Dock = DockStyle.Fill;
            lblTiSo.Location = new Point(368, 20);
            lblTiSo.Margin = new Padding(10);
            lblTiSo.Name = "lblTiSo";
            lblTiSo.Size = new Size(154, 28);
            lblTiSo.TabIndex = 12;
            lblTiSo.Text = "Tỉ số";
            lblTiSo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTranDau
            // 
            lblTranDau.AutoSize = true;
            tlpFrame.SetColumnSpan(lblTranDau, 2);
            lblTranDau.Dock = DockStyle.Fill;
            lblTranDau.Location = new Point(20, 20);
            lblTranDau.Margin = new Padding(10);
            lblTranDau.Name = "lblTranDau";
            lblTranDau.Size = new Size(328, 28);
            lblTranDau.TabIndex = 1;
            lblTranDau.Text = "Trận đấu";
            lblTranDau.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnGhiNhanKetQua
            // 
            btnGhiNhanKetQua.Dock = DockStyle.Fill;
            btnGhiNhanKetQua.Font = new Font("Segoe UI", 8F);
            btnGhiNhanKetQua.Location = new Point(20, 456);
            btnGhiNhanKetQua.Margin = new Padding(10, 10, 10, 0);
            btnGhiNhanKetQua.Name = "btnGhiNhanKetQua";
            btnGhiNhanKetQua.Size = new Size(154, 41);
            btnGhiNhanKetQua.TabIndex = 11;
            btnGhiNhanKetQua.Text = "Ghi nhận";
            btnGhiNhanKetQua.UseVisualStyleBackColor = true;
            btnGhiNhanKetQua.Click += btnGhiNhanKetQua_Click;
            // 
            // GUI_GhiNhanKetQua
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1418, 507);
            Controls.Add(tlpFrame);
            Name = "GUI_GhiNhanKetQua";
            Text = "GUI_GhiNhanKetQua";
            Load += GUI_GhiNhanKetQua_Load;
            tlpFrame.ResumeLayout(false);
            tlpFrame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gcDanhSachBanThang).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvcDanhSachBanThang).EndInit();
            ((System.ComponentModel.ISupportInitialize)lkMaCauThu).EndInit();
            ((System.ComponentModel.ISupportInitialize)lkMaLoaiBanThang).EndInit();
            ((System.ComponentModel.ISupportInitialize)spThoiDiemGhiBan).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpFrame;
        private Button btnThemBanThang;
        private Button btnThoat;
        private Label lblTiSo;
        private Label lblTranDau;
        private Button btnGhiNhanKetQua;
        private TextBox txtTenSan;
        private TextBox txtTiSo;
        private TextBox txtNgayGio;
        private Label lblNgayGio;
        private Label lblTenSan;
        private ComboBox cbTranDau;
        private DevExpress.XtraGrid.GridControl gcDanhSachBanThang;
        private DevExpress.XtraGrid.Views.Grid.GridView gvcDanhSachBanThang;
        private DevExpress.XtraGrid.Columns.GridColumn gccMaBanThang;
        private DevExpress.XtraGrid.Columns.GridColumn gccMaCauThu;
        private DevExpress.XtraGrid.Columns.GridColumn gccMaDoiBong;
        private DevExpress.XtraGrid.Columns.GridColumn gccMaLoaiBanThang;
        private DevExpress.XtraGrid.Columns.GridColumn gccThoiDiemGhiBan;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lkMaCauThu;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lkMaLoaiBanThang;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit spThoiDiemGhiBan;
    }
}