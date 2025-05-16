namespace LibraryManagement
{
    partial class fMemberManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMemberManagement));
            pnlMemberInfo = new Panel();
            txtNotes = new TextBox();
            lblNotes = new Label();
            dtpExpiryDate = new DateTimePicker();
            lblExpiryDate = new Label();
            txtCardNumber = new TextBox();
            lblCardNumber = new Label();
            cboStatus = new ComboBox();
            lblStatus = new Label();
            dtpJoinDate = new DateTimePicker();
            lblJoinDate = new Label();
            txtAddress = new TextBox();
            lblAddress = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtPhone = new TextBox();
            lblPhone = new Label();
            txtName = new TextBox();
            lblName = new Label();
            txtMemberId = new TextBox();
            lblMemberId = new Label();
            lblMemberInfo = new Label();
            pnlSearch = new Panel();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            pnlDataGrid = new Panel();
            dgvMembers = new DataGridView();
            pictureBox1 = new PictureBox();
            btnRefresh = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            lblMemberList = new Label();
            pnlMemberInfo.SuspendLayout();
            pnlSearch.SuspendLayout();
            pnlDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMembers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnlMemberInfo
            // 
            pnlMemberInfo.BackColor = Color.White;
            pnlMemberInfo.Controls.Add(txtNotes);
            pnlMemberInfo.Controls.Add(lblNotes);
            pnlMemberInfo.Controls.Add(dtpExpiryDate);
            pnlMemberInfo.Controls.Add(lblExpiryDate);
            pnlMemberInfo.Controls.Add(txtCardNumber);
            pnlMemberInfo.Controls.Add(lblCardNumber);
            pnlMemberInfo.Controls.Add(cboStatus);
            pnlMemberInfo.Controls.Add(lblStatus);
            pnlMemberInfo.Controls.Add(dtpJoinDate);
            pnlMemberInfo.Controls.Add(lblJoinDate);
            pnlMemberInfo.Controls.Add(txtAddress);
            pnlMemberInfo.Controls.Add(lblAddress);
            pnlMemberInfo.Controls.Add(txtEmail);
            pnlMemberInfo.Controls.Add(lblEmail);
            pnlMemberInfo.Controls.Add(txtPhone);
            pnlMemberInfo.Controls.Add(lblPhone);
            pnlMemberInfo.Controls.Add(txtName);
            pnlMemberInfo.Controls.Add(lblName);
            pnlMemberInfo.Controls.Add(txtMemberId);
            pnlMemberInfo.Controls.Add(lblMemberId);
            pnlMemberInfo.Controls.Add(lblMemberInfo);
            pnlMemberInfo.Location = new Point(20, 20);
            pnlMemberInfo.Name = "pnlMemberInfo";
            pnlMemberInfo.Size = new Size(930, 280);
            pnlMemberInfo.TabIndex = 0;
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(590, 192);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.ScrollBars = ScrollBars.Vertical;
            txtNotes.Size = new Size(300, 60);
            txtNotes.TabIndex = 20;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNotes.ForeColor = Color.FromArgb(94, 76, 76);
            lblNotes.Location = new Point(450, 195);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(66, 20);
            lblNotes.TabIndex = 19;
            lblNotes.Text = "Ghi chú:";
            // 
            // dtpExpiryDate
            // 
            dtpExpiryDate.Format = DateTimePickerFormat.Short;
            dtpExpiryDate.Location = new Point(590, 157);
            dtpExpiryDate.Name = "dtpExpiryDate";
            dtpExpiryDate.Size = new Size(200, 27);
            dtpExpiryDate.TabIndex = 18;
            // 
            // lblExpiryDate
            // 
            lblExpiryDate.AutoSize = true;
            lblExpiryDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblExpiryDate.ForeColor = Color.FromArgb(94, 76, 76);
            lblExpiryDate.Location = new Point(450, 160);
            lblExpiryDate.Name = "lblExpiryDate";
            lblExpiryDate.Size = new Size(107, 20);
            lblExpiryDate.TabIndex = 17;
            lblExpiryDate.Text = "Ngày hết hạn:";
            // 
            // txtCardNumber
            // 
            txtCardNumber.Location = new Point(590, 122);
            txtCardNumber.Name = "txtCardNumber";
            txtCardNumber.Size = new Size(200, 27);
            txtCardNumber.TabIndex = 16;
            // 
            // lblCardNumber
            // 
            lblCardNumber.AutoSize = true;
            lblCardNumber.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCardNumber.ForeColor = Color.FromArgb(94, 76, 76);
            lblCardNumber.Location = new Point(450, 125);
            lblCardNumber.Name = "lblCardNumber";
            lblCardNumber.Size = new Size(57, 20);
            lblCardNumber.TabIndex = 15;
            lblCardNumber.Text = "Số thẻ:";
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.FormattingEnabled = true;
            cboStatus.Items.AddRange(new object[] { "Hoạt Động", "Tạm Khóa", "Khóa" });
            cboStatus.Location = new Point(590, 87);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(200, 28);
            cboStatus.TabIndex = 14;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.FromArgb(94, 76, 76);
            lblStatus.Location = new Point(450, 90);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(84, 20);
            lblStatus.TabIndex = 13;
            lblStatus.Text = "Trạng thái:";
            // 
            // dtpJoinDate
            // 
            dtpJoinDate.Format = DateTimePickerFormat.Short;
            dtpJoinDate.Location = new Point(590, 52);
            dtpJoinDate.Name = "dtpJoinDate";
            dtpJoinDate.Size = new Size(200, 27);
            dtpJoinDate.TabIndex = 12;
            // 
            // lblJoinDate
            // 
            lblJoinDate.AutoSize = true;
            lblJoinDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblJoinDate.ForeColor = Color.FromArgb(94, 76, 76);
            lblJoinDate.Location = new Point(450, 55);
            lblJoinDate.Name = "lblJoinDate";
            lblJoinDate.Size = new Size(109, 20);
            lblJoinDate.TabIndex = 11;
            lblJoinDate.Text = "Ngày đăng ký:";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(155, 192);
            txtAddress.Multiline = true;
            txtAddress.Name = "txtAddress";
            txtAddress.ScrollBars = ScrollBars.Vertical;
            txtAddress.Size = new Size(250, 60);
            txtAddress.TabIndex = 10;
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAddress.ForeColor = Color.FromArgb(94, 76, 76);
            lblAddress.Location = new Point(15, 195);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(60, 20);
            lblAddress.TabIndex = 9;
            lblAddress.Text = "Địa chỉ:";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(155, 157);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(250, 27);
            txtEmail.TabIndex = 8;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.FromArgb(94, 76, 76);
            lblEmail.Location = new Point(15, 160);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(51, 20);
            lblEmail.TabIndex = 7;
            lblEmail.Text = "Email:";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(155, 122);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(250, 27);
            txtPhone.TabIndex = 6;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPhone.ForeColor = Color.FromArgb(94, 76, 76);
            lblPhone.Location = new Point(15, 125);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(104, 20);
            lblPhone.TabIndex = 5;
            lblPhone.Text = "Số điện thoại:";
            // 
            // txtName
            // 
            txtName.Location = new Point(155, 87);
            txtName.Name = "txtName";
            txtName.Size = new Size(250, 27);
            txtName.TabIndex = 4;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.FromArgb(94, 76, 76);
            lblName.Location = new Point(15, 90);
            lblName.Name = "lblName";
            lblName.Size = new Size(80, 20);
            lblName.TabIndex = 3;
            lblName.Text = "Họ và tên:";
            // 
            // txtMemberId
            // 
            txtMemberId.Enabled = false;
            txtMemberId.Location = new Point(155, 52);
            txtMemberId.Name = "txtMemberId";
            txtMemberId.Size = new Size(250, 27);
            txtMemberId.TabIndex = 2;
            // 
            // lblMemberId
            // 
            lblMemberId.AutoSize = true;
            lblMemberId.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMemberId.ForeColor = Color.FromArgb(94, 76, 76);
            lblMemberId.Location = new Point(15, 55);
            lblMemberId.Name = "lblMemberId";
            lblMemberId.Size = new Size(113, 20);
            lblMemberId.TabIndex = 1;
            lblMemberId.Text = "Mã thành viên:";
            // 
            // lblMemberInfo
            // 
            lblMemberInfo.AutoSize = true;
            lblMemberInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMemberInfo.ForeColor = Color.FromArgb(210, 121, 106);
            lblMemberInfo.Location = new Point(15, 15);
            lblMemberInfo.Name = "lblMemberInfo";
            lblMemberInfo.Size = new Size(254, 28);
            lblMemberInfo.TabIndex = 0;
            lblMemberInfo.Text = "THÔNG TIN THÀNH VIÊN";
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
            pnlSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(129, 195, 215);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(610, 13);
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
            txtSearch.Size = new Size(500, 27);
            txtSearch.TabIndex = 1;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSearch.ForeColor = Color.FromArgb(94, 76, 76);
            lblSearch.Location = new Point(15, 20);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(74, 20);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Tìm kiếm";
            // 
            // pnlDataGrid
            // 
            pnlDataGrid.BackColor = Color.White;
            pnlDataGrid.Controls.Add(dgvMembers);
            pnlDataGrid.Controls.Add(pictureBox1);
            pnlDataGrid.Controls.Add(btnRefresh);
            pnlDataGrid.Controls.Add(btnDelete);
            pnlDataGrid.Controls.Add(btnUpdate);
            pnlDataGrid.Controls.Add(btnAdd);
            pnlDataGrid.Controls.Add(lblMemberList);
            pnlDataGrid.Location = new Point(20, 380);
            pnlDataGrid.Name = "pnlDataGrid";
            pnlDataGrid.Size = new Size(930, 250);
            pnlDataGrid.TabIndex = 2;
            // 
            // dgvMembers
            // 
            dgvMembers.AllowUserToAddRows = false;
            dgvMembers.AllowUserToDeleteRows = false;
            dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMembers.BackgroundColor = Color.White;
            dgvMembers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMembers.Location = new Point(15, 50);
            dgvMembers.Name = "dgvMembers";
            dgvMembers.ReadOnly = true;
            dgvMembers.RowHeadersWidth = 51;
            dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMembers.Size = new Size(900, 200);
            dgvMembers.TabIndex = 1;
            dgvMembers.SelectionChanged += dgvMembers_SelectionChanged;
            dgvMembers.DoubleClick += dgvMembers_DoubleClick;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.group;
            pictureBox1.InitialImage = (Image)resources.GetObject("pictureBox1.InitialImage");
            pictureBox1.Location = new Point(270, 15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(33, 28);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
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
            btnRefresh.TabIndex = 6;
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
            btnDelete.ForeColor = Color.WhiteSmoke;
            btnDelete.Location = new Point(710, 15);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(96, 29);
            btnDelete.TabIndex = 5;
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
            btnUpdate.ForeColor = Color.WhiteSmoke;
            btnUpdate.Location = new Point(605, 15);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(96, 29);
            btnUpdate.TabIndex = 4;
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
            btnAdd.TabIndex = 3;
            btnAdd.Text = "Tạo mới";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblMemberList
            // 
            lblMemberList.AutoSize = true;
            lblMemberList.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMemberList.ForeColor = Color.FromArgb(210, 121, 106);
            lblMemberList.Location = new Point(15, 15);
            lblMemberList.Name = "lblMemberList";
            lblMemberList.Size = new Size(260, 28);
            lblMemberList.TabIndex = 0;
            lblMemberList.Text = "DANH SÁCH THÀNH VIÊN";
            // 
            // fMemberManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(249, 241, 240);
            ClientSize = new Size(970, 650);
            Controls.Add(pnlDataGrid);
            Controls.Add(pnlSearch);
            Controls.Add(pnlMemberInfo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fMemberManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý thành viên";
            Load += fMemberManagement_Load;
            pnlMemberInfo.ResumeLayout(false);
            pnlMemberInfo.PerformLayout();
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            pnlDataGrid.ResumeLayout(false);
            pnlDataGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMembers).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMemberInfo;
        private Label lblMemberInfo;
        private TextBox txtMemberId;
        private Label lblMemberId;
        private Label lblName;
        private TextBox txtName;
        private TextBox txtEmail;
        private Label lblEmail;
        private TextBox txtPhone;
        private Label lblPhone;
        private Label lblJoinDate;
        private TextBox txtAddress;
        private Label lblAddress;
        private ComboBox cboStatus;
        private Label lblStatus;
        private DateTimePicker dtpJoinDate;
        private Label lblCardNumber;
        private Label lblExpiryDate;
        private TextBox txtCardNumber;
        private TextBox txtNotes;
        private Label lblNotes;
        private DateTimePicker dtpExpiryDate;
        private Panel pnlSearch;
        private TextBox txtSearch;
        private Label lblSearch;
        private Button btnSearch;
        private Panel pnlDataGrid;
        private Label lblMemberList;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnRefresh;
        private PictureBox pictureBox1;
        private DataGridView dgvMembers;
    }
}