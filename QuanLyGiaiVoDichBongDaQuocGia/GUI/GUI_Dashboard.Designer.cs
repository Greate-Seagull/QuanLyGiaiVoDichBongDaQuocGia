namespace QuanLyGiaiVoDichBongDaQuocGia.GUI
{
    partial class GUI_Dashboard
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
            tlpArrangement = new TableLayoutPanel();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnThayDoiQuiDinh = new Button();
            btnTraCuuCauThu = new Button();
            btnGhiNhanKetQua = new Button();
            btnLapLichThiDau = new Button();
            btnTiepNhanDoiBong = new Button();
            btnBangXepHangCauThu = new Button();
            btnBangXepHangDoiBong = new Button();
            pFormContainer = new Panel();
            tlpArrangement.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // tlpArrangement
            // 
            tlpArrangement.AutoScroll = true;
            tlpArrangement.ColumnCount = 2;
            tlpArrangement.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tlpArrangement.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 75F));
            tlpArrangement.Controls.Add(tableLayoutPanel2, 0, 0);
            tlpArrangement.Controls.Add(pFormContainer, 1, 0);
            tlpArrangement.Dock = DockStyle.Fill;
            tlpArrangement.Location = new Point(0, 0);
            tlpArrangement.Name = "tlpArrangement";
            tlpArrangement.RowCount = 2;
            tlpArrangement.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpArrangement.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpArrangement.Size = new Size(1898, 1024);
            tlpArrangement.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(btnThayDoiQuiDinh, 0, 6);
            tableLayoutPanel2.Controls.Add(btnTraCuuCauThu, 0, 5);
            tableLayoutPanel2.Controls.Add(btnGhiNhanKetQua, 0, 4);
            tableLayoutPanel2.Controls.Add(btnLapLichThiDau, 0, 3);
            tableLayoutPanel2.Controls.Add(btnTiepNhanDoiBong, 0, 2);
            tableLayoutPanel2.Controls.Add(btnBangXepHangCauThu, 0, 1);
            tableLayoutPanel2.Controls.Add(btnBangXepHangDoiBong, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Margin = new Padding(0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.Padding = new Padding(0, 0, 25, 0);
            tableLayoutPanel2.RowCount = 8;
            tlpArrangement.SetRowSpan(tableLayoutPanel2, 2);
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel2.Size = new Size(474, 1024);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // btnThayDoiQuiDinh
            // 
            btnThayDoiQuiDinh.Dock = DockStyle.Fill;
            btnThayDoiQuiDinh.FlatAppearance.BorderSize = 0;
            btnThayDoiQuiDinh.FlatStyle = FlatStyle.Flat;
            btnThayDoiQuiDinh.Location = new Point(3, 615);
            btnThayDoiQuiDinh.Name = "btnThayDoiQuiDinh";
            btnThayDoiQuiDinh.Padding = new Padding(25, 0, 0, 0);
            btnThayDoiQuiDinh.Size = new Size(443, 96);
            btnThayDoiQuiDinh.TabIndex = 6;
            btnThayDoiQuiDinh.TabStop = false;
            btnThayDoiQuiDinh.Text = "Thay đổi qui định";
            btnThayDoiQuiDinh.TextAlign = ContentAlignment.MiddleLeft;
            btnThayDoiQuiDinh.UseVisualStyleBackColor = true;
            btnThayDoiQuiDinh.Click += btnThayDoiQuiDinh_Click;
            // 
            // btnTraCuuCauThu
            // 
            btnTraCuuCauThu.Dock = DockStyle.Fill;
            btnTraCuuCauThu.FlatAppearance.BorderSize = 0;
            btnTraCuuCauThu.FlatStyle = FlatStyle.Flat;
            btnTraCuuCauThu.Location = new Point(3, 513);
            btnTraCuuCauThu.Name = "btnTraCuuCauThu";
            btnTraCuuCauThu.Padding = new Padding(25, 0, 0, 0);
            btnTraCuuCauThu.Size = new Size(443, 96);
            btnTraCuuCauThu.TabIndex = 5;
            btnTraCuuCauThu.TabStop = false;
            btnTraCuuCauThu.Text = "Tra cứu cầu thủ";
            btnTraCuuCauThu.TextAlign = ContentAlignment.MiddleLeft;
            btnTraCuuCauThu.UseVisualStyleBackColor = true;
            btnTraCuuCauThu.Click += btnTraCuuCauThu_Click;
            // 
            // btnGhiNhanKetQua
            // 
            btnGhiNhanKetQua.Dock = DockStyle.Fill;
            btnGhiNhanKetQua.FlatAppearance.BorderSize = 0;
            btnGhiNhanKetQua.FlatStyle = FlatStyle.Flat;
            btnGhiNhanKetQua.Location = new Point(3, 411);
            btnGhiNhanKetQua.Name = "btnGhiNhanKetQua";
            btnGhiNhanKetQua.Padding = new Padding(25, 0, 0, 0);
            btnGhiNhanKetQua.Size = new Size(443, 96);
            btnGhiNhanKetQua.TabIndex = 4;
            btnGhiNhanKetQua.TabStop = false;
            btnGhiNhanKetQua.Text = "Ghi nhận kết quả";
            btnGhiNhanKetQua.TextAlign = ContentAlignment.MiddleLeft;
            btnGhiNhanKetQua.UseVisualStyleBackColor = true;
            btnGhiNhanKetQua.Click += btnGhiNhanKetQua_Click;
            // 
            // btnLapLichThiDau
            // 
            btnLapLichThiDau.Dock = DockStyle.Fill;
            btnLapLichThiDau.FlatAppearance.BorderSize = 0;
            btnLapLichThiDau.FlatStyle = FlatStyle.Flat;
            btnLapLichThiDau.Location = new Point(3, 309);
            btnLapLichThiDau.Name = "btnLapLichThiDau";
            btnLapLichThiDau.Padding = new Padding(25, 0, 0, 0);
            btnLapLichThiDau.Size = new Size(443, 96);
            btnLapLichThiDau.TabIndex = 3;
            btnLapLichThiDau.TabStop = false;
            btnLapLichThiDau.Text = "Lập lịch thi đấu";
            btnLapLichThiDau.TextAlign = ContentAlignment.MiddleLeft;
            btnLapLichThiDau.UseVisualStyleBackColor = true;
            btnLapLichThiDau.Click += btnLapLichThiDau_Click;
            // 
            // btnTiepNhanDoiBong
            // 
            btnTiepNhanDoiBong.Dock = DockStyle.Fill;
            btnTiepNhanDoiBong.FlatAppearance.BorderSize = 0;
            btnTiepNhanDoiBong.FlatStyle = FlatStyle.Flat;
            btnTiepNhanDoiBong.Location = new Point(3, 207);
            btnTiepNhanDoiBong.Name = "btnTiepNhanDoiBong";
            btnTiepNhanDoiBong.Padding = new Padding(25, 0, 0, 0);
            btnTiepNhanDoiBong.Size = new Size(443, 96);
            btnTiepNhanDoiBong.TabIndex = 2;
            btnTiepNhanDoiBong.TabStop = false;
            btnTiepNhanDoiBong.Text = "Tiếp nhận đội bóng";
            btnTiepNhanDoiBong.TextAlign = ContentAlignment.MiddleLeft;
            btnTiepNhanDoiBong.UseVisualStyleBackColor = true;
            btnTiepNhanDoiBong.Click += btnTiepNhanDoiBong_Click;
            // 
            // btnBangXepHangCauThu
            // 
            btnBangXepHangCauThu.Dock = DockStyle.Fill;
            btnBangXepHangCauThu.FlatAppearance.BorderSize = 0;
            btnBangXepHangCauThu.FlatStyle = FlatStyle.Flat;
            btnBangXepHangCauThu.Location = new Point(3, 105);
            btnBangXepHangCauThu.Name = "btnBangXepHangCauThu";
            btnBangXepHangCauThu.Padding = new Padding(25, 0, 0, 0);
            btnBangXepHangCauThu.Size = new Size(443, 96);
            btnBangXepHangCauThu.TabIndex = 1;
            btnBangXepHangCauThu.TabStop = false;
            btnBangXepHangCauThu.Text = "Bảng xếp hạng cầu thủ";
            btnBangXepHangCauThu.TextAlign = ContentAlignment.MiddleLeft;
            btnBangXepHangCauThu.UseVisualStyleBackColor = true;
            btnBangXepHangCauThu.Click += btnBangXepHangCauThu_Click;
            // 
            // btnBangXepHangDoiBong
            // 
            btnBangXepHangDoiBong.Dock = DockStyle.Fill;
            btnBangXepHangDoiBong.FlatAppearance.BorderSize = 0;
            btnBangXepHangDoiBong.FlatStyle = FlatStyle.Flat;
            btnBangXepHangDoiBong.Location = new Point(3, 3);
            btnBangXepHangDoiBong.Name = "btnBangXepHangDoiBong";
            btnBangXepHangDoiBong.Padding = new Padding(25, 0, 0, 0);
            btnBangXepHangDoiBong.Size = new Size(443, 96);
            btnBangXepHangDoiBong.TabIndex = 0;
            btnBangXepHangDoiBong.TabStop = false;
            btnBangXepHangDoiBong.Text = "Bảng xếp hạng dội bóng";
            btnBangXepHangDoiBong.TextAlign = ContentAlignment.MiddleLeft;
            btnBangXepHangDoiBong.UseVisualStyleBackColor = true;
            btnBangXepHangDoiBong.Click += btnBangXepHangDoiBong_Click;
            // 
            // pFormContainer
            // 
            pFormContainer.Dock = DockStyle.Fill;
            pFormContainer.Location = new Point(477, 3);
            pFormContainer.Name = "pFormContainer";
            tlpArrangement.SetRowSpan(pFormContainer, 2);
            pFormContainer.Size = new Size(1418, 1018);
            pFormContainer.TabIndex = 1;
            // 
            // GUI_Dashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1898, 1024);
            Controls.Add(tlpArrangement);
            Name = "GUI_Dashboard";
            Text = "Quản lý giải vô địch bóng đá Quốc gia";
            Load += GUI_Dashboard_Load;
            tlpArrangement.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpArrangement;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btnBangXepHangDoiBong;
        private Button btnThayDoiQuiDinh;
        private Button btnTraCuuCauThu;
        private Button btnGhiNhanKetQua;
        private Button btnLapLichThiDau;
        private Button btnTiepNhanDoiBong;
        private Button btnBangXepHangCauThu;
        private Panel pFormContainer;
    }
}