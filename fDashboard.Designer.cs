namespace LibraryManagement
{
    partial class fDashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fDashboard));
            pnlStatistics = new Panel();
            pnlTotalBooks = new Panel();
            pnlTotalMembers = new Panel();
            pnlCurrentBorrows = new Panel();
            pnlOverdue = new Panel();
            lblBooksIcon = new PictureBox();
            lblBooksValue = new Label();
            lblBooksTitle = new Label();
            lblMembersTitle = new Label();
            lblMembersValue = new Label();
            lblMembersIcon = new PictureBox();
            pictureBox1 = new PictureBox();
            lblBorrowsTitle = new Label();
            lblBorrowsValue = new Label();
            pictureBox2 = new PictureBox();
            lblOverdueTitle = new Label();
            lblOverdueValue = new Label();
            pnlRecentActivities = new Panel();
            lblRecentTitle = new Label();
            dgvRecentActivities = new DataGridView();
            btnRefreshActivities = new Button();
            pnlPopularBooks = new Panel();
            lblPopularTitle = new Label();
            lvPopularBooks = new ListView();
            btnViewReports = new Button();
            pnlCharts = new Panel();
            lblChartsTitle = new Label();
            pnlChart = new Panel();
            btnExportReport = new Button();
            pnlStatistics.SuspendLayout();
            pnlTotalBooks.SuspendLayout();
            pnlTotalMembers.SuspendLayout();
            pnlCurrentBorrows.SuspendLayout();
            pnlOverdue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lblBooksIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lblMembersIcon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            pnlRecentActivities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecentActivities).BeginInit();
            pnlPopularBooks.SuspendLayout();
            pnlCharts.SuspendLayout();
            SuspendLayout();
            // 
            // pnlStatistics
            // 
            pnlStatistics.BackColor = Color.Transparent;
            pnlStatistics.Controls.Add(pnlOverdue);
            pnlStatistics.Controls.Add(pnlCurrentBorrows);
            pnlStatistics.Controls.Add(pnlTotalMembers);
            pnlStatistics.Controls.Add(pnlTotalBooks);
            pnlStatistics.Location = new Point(20, 20);
            pnlStatistics.Name = "pnlStatistics";
            pnlStatistics.Size = new Size(930, 120);
            pnlStatistics.TabIndex = 0;
            // 
            // pnlTotalBooks
            // 
            pnlTotalBooks.BackColor = Color.White;
            pnlTotalBooks.Controls.Add(lblBooksTitle);
            pnlTotalBooks.Controls.Add(lblBooksValue);
            pnlTotalBooks.Controls.Add(lblBooksIcon);
            pnlTotalBooks.Location = new Point(5, 10);
            pnlTotalBooks.Name = "pnlTotalBooks";
            pnlTotalBooks.Size = new Size(220, 100);
            pnlTotalBooks.TabIndex = 0;
            // 
            // pnlTotalMembers
            // 
            pnlTotalMembers.BackColor = Color.White;
            pnlTotalMembers.Controls.Add(lblMembersIcon);
            pnlTotalMembers.Controls.Add(lblMembersValue);
            pnlTotalMembers.Controls.Add(lblMembersTitle);
            pnlTotalMembers.Location = new Point(235, 10);
            pnlTotalMembers.Name = "pnlTotalMembers";
            pnlTotalMembers.Size = new Size(220, 100);
            pnlTotalMembers.TabIndex = 1;
            // 
            // pnlCurrentBorrows
            // 
            pnlCurrentBorrows.BackColor = Color.White;
            pnlCurrentBorrows.Controls.Add(lblBorrowsValue);
            pnlCurrentBorrows.Controls.Add(lblBorrowsTitle);
            pnlCurrentBorrows.Controls.Add(pictureBox1);
            pnlCurrentBorrows.Location = new Point(465, 10);
            pnlCurrentBorrows.Name = "pnlCurrentBorrows";
            pnlCurrentBorrows.Size = new Size(220, 100);
            pnlCurrentBorrows.TabIndex = 2;
            // 
            // pnlOverdue
            // 
            pnlOverdue.BackColor = Color.White;
            pnlOverdue.Controls.Add(lblOverdueValue);
            pnlOverdue.Controls.Add(lblOverdueTitle);
            pnlOverdue.Controls.Add(pictureBox2);
            pnlOverdue.Location = new Point(695, 10);
            pnlOverdue.Name = "pnlOverdue";
            pnlOverdue.Size = new Size(220, 100);
            pnlOverdue.TabIndex = 3;
            // 
            // lblBooksIcon
            // 
            lblBooksIcon.Image = (Image)resources.GetObject("lblBooksIcon.Image");
            lblBooksIcon.Location = new Point(15, 30);
            lblBooksIcon.Name = "lblBooksIcon";
            lblBooksIcon.Size = new Size(34, 34);
            lblBooksIcon.SizeMode = PictureBoxSizeMode.Zoom;
            lblBooksIcon.TabIndex = 0;
            lblBooksIcon.TabStop = false;
            // 
            // lblBooksValue
            // 
            lblBooksValue.AutoSize = true;
            lblBooksValue.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBooksValue.ForeColor = Color.FromArgb(210, 121, 106);
            lblBooksValue.Location = new Point(121, 40);
            lblBooksValue.Name = "lblBooksValue";
            lblBooksValue.Size = new Size(43, 50);
            lblBooksValue.TabIndex = 1;
            lblBooksValue.Text = "0";
            // 
            // lblBooksTitle
            // 
            lblBooksTitle.AutoSize = true;
            lblBooksTitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBooksTitle.ForeColor = Color.Gray;
            lblBooksTitle.Location = new Point(86, 20);
            lblBooksTitle.Name = "lblBooksTitle";
            lblBooksTitle.Size = new Size(114, 20);
            lblBooksTitle.TabIndex = 2;
            lblBooksTitle.Text = "TỔNG SỐ SÁCH";
            // 
            // lblMembersTitle
            // 
            lblMembersTitle.AutoSize = true;
            lblMembersTitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMembersTitle.ForeColor = Color.Gray;
            lblMembersTitle.Location = new Point(104, 20);
            lblMembersTitle.Name = "lblMembersTitle";
            lblMembersTitle.Size = new Size(96, 20);
            lblMembersTitle.TabIndex = 3;
            lblMembersTitle.Text = "THÀNH VIÊN";
            // 
            // lblMembersValue
            // 
            lblMembersValue.AutoSize = true;
            lblMembersValue.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMembersValue.ForeColor = Color.FromArgb(52, 152, 219);
            lblMembersValue.Location = new Point(135, 40);
            lblMembersValue.Name = "lblMembersValue";
            lblMembersValue.Size = new Size(43, 50);
            lblMembersValue.TabIndex = 3;
            lblMembersValue.Text = "0";
            // 
            // lblMembersIcon
            // 
            lblMembersIcon.Image = (Image)resources.GetObject("lblMembersIcon.Image");
            lblMembersIcon.Location = new Point(15, 30);
            lblMembersIcon.Name = "lblMembersIcon";
            lblMembersIcon.Size = new Size(34, 34);
            lblMembersIcon.SizeMode = PictureBoxSizeMode.Zoom;
            lblMembersIcon.TabIndex = 3;
            lblMembersIcon.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(15, 30);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(34, 34);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // lblBorrowsTitle
            // 
            lblBorrowsTitle.AutoSize = true;
            lblBorrowsTitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBorrowsTitle.ForeColor = Color.Gray;
            lblBorrowsTitle.Location = new Point(64, 20);
            lblBorrowsTitle.Name = "lblBorrowsTitle";
            lblBorrowsTitle.Size = new Size(136, 20);
            lblBorrowsTitle.TabIndex = 4;
            lblBorrowsTitle.Text = "ĐANG CHO MƯỢN";
            // 
            // lblBorrowsValue
            // 
            lblBorrowsValue.AutoSize = true;
            lblBorrowsValue.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBorrowsValue.ForeColor = Color.FromArgb(46, 204, 113);
            lblBorrowsValue.Location = new Point(110, 40);
            lblBorrowsValue.Name = "lblBorrowsValue";
            lblBorrowsValue.Size = new Size(43, 50);
            lblBorrowsValue.TabIndex = 4;
            lblBorrowsValue.Text = "0";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(15, 30);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(34, 34);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // lblOverdueTitle
            // 
            lblOverdueTitle.AutoSize = true;
            lblOverdueTitle.BackColor = Color.White;
            lblOverdueTitle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOverdueTitle.ForeColor = Color.Gray;
            lblOverdueTitle.Location = new Point(104, 20);
            lblOverdueTitle.Name = "lblOverdueTitle";
            lblOverdueTitle.Size = new Size(76, 20);
            lblOverdueTitle.TabIndex = 5;
            lblOverdueTitle.Text = "QUÁ HẠN";
            // 
            // lblOverdueValue
            // 
            lblOverdueValue.AutoSize = true;
            lblOverdueValue.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOverdueValue.ForeColor = Color.FromArgb(231, 76, 60);
            lblOverdueValue.Location = new Point(121, 40);
            lblOverdueValue.Name = "lblOverdueValue";
            lblOverdueValue.Size = new Size(43, 50);
            lblOverdueValue.TabIndex = 5;
            lblOverdueValue.Text = "0";
            // 
            // pnlRecentActivities
            // 
            pnlRecentActivities.BackColor = Color.White;
            pnlRecentActivities.Controls.Add(btnRefreshActivities);
            pnlRecentActivities.Controls.Add(dgvRecentActivities);
            pnlRecentActivities.Controls.Add(lblRecentTitle);
            pnlRecentActivities.Location = new Point(20, 150);
            pnlRecentActivities.Name = "pnlRecentActivities";
            pnlRecentActivities.Size = new Size(455, 300);
            pnlRecentActivities.TabIndex = 1;
            // 
            // lblRecentTitle
            // 
            lblRecentTitle.AutoSize = true;
            lblRecentTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRecentTitle.ForeColor = Color.FromArgb(210, 121, 106);
            lblRecentTitle.Location = new Point(15, 15);
            lblRecentTitle.Name = "lblRecentTitle";
            lblRecentTitle.Size = new Size(229, 28);
            lblRecentTitle.TabIndex = 0;
            lblRecentTitle.Text = "HOẠT ĐỘNG GẦN ĐÂY";
            // 
            // dgvRecentActivities
            // 
            dgvRecentActivities.AllowUserToAddRows = false;
            dgvRecentActivities.AllowUserToDeleteRows = false;
            dgvRecentActivities.BackgroundColor = Color.White;
            dgvRecentActivities.BorderStyle = BorderStyle.None;
            dgvRecentActivities.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecentActivities.Location = new Point(15, 50);
            dgvRecentActivities.Name = "dgvRecentActivities";
            dgvRecentActivities.ReadOnly = true;
            dgvRecentActivities.RowHeadersVisible = false;
            dgvRecentActivities.RowHeadersWidth = 51;
            dgvRecentActivities.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecentActivities.Size = new Size(425, 200);
            dgvRecentActivities.TabIndex = 1;
            // 
            // btnRefreshActivities
            // 
            btnRefreshActivities.BackColor = Color.FromArgb(129, 195, 215);
            btnRefreshActivities.FlatAppearance.BorderSize = 0;
            btnRefreshActivities.FlatStyle = FlatStyle.Flat;
            btnRefreshActivities.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefreshActivities.ForeColor = Color.White;
            btnRefreshActivities.Location = new Point(340, 260);
            btnRefreshActivities.Name = "btnRefreshActivities";
            btnRefreshActivities.Size = new Size(100, 30);
            btnRefreshActivities.TabIndex = 2;
            btnRefreshActivities.Text = "Làm mới";
            btnRefreshActivities.UseVisualStyleBackColor = false;
            // 
            // pnlPopularBooks
            // 
            pnlPopularBooks.BackColor = Color.White;
            pnlPopularBooks.Controls.Add(btnViewReports);
            pnlPopularBooks.Controls.Add(lvPopularBooks);
            pnlPopularBooks.Controls.Add(lblPopularTitle);
            pnlPopularBooks.Location = new Point(485, 150);
            pnlPopularBooks.Name = "pnlPopularBooks";
            pnlPopularBooks.Size = new Size(455, 300);
            pnlPopularBooks.TabIndex = 2;
            // 
            // lblPopularTitle
            // 
            lblPopularTitle.AutoSize = true;
            lblPopularTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPopularTitle.ForeColor = Color.FromArgb(210, 121, 106);
            lblPopularTitle.Location = new Point(15, 15);
            lblPopularTitle.Name = "lblPopularTitle";
            lblPopularTitle.Size = new Size(287, 28);
            lblPopularTitle.TabIndex = 3;
            lblPopularTitle.Text = "SÁCH PHỔ BIẾN / THỐNG KÊ";
            // 
            // lvPopularBooks
            // 
            lvPopularBooks.FullRowSelect = true;
            lvPopularBooks.GridLines = true;
            lvPopularBooks.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lvPopularBooks.Location = new Point(15, 50);
            lvPopularBooks.Name = "lvPopularBooks";
            lvPopularBooks.Size = new Size(425, 200);
            lvPopularBooks.TabIndex = 4;
            lvPopularBooks.UseCompatibleStateImageBehavior = false;
            lvPopularBooks.View = View.Details;
            // 
            // btnViewReports
            // 
            btnViewReports.BackColor = Color.FromArgb(231, 76, 60);
            btnViewReports.FlatAppearance.BorderSize = 0;
            btnViewReports.FlatStyle = FlatStyle.Flat;
            btnViewReports.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnViewReports.ForeColor = Color.White;
            btnViewReports.Location = new Point(320, 260);
            btnViewReports.Name = "btnViewReports";
            btnViewReports.Size = new Size(120, 30);
            btnViewReports.TabIndex = 3;
            btnViewReports.Text = "Xem báo cáo";
            btnViewReports.UseVisualStyleBackColor = false;
            // 
            // pnlCharts
            // 
            pnlCharts.BackColor = Color.White;
            pnlCharts.Controls.Add(btnExportReport);
            pnlCharts.Controls.Add(pnlChart);
            pnlCharts.Controls.Add(lblChartsTitle);
            pnlCharts.Location = new Point(20, 460);
            pnlCharts.Name = "pnlCharts";
            pnlCharts.Size = new Size(930, 180);
            pnlCharts.TabIndex = 3;
            // 
            // lblChartsTitle
            // 
            lblChartsTitle.AutoSize = true;
            lblChartsTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblChartsTitle.ForeColor = Color.FromArgb(210, 121, 106);
            lblChartsTitle.Location = new Point(15, 15);
            lblChartsTitle.Name = "lblChartsTitle";
            lblChartsTitle.Size = new Size(250, 28);
            lblChartsTitle.TabIndex = 0;
            lblChartsTitle.Text = "THỐNG KÊ THEO THÁNG";
            // 
            // pnlChart
            // 
            pnlChart.Location = new Point(15, 50);
            pnlChart.Name = "pnlChart";
            pnlChart.Size = new Size(900, 120);
            pnlChart.TabIndex = 1;
            // 
            // btnExportReport
            // 
            btnExportReport.BackColor = Color.FromArgb(129, 195, 215);
            btnExportReport.FlatAppearance.BorderSize = 0;
            btnExportReport.FlatStyle = FlatStyle.Flat;
            btnExportReport.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExportReport.ForeColor = Color.White;
            btnExportReport.Location = new Point(786, 15);
            btnExportReport.Name = "btnExportReport";
            btnExportReport.Size = new Size(120, 30);
            btnExportReport.TabIndex = 3;
            btnExportReport.Text = "Xuất báo cáo";
            btnExportReport.UseVisualStyleBackColor = false;
            // 
            // fDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(249, 241, 240);
            ClientSize = new Size(970, 650);
            Controls.Add(pnlCharts);
            Controls.Add(pnlPopularBooks);
            Controls.Add(pnlRecentActivities);
            Controls.Add(pnlStatistics);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fDashboard";
            Text = "Dashboard";
            pnlStatistics.ResumeLayout(false);
            pnlTotalBooks.ResumeLayout(false);
            pnlTotalBooks.PerformLayout();
            pnlTotalMembers.ResumeLayout(false);
            pnlTotalMembers.PerformLayout();
            pnlCurrentBorrows.ResumeLayout(false);
            pnlCurrentBorrows.PerformLayout();
            pnlOverdue.ResumeLayout(false);
            pnlOverdue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lblBooksIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)lblMembersIcon).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            pnlRecentActivities.ResumeLayout(false);
            pnlRecentActivities.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecentActivities).EndInit();
            pnlPopularBooks.ResumeLayout(false);
            pnlPopularBooks.PerformLayout();
            pnlCharts.ResumeLayout(false);
            pnlCharts.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlStatistics;
        private Panel pnlOverdue;
        private Panel pnlCurrentBorrows;
        private Panel pnlTotalMembers;
        private Panel pnlTotalBooks;
        private PictureBox lblBooksIcon;
        private Label lblBooksTitle;
        private Label lblBooksValue;
        private PictureBox pictureBox1;
        private PictureBox lblMembersIcon;
        private Label lblMembersValue;
        private Label lblMembersTitle;
        private Label lblBorrowsTitle;
        private PictureBox pictureBox2;
        private Label lblBorrowsValue;
        private Label lblOverdueValue;
        private Label lblOverdueTitle;
        private Panel pnlRecentActivities;
        private Label lblRecentTitle;
        private DataGridView dgvRecentActivities;
        private Button btnRefreshActivities;
        private Panel pnlPopularBooks;
        private ListView lvPopularBooks;
        private Label lblPopularTitle;
        private Button btnViewReports;
        private Panel pnlCharts;
        private Label lblChartsTitle;
        private Panel pnlChart;
        private Button btnExportReport;
    }
}