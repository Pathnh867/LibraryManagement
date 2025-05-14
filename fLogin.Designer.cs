namespace LibraryManagement
{
    partial class fLogin
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
            pnlMain = new Panel();
            pnlRight = new Panel();
            pnlTitleBar = new Panel();
            btnClose = new Button();
            lblFormTitle = new Label();
            btnExit = new Button();
            btnLogin = new Button();
            chkRememberLogin = new CheckBox();
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtUsername = new TextBox();
            lblUsername = new Label();
            lblLoginInstruction = new Label();
            lblLoginTitle = new Label();
            pnlLeft = new Panel();
            lblInfo = new Label();
            lblSubtitle = new Label();
            lblLibraryTitle = new Label();
            picLogo = new PictureBox();
            picShowPassword = new PictureBox();
            pnlMain.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlTitleBar.SuspendLayout();
            pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picShowPassword).BeginInit();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.FromArgb(249, 241, 240);
            pnlMain.Controls.Add(pnlRight);
            pnlMain.Controls.Add(pnlLeft);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(0, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(800, 500);
            pnlMain.TabIndex = 0;
            // 
            // pnlRight
            // 
            pnlRight.Controls.Add(picShowPassword);
            pnlRight.Controls.Add(pnlTitleBar);
            pnlRight.Controls.Add(btnExit);
            pnlRight.Controls.Add(btnLogin);
            pnlRight.Controls.Add(chkRememberLogin);
            pnlRight.Controls.Add(txtPassword);
            pnlRight.Controls.Add(lblPassword);
            pnlRight.Controls.Add(txtUsername);
            pnlRight.Controls.Add(lblUsername);
            pnlRight.Controls.Add(lblLoginInstruction);
            pnlRight.Controls.Add(lblLoginTitle);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(350, 0);
            pnlRight.Margin = new Padding(40);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(450, 500);
            pnlRight.TabIndex = 1;
            // 
            // pnlTitleBar
            // 
            pnlTitleBar.BackColor = Color.Transparent;
            pnlTitleBar.Controls.Add(btnClose);
            pnlTitleBar.Controls.Add(lblFormTitle);
            pnlTitleBar.Dock = DockStyle.Top;
            pnlTitleBar.Location = new Point(0, 0);
            pnlTitleBar.Name = "pnlTitleBar";
            pnlTitleBar.Size = new Size(450, 41);
            pnlTitleBar.TabIndex = 4;
            pnlTitleBar.Paint += pnlTitleBar_Paint;
            pnlTitleBar.MouseDown += pnlTitleBar_MouseDown;
            pnlTitleBar.MouseMove += pnlTitleBar_MouseMove;
            pnlTitleBar.MouseUp += pnlTitleBar_MouseUp;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Transparent;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.FromArgb(210, 121, 106);
            btnClose.Location = new Point(417, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(30, 41);
            btnClose.TabIndex = 1;
            btnClose.Text = "×";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.ForeColor = Color.FromArgb(142, 127, 127);
            lblFormTitle.Location = new Point(10, 7);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(203, 20);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "Quản lý thư viện - Đăng nhập";
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(129, 195, 215);
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(257, 397);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(93, 29);
            btnExit.TabIndex = 8;
            btnExit.Text = "Thoát";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            btnExit.MouseEnter += btnExit_MouseEnter;
            btnExit.MouseLeave += btnExit_MouseLeave;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(210, 121, 106);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Calibri", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(100, 340);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(250, 40);
            btnLogin.TabIndex = 7;
            btnLogin.Text = "ĐĂNG NHẬP";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            btnLogin.MouseEnter += btnLogin_MouseEnter;
            btnLogin.MouseLeave += btnLogin_MouseLeave;
            // 
            // chkRememberLogin
            // 
            chkRememberLogin.AutoSize = true;
            chkRememberLogin.ForeColor = Color.FromArgb(142, 127, 127);
            chkRememberLogin.Location = new Point(100, 305);
            chkRememberLogin.Name = "chkRememberLogin";
            chkRememberLogin.Size = new Size(134, 24);
            chkRememberLogin.TabIndex = 6;
            chkRememberLogin.Text = "Nhớ đăng nhập";
            chkRememberLogin.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(249, 241, 240);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(100, 265);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '•';
            txtPassword.Size = new Size(250, 27);
            txtPassword.TabIndex = 5;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10F);
            lblPassword.ForeColor = Color.FromArgb(94, 76, 76);
            lblPassword.Location = new Point(100, 240);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(82, 23);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Mật khẩu";
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(249, 241, 240);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Location = new Point(100, 195);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(250, 27);
            txtUsername.TabIndex = 3;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 10F);
            lblUsername.ForeColor = Color.FromArgb(94, 76, 76);
            lblUsername.Location = new Point(100, 170);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(124, 23);
            lblUsername.TabIndex = 2;
            lblUsername.Text = "Tên đăng nhập";
            // 
            // lblLoginInstruction
            // 
            lblLoginInstruction.AutoSize = true;
            lblLoginInstruction.ForeColor = Color.FromArgb(142, 127, 127);
            lblLoginInstruction.Location = new Point(100, 125);
            lblLoginInstruction.Name = "lblLoginInstruction";
            lblLoginInstruction.Size = new Size(280, 20);
            lblLoginInstruction.TabIndex = 1;
            lblLoginInstruction.Text = "Vui lòng đăng nhập để sử dụng hệ thống";
            // 
            // lblLoginTitle
            // 
            lblLoginTitle.AutoSize = true;
            lblLoginTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLoginTitle.ForeColor = Color.FromArgb(210, 121, 106);
            lblLoginTitle.Location = new Point(130, 80);
            lblLoginTitle.Name = "lblLoginTitle";
            lblLoginTitle.Size = new Size(227, 46);
            lblLoginTitle.TabIndex = 0;
            lblLoginTitle.Text = "ĐĂNG NHẬP";
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.DarkSalmon;
            pnlLeft.Controls.Add(lblInfo);
            pnlLeft.Controls.Add(lblSubtitle);
            pnlLeft.Controls.Add(lblLibraryTitle);
            pnlLeft.Controls.Add(picLogo);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(350, 500);
            pnlLeft.TabIndex = 0;
            // 
            // lblInfo
            // 
            lblInfo.ForeColor = Color.White;
            lblInfo.Location = new Point(50, 330);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(250, 30);
            lblInfo.TabIndex = 3;
            lblInfo.Text = "Hệ thống quản lý thư viện chuyên nghiệp";
            lblInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            lblSubtitle.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtitle.ForeColor = Color.White;
            lblSubtitle.Location = new Point(50, 290);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(250, 30);
            lblSubtitle.TabIndex = 2;
            lblSubtitle.Text = "KNOWLEDGE KEEPER";
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblLibraryTitle
            // 
            lblLibraryTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLibraryTitle.ForeColor = SystemColors.ButtonHighlight;
            lblLibraryTitle.Location = new Point(50, 250);
            lblLibraryTitle.Name = "lblLibraryTitle";
            lblLibraryTitle.Size = new Size(250, 40);
            lblLibraryTitle.TabIndex = 1;
            lblLibraryTitle.Text = "THƯ VIỆN";
            lblLibraryTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picLogo
            // 
            picLogo.Image = Properties.Resources.librarylgin;
            picLogo.Location = new Point(50, 60);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(250, 180);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // picShowPassword
            // 
            picShowPassword.Cursor = Cursors.Hand;
            picShowPassword.Location = new Point(356, 272);
            picShowPassword.Name = "picShowPassword";
            picShowPassword.Size = new Size(20, 20);
            picShowPassword.SizeMode = PictureBoxSizeMode.Zoom;
            picShowPassword.TabIndex = 9;
            picShowPassword.TabStop = false;
            picShowPassword.Click += picShowPassword_Click;
            // 
            // fLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 500);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng nhập - Quản lý thư viện";
            Load += fLogin_Load;
            pnlMain.ResumeLayout(false);
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            pnlTitleBar.ResumeLayout(false);
            pnlTitleBar.PerformLayout();
            pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ((System.ComponentModel.ISupportInitialize)picShowPassword).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
        private Panel pnlLeft;
        private Label lblLibraryTitle;
        private PictureBox picLogo;
        private Label lblSubtitle;
        private Panel pnlRight;
        private Label lblInfo;
        private Label lblLoginInstruction;
        private Label lblLoginTitle;
        private Label lblPassword;
        private TextBox txtUsername;
        private Label lblUsername;
        private Button btnLogin;
        private CheckBox chkRememberLogin;
        private TextBox txtPassword;
        private Button btnExit;
        private Panel pnlTitleBar;
        private Button btnClose;
        private Label lblFormTitle;
        private PictureBox picShowPassword;
    }
}