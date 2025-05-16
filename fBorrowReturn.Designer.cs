namespace LibraryManagement
{
    partial class fBorrowReturn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fBorrowReturn));

            // Panels
            pnlMemberSearch = new Panel();
            pnlBookSearch = new Panel();
            pnlBorrowInfo = new Panel();
            pnlCurrentBorrows = new Panel();
            pnlBorrowHistory = new Panel();

            // Member Search Controls
            lblMemberTitle = new Label();
            txtMemberSearch = new TextBox();
            btnSearchMember = new Button();
            lblMemberInfo = new Label();
            txtMemberInfo = new TextBox();

            // Book Search Controls
            lblBookTitle = new Label();
            txtBookSearch = new TextBox();
            btnSearchBook = new Button();
            lblBookInfo = new Label();
            txtBookInfo = new TextBox();

            // Borrow Info Controls
            lblBorrowTitle = new Label();
            lblBorrowDate = new Label();
            dtpBorrowDate = new DateTimePicker();
            lblDueDate = new Label();
            dtpDueDate = new DateTimePicker();
            lblNotes = new Label();
            txtNotes = new TextBox();
            btnBorrow = new Button();

            // Current Borrows Controls
            lblCurrentBorrows = new Label();
            dgvCurrentBorrows = new DataGridView();
            btnReturn = new Button();
            btnRenew = new Button();

            // Borrow History Controls
            lblBorrowHistory = new Label();
            dgvBorrowHistory = new DataGridView();
            btnRefresh = new Button();

            // PictureBoxes
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            pbborrow = new PictureBox();

            // Suspend Layout
            pnlMemberSearch.SuspendLayout();
            pnlBookSearch.SuspendLayout();
            pnlBorrowInfo.SuspendLayout();
            pnlCurrentBorrows.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCurrentBorrows).BeginInit();
            pnlBorrowHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBorrowHistory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbborrow).BeginInit();
            SuspendLayout();

            // 
            // pnlMemberSearch
            // 
            pnlMemberSearch.BackColor = Color.White;
            pnlMemberSearch.Controls.Add(pictureBox2);
            pnlMemberSearch.Controls.Add(txtMemberInfo);
            pnlMemberSearch.Controls.Add(lblMemberInfo);
            pnlMemberSearch.Controls.Add(btnSearchMember);
            pnlMemberSearch.Controls.Add(txtMemberSearch);
            pnlMemberSearch.Controls.Add(lblMemberTitle);
            pnlMemberSearch.Location = new Point(20, 20);
            pnlMemberSearch.Name = "pnlMemberSearch";
            pnlMemberSearch.Size = new Size(460, 140);
            pnlMemberSearch.TabIndex = 0;

            // 
            // lblMemberTitle
            // 
            lblMemberTitle.AutoSize = true;
            lblMemberTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMemberTitle.ForeColor = Color.FromArgb(210, 121, 106);
            lblMemberTitle.Location = new Point(15, 15);
            lblMemberTitle.Name = "lblMemberTitle";
            lblMemberTitle.Size = new Size(179, 28);
            lblMemberTitle.TabIndex = 0;
            lblMemberTitle.Text = "TÌM THÀNH VIÊN";

            // 
            // txtMemberSearch
            // 
            txtMemberSearch.Location = new Point(15, 50);
            txtMemberSearch.Name = "txtMemberSearch";
            txtMemberSearch.PlaceholderText = "Nhập tên hoặc số điện thoại...";
            txtMemberSearch.Size = new Size(320, 27);
            txtMemberSearch.TabIndex = 0;
            txtMemberSearch.KeyDown += TxtMemberSearch_KeyDown;

            // 
            // btnSearchMember
            // 
            btnSearchMember.BackColor = Color.FromArgb(129, 195, 215);
            btnSearchMember.FlatAppearance.BorderSize = 0;
            btnSearchMember.FlatStyle = FlatStyle.Flat;
            btnSearchMember.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearchMember.ForeColor = Color.White;
            btnSearchMember.Location = new Point(345, 50);
            btnSearchMember.Name = "btnSearchMember";
            btnSearchMember.Size = new Size(80, 27);
            btnSearchMember.TabIndex = 1;
            btnSearchMember.Text = "Tìm";
            btnSearchMember.UseVisualStyleBackColor = false;
            btnSearchMember.Click += btnSearchMember_Click;

            // 
            // lblMemberInfo
            // 
            lblMemberInfo.AutoSize = true;
            lblMemberInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMemberInfo.ForeColor = Color.FromArgb(94, 76, 76);
            lblMemberInfo.Location = new Point(15, 80);
            lblMemberInfo.Name = "lblMemberInfo";
            lblMemberInfo.Size = new Size(159, 20);
            lblMemberInfo.TabIndex = 2;
            lblMemberInfo.Text = "Thông tin thành viên:";

            // 
            // txtMemberInfo
            // 
            txtMemberInfo.BackColor = Color.FromArgb(249, 245, 245);
            txtMemberInfo.BorderStyle = BorderStyle.FixedSingle;
            txtMemberInfo.Location = new Point(15, 105);
            txtMemberInfo.Name = "txtMemberInfo";
            txtMemberInfo.ReadOnly = true;
            txtMemberInfo.Size = new Size(410, 27);
            txtMemberInfo.TabIndex = 3;

            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(193, 15);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(33, 28);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;

            // 
            // pnlBookSearch
            // 
            pnlBookSearch.BackColor = Color.White;
            pnlBookSearch.Controls.Add(pictureBox3);
            pnlBookSearch.Controls.Add(txtBookInfo);
            pnlBookSearch.Controls.Add(lblBookInfo);
            pnlBookSearch.Controls.Add(btnSearchBook);
            pnlBookSearch.Controls.Add(txtBookSearch);
            pnlBookSearch.Controls.Add(lblBookTitle);
            pnlBookSearch.Location = new Point(490, 20);
            pnlBookSearch.Name = "pnlBookSearch";
            pnlBookSearch.Size = new Size(460, 140);
            pnlBookSearch.TabIndex = 1;

            // 
            // lblBookTitle
            // 
            lblBookTitle.AutoSize = true;
            lblBookTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBookTitle.ForeColor = Color.FromArgb(210, 121, 106);
            lblBookTitle.Location = new Point(15, 15);
            lblBookTitle.Name = "lblBookTitle";
            lblBookTitle.Size = new Size(107, 28);
            lblBookTitle.TabIndex = 4;
            lblBookTitle.Text = "TÌM SÁCH";

            // 
            // txtBookSearch
            // 
            txtBookSearch.Location = new Point(15, 50);
            txtBookSearch.Name = "txtBookSearch";
            txtBookSearch.PlaceholderText = "Nhập tên sách, ISBN...";
            txtBookSearch.Size = new Size(320, 27);
            txtBookSearch.TabIndex = 2;
            txtBookSearch.KeyDown += TxtBookSearch_KeyDown;

            // 
            // btnSearchBook
            // 
            btnSearchBook.BackColor = Color.FromArgb(129, 195, 215);
            btnSearchBook.FlatAppearance.BorderSize = 0;
            btnSearchBook.FlatStyle = FlatStyle.Flat;
            btnSearchBook.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearchBook.ForeColor = Color.White;
            btnSearchBook.Location = new Point(345, 50);
            btnSearchBook.Name = "btnSearchBook";
            btnSearchBook.Size = new Size(80, 27);
            btnSearchBook.TabIndex = 3;
            btnSearchBook.Text = "Tìm";
            btnSearchBook.UseVisualStyleBackColor = false;
            btnSearchBook.Click += btnSearchBook_Click;

            // 
            // lblBookInfo
            // 
            lblBookInfo.AutoSize = true;
            lblBookInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBookInfo.ForeColor = Color.FromArgb(94, 76, 76);
            lblBookInfo.Location = new Point(15, 80);
            lblBookInfo.Name = "lblBookInfo";
            lblBookInfo.Size = new Size(116, 20);
            lblBookInfo.TabIndex = 4;
            lblBookInfo.Text = "Thông tin sách:";

            // 
            // txtBookInfo
            // 
            txtBookInfo.BackColor = Color.FromArgb(249, 245, 245);
            txtBookInfo.BorderStyle = BorderStyle.FixedSingle;
            txtBookInfo.Location = new Point(15, 105);
            txtBookInfo.Name = "txtBookInfo";
            txtBookInfo.ReadOnly = true;
            txtBookInfo.Size = new Size(410, 27);
            txtBookInfo.TabIndex = 5;

            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(120, 16);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(33, 28);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 12;
            pictureBox3.TabStop = false;

            // 
            // pnlBorrowInfo
            // 
            pnlBorrowInfo.BackColor = Color.White;
            pnlBorrowInfo.Controls.Add(pictureBox4);
            pnlBorrowInfo.Controls.Add(btnBorrow);
            pnlBorrowInfo.Controls.Add(txtNotes);
            pnlBorrowInfo.Controls.Add(lblNotes);
            pnlBorrowInfo.Controls.Add(dtpDueDate);
            pnlBorrowInfo.Controls.Add(dtpBorrowDate);
            pnlBorrowInfo.Controls.Add(lblDueDate);
            pnlBorrowInfo.Controls.Add(lblBorrowDate);
            pnlBorrowInfo.Controls.Add(lblBorrowTitle);
            pnlBorrowInfo.Location = new Point(20, 170);
            pnlBorrowInfo.Name = "pnlBorrowInfo";
            pnlBorrowInfo.Size = new Size(930, 100);
            pnlBorrowInfo.TabIndex = 2;

            // 
            // lblBorrowTitle
            // 
            lblBorrowTitle.AutoSize = true;
            lblBorrowTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBorrowTitle.ForeColor = Color.FromArgb(210, 121, 106);
            lblBorrowTitle.Location = new Point(15, 15);
            lblBorrowTitle.Name = "lblBorrowTitle";
            lblBorrowTitle.Size = new Size(255, 28);
            lblBorrowTitle.TabIndex = 0;
            lblBorrowTitle.Text = "THÔNG TIN MƯỢN SÁCH";

            // 
            // lblBorrowDate
            // 
            lblBorrowDate.AutoSize = true;
            lblBorrowDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBorrowDate.ForeColor = Color.FromArgb(94, 76, 76);
            lblBorrowDate.Location = new Point(15, 50);
            lblBorrowDate.Name = "lblBorrowDate";
            lblBorrowDate.Size = new Size(96, 20);
            lblBorrowDate.TabIndex = 1;
            lblBorrowDate.Text = "Ngày mượn:";

            // 
            // dtpBorrowDate
            // 
            dtpBorrowDate.Format = DateTimePickerFormat.Short;
            dtpBorrowDate.Location = new Point(115, 47);
            dtpBorrowDate.Name = "dtpBorrowDate";
            dtpBorrowDate.Size = new Size(150, 27);
            dtpBorrowDate.TabIndex = 4;

            // 
            // lblDueDate
            // 
            lblDueDate.AutoSize = true;
            lblDueDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDueDate.ForeColor = Color.FromArgb(94, 76, 76);
            lblDueDate.Location = new Point(280, 50);
            lblDueDate.Name = "lblDueDate";
            lblDueDate.Size = new Size(65, 20);
            lblDueDate.TabIndex = 2;
            lblDueDate.Text = "Hạn trả:";

            // 
            // dtpDueDate
            // 
            dtpDueDate.Format = DateTimePickerFormat.Short;
            dtpDueDate.Location = new Point(347, 47);
            dtpDueDate.Name = "dtpDueDate";
            dtpDueDate.Size = new Size(150, 27);
            dtpDueDate.TabIndex = 5;

            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNotes.ForeColor = Color.FromArgb(94, 76, 76);
            lblNotes.Location = new Point(520, 50);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(66, 20);
            lblNotes.TabIndex = 5;
            lblNotes.Text = "Ghi chú:";

            // 
            // txtNotes
            // 
            txtNotes.ForeColor = Color.FromArgb(94, 76, 76);
            txtNotes.Location = new Point(590, 47);
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(200, 27);
            txtNotes.TabIndex = 6;

            // 
            // btnBorrow
            // 
            btnBorrow.BackColor = Color.FromArgb(210, 121, 106);
            btnBorrow.FlatAppearance.BorderSize = 0;
            btnBorrow.FlatStyle = FlatStyle.Flat;
            btnBorrow.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBorrow.ForeColor = Color.White;
            btnBorrow.Location = new Point(800, 44);
            btnBorrow.Name = "btnBorrow";
            btnBorrow.Size = new Size(100, 35);
            btnBorrow.TabIndex = 7;
            btnBorrow.Text = "Mượn sách";
            btnBorrow.UseVisualStyleBackColor = false;
            btnBorrow.Click += btnBorrow_Click;

            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(269, 15);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(33, 28);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 13;
            pictureBox4.TabStop = false;

            // 
            // pnlCurrentBorrows
            // 
            pnlCurrentBorrows.BackColor = Color.White;
            pnlCurrentBorrows.Controls.Add(pbborrow);
            pnlCurrentBorrows.Controls.Add(btnRenew);
            pnlCurrentBorrows.Controls.Add(btnReturn);
            pnlCurrentBorrows.Controls.Add(dgvCurrentBorrows);
            pnlCurrentBorrows.Controls.Add(lblCurrentBorrows);
            pnlCurrentBorrows.Location = new Point(20, 280);
            pnlCurrentBorrows.Name = "pnlCurrentBorrows";
            pnlCurrentBorrows.Size = new Size(460, 350);
            pnlCurrentBorrows.TabIndex = 3;

            // 
            // lblCurrentBorrows
            // 
            lblCurrentBorrows.AutoSize = true;
            lblCurrentBorrows.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCurrentBorrows.ForeColor = Color.FromArgb(210, 121, 106);
            lblCurrentBorrows.Location = new Point(15, 15);
            lblCurrentBorrows.Name = "lblCurrentBorrows";
            lblCurrentBorrows.Size = new Size(202, 28);
            lblCurrentBorrows.TabIndex = 7;
            lblCurrentBorrows.Text = "SÁCH ĐANG MƯỢN";

            // 
            // dgvCurrentBorrows
            // 
            dgvCurrentBorrows.AllowUserToAddRows = false;
            dgvCurrentBorrows.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCurrentBorrows.BackgroundColor = Color.White;
            dgvCurrentBorrows.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCurrentBorrows.Location = new Point(15, 50);
            dgvCurrentBorrows.Name = "dgvCurrentBorrows";
            dgvCurrentBorrows.ReadOnly = true;
            dgvCurrentBorrows.RowHeadersWidth = 51;
            dgvCurrentBorrows.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCurrentBorrows.Size = new Size(430, 250);
            dgvCurrentBorrows.TabIndex = 8;
            dgvCurrentBorrows.SelectionChanged += DgvCurrentBorrows_SelectionChanged;

            // 
            // btnReturn
            // 
            btnReturn.BackColor = Color.FromArgb(34, 139, 34);
            btnReturn.FlatAppearance.BorderSize = 0;
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReturn.ForeColor = Color.White;
            btnReturn.Location = new Point(250, 310);
            btnReturn.Name = "btnReturn";
            btnReturn.Size = new Size(90, 30);
            btnReturn.TabIndex = 9;
            btnReturn.Text = "Trả sách";
            btnReturn.UseVisualStyleBackColor = false;
            btnReturn.Click += btnReturn_Click;

            // 
            // btnRenew
            // 
            btnRenew.BackColor = Color.FromArgb(255, 165, 0);
            btnRenew.FlatAppearance.BorderSize = 0;
            btnRenew.FlatStyle = FlatStyle.Flat;
            btnRenew.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRenew.ForeColor = Color.White;
            btnRenew.Location = new Point(350, 310);
            btnRenew.Name = "btnRenew";
            btnRenew.Size = new Size(90, 30);
            btnRenew.TabIndex = 10;
            btnRenew.Text = "Gia hạn";
            btnRenew.UseVisualStyleBackColor = false;
            btnRenew.Click += btnRenew_Click;

            // 
            // pbborrow
            // 
            pbborrow.Image = (Image)resources.GetObject("pbborrow.Image");
            pbborrow.Location = new Point(211, 15);
            pbborrow.Name = "pbborrow";
            pbborrow.Size = new Size(33, 28);
            pbborrow.SizeMode = PictureBoxSizeMode.Zoom;
            pbborrow.TabIndex = 9;
            pbborrow.TabStop = false;

            // 
            // pnlBorrowHistory
            // 
            pnlBorrowHistory.BackColor = Color.White;
            pnlBorrowHistory.Controls.Add(pictureBox1);
            pnlBorrowHistory.Controls.Add(btnRefresh);
            pnlBorrowHistory.Controls.Add(dgvBorrowHistory);
            pnlBorrowHistory.Controls.Add(lblBorrowHistory);
            pnlBorrowHistory.Location = new Point(490, 280);
            pnlBorrowHistory.Name = "pnlBorrowHistory";
            pnlBorrowHistory.Size = new Size(460, 350);
            pnlBorrowHistory.TabIndex = 10;

            // 
            // lblBorrowHistory
            // 
            lblBorrowHistory.AutoSize = true;
            lblBorrowHistory.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBorrowHistory.ForeColor = Color.FromArgb(210, 121, 106);
            lblBorrowHistory.Location = new Point(15, 15);
            lblBorrowHistory.Name = "lblBorrowHistory";
            lblBorrowHistory.Size = new Size(161, 28);
            lblBorrowHistory.TabIndex = 7;
            lblBorrowHistory.Text = "LỊCH SỬ MƯỢN";

            // 
            // dgvBorrowHistory
            // 
            dgvBorrowHistory.AllowUserToAddRows = false;
            dgvBorrowHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBorrowHistory.BackgroundColor = Color.White;
            dgvBorrowHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBorrowHistory.Location = new Point(15, 50);
            dgvBorrowHistory.Name = "dgvBorrowHistory";
            dgvBorrowHistory.ReadOnly = true;
            dgvBorrowHistory.RowHeadersWidth = 51;
            dgvBorrowHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBorrowHistory.Size = new Size(430, 250);
            dgvBorrowHistory.TabIndex = 8;
            dgvBorrowHistory.SelectionChanged += DgvBorrowHistory_SelectionChanged;

            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(129, 195, 215);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(350, 310);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(90, 30);
            btnRefresh.TabIndex = 11;
            btnRefresh.Text = "Làm mới";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;

            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(175, 15);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(33, 28);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;

            // 
            // fBorrowReturn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(249, 241, 240);
            ClientSize = new Size(970, 650);
            Controls.Add(pnlBorrowHistory);
            Controls.Add(pnlCurrentBorrows);
            Controls.Add(pnlBorrowInfo);
            Controls.Add(pnlBookSearch);
            Controls.Add(pnlMemberSearch);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fBorrowReturn";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mượn / Trả sách";
            Load += fBorrowReturn_Load;
            pnlMemberSearch.ResumeLayout(false);
            pnlMemberSearch.PerformLayout();
            pnlBookSearch.ResumeLayout(false);
            pnlBookSearch.PerformLayout();
            pnlBorrowInfo.ResumeLayout(false);
            pnlBorrowInfo.PerformLayout();
            pnlCurrentBorrows.ResumeLayout(false);
            pnlCurrentBorrows.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCurrentBorrows).EndInit();
            pnlBorrowHistory.ResumeLayout(false);
            pnlBorrowHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbborrow).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMemberSearch;
        private Panel pnlBookSearch;
        private Panel pnlBorrowInfo;
        private Panel pnlCurrentBorrows;
        private Panel pnlBorrowHistory;

        private Label lblMemberTitle;
        private TextBox txtMemberSearch;
        private Button btnSearchMember;
        private Label lblMemberInfo;
        private TextBox txtMemberInfo;

        private Label lblBookTitle;
        private TextBox txtBookSearch;
        private Button btnSearchBook;
        private Label lblBookInfo;
        private TextBox txtBookInfo;

        private Label lblBorrowTitle;
        private Label lblBorrowDate;
        private DateTimePicker dtpBorrowDate;
        private Label lblDueDate;
        private DateTimePicker dtpDueDate;
        private Label lblNotes;
        private TextBox txtNotes;
        private Button btnBorrow;

        private Label lblCurrentBorrows;
        private DataGridView dgvCurrentBorrows;
        private Button btnReturn;
        private Button btnRenew;

        private Label lblBorrowHistory;
        private DataGridView dgvBorrowHistory;
        private Button btnRefresh;

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pbborrow;
    }
}