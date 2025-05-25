namespace LibraryManagement
{
    partial class fLocationManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fLocationManagement));
            pnlLocationInfo = new Panel();
            txtDescription = new TextBox();
            lblDescription = new Label();
            numSectionNumber = new NumericUpDown();
            lblSectionNumber = new Label();
            numShelfNumber = new NumericUpDown();
            lblShelfNumber = new Label();
            txtAreaCode = new TextBox();
            lblAreaCode = new Label();
            txtLocationId = new TextBox();
            lblLocationId = new Label();
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
            pnlLocationInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSectionNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numShelfNumber).BeginInit();
            pnlSearch.SuspendLayout();
            pnlDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLocations).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnlLocationInfo
            // 
            pnlLocationInfo.BackColor = Color.White;
            pnlLocationInfo.Controls.Add(txtDescription);
            pnlLocationInfo.Controls.Add(lblDescription);
            pnlLocationInfo.Controls.Add(numSectionNumber);
            pnlLocationInfo.Controls.Add(lblSectionNumber);
            pnlLocationInfo.Controls.Add(numShelfNumber);
            pnlLocationInfo.Controls.Add(lblShelfNumber);
            pnlLocationInfo.Controls.Add(txtAreaCode);
            pnlLocationInfo.Controls.Add(lblAreaCode);
            pnlLocationInfo.Controls.Add(txtLocationId);
            pnlLocationInfo.Controls.Add(lblLocationId);
            pnlLocationInfo.Controls.Add(lblLocationInfo);
            pnlLocationInfo.Location = new Point(20, 20);
            pnlLocationInfo.Name = "pnlLocationInfo";
            pnlLocationInfo.Size = new Size(930, 220);
            pnlLocationInfo.TabIndex = 0;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(590, 87);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(300, 100);
            txtDescription.TabIndex = 10;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.BackColor = Color.White;
            lblDescription.ForeColor = Color.FromArgb(94, 76, 76);
            lblDescription.Location = new Point(450, 90);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(51, 20);
            lblDescription.TabIndex = 9;
            lblDescription.Text = "Mô tả:";
            // 
            // numSectionNumber
            // 
            numSectionNumber.Location = new Point(590, 52);
            numSectionNumber.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            numSectionNumber.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numSectionNumber.Name = "numSectionNumber";
            numSectionNumber.Size = new Size(200, 27);
            numSectionNumber.TabIndex = 8;
            numSectionNumber.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblSectionNumber
            // 
            lblSectionNumber.AutoSize = true;
            lblSectionNumber.BackColor = Color.White;
            lblSectionNumber.ForeColor = Color.FromArgb(94, 76, 76);
            lblSectionNumber.Location = new Point(450, 55);
            lblSectionNumber.Name = "lblSectionNumber";
            lblSectionNumber.Size = new Size(66, 20);
            lblSectionNumber.TabIndex = 7;
            lblSectionNumber.Text = "Số ngăn:";
            // 
            // numShelfNumber
            // 
            numShelfNumber.Location = new Point(155, 122);
            numShelfNumber.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
            numShelfNumber.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numShelfNumber.Name = "numShelfNumber";
            numShelfNumber.Size = new Size(200, 27);
            numShelfNumber.TabIndex = 6;
            numShelfNumber.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblShelfNumber
            // 
            lblShelfNumber.AutoSize = true;
            lblShelfNumber.BackColor = Color.White;
            lblShelfNumber.ForeColor = Color.FromArgb(94, 76, 76);
            lblShelfNumber.Location = new Point(15, 125);
            lblShelfNumber.Name = "lblShelfNumber";
            lblShelfNumber.Size = new Size(48, 20);
            lblShelfNumber.TabIndex = 5;
            lblShelfNumber.Text = "Số kệ:";
            // 
            // txtAreaCode
            // 
            txtAreaCode.CharacterCasing = CharacterCasing.Upper;
            txtAreaCode.Location = new Point(155, 87);
            txtAreaCode.MaxLength = 10;
            txtAreaCode.Name = "txtAreaCode";
            txtAreaCode.Size = new Size(200, 27);
            txtAreaCode.TabIndex = 4;
            // 
            // lblAreaCode
            // 
            lblAreaCode.AutoSize = true;
            lblAreaCode.BackColor = Color.White;
            lblAreaCode.ForeColor = Color.FromArgb(94, 76, 76);
            lblAreaCode.Location = new Point(15, 90);
            lblAreaCode.Name = "lblAreaCode";
            lblAreaCode.Size = new Size(64, 20);
            lblAreaCode.TabIndex = 3;
            lblAreaCode.Text = "Khu vực:";
            // 
            // txtLocationId
            // 
            txtLocationId.Enabled = false;
            txtLocationId.Location = new Point(155, 52);
            txtLocationId.Name = "txtLocationId";
            txtLocationId.Size = new Size(200, 27);
            txtLocationId.TabIndex = 2;
            // 
            // lblLocationId
            // 
            lblLocationId.AutoSize = true;
            lblLocationId.BackColor = Color.White;
            lblLocationId.ForeColor = Color.FromArgb(94, 76, 76);
            lblLocationId.Location = new Point(15, 55);
            lblLocationId.Name = "lblLocationId";
            lblLocationId.Size = new Size(66, 20);
            lblLocationId.TabIndex = 1;
            lblLocationId.Text = "Mã vị trí:";
            // 
            // lblLocationInfo
            // 
            lblLocationInfo.AutoSize = true;
            lblLocationInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLocationInfo.ForeColor = Color.FromArgb(210, 121, 106);
            lblLocationInfo.Location = new Point(15, 15);
            lblLocationInfo.Name = "lblLocationInfo";
            lblLocationInfo.Size = new Size(186, 28);
            lblLocationInfo.TabIndex = 0;
            lblLocationInfo.Text = "THÔNG TIN VỊ TRÍ";
            // 
            // pnlSearch
            // 
            pnlSearch.BackColor = Color.White;
            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Controls.Add(lblSearch);
            pnlSearch.Location = new Point(20, 250);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(930, 60);
            pnlSearch.TabIndex = 1;
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
            btnSearch.TabIndex = 2;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(100, 17);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Nhập mã khu vực, số kệ, mô tả hoặc mã định vị (A-01-01)...";
            txtSearch.Size = new Size(450, 27);
            txtSearch.TabIndex = 1;
            txtSearch.KeyDown += txtSearch_KeyDown;
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
            pnlDataGrid.Location = new Point(20, 320);
            pnlDataGrid.Name = "pnlDataGrid";
            pnlDataGrid.Size = new Size(930, 310);
            pnlDataGrid.TabIndex = 2;
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
            dgvLocations.Size = new Size(900, 250);
            dgvLocations.TabIndex = 7;
            dgvLocations.CellDoubleClick += dgvLocations_CellDoubleClick;
            dgvLocations.SelectionChanged += dgvLocations_SelectionChanged;
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
            btnRefresh.TabIndex = 5;
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
            btnDelete.TabIndex = 4;
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
            btnUpdate.TabIndex = 3;
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
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Tạo mới";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
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
            // fLocationManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(249, 241, 240);
            ClientSize = new Size(970, 650);
            Controls.Add(pnlDataGrid);
            Controls.Add(pnlSearch);
            Controls.Add(pnlLocationInfo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fLocationManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý vị trí sách";
            Load += fLocationManagement_Load;
            pnlLocationInfo.ResumeLayout(false);
            pnlLocationInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSectionNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)numShelfNumber).EndInit();
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            pnlDataGrid.ResumeLayout(false);
            pnlDataGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLocations).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLocationInfo;
        private Label lblLocationInfo;
        private TextBox txtLocationId;
        private Label lblLocationId;
        private TextBox txtAreaCode;
        private Label lblAreaCode;
        private NumericUpDown numShelfNumber;
        private Label lblShelfNumber;
        private NumericUpDown numSectionNumber;
        private Label lblSectionNumber;
        private TextBox txtDescription;
        private Label lblDescription;
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