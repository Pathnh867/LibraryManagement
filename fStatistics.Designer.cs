namespace LibraryManagement
{
    partial class fStatistics
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
            pnlFilters = new Panel();
            btnGenerate = new Button();
            cboReportType = new ComboBox();
            lblReportType = new Label();
            dtpToDate = new DateTimePicker();
            lblToDate = new Label();
            dtpFromDate = new DateTimePicker();
            lblFromDate = new Label();
            lblTitle = new Label();
            tcReports = new TabControl();
            tpOverview = new TabPage();
            dgvOverview = new DataGridView();
            tpBooks = new TabPage();
            dgvBooks = new DataGridView();
            tpMembers = new TabPage();
            dgvMembers = new DataGridView();
            tpOverdue = new TabPage();
            dgvOverdue = new DataGridView();
            pnlExport = new Panel();
            btnPrint = new Button();
            btnExportPdf = new Button();
            btnExportExcel = new Button();
            lblExport = new Label();
            toolTip1 = new ToolTip(components);
            pnlFilters.SuspendLayout();
            tcReports.SuspendLayout();
            tpOverview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOverview).BeginInit();
            tpBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            tpMembers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMembers).BeginInit();
            tpOverdue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOverdue).BeginInit();
            pnlExport.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFilters
            // 
            pnlFilters.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlFilters.BackColor = Color.White;
            pnlFilters.Controls.Add(btnGenerate);
            pnlFilters.Controls.Add(cboReportType);
            pnlFilters.Controls.Add(lblReportType);
            pnlFilters.Controls.Add(dtpToDate);
            pnlFilters.Controls.Add(lblToDate);
            pnlFilters.Controls.Add(dtpFromDate);
            pnlFilters.Controls.Add(lblFromDate);
            pnlFilters.Controls.Add(lblTitle);
            pnlFilters.Location = new Point(20, 20);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Size = new Size(930, 80);
            pnlFilters.TabIndex = 0;
            // 
            // btnGenerate
            // 
            btnGenerate.BackColor = Color.FromArgb(129, 195, 215);
            btnGenerate.Cursor = Cursors.Hand;
            btnGenerate.FlatAppearance.BorderSize = 0;
            btnGenerate.FlatStyle = FlatStyle.Flat;
            btnGenerate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGenerate.ForeColor = Color.White;
            btnGenerate.Location = new Point(770, 42);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(120, 30);
            btnGenerate.TabIndex = 3;
            btnGenerate.Text = "Tạo báo cáo";
            toolTip1.SetToolTip(btnGenerate, "Tạo báo cáo với thông tin đã chọn");
            btnGenerate.UseVisualStyleBackColor = false;
            // 
            // cboReportType
            // 
            cboReportType.DropDownStyle = ComboBoxStyle.DropDownList;
            cboReportType.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cboReportType.FormattingEnabled = true;
            cboReportType.Items.AddRange(new object[] { "Tổng quan", "Theo sách", "Theo thành viên", "Sách quá hạn" });
            cboReportType.Location = new Point(600, 42);
            cboReportType.Name = "cboReportType";
            cboReportType.Size = new Size(150, 28);
            cboReportType.TabIndex = 2;
            toolTip1.SetToolTip(cboReportType, "Chọn loại báo cáo muốn tạo");
            // 
            // lblReportType
            // 
            lblReportType.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblReportType.ForeColor = Color.FromArgb(94, 76, 76);
            lblReportType.Location = new Point(500, 45);
            lblReportType.Name = "lblReportType";
            lblReportType.Size = new Size(100, 20);
            lblReportType.TabIndex = 5;
            lblReportType.Text = "Loại báo cáo:";
            lblReportType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtpToDate
            // 
            dtpToDate.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpToDate.Format = DateTimePickerFormat.Short;
            dtpToDate.Location = new Point(330, 42);
            dtpToDate.Name = "dtpToDate";
            dtpToDate.Size = new Size(150, 27);
            dtpToDate.TabIndex = 1;
            toolTip1.SetToolTip(dtpToDate, "Chọn ngày kết thúc của khoảng thời gian báo cáo");
            // 
            // lblToDate
            // 
            lblToDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblToDate.ForeColor = Color.FromArgb(94, 76, 76);
            lblToDate.Location = new Point(250, 45);
            lblToDate.Name = "lblToDate";
            lblToDate.Size = new Size(80, 20);
            lblToDate.TabIndex = 3;
            lblToDate.Text = "Đến ngày:";
            lblToDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dtpFromDate
            // 
            dtpFromDate.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpFromDate.Format = DateTimePickerFormat.Short;
            dtpFromDate.Location = new Point(85, 42);
            dtpFromDate.Name = "dtpFromDate";
            dtpFromDate.Size = new Size(150, 27);
            dtpFromDate.TabIndex = 0;
            toolTip1.SetToolTip(dtpFromDate, "Chọn ngày bắt đầu của khoảng thời gian báo cáo");
            // 
            // lblFromDate
            // 
            lblFromDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFromDate.ForeColor = Color.FromArgb(94, 76, 76);
            lblFromDate.Location = new Point(15, 45);
            lblFromDate.Name = "lblFromDate";
            lblFromDate.Size = new Size(70, 20);
            lblFromDate.TabIndex = 1;
            lblFromDate.Text = "Từ ngày:";
            lblFromDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(210, 121, 106);
            lblTitle.Location = new Point(15, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(209, 28);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "BÁO CÁO THỐNG KÊ";
            // 
            // tcReports
            // 
            tcReports.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tcReports.Controls.Add(tpOverview);
            tcReports.Controls.Add(tpBooks);
            tcReports.Controls.Add(tpMembers);
            tcReports.Controls.Add(tpOverdue);
            tcReports.Font = new Font("Segoe UI", 10F);
            tcReports.Location = new Point(20, 110);
            tcReports.Name = "tcReports";
            tcReports.SelectedIndex = 0;
            tcReports.Size = new Size(930, 400);
            tcReports.TabIndex = 0;
            toolTip1.SetToolTip(tcReports, "Dữ liệu báo cáo được hiển thị theo từng tab");
            // 
            // tpOverview
            // 
            tpOverview.BackColor = Color.White;
            tpOverview.Controls.Add(dgvOverview);
            tpOverview.Location = new Point(4, 32);
            tpOverview.Name = "tpOverview";
            tpOverview.Padding = new Padding(10);
            tpOverview.Size = new Size(922, 364);
            tpOverview.TabIndex = 0;
            tpOverview.Text = "Tổng quan";
            // 
            // dgvOverview
            // 
            dgvOverview.AllowUserToAddRows = false;
            dgvOverview.AllowUserToDeleteRows = false;
            dgvOverview.AllowUserToResizeColumns = false;
            dgvOverview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOverview.BackgroundColor = Color.White;
            dgvOverview.BorderStyle = BorderStyle.None;
            dgvOverview.ColumnHeadersHeight = 29;
            dgvOverview.Dock = DockStyle.Fill;
            dgvOverview.Location = new Point(10, 10);
            dgvOverview.Name = "dgvOverview";
            dgvOverview.ReadOnly = true;
            dgvOverview.RowHeadersVisible = false;
            dgvOverview.RowHeadersWidth = 51;
            dgvOverview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOverview.Size = new Size(902, 344);
            dgvOverview.TabIndex = 0;
            // 
            // tpBooks
            // 
            tpBooks.BackColor = Color.White;
            tpBooks.Controls.Add(dgvBooks);
            tpBooks.Location = new Point(4, 32);
            tpBooks.Name = "tpBooks";
            tpBooks.Padding = new Padding(3);
            tpBooks.Size = new Size(922, 364);
            tpBooks.TabIndex = 1;
            tpBooks.Text = "Thống kê sách";
            // 
            // dgvBooks
            // 
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AllowUserToDeleteRows = false;
            dgvBooks.AllowUserToResizeColumns = false;
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.BackgroundColor = Color.White;
            dgvBooks.BorderStyle = BorderStyle.None;
            dgvBooks.ColumnHeadersHeight = 29;
            dgvBooks.Dock = DockStyle.Fill;
            dgvBooks.Location = new Point(3, 3);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.ReadOnly = true;
            dgvBooks.RowHeadersVisible = false;
            dgvBooks.RowHeadersWidth = 51;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.Size = new Size(916, 358);
            dgvBooks.TabIndex = 1;
            // 
            // tpMembers
            // 
            tpMembers.BackColor = Color.White;
            tpMembers.Controls.Add(dgvMembers);
            tpMembers.Location = new Point(4, 32);
            tpMembers.Name = "tpMembers";
            tpMembers.Padding = new Padding(3);
            tpMembers.Size = new Size(922, 364);
            tpMembers.TabIndex = 2;
            tpMembers.Text = "Thống kê thành viên";
            // 
            // dgvMembers
            // 
            dgvMembers.AllowUserToAddRows = false;
            dgvMembers.AllowUserToDeleteRows = false;
            dgvMembers.AllowUserToResizeColumns = false;
            dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMembers.BackgroundColor = Color.White;
            dgvMembers.BorderStyle = BorderStyle.None;
            dgvMembers.ColumnHeadersHeight = 29;
            dgvMembers.Dock = DockStyle.Fill;
            dgvMembers.Location = new Point(3, 3);
            dgvMembers.Name = "dgvMembers";
            dgvMembers.ReadOnly = true;
            dgvMembers.RowHeadersVisible = false;
            dgvMembers.RowHeadersWidth = 51;
            dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMembers.Size = new Size(916, 358);
            dgvMembers.TabIndex = 2;
            // 
            // tpOverdue
            // 
            tpOverdue.BackColor = Color.White;
            tpOverdue.Controls.Add(dgvOverdue);
            tpOverdue.Location = new Point(4, 32);
            tpOverdue.Name = "tpOverdue";
            tpOverdue.Padding = new Padding(3);
            tpOverdue.Size = new Size(922, 364);
            tpOverdue.TabIndex = 3;
            tpOverdue.Text = "Sách quá hạn";
            // 
            // dgvOverdue
            // 
            dgvOverdue.AllowUserToAddRows = false;
            dgvOverdue.AllowUserToDeleteRows = false;
            dgvOverdue.AllowUserToResizeColumns = false;
            dgvOverdue.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOverdue.BackgroundColor = Color.White;
            dgvOverdue.BorderStyle = BorderStyle.None;
            dgvOverdue.ColumnHeadersHeight = 29;
            dgvOverdue.Dock = DockStyle.Fill;
            dgvOverdue.Location = new Point(3, 3);
            dgvOverdue.Name = "dgvOverdue";
            dgvOverdue.ReadOnly = true;
            dgvOverdue.RowHeadersVisible = false;
            dgvOverdue.RowHeadersWidth = 51;
            dgvOverdue.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOverdue.Size = new Size(916, 358);
            dgvOverdue.TabIndex = 2;
            // 
            // pnlExport
            // 
            pnlExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlExport.BackColor = Color.White;
            pnlExport.Controls.Add(btnPrint);
            pnlExport.Controls.Add(btnExportPdf);
            pnlExport.Controls.Add(btnExportExcel);
            pnlExport.Controls.Add(lblExport);
            pnlExport.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnlExport.Location = new Point(20, 520);
            pnlExport.Name = "pnlExport";
            pnlExport.Size = new Size(930, 60);
            pnlExport.TabIndex = 2;
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.FromArgb(210, 121, 106);
            btnPrint.Cursor = Cursors.Hand;
            btnPrint.FlatAppearance.BorderSize = 0;
            btnPrint.FlatStyle = FlatStyle.Flat;
            btnPrint.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPrint.ForeColor = Color.White;
            btnPrint.Location = new Point(550, 15);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(115, 35);
            btnPrint.TabIndex = 0;
            btnPrint.Text = "🖨️ In";
            toolTip1.SetToolTip(btnPrint, "In báo cáo trực tiếp");
            btnPrint.UseVisualStyleBackColor = false;
            // 
            // btnExportPdf
            // 
            btnExportPdf.BackColor = Color.FromArgb(231, 76, 60);
            btnExportPdf.Cursor = Cursors.Hand;
            btnExportPdf.FlatAppearance.BorderSize = 0;
            btnExportPdf.FlatStyle = FlatStyle.Flat;
            btnExportPdf.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExportPdf.ForeColor = Color.White;
            btnExportPdf.Location = new Point(790, 15);
            btnExportPdf.Name = "btnExportPdf";
            btnExportPdf.Size = new Size(115, 35);
            btnExportPdf.TabIndex = 2;
            btnExportPdf.Text = "📄 Xuất PDF";
            toolTip1.SetToolTip(btnExportPdf, "Xuất báo cáo dạng file PDF");
            btnExportPdf.UseVisualStyleBackColor = false;
            // 
            // btnExportExcel
            // 
            btnExportExcel.BackColor = Color.FromArgb(46, 204, 113);
            btnExportExcel.Cursor = Cursors.Hand;
            btnExportExcel.FlatAppearance.BorderSize = 0;
            btnExportExcel.FlatStyle = FlatStyle.Flat;
            btnExportExcel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExportExcel.ForeColor = Color.White;
            btnExportExcel.Location = new Point(670, 15);
            btnExportExcel.Name = "btnExportExcel";
            btnExportExcel.Size = new Size(115, 35);
            btnExportExcel.TabIndex = 1;
            btnExportExcel.Text = "📊 Xuất Excel";
            toolTip1.SetToolTip(btnExportExcel, "Xuất dữ liệu ra file Excel (.xlsx)");
            btnExportExcel.UseVisualStyleBackColor = false;
            // 
            // lblExport
            // 
            lblExport.AutoSize = true;
            lblExport.BackColor = Color.White;
            lblExport.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblExport.ForeColor = Color.FromArgb(210, 121, 106);
            lblExport.Location = new Point(15, 15);
            lblExport.Name = "lblExport";
            lblExport.Size = new Size(160, 28);
            lblExport.TabIndex = 0;
            lblExport.Text = "XUẤT BÁO CÁO";
            // 
            // toolTip1
            // 
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            // 
            // fStatistics
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(249, 241, 240);
            ClientSize = new Size(970, 650);
            Controls.Add(pnlExport);
            Controls.Add(tcReports);
            Controls.Add(pnlFilters);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fStatistics";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thống kê & Báo cáo";
            pnlFilters.ResumeLayout(false);
            pnlFilters.PerformLayout();
            tcReports.ResumeLayout(false);
            tpOverview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOverview).EndInit();
            tpBooks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            tpMembers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMembers).EndInit();
            tpOverdue.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvOverdue).EndInit();
            pnlExport.ResumeLayout(false);
            pnlExport.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlFilters;
        private Label lblTitle;
        private Label lblFromDate;
        private DateTimePicker dtpFromDate;
        private ComboBox cboReportType;
        private Label lblReportType;
        private DateTimePicker dtpToDate;
        private Label lblToDate;
        private Button btnGenerate;
        private TabControl tcReports;
        private TabPage tpOverview;
        private TabPage tpBooks;
        private TabPage tpMembers;
        private TabPage tpOverdue;
        private DataGridView dgvOverview;
        private DataGridView dgvBooks;
        private DataGridView dgvMembers;
        private DataGridView dgvOverdue;
        private Panel pnlExport;
        private Button btnExportExcel;
        private Label lblExport;
        private Button btnExportPdf;
        private Button btnPrint;
        private ToolTip toolTip1;
    }
}