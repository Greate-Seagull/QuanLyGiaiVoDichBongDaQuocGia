namespace QuanLyGiaiVoDichBongDaQuocGia.GUI
{
    partial class GUI_TiepNhanDoiBong
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
            components = new System.ComponentModel.Container();
            tlpFrame = new TableLayoutPanel();
            btnThemCauThu = new Button();
            lblMaDoiBong = new Label();
            lblTenSanNha = new Label();
            lblTenDoiBong = new Label();
            txtMaDoiBong = new TextBox();
            txtTenDoiBong = new TextBox();
            txtTenSanNha = new TextBox();
            btnTiepNhanDoiBong = new Button();
            btnThoat = new Button();
            gcDanhSachCauThu = new DevExpress.XtraGrid.GridControl();
            gvcDanhSachCauThu = new DevExpress.XtraGrid.Views.Grid.GridView();
            gccMaCauThu = new DevExpress.XtraGrid.Columns.GridColumn();
            gccTenCauThu = new DevExpress.XtraGrid.Columns.GridColumn();
            gccLoaiCauThu = new DevExpress.XtraGrid.Columns.GridColumn();
            lkLoaiCauThu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            gccNgaySinh = new DevExpress.XtraGrid.Columns.GridColumn();
            dtpNgaySinh = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            gccGhiChu = new DevExpress.XtraGrid.Columns.GridColumn();
            behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(components);
            tlpFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gcDanhSachCauThu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gvcDanhSachCauThu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lkLoaiCauThu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtpNgaySinh).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtpNgaySinh.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)behaviorManager1).BeginInit();
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
            tlpFrame.Controls.Add(btnThemCauThu, 1, 3);
            tlpFrame.Controls.Add(lblMaDoiBong, 0, 0);
            tlpFrame.Controls.Add(lblTenSanNha, 2, 0);
            tlpFrame.Controls.Add(lblTenDoiBong, 1, 0);
            tlpFrame.Controls.Add(txtMaDoiBong, 0, 1);
            tlpFrame.Controls.Add(txtTenDoiBong, 1, 1);
            tlpFrame.Controls.Add(txtTenSanNha, 2, 1);
            tlpFrame.Controls.Add(btnTiepNhanDoiBong, 0, 3);
            tlpFrame.Controls.Add(btnThoat, 8, 3);
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
            tlpFrame.Size = new Size(1418, 507);
            tlpFrame.TabIndex = 3;
            // 
            // btnThemCauThu
            // 
            btnThemCauThu.Dock = DockStyle.Bottom;
            btnThemCauThu.Font = new Font("Segoe UI", 8F);
            btnThemCauThu.Location = new Point(194, 456);
            btnThemCauThu.Margin = new Padding(10, 10, 10, 0);
            btnThemCauThu.Name = "btnThemCauThu";
            btnThemCauThu.Size = new Size(154, 41);
            btnThemCauThu.TabIndex = 8;
            btnThemCauThu.Text = "Thêm cầu thủ";
            btnThemCauThu.UseVisualStyleBackColor = true;
            btnThemCauThu.Click += btnThemCauThu_Click;
            // 
            // lblMaDoiBong
            // 
            lblMaDoiBong.AutoSize = true;
            lblMaDoiBong.Dock = DockStyle.Fill;
            lblMaDoiBong.Location = new Point(20, 20);
            lblMaDoiBong.Margin = new Padding(10);
            lblMaDoiBong.Name = "lblMaDoiBong";
            lblMaDoiBong.Size = new Size(154, 28);
            lblMaDoiBong.TabIndex = 0;
            lblMaDoiBong.Text = "Mã đội bóng";
            lblMaDoiBong.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTenSanNha
            // 
            lblTenSanNha.AutoSize = true;
            tlpFrame.SetColumnSpan(lblTenSanNha, 2);
            lblTenSanNha.Dock = DockStyle.Fill;
            lblTenSanNha.Location = new Point(542, 20);
            lblTenSanNha.Margin = new Padding(10);
            lblTenSanNha.Name = "lblTenSanNha";
            lblTenSanNha.Size = new Size(328, 28);
            lblTenSanNha.TabIndex = 1;
            lblTenSanNha.Text = "Tên sân nhà";
            lblTenSanNha.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTenDoiBong
            // 
            lblTenDoiBong.AutoSize = true;
            tlpFrame.SetColumnSpan(lblTenDoiBong, 2);
            lblTenDoiBong.Dock = DockStyle.Fill;
            lblTenDoiBong.Location = new Point(194, 20);
            lblTenDoiBong.Margin = new Padding(10);
            lblTenDoiBong.Name = "lblTenDoiBong";
            lblTenDoiBong.Size = new Size(328, 28);
            lblTenDoiBong.TabIndex = 2;
            lblTenDoiBong.Text = "Tên đội bóng";
            lblTenDoiBong.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtMaDoiBong
            // 
            txtMaDoiBong.BorderStyle = BorderStyle.FixedSingle;
            txtMaDoiBong.Dock = DockStyle.Fill;
            txtMaDoiBong.Location = new Point(20, 68);
            txtMaDoiBong.Margin = new Padding(10);
            txtMaDoiBong.Name = "txtMaDoiBong";
            txtMaDoiBong.ReadOnly = true;
            txtMaDoiBong.Size = new Size(154, 31);
            txtMaDoiBong.TabIndex = 3;
            // 
            // txtTenDoiBong
            // 
            txtTenDoiBong.BorderStyle = BorderStyle.FixedSingle;
            tlpFrame.SetColumnSpan(txtTenDoiBong, 2);
            txtTenDoiBong.Dock = DockStyle.Fill;
            txtTenDoiBong.Location = new Point(194, 68);
            txtTenDoiBong.Margin = new Padding(10);
            txtTenDoiBong.Name = "txtTenDoiBong";
            txtTenDoiBong.Size = new Size(328, 31);
            txtTenDoiBong.TabIndex = 4;
            // 
            // txtTenSanNha
            // 
            txtTenSanNha.BorderStyle = BorderStyle.FixedSingle;
            tlpFrame.SetColumnSpan(txtTenSanNha, 2);
            txtTenSanNha.Dock = DockStyle.Fill;
            txtTenSanNha.Location = new Point(542, 68);
            txtTenSanNha.Margin = new Padding(10);
            txtTenSanNha.Name = "txtTenSanNha";
            txtTenSanNha.Size = new Size(328, 31);
            txtTenSanNha.TabIndex = 5;
            // 
            // btnTiepNhanDoiBong
            // 
            btnTiepNhanDoiBong.Dock = DockStyle.Bottom;
            btnTiepNhanDoiBong.Font = new Font("Segoe UI", 8F);
            btnTiepNhanDoiBong.Location = new Point(20, 456);
            btnTiepNhanDoiBong.Margin = new Padding(10, 10, 10, 0);
            btnTiepNhanDoiBong.Name = "btnTiepNhanDoiBong";
            btnTiepNhanDoiBong.Size = new Size(154, 41);
            btnTiepNhanDoiBong.TabIndex = 6;
            btnTiepNhanDoiBong.Text = "Tiếp nhận đội bóng";
            btnTiepNhanDoiBong.UseVisualStyleBackColor = true;
            btnTiepNhanDoiBong.Click += btnTiepNhanDoiBong_Click;
            // 
            // btnThoat
            // 
            btnThoat.Dock = DockStyle.Bottom;
            btnThoat.Font = new Font("Segoe UI", 8F);
            btnThoat.Location = new Point(1238, 456);
            btnThoat.Margin = new Padding(10, 10, 10, 0);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(160, 41);
            btnThoat.TabIndex = 7;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // gcDanhSachCauThu
            // 
            tlpFrame.SetColumnSpan(gcDanhSachCauThu, 8);
            gcDanhSachCauThu.Dock = DockStyle.Fill;
            gcDanhSachCauThu.Location = new Point(20, 116);
            gcDanhSachCauThu.MainView = gvcDanhSachCauThu;
            gcDanhSachCauThu.Margin = new Padding(10);
            gcDanhSachCauThu.Name = "gcDanhSachCauThu";
            gcDanhSachCauThu.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { lkLoaiCauThu, dtpNgaySinh });
            gcDanhSachCauThu.Size = new Size(1378, 320);
            gcDanhSachCauThu.TabIndex = 9;
            gcDanhSachCauThu.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gvcDanhSachCauThu });
            gcDanhSachCauThu.KeyDown += gcDanhSachCauThu_KeyDown;
            // 
            // gvcDanhSachCauThu
            // 
            gvcDanhSachCauThu.Appearance.HeaderPanel.FontStyleDelta = FontStyle.Bold;
            gvcDanhSachCauThu.Appearance.HeaderPanel.Options.UseFont = true;
            gvcDanhSachCauThu.Appearance.HeaderPanel.Options.UseTextOptions = true;
            gvcDanhSachCauThu.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gvcDanhSachCauThu.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            gvcDanhSachCauThu.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] { gccMaCauThu, gccTenCauThu, gccLoaiCauThu, gccNgaySinh, gccGhiChu });
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
            gvcDanhSachCauThu.ViewCaption = "Danh sách cầu thủ";
            gvcDanhSachCauThu.CustomDrawRowIndicator += gvcDanhSachCauThu_CustomDrawRowIndicator;
            gvcDanhSachCauThu.RowDeleting += gvcDanhSachCauThu_RowDeleting;
            gvcDanhSachCauThu.RowDeleted += gvcDanhSachCauThu_RowDeleted;
            // 
            // gccMaCauThu
            // 
            gccMaCauThu.Caption = "Mã cầu thủ";
            gccMaCauThu.FieldName = "MaCauThu";
            gccMaCauThu.MinWidth = 30;
            gccMaCauThu.Name = "gccMaCauThu";
            gccMaCauThu.OptionsColumn.ReadOnly = true;
            gccMaCauThu.Visible = true;
            gccMaCauThu.VisibleIndex = 0;
            gccMaCauThu.Width = 112;
            // 
            // gccTenCauThu
            // 
            gccTenCauThu.Caption = "Họ tên";
            gccTenCauThu.FieldName = "TenCauThu";
            gccTenCauThu.MinWidth = 30;
            gccTenCauThu.Name = "gccTenCauThu";
            gccTenCauThu.Visible = true;
            gccTenCauThu.VisibleIndex = 1;
            gccTenCauThu.Width = 112;
            // 
            // gccLoaiCauThu
            // 
            gccLoaiCauThu.Caption = "Loại cầu thủ";
            gccLoaiCauThu.ColumnEdit = lkLoaiCauThu;
            gccLoaiCauThu.FieldName = "MaLoaiCauThu";
            gccLoaiCauThu.MinWidth = 30;
            gccLoaiCauThu.Name = "gccLoaiCauThu";
            gccLoaiCauThu.Visible = true;
            gccLoaiCauThu.VisibleIndex = 2;
            gccLoaiCauThu.Width = 112;
            // 
            // lkLoaiCauThu
            // 
            lkLoaiCauThu.AutoHeight = false;
            lkLoaiCauThu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lkLoaiCauThu.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] { new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenLoaiCauThu", "Loại cầu thủ"), new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SoLuongCauThuToiDaTheoLoaiCauThu", "Số lượng tối đa") });
            lkLoaiCauThu.Name = "lkLoaiCauThu";
            // 
            // gccNgaySinh
            // 
            gccNgaySinh.Caption = "Ngày sinh";
            gccNgaySinh.ColumnEdit = dtpNgaySinh;
            gccNgaySinh.FieldName = "NgaySinh";
            gccNgaySinh.MinWidth = 30;
            gccNgaySinh.Name = "gccNgaySinh";
            gccNgaySinh.Visible = true;
            gccNgaySinh.VisibleIndex = 3;
            gccNgaySinh.Width = 112;
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.AutoHeight = false;
            dtpNgaySinh.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtpNgaySinh.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtpNgaySinh.Name = "dtpNgaySinh";
            // 
            // gccGhiChu
            // 
            gccGhiChu.Caption = "Ghi chú";
            gccGhiChu.FieldName = "GhiChu";
            gccGhiChu.MinWidth = 30;
            gccGhiChu.Name = "gccGhiChu";
            gccGhiChu.Visible = true;
            gccGhiChu.VisibleIndex = 4;
            gccGhiChu.Width = 112;
            // 
            // GUI_TiepNhanDoiBong
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1418, 507);
            Controls.Add(tlpFrame);
            Name = "GUI_TiepNhanDoiBong";
            Text = "Tiếp nhận hồ sơ đội bóng";
            Load += GUI_TiepNhanDoiBong_Load;
            tlpFrame.ResumeLayout(false);
            tlpFrame.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gcDanhSachCauThu).EndInit();
            ((System.ComponentModel.ISupportInitialize)gvcDanhSachCauThu).EndInit();
            ((System.ComponentModel.ISupportInitialize)lkLoaiCauThu).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtpNgaySinh.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtpNgaySinh).EndInit();
            ((System.ComponentModel.ISupportInitialize)behaviorManager1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tlpFrame;
        private Button btnThemCauThu;
        private Label lblMaDoiBong;
        private Label lblTenSanNha;
        private Label lblTenDoiBong;
        private TextBox txtMaDoiBong;
        private TextBox txtTenDoiBong;
        private TextBox txtTenSanNha;
        private Button btnTiepNhanDoiBong;
        private Button btnThoat;
        private DevExpress.XtraGrid.GridControl gcDanhSachCauThu;
        private DevExpress.XtraGrid.Views.Grid.GridView gvcDanhSachCauThu;
        private DevExpress.XtraGrid.Columns.GridColumn gccMaCauThu;
        private DevExpress.XtraGrid.Columns.GridColumn gccTenCauThu;
        private DevExpress.XtraGrid.Columns.GridColumn gccLoaiCauThu;
        private DevExpress.XtraGrid.Columns.GridColumn gccNgaySinh;
        private DevExpress.XtraGrid.Columns.GridColumn gccGhiChu;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit lkLoaiCauThu;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit dtpNgaySinh;
    }
}