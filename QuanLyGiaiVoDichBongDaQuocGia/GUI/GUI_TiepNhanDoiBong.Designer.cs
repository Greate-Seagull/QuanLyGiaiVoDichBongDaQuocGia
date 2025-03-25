﻿namespace QuanLyGiaiVoDichBongDaQuocGia.GUI
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
            tableLayoutPanel = new TableLayoutPanel();
            btnThemCauThu = new Button();
            lblMaDoiBong = new Label();
            lblTenSanNha = new Label();
            lblTenDoiBong = new Label();
            txtMaDoiBong = new TextBox();
            txtTenDoiBong = new TextBox();
            txtTenSanNha = new TextBox();
            btnTiepNhanDoiBong = new Button();
            btnThoat = new Button();
            pDanhSachCauThu = new Panel();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 8;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel.Controls.Add(btnThemCauThu, 1, 3);
            tableLayoutPanel.Controls.Add(lblMaDoiBong, 0, 0);
            tableLayoutPanel.Controls.Add(lblTenSanNha, 2, 0);
            tableLayoutPanel.Controls.Add(lblTenDoiBong, 1, 0);
            tableLayoutPanel.Controls.Add(txtMaDoiBong, 0, 1);
            tableLayoutPanel.Controls.Add(txtTenDoiBong, 1, 1);
            tableLayoutPanel.Controls.Add(txtTenSanNha, 2, 1);
            tableLayoutPanel.Controls.Add(btnTiepNhanDoiBong, 0, 3);
            tableLayoutPanel.Controls.Add(btnThoat, 8, 3);
            tableLayoutPanel.Controls.Add(pDanhSachCauThu, 0, 2);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Margin = new Padding(0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.Padding = new Padding(10);
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new Size(1418, 507);
            tableLayoutPanel.TabIndex = 3;
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
            tableLayoutPanel.SetColumnSpan(lblTenSanNha, 2);
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
            tableLayoutPanel.SetColumnSpan(lblTenDoiBong, 2);
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
            tableLayoutPanel.SetColumnSpan(txtTenDoiBong, 2);
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
            tableLayoutPanel.SetColumnSpan(txtTenSanNha, 2);
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
            // pDanhSachCauThu
            // 
            pDanhSachCauThu.AutoScroll = true;
            pDanhSachCauThu.BackColor = Color.White;
            pDanhSachCauThu.BorderStyle = BorderStyle.FixedSingle;
            tableLayoutPanel.SetColumnSpan(pDanhSachCauThu, 8);
            pDanhSachCauThu.Dock = DockStyle.Fill;
            pDanhSachCauThu.Location = new Point(20, 116);
            pDanhSachCauThu.Margin = new Padding(10);
            pDanhSachCauThu.Name = "pDanhSachCauThu";
            pDanhSachCauThu.Padding = new Padding(10);
            pDanhSachCauThu.Size = new Size(1378, 320);
            pDanhSachCauThu.TabIndex = 9;
            // 
            // GUI_TiepNhanDoiBong
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1418, 507);
            Controls.Add(tableLayoutPanel);
            Name = "GUI_TiepNhanDoiBong";
            Text = "Tiếp nhận hồ sơ đội bóng";
            Load += GUI_TiepNhanDoiBong_Load;
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel;
        private Button btnThemCauThu;
        private Label lblMaDoiBong;
        private Label lblTenSanNha;
        private Label lblTenDoiBong;
        private TextBox txtMaDoiBong;
        private TextBox txtTenDoiBong;
        private TextBox txtTenSanNha;
        private Button btnTiepNhanDoiBong;
        private Button btnThoat;
        private Panel pDanhSachCauThu;
    }
}