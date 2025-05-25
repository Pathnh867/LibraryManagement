namespace LibraryManagement
{
    partial class fLostBookManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fLostBookManagement));
            pnlLostBookInfo = new Panel();
            lblNotes = new Label();
            txtReason = new TextBox();
            lblReason = new Label();
            dateTimePicker1 = new DateTimePicker();
            cboEmployee = new ComboBox();
            txtBookTitle = new TextBox();
            btnSelectCopy = new Button();
            txtDescription = new TextBox();
            lblReportDate = new Label();
            lblEmployee = new Label();
            lblBookTitle = new Label();
            txtCopyId = new TextBox();
            lblCopyId = new Label();
            txtLostBookId = new TextBox();
            lblLostBookId = new Label();
            lblLocationInfo = new Label();
            pnlSearch = new Panel();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            pnlDataGrid = new Panel();
            dgvLocations = new DataGridView();
            pictureBox1 = new PictureBox();
            btnRefresh = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            lblLocationList = new Label();
            pnlLostBookInfo.SuspendLayout();
            pnlSearch.SuspendLayout();
            pnlDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLocations).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnlLostBookInfo
            // 
            pnlLostBookInfo.BackColor = Color.White;
            pnlLostBookInfo.Controls.Add(lblNotes);
            pnlLostBookInfo.Controls.Add(txtReason);
            pnlLostBookInfo.Controls.Add(lblReason);
            pnlLostBookInfo.Controls.Add(dateTimePicker1);
            pnlLostBookInfo.Controls.Add(cboEmployee);
            pnlLostBookInfo.Controls.Add(txtBookTitle);
            pnlLostBookInfo.Controls.Add(btnSelectCopy);
            pnlLostBookInfo.Controls.Add(txtDescription);
            pnlLostBookInfo.Controls.Add(lblReportDate);
            pnlLostBookInfo.Controls.Add(lblEmployee);
            pnlLostBookInfo.Controls.Add(lblBookTitle);
            pnlLostBookInfo.Controls.Add(txtCopyId);
            pnlLostBookInfo.Controls.Add(lblCopyId);
            pnlLostBookInfo.Controls.Add(txtLostBookId);
            pnlLostBookInfo.Controls.Add(lblLostBookId);
            pnlLostBookInfo.Controls.Add(lblLocationInfo);
            pnlLostBookInfo.Location = new Point(20, 20);
            pnlLostBookInfo.Name = "pnlLostBookInfo";
            pnlLostBookInfo.Size = new Size(930, 280);
            pnlLostBookInfo.TabIndex = 1;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.BackColor = Color.White;
            lblNotes.ForeColor = Color.FromArgb(94, 76, 76);
            lblNotes.Location = new Point(450, 125);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(61, 20);
            lblNotes.TabIndex = 17;
            lblNotes.Text = "Ghi chú:";
            // 
            // txtReason
            // 
            txtReason.Location = new Point(550, 52);
            txtReason.MaxLength = 200;
            txtReason.Multiline = true;
            txtReason.Name = "txtReason";
            txtReason.Size = new Size(350, 50);
            txtReason.TabIndex = 4;
            // 
            // lblReason
            // 
            lblReason.AutoSize = true;
            lblReason.BackColor = Color.White;
            lblReason.ForeColor = Color.FromArgb(94, 76, 76);
            lblReason.Location = new Point(450, 55);
            lblReason.Name = "lblReason";
            lblReason.Size = new Size(47, 20);
            lblReason.TabIndex = 15;
            lblReason.Text = "Lý do:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(155, 192);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(126, 27);
            dateTimePicker1.TabIndex = 3;
            // 
            // cboEmployee
            // 
            cboEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEmployee.FormattingEnabled = true;
            cboEmployee.Location = new Point(155, 157);
            cboEmployee.Name = "cboEmployee";
            cboEmployee.Size = new Size(250, 28);
            cboEmployee.TabIndex = 2;
            // 
            // txtBookTitle
            // 
            txtBookTitle.Location = new Point(155, 122);
            txtBookTitle.Name = "txtBookTitle";
            txtBookTitle.ReadOnly = true;
            txtBookTitle.Size = new Size(250, 27);
            txtBookTitle.TabIndex = 12;
            // 
            // btnSelectCopy
            // 
            btnSelectCopy.BackColor = Color.MediumAquamarine;
            btnSelectCopy.FlatAppearance.BorderSize = 0;
            btnSelectCopy.FlatStyle = FlatStyle.Flat;
            btnSelectCopy.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSelectCopy.ForeColor = Color.White;
            btnSelectCopy.Location = new Point(315, 87);
            btnSelectCopy.Name = "btnSelectCopy";
            btnSelectCopy.Size = new Size(80, 27);
            btnSelectCopy.TabIndex = 1;
            btnSelectCopy.Text = "Chọn";
            btnSelectCopy.UseVisualStyleBackColor = false;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(550, 122);
            txtDescription.MaxLength = 500;
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(350, 130);
            txtDescription.TabIndex = 5;
            // 
            // lblReportDate
            // 
            lblReportDate.AutoSize = true;
            lblReportDate.BackColor = Color.White;
            lblReportDate.ForeColor = Color.FromArgb(94, 76, 76);
            lblReportDate.Location = new Point(15, 195);
            lblReportDate.Name = "lblReportDate";
            lblReportDate.Size = new Size(105, 20);
            lblReportDate.TabIndex = 9;
            lblReportDate.Text = "Ngày báo cáo:";
            // 
            // lblEmployee
            // 
            lblEmployee.AutoSize = true;
            lblEmployee.BackColor = Color.White;
            lblEmployee.ForeColor = Color.FromArgb(94, 76, 76);
            lblEmployee.Location = new Point(15, 160);
            lblEmployee.Name = "lblEmployee";
            lblEmployee.Size = new Size(112, 20);
            lblEmployee.TabIndex = 7;
            lblEmployee.Text = "Người báo cáo:";
            // 
            // lblBookTitle
            // 
            lblBookTitle.AutoSize = true;
            lblBookTitle.BackColor = Color.White;
            lblBookTitle.ForeColor = Color.FromArgb(94, 76, 76);
            lblBookTitle.Location = new Point(15, 125);
            lblBookTitle.Name = "lblBookTitle";
            lblBookTitle.Size = new Size(68, 20);
            lblBookTitle.TabIndex = 5;
            lblBookTitle.Text = "Tên sách:";
            // 
            // txtCopyId
            // 
            txtCopyId.CharacterCasing = CharacterCasing.Upper;
            txtCopyId.Location = new Point(155, 87);
            txtCopyId.MaxLength = 10;
            txtCopyId.Name = "txtCopyId";
            txtCopyId.ReadOnly = true;
            txtCopyId.Size = new Size(150, 27);
            txtCopyId.TabIndex = 0;
            // 
            // lblCopyId
            // 
            lblCopyId.AutoSize = true;
            lblCopyId.BackColor = Color.White;
            lblCopyId.ForeColor = Color.FromArgb(94, 76, 76);
            lblCopyId.Location = new Point(15, 90);
            lblCopyId.Name = "lblCopyId";
            lblCopyId.Size = new Size(89, 20);
            lblCopyId.TabIndex = 3;
            lblCopyId.Text = "Mã bản sao:";
            // 
            // txtLostBookId
            // 
            txtLostBookId.Enabled = false;
            txtLostBookId.Location = new Point(155, 52);
            txtLostBookId.Name = "txtLostBookId";
            txtLostBookId.Size = new Size(200, 27);
            txtLostBookId.TabIndex = 2;
            // 
            // lblLostBookId
            // 
            lblLostBookId.AutoSize = true;
            lblLostBookId.BackColor = Color.White;
            lblLostBookId.ForeColor = Color.FromArgb(94, 76, 76);
            lblLostBookId.Location = new Point(15, 55);
            lblLostBookId.Name = "lblLostBookId";
            lblLostBookId.Size = new Size(91, 20);
            lblLostBookId.TabIndex = 1;
            lblLostBookId.Text = "Mã báo cáo:";
            // 
            // lblLocationInfo
            // 
            lblLocationInfo.AutoSize = true;
            lblLocationInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLocationInfo.ForeColor = Color.FromArgb(210, 121, 106);
            lblLocationInfo.Location = new Point(15, 15);
            lblLocationInfo.Name = "lblLocationInfo";
            lblLocationInfo.Size = new Size(258, 28);
            lblLocationInfo.TabIndex = 0;
            lblLocationInfo.Text = "THÔNG TIN SÁCH BỊ MẤT";
            // 
            // pnlSearch
            // 
            pnlSearch.BackColor = Color.White;
            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Controls.Add(lblSearch);
            pnlSearch.Location = new Point(20, 310);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(930, 60);
            pnlSearch.TabIndex = 18;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(129, 195, 215);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(560, 13);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 35);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(100, 17);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập tên sách, mã bản sao, lý do...";
            txtSearch.Size = new Size(450, 27);
            txtSearch.TabIndex = 0;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.BackColor = Color.White;
            lblSearch.ForeColor = Color.FromArgb(94, 76, 76);
            lblSearch.Location = new Point(15, 20);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(73, 20);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Tìm kiếm:";
            // 
            // pnlDataGrid
            // 
            pnlDataGrid.BackColor = Color.White;
            pnlDataGrid.Controls.Add(dgvLocations);
            pnlDataGrid.Controls.Add(pictureBox1);
            pnlDataGrid.Controls.Add(btnRefresh);
            pnlDataGrid.Controls.Add(btnDelete);
            pnlDataGrid.Controls.Add(btnUpdate);
            pnlDataGrid.Controls.Add(btnAdd);
            pnlDataGrid.Controls.Add(lblLocationList);
            pnlDataGrid.Location = new Point(20, 380);
            pnlDataGrid.Name = "pnlDataGrid";
            pnlDataGrid.Size = new Size(930, 250);
            pnlDataGrid.TabIndex = 19;
            // 
            // dgvLocations
            // 
            dgvLocations.AllowUserToAddRows = false;
            dgvLocations.AllowUserToDeleteRows = false;
            dgvLocations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLocations.BackgroundColor = Color.White;
            dgvLocations.BorderStyle = BorderStyle.None;
            dgvLocations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLocations.Location = new Point(15, 50);
            dgvLocations.Name = "dgvLocations";
            dgvLocations.ReadOnly = true;
            dgvLocations.RowHeadersWidth = 51;
            dgvLocations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLocations.Size = new Size(900, 180);
            dgvLocations.TabIndex = 7;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(213, 15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(33, 28);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(129, 195, 215);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(815, 15);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(96, 29);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(192, 0, 0);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(710, 15);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(96, 29);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(210, 121, 106);
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(605, 15);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(96, 29);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(210, 121, 106);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(471, 15);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(125, 29);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Báo cáo bị mất";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // lblLocationList
            // 
            lblLocationList.AutoSize = true;
            lblLocationList.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLocationList.ForeColor = Color.FromArgb(210, 121, 106);
            lblLocationList.Location = new Point(15, 15);
            lblLocationList.Name = "lblLocationList";
            lblLocationList.Size = new Size(192, 28);
            lblLocationList.TabIndex = 0;
            lblLocationList.Text = "DANH SÁCH VỊ TRÍ";
            // 
            // fLostBookManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(249, 241, 240);
            ClientSize = new Size(970, 650);
            Controls.Add(pnlDataGrid);
            Controls.Add(pnlSearch);
            Controls.Add(pnlLostBookInfo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fLostBookManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý sách bị mất";
            pnlLostBookInfo.ResumeLayout(false);
            pnlLostBookInfo.PerformLayout();
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            pnlDataGrid.ResumeLayout(false);
            pnlDataGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLocations).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLostBookInfo;
        private TextBox txtDescription;
        private Label lblReportDate;
        private Label lblEmployee;
        private Label lblBookTitle;
        private TextBox txtCopyId;
        private Label lblCopyId;
        private TextBox txtLostBookId;
        private Label lblLostBookId;
        private Label lblLocationInfo;
        private Button btnSelectCopy;
        private TextBox txtBookTitle;
        private ComboBox cboEmployee;
        private DateTimePicker dateTimePicker1;
        private Label lblReason;
        private TextBox txtReason;
        private Label lblNotes;
        private Panel pnlSearch;
        private Button btnSearch;
        private TextBox txtSearch;
        private Label lblSearch;
        private Panel pnlDataGrid;
        private DataGridView dgvLocations;
        private PictureBox pictureBox1;
        private Button btnRefresh;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private Label lblLocationList;
    }
}