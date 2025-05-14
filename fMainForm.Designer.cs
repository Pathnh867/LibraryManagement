namespace LibraryManagement
{
    partial class fMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMainForm));
            pnlHeader = new Panel();
            lblTitle = new Label();
            btnMinimize = new Button();
            btnClose = new Button();
            pnlSidebar = new Panel();
            lblUserName = new Label();
            pnlUserInfo = new Panel();
            picAvatar = new PictureBox();
            pnlContent = new Panel();
            lblUserRole = new Label();
            pnlHeader.SuspendLayout();
            pnlSidebar.SuspendLayout();
            pnlUserInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.DarkSalmon;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnMinimize);
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1200, 50);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Top;
            lblTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(500, 5);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(300, 40);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "QUẢN LÝ THƯ VIỆN";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnMinimize
            // 
            btnMinimize.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnMinimize.Location = new Point(1115, 5);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(40, 40);
            btnMinimize.TabIndex = 1;
            btnMinimize.Text = "−";
            btnMinimize.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            btnClose.Location = new Point(1155, 5);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(40, 40);
            btnClose.TabIndex = 0;
            btnClose.Text = "×";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // pnlSidebar
            // 
            pnlSidebar.BackColor = Color.FromArgb(210, 121, 106);
            pnlSidebar.Controls.Add(pnlUserInfo);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 50);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(230, 650);
            pnlSidebar.TabIndex = 1;
            // 
            // lblUserName
            // 
            lblUserName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserName.Location = new Point(15, 105);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(200, 25);
            lblUserName.TabIndex = 1;
            lblUserName.Text = "Admin";
            lblUserName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlUserInfo
            // 
            pnlUserInfo.BackColor = Color.Transparent;
            pnlUserInfo.Controls.Add(lblUserRole);
            pnlUserInfo.Controls.Add(lblUserName);
            pnlUserInfo.Controls.Add(picAvatar);
            pnlUserInfo.Dock = DockStyle.Top;
            pnlUserInfo.Location = new Point(0, 0);
            pnlUserInfo.Name = "pnlUserInfo";
            pnlUserInfo.Size = new Size(230, 150);
            pnlUserInfo.TabIndex = 0;
            // 
            // picAvatar
            // 
            picAvatar.Image = (Image)resources.GetObject("picAvatar.Image");
            picAvatar.Location = new Point(75, 20);
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(80, 80);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 0;
            picAvatar.TabStop = false;
            // 
            // pnlContent
            // 
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(230, 50);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(970, 650);
            pnlContent.TabIndex = 2;
            // 
            // lblUserRole
            // 
            lblUserRole.ForeColor = Color.WhiteSmoke;
            lblUserRole.Location = new Point(15, 130);
            lblUserRole.Name = "lblUserRole";
            lblUserRole.Size = new Size(200, 20);
            lblUserRole.TabIndex = 2;
            lblUserRole.Text = "Quản trị viên";
            lblUserRole.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(249, 241, 240);
            ClientSize = new Size(1200, 700);
            Controls.Add(pnlContent);
            Controls.Add(pnlSidebar);
            Controls.Add(pnlHeader);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Name = "fMainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý thư viện";
            Load += fMainForm_Load;
            pnlHeader.ResumeLayout(false);
            pnlSidebar.ResumeLayout(false);
            pnlUserInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Button btnClose;
        private Panel pnlSidebar;
        private Panel pnlUserInfo;
        private Panel pnlContent;
        private Button btnMinimize;
        private Label lblTitle;
        private PictureBox picAvatar;
        private Label lblUserName;
        private Button button1;
        private Label lblUserRole;
    }
}