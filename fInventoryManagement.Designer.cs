namespace LibraryManagement
{
    partial class fInventoryManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fInventoryManagement));
            pnlInventoryInfo = new Panel();
            btnSelectBooks = new Button();
            lblNotes = new Label();
            dtpCheckDate = new DateTimePicker();
            cboEmployee = new ComboBox();
            txtNotes = new TextBox();
            lblEmployee = new Label();
            lblCheckDate = new Label();
            txtInventoryId = new TextBox();
            lblInventoryId = new Label();
            lblInventoryInfo = new Label();
            pnlSearch = new Panel();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            pnlDataGrid = new Panel();
            dgvInventory = new DataGridView();
            pictureBox1 = new PictureBox();
            btnRefresh = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            lblInventoryList = new Label();
            pnlInventoryInfo.SuspendLayout();
            pnlSearch.SuspendLayout();
            pnlDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnlInventoryInfo
            // 
            pnlInventoryInfo.BackColor = Color.White;
            pnlInventoryInfo.Controls.Add(btnSelectBooks);
            pnlInventoryInfo.Controls.Add(lblNotes);
            pnlInventoryInfo.Controls.Add(dtpCheckDate);
            pnlInventoryInfo.Controls.Add(cboEmployee);
            pnlInventoryInfo.Controls.Add(txtNotes);
            pnlInventoryInfo.Controls.Add(lblEmployee);
            pnlInventoryInfo.Controls.Add(lblCheckDate);
            pnlInventoryInfo.Controls.Add(txtInventoryId);
            pnlInventoryInfo.Controls.Add(lblInventoryId);
            pnlInventoryInfo.Controls.Add(lblInventoryInfo);
            pnlInventoryInfo.Location = new Point(20, 20);
            pnlInventoryInfo.Name = "pnlInventoryInfo";
            pnlInventoryInfo.Size = new Size(930, 200);
            pnlInventoryInfo.TabIndex = 2;
            // 
            // btnSelectBooks
            // 
            btnSelectBooks.BackColor = Color.MediumAquamarine;
            btnSelectBooks.FlatAppearance.BorderSize = 0;
            btnSelectBooks.FlatStyle = FlatStyle.Flat;
            btnSelectBooks.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSelectBooks.ForeColor = Color.White;
            btnSelectBooks.Location = new Point(155, 160);
            btnSelectBooks.Name = "btnSelectBooks";
            btnSelectBooks.Size = new Size(150, 30);
            btnSelectBooks.TabIndex = 18;
            btnSelectBooks.Text = "Chọn sách kiểm kê";
            btnSelectBooks.UseVisualStyleBackColor = false;
            btnSelectBooks.Click += btnSelectBooks_Click;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.BackColor = Color.White;
            lblNotes.ForeColor = Color.FromArgb(94, 76, 76);
            lblNotes.Location = new Point(450, 55);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(61, 20);
            lblNotes.TabIndex = 17;
            lblNotes.Text = "Ghi chú:";
            // 
            // dtpCheckDate
            // 
            dtpCheckDate.Format = DateTimePickerFormat.Short;
            dtpCheckDate.Location = new Point(155, 87);
            dtpCheckDate.Name = "dtpCheckDate";
            dtpCheckDate.Size = new Size(200, 27);
            dtpCheckDate.TabIndex = 3;
            // 
            // cboEmployee
            // 
            cboEmployee.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEmployee.FormattingEnabled = true;
            cboEmployee.Location = new Point(155, 122);
            cboEmployee.Name = "cboEmployee";
            cboEmployee.Size = new Size(250, 28);
            cboEmployee.TabIndex = 2;
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(550, 52);
            txtNotes.MaxLength = 500;
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.ScrollBars = ScrollBars.Vertical;
            txtNotes.Size = new Size(350, 130);
            txtNotes.TabIndex = 5;
            // 
            // lblEmployee
            // 
            lblEmployee.AutoSize = true;
            lblEmployee.BackColor = Color.White;
            lblEmployee.ForeColor = Color.FromArgb(94, 76, 76);
            lblEmployee.Location = new Point(15, 125);
            lblEmployee.Name = "lblEmployee";
            lblEmployee.Size = new Size(78, 20);
            lblEmployee.TabIndex = 7;
            lblEmployee.Text = "Nhân viên:";
            // 
            // lblCheckDate
            // 
            lblCheckDate.AutoSize = true;
            lblCheckDate.BackColor = Color.White;
            lblCheckDate.ForeColor = Color.FromArgb(94, 76, 76);
            lblCheckDate.Location = new Point(15, 90);
            lblCheckDate.Name = "lblCheckDate";
            lblCheckDate.Size = new Size(102, 20);
            lblCheckDate.TabIndex = 3;
            lblCheckDate.Text = "Ngày kiểm kê:";
            // 
            // txtInventoryId
            // 
            txtInventoryId.Enabled = false;
            txtInventoryId.Location = new Point(155, 52);
            txtInventoryId.Name = "txtInventoryId";
            txtInventoryId.Size = new Size(200, 27);
            txtInventoryId.TabIndex = 2;
            // 
            // lblInventoryId
            // 
            lblInventoryId.AutoSize = true;
            lblInventoryId.BackColor = Color.White;
            lblInventoryId.ForeColor = Color.FromArgb(94, 76, 76);
            lblInventoryId.Location = new Point(15, 55);
            lblInventoryId.Name = "lblInventoryId";
            lblInventoryId.Size = new Size(85, 20);
            lblInventoryId.TabIndex = 1;
            lblInventoryId.Text = "Mã kiểm kê";
            // 
            // lblInventoryInfo
            // 
            lblInventoryInfo.AutoSize = true;
            lblInventoryInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInventoryInfo.ForeColor = Color.FromArgb(210, 121, 106);
            lblInventoryInfo.Location = new Point(15, 15);
            lblInventoryInfo.Name = "lblInventoryInfo";
            lblInventoryInfo.Size = new Size(209, 28);
            lblInventoryInfo.TabIndex = 0;
            lblInventoryInfo.Text = "THÔNG TIN KIỂM KÊ";
            // 
            // pnlSearch
            // 
            pnlSearch.BackColor = Color.White;
            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Controls.Add(lblSearch);
            pnlSearch.Location = new Point(20, 230);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(930, 60);
            pnlSearch.TabIndex = 19;
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
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(100, 17);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập mã kiểm kê, tên nhân viên...";
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
            pnlDataGrid.Controls.Add(dgvInventory);
            pnlDataGrid.Controls.Add(pictureBox1);
            pnlDataGrid.Controls.Add(btnRefresh);
            pnlDataGrid.Controls.Add(btnDelete);
            pnlDataGrid.Controls.Add(btnUpdate);
            pnlDataGrid.Controls.Add(btnAdd);
            pnlDataGrid.Controls.Add(lblInventoryList);
            pnlDataGrid.Location = new Point(20, 300);
            pnlDataGrid.Name = "pnlDataGrid";
            pnlDataGrid.Size = new Size(930, 330);
            pnlDataGrid.TabIndex = 20;
            // 
            // dgvInventory
            // 
            dgvInventory.AllowUserToAddRows = false;
            dgvInventory.AllowUserToDeleteRows = false;
            dgvInventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInventory.BackgroundColor = Color.White;
            dgvInventory.BorderStyle = BorderStyle.None;
            dgvInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventory.Location = new Point(15, 50);
            dgvInventory.Name = "dgvInventory";
            dgvInventory.ReadOnly = true;
            dgvInventory.RowHeadersWidth = 51;
            dgvInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventory.Size = new Size(900, 260);
            dgvInventory.TabIndex = 7;
            dgvInventory.DataBindingComplete += dgvInventory_DataBindingComplete;
            dgvInventory.SelectionChanged += dgvInventory_SelectionChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(236, 16);
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
            btnRefresh.Click += btnRefresh_Click;
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
            btnDelete.Click += btnDelete_Click;
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
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(210, 121, 106);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(500, 15);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(96, 29);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "Tạo mới";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblInventoryList
            // 
            lblInventoryList.AutoSize = true;
            lblInventoryList.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblInventoryList.ForeColor = Color.FromArgb(210, 121, 106);
            lblInventoryList.Location = new Point(15, 15);
            lblInventoryList.Name = "lblInventoryList";
            lblInventoryList.Size = new Size(215, 28);
            lblInventoryList.TabIndex = 0;
            lblInventoryList.Text = "DANH SÁCH KIỂM KÊ";
            // 
            // fInventoryManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(249, 241, 240);
            ClientSize = new Size(970, 650);
            Controls.Add(pnlDataGrid);
            Controls.Add(pnlSearch);
            Controls.Add(pnlInventoryInfo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fInventoryManagement";
            Text = "Form1";
            Load += fInventoryManagement_Load;
            pnlInventoryInfo.ResumeLayout(false);
            pnlInventoryInfo.PerformLayout();
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            pnlDataGrid.ResumeLayout(false);
            pnlDataGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventory).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlInventoryInfo;
        private Label lblNotes;
        private DateTimePicker dtpCheckDate;
        private ComboBox cboEmployee;
        private TextBox txtNotes;
        private Label lblEmployee;
        private Label lblCheckDate;
        private TextBox txtInventoryId;
        private Label lblInventoryId;
        private Label lblInventoryInfo;
        private Button btnSelectBooks;
        private Panel pnlSearch;
        private Button btnSearch;
        private TextBox txtSearch;
        private Label lblSearch;
        private Panel pnlDataGrid;
        private DataGridView dgvInventory;
        private PictureBox pictureBox1;
        private Button btnRefresh;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private Label lblInventoryList;
    }
}