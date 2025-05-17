namespace LibraryManagement
{
    partial class fEmployeeManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fEmployeeManagement));
            pnlEmployeeInfo = new Panel();
            btnResetPassword = new Button();
            btnChangePassword = new Button();
            chkRequirePasswordChange = new CheckBox();
            txtConfirmPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtPassword = new TextBox();
            lblPassword = new Label();
            cboStatus = new ComboBox();
            lblStatus = new Label();
            cboRole = new ComboBox();
            lblRole = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtName = new TextBox();
            lblName = new Label();
            txtEmployeeId = new TextBox();
            lblEmployeeId = new Label();
            lblEmployeeInfo = new Label();
            pnlSearch = new Panel();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            pnlDataGrid = new Panel();
            dgvEmployees = new DataGridView();
            btnRefresh = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            pictureBox1 = new PictureBox();
            lblEmployeeList = new Label();
            pnlEmployeeInfo.SuspendLayout();
            pnlSearch.SuspendLayout();
            pnlDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnlEmployeeInfo
            // 
            pnlEmployeeInfo.BackColor = Color.White;
            pnlEmployeeInfo.Controls.Add(btnResetPassword);
            pnlEmployeeInfo.Controls.Add(btnChangePassword);
            pnlEmployeeInfo.Controls.Add(chkRequirePasswordChange);
            pnlEmployeeInfo.Controls.Add(txtConfirmPassword);
            pnlEmployeeInfo.Controls.Add(lblConfirmPassword);
            pnlEmployeeInfo.Controls.Add(txtPassword);
            pnlEmployeeInfo.Controls.Add(lblPassword);
            pnlEmployeeInfo.Controls.Add(cboStatus);
            pnlEmployeeInfo.Controls.Add(lblStatus);
            pnlEmployeeInfo.Controls.Add(cboRole);
            pnlEmployeeInfo.Controls.Add(lblRole);
            pnlEmployeeInfo.Controls.Add(txtEmail);
            pnlEmployeeInfo.Controls.Add(lblEmail);
            pnlEmployeeInfo.Controls.Add(txtName);
            pnlEmployeeInfo.Controls.Add(lblName);
            pnlEmployeeInfo.Controls.Add(txtEmployeeId);
            pnlEmployeeInfo.Controls.Add(lblEmployeeId);
            pnlEmployeeInfo.Controls.Add(lblEmployeeInfo);
            pnlEmployeeInfo.Location = new Point(20, 20);
            pnlEmployeeInfo.Name = "pnlEmployeeInfo";
            pnlEmployeeInfo.Size = new Size(930, 280);
            pnlEmployeeInfo.TabIndex = 0;
            // 
            // btnResetPassword
            // 
            btnResetPassword.BackColor = Color.FromArgb(231, 76, 60);
            btnResetPassword.Cursor = Cursors.Hand;
            btnResetPassword.FlatAppearance.BorderSize = 0;
            btnResetPassword.FlatStyle = FlatStyle.Flat;
            btnResetPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnResetPassword.ForeColor = Color.White;
            btnResetPassword.Location = new Point(700, 225);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Size = new Size(100, 30);
            btnResetPassword.TabIndex = 17;
            btnResetPassword.Text = "Reset MK";
            btnResetPassword.UseVisualStyleBackColor = false;
            btnResetPassword.Click += btnResetPassword_Click;
            // 
            // btnChangePassword
            // 
            btnChangePassword.BackColor = Color.FromArgb(210, 121, 106);
            btnChangePassword.Cursor = Cursors.Hand;
            btnChangePassword.FlatAppearance.BorderSize = 0;
            btnChangePassword.FlatStyle = FlatStyle.Flat;
            btnChangePassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChangePassword.ForeColor = Color.White;
            btnChangePassword.Location = new Point(590, 225);
            btnChangePassword.Name = "btnChangePassword";
            btnChangePassword.Size = new Size(100, 30);
            btnChangePassword.TabIndex = 16;
            btnChangePassword.Text = "Đổi MK";
            btnChangePassword.UseVisualStyleBackColor = false;
            btnChangePassword.Click += btnChangePassword_Click;
            // 
            // chkRequirePasswordChange
            // 
            chkRequirePasswordChange.ForeColor = Color.Gray;
            chkRequirePasswordChange.Location = new Point(590, 192);
            chkRequirePasswordChange.Name = "chkRequirePasswordChange";
            chkRequirePasswordChange.Size = new Size(300, 24);
            chkRequirePasswordChange.TabIndex = 15;
            chkRequirePasswordChange.Text = "Yêu cầu đổi mật khẩu lần đăng nhập sau";
            chkRequirePasswordChange.UseVisualStyleBackColor = true;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmPassword.Enabled = false;
            txtConfirmPassword.Location = new Point(590, 157);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '*';
            txtConfirmPassword.Size = new Size(200, 27);
            txtConfirmPassword.TabIndex = 14;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblConfirmPassword.ForeColor = Color.FromArgb(94, 76, 76);
            lblConfirmPassword.Location = new Point(450, 160);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(105, 20);
            lblConfirmPassword.TabIndex = 13;
            lblConfirmPassword.Text = "Xác nhận MK:";
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Enabled = false;
            txtPassword.Location = new Point(590, 122);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(200, 27);
            txtPassword.TabIndex = 12;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.ForeColor = Color.FromArgb(94, 76, 76);
            lblPassword.Location = new Point(450, 125);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(79, 20);
            lblPassword.TabIndex = 11;
            lblPassword.Text = "Mật khẩu:";
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.FormattingEnabled = true;
            cboStatus.Items.AddRange(new object[] { "Hoạt động", "", "Tạm khóa" });
            cboStatus.Location = new Point(590, 87);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(200, 28);
            cboStatus.TabIndex = 10;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.FromArgb(94, 76, 76);
            lblStatus.Location = new Point(450, 90);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(84, 20);
            lblStatus.TabIndex = 9;
            lblStatus.Text = "Trạng thái:";
            // 
            // cboRole
            // 
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRole.FormattingEnabled = true;
            cboRole.Items.AddRange(new object[] { "Quản trị viên", "", "Thủ thư", "", "Nhân viên" });
            cboRole.Location = new Point(590, 52);
            cboRole.Name = "cboRole";
            cboRole.Size = new Size(200, 28);
            cboRole.TabIndex = 8;
            // 
            // lblRole
            // 
            lblRole.AutoSize = true;
            lblRole.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRole.ForeColor = Color.FromArgb(94, 76, 76);
            lblRole.Location = new Point(450, 55);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(59, 20);
            lblRole.TabIndex = 7;
            lblRole.Text = "Vai trò:";
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Enabled = false;
            txtEmail.Location = new Point(155, 122);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(250, 27);
            txtEmail.TabIndex = 6;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.FromArgb(94, 76, 76);
            lblEmail.Location = new Point(15, 125);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(51, 20);
            lblEmail.TabIndex = 5;
            lblEmail.Text = "Email:";
            // 
            // txtName
            // 
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Enabled = false;
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
            // txtEmployeeId
            // 
            txtEmployeeId.BorderStyle = BorderStyle.FixedSingle;
            txtEmployeeId.Enabled = false;
            txtEmployeeId.Location = new Point(155, 52);
            txtEmployeeId.Name = "txtEmployeeId";
            txtEmployeeId.Size = new Size(250, 27);
            txtEmployeeId.TabIndex = 2;
            // 
            // lblEmployeeId
            // 
            lblEmployeeId.AutoSize = true;
            lblEmployeeId.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmployeeId.ForeColor = Color.FromArgb(94, 76, 76);
            lblEmployeeId.Location = new Point(15, 55);
            lblEmployeeId.Name = "lblEmployeeId";
            lblEmployeeId.Size = new Size(107, 20);
            lblEmployeeId.TabIndex = 1;
            lblEmployeeId.Text = "Mã nhân viên:";
            // 
            // lblEmployeeInfo
            // 
            lblEmployeeInfo.AutoSize = true;
            lblEmployeeInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmployeeInfo.ForeColor = Color.FromArgb(210, 121, 106);
            lblEmployeeInfo.Location = new Point(15, 15);
            lblEmployeeInfo.Name = "lblEmployeeInfo";
            lblEmployeeInfo.Size = new Size(243, 28);
            lblEmployeeInfo.TabIndex = 0;
            lblEmployeeInfo.Text = "THÔNG TIN NHÂN VIÊN";
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
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(610, 13);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(100, 35);
            btnSearch.TabIndex = 18;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Enabled = false;
            txtSearch.Location = new Point(100, 17);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(500, 27);
            txtSearch.TabIndex = 18;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSearch.ForeColor = Color.FromArgb(94, 76, 76);
            lblSearch.Location = new Point(15, 20);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(78, 20);
            lblSearch.TabIndex = 18;
            lblSearch.Text = "Tìm kiếm:";
            // 
            // pnlDataGrid
            // 
            pnlDataGrid.BackColor = Color.White;
            pnlDataGrid.Controls.Add(dgvEmployees);
            pnlDataGrid.Controls.Add(btnRefresh);
            pnlDataGrid.Controls.Add(btnDelete);
            pnlDataGrid.Controls.Add(btnUpdate);
            pnlDataGrid.Controls.Add(btnAdd);
            pnlDataGrid.Controls.Add(pictureBox1);
            pnlDataGrid.Controls.Add(lblEmployeeList);
            pnlDataGrid.Location = new Point(20, 380);
            pnlDataGrid.Name = "pnlDataGrid";
            pnlDataGrid.Size = new Size(930, 260);
            pnlDataGrid.TabIndex = 2;
            // 
            // dgvEmployees
            // 
            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.AllowUserToDeleteRows = false;
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployees.BackgroundColor = Color.White;
            dgvEmployees.BorderStyle = BorderStyle.None;
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Location = new Point(15, 50);
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.ReadOnly = true;
            dgvEmployees.RowHeadersVisible = false;
            dgvEmployees.RowHeadersWidth = 51;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.Size = new Size(900, 200);
            dgvEmployees.TabIndex = 23;
            dgvEmployees.SelectionChanged += dgvEmployees_SelectionChanged;
            dgvEmployees.DoubleClick += dgvEmployees_DoubleClick;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(129, 195, 215);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(815, 15);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(96, 29);
            btnRefresh.TabIndex = 22;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(192, 0, 0);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(710, 15);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(96, 29);
            btnDelete.TabIndex = 21;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(210, 121, 106);
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(605, 15);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(96, 29);
            btnUpdate.TabIndex = 20;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(210, 121, 106);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(500, 15);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(96, 29);
            btnAdd.TabIndex = 19;
            btnAdd.Text = "Tạo mới";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(265, 15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(33, 28);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            // 
            // lblEmployeeList
            // 
            lblEmployeeList.AutoSize = true;
            lblEmployeeList.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmployeeList.ForeColor = Color.FromArgb(210, 121, 106);
            lblEmployeeList.Location = new Point(15, 15);
            lblEmployeeList.Name = "lblEmployeeList";
            lblEmployeeList.Size = new Size(249, 28);
            lblEmployeeList.TabIndex = 18;
            lblEmployeeList.Text = "DANH SÁCH NHÂN VIÊN";
            // 
            // fEmployeeManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(249, 241, 240);
            ClientSize = new Size(970, 650);
            Controls.Add(pnlDataGrid);
            Controls.Add(pnlSearch);
            Controls.Add(pnlEmployeeInfo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fEmployeeManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý nhân viên";
            Load += fEmployeeManagement_Load;
            pnlEmployeeInfo.ResumeLayout(false);
            pnlEmployeeInfo.PerformLayout();
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            pnlDataGrid.ResumeLayout(false);
            pnlDataGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlEmployeeInfo;
        private Label lblEmployeeId;
        private Label lblEmployeeInfo;
        private TextBox txtEmployeeId;
        private Label lblName;
        private TextBox txtName;
        private TextBox txtEmail;
        private Label lblEmail;
        private ComboBox cboStatus;
        private Label lblStatus;
        private ComboBox cboRole;
        private Label lblRole;
        private Label lblPassword;
        private Label lblConfirmPassword;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
        private CheckBox chkRequirePasswordChange;
        private Button btnChangePassword;
        private Button btnResetPassword;
        private Panel pnlSearch;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private Panel pnlDataGrid;
        private Label lblEmployeeList;
        private PictureBox pictureBox1;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnRefresh;
        private DataGridView dgvEmployees;
    }
}