namespace LibraryManagement
{
    partial class fBookManagement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fBookManagement));
            pnlBookInfo = new Panel();
            txtDescription = new TextBox();
            lblDescription = new Label();
            lblTotalCopies = new Label();
            cboAuthor = new ComboBox();
            numTotalCopies = new NumericUpDown();
            lblAuthor = new Label();
            comboBox1 = new ComboBox();
            lblCategory = new Label();
            txtPublicationYear = new TextBox();
            lblPublicationYear = new Label();
            txtISBN = new TextBox();
            txtTitle = new TextBox();
            lblISBN = new Label();
            lblTitle = new Label();
            lblBookInfo = new Label();
            pnlSearch = new Panel();
            btnSearch = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            pnlDataGird = new Panel();
            btnRefresh = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            pictureBox1 = new PictureBox();
            dgvBooks = new DataGridView();
            lblBookList = new Label();
            pnlBookInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numTotalCopies).BeginInit();
            pnlSearch.SuspendLayout();
            pnlDataGird.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).BeginInit();
            SuspendLayout();
            // 
            // pnlBookInfo
            // 
            pnlBookInfo.BackColor = Color.White;
            pnlBookInfo.Controls.Add(txtDescription);
            pnlBookInfo.Controls.Add(lblDescription);
            pnlBookInfo.Controls.Add(lblTotalCopies);
            pnlBookInfo.Controls.Add(cboAuthor);
            pnlBookInfo.Controls.Add(numTotalCopies);
            pnlBookInfo.Controls.Add(lblAuthor);
            pnlBookInfo.Controls.Add(comboBox1);
            pnlBookInfo.Controls.Add(lblCategory);
            pnlBookInfo.Controls.Add(txtPublicationYear);
            pnlBookInfo.Controls.Add(lblPublicationYear);
            pnlBookInfo.Controls.Add(txtISBN);
            pnlBookInfo.Controls.Add(txtTitle);
            pnlBookInfo.Controls.Add(lblISBN);
            pnlBookInfo.Controls.Add(lblTitle);
            pnlBookInfo.Controls.Add(lblBookInfo);
            pnlBookInfo.Location = new Point(20, 20);
            pnlBookInfo.Name = "pnlBookInfo";
            pnlBookInfo.Size = new Size(930, 260);
            pnlBookInfo.TabIndex = 1;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(550, 55);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(350, 170);
            txtDescription.TabIndex = 14;
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.BackColor = Color.White;
            lblDescription.ForeColor = Color.FromArgb(94, 76, 76);
            lblDescription.Location = new Point(435, 55);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(51, 20);
            lblDescription.TabIndex = 13;
            lblDescription.Text = "Mô tả:";
            // 
            // lblTotalCopies
            // 
            lblTotalCopies.AutoSize = true;
            lblTotalCopies.BackColor = Color.White;
            lblTotalCopies.ForeColor = Color.FromArgb(94, 76, 76);
            lblTotalCopies.Location = new Point(15, 230);
            lblTotalCopies.Name = "lblTotalCopies";
            lblTotalCopies.Size = new Size(72, 20);
            lblTotalCopies.TabIndex = 12;
            lblTotalCopies.Text = "Số lượng:";
            // 
            // cboAuthor
            // 
            cboAuthor.FormattingEnabled = true;
            cboAuthor.Location = new Point(155, 195);
            cboAuthor.Name = "cboAuthor";
            cboAuthor.Size = new Size(250, 28);
            cboAuthor.TabIndex = 11;
            // 
            // numTotalCopies
            // 
            numTotalCopies.Location = new Point(155, 229);
            numTotalCopies.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numTotalCopies.Name = "numTotalCopies";
            numTotalCopies.Size = new Size(250, 27);
            numTotalCopies.TabIndex = 10;
            numTotalCopies.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.BackColor = Color.White;
            lblAuthor.ForeColor = Color.FromArgb(94, 76, 76);
            lblAuthor.Location = new Point(15, 195);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(58, 20);
            lblAuthor.TabIndex = 9;
            lblAuthor.Text = "Tác giả:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(155, 160);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(250, 28);
            comboBox1.TabIndex = 8;
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.BackColor = Color.White;
            lblCategory.ForeColor = Color.FromArgb(94, 76, 76);
            lblCategory.Location = new Point(15, 160);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(65, 20);
            lblCategory.TabIndex = 7;
            lblCategory.Text = "Thể loại:";
            // 
            // txtPublicationYear
            // 
            txtPublicationYear.Location = new Point(155, 125);
            txtPublicationYear.Name = "txtPublicationYear";
            txtPublicationYear.Size = new Size(250, 27);
            txtPublicationYear.TabIndex = 6;
            // 
            // lblPublicationYear
            // 
            lblPublicationYear.AutoSize = true;
            lblPublicationYear.BackColor = Color.White;
            lblPublicationYear.ForeColor = Color.FromArgb(94, 76, 76);
            lblPublicationYear.Location = new Point(15, 125);
            lblPublicationYear.Name = "lblPublicationYear";
            lblPublicationYear.Size = new Size(105, 20);
            lblPublicationYear.TabIndex = 5;
            lblPublicationYear.Text = "Năm xuất bản:";
            // 
            // txtISBN
            // 
            txtISBN.Location = new Point(155, 90);
            txtISBN.Name = "txtISBN";
            txtISBN.Size = new Size(250, 27);
            txtISBN.TabIndex = 4;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(155, 55);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(250, 27);
            txtTitle.TabIndex = 3;
            // 
            // lblISBN
            // 
            lblISBN.AutoSize = true;
            lblISBN.BackColor = Color.White;
            lblISBN.ForeColor = Color.FromArgb(94, 76, 76);
            lblISBN.Location = new Point(15, 90);
            lblISBN.Name = "lblISBN";
            lblISBN.Size = new Size(44, 20);
            lblISBN.TabIndex = 2;
            lblISBN.Text = "ISBN:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.BackColor = Color.White;
            lblTitle.ForeColor = Color.FromArgb(94, 76, 76);
            lblTitle.Location = new Point(15, 55);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(68, 20);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Tên sách:";
            // 
            // lblBookInfo
            // 
            lblBookInfo.AutoSize = true;
            lblBookInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBookInfo.ForeColor = Color.FromArgb(210, 121, 106);
            lblBookInfo.Location = new Point(15, 15);
            lblBookInfo.Name = "lblBookInfo";
            lblBookInfo.Size = new Size(182, 28);
            lblBookInfo.TabIndex = 0;
            lblBookInfo.Text = "THÔNG TIN SÁCH";
            // 
            // pnlSearch
            // 
            pnlSearch.BackColor = Color.White;
            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Controls.Add(lblSearch);
            pnlSearch.Location = new Point(20, 283);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(930, 60);
            pnlSearch.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(129, 195, 215);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
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
            txtSearch.BackColor = Color.White;
            txtSearch.Location = new Point(100, 17);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(450, 27);
            txtSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.ForeColor = Color.FromArgb(94, 76, 76);
            lblSearch.Location = new Point(15, 20);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(73, 20);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Tìm kiếm:";
            // 
            // pnlDataGird
            // 
            pnlDataGird.BackColor = Color.White;
            pnlDataGird.Controls.Add(btnRefresh);
            pnlDataGird.Controls.Add(btnDelete);
            pnlDataGird.Controls.Add(btnUpdate);
            pnlDataGird.Controls.Add(btnAdd);
            pnlDataGird.Controls.Add(pictureBox1);
            pnlDataGird.Controls.Add(dgvBooks);
            pnlDataGird.Controls.Add(lblBookList);
            pnlDataGird.ForeColor = SystemColors.ButtonHighlight;
            pnlDataGird.Location = new Point(20, 350);
            pnlDataGird.Name = "pnlDataGird";
            pnlDataGird.Size = new Size(930, 250);
            pnlDataGird.TabIndex = 3;
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
            btnDelete.ForeColor = Color.White;
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
            btnUpdate.ForeColor = Color.White;
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
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(202, 14);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(33, 28);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // dgvBooks
            // 
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.AllowUserToDeleteRows = false;
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.BackgroundColor = Color.White;
            dgvBooks.BorderStyle = BorderStyle.None;
            dgvBooks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBooks.Location = new Point(15, 50);
            dgvBooks.Name = "dgvBooks";
            dgvBooks.ReadOnly = true;
            dgvBooks.RowHeadersWidth = 51;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBooks.Size = new Size(900, 180);
            dgvBooks.TabIndex = 1;
            dgvBooks.SelectionChanged += dgvBooks_SelectionChanged;
            // 
            // lblBookList
            // 
            lblBookList.AutoSize = true;
            lblBookList.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBookList.ForeColor = Color.FromArgb(210, 121, 106);
            lblBookList.Location = new Point(15, 15);
            lblBookList.Name = "lblBookList";
            lblBookList.Size = new Size(194, 28);
            lblBookList.TabIndex = 0;
            lblBookList.Text = "DANH SÁCH SÁCH ";
            // 
            // fBookManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(249, 241, 240);
            ClientSize = new Size(970, 650);
            Controls.Add(pnlDataGird);
            Controls.Add(pnlSearch);
            Controls.Add(pnlBookInfo);
            FormBorderStyle = FormBorderStyle.None;
            Name = "fBookManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý sách";
            Load += fBookManagement_Load;
            pnlBookInfo.ResumeLayout(false);
            pnlBookInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numTotalCopies).EndInit();
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            pnlDataGird.ResumeLayout(false);
            pnlDataGird.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBooks).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlBookInfo;
        private Panel pnlSearch;
        private Panel pnlDataGird;
        private Label lblISBN;
        private Label lblTitle;
        private Label lblBookInfo;
        private TextBox txtISBN;
        private TextBox txtTitle;
        private ComboBox cboAuthor;
        private NumericUpDown numTotalCopies;
        private Label lblAuthor;
        private ComboBox comboBox1;
        private Label lblCategory;
        private TextBox txtPublicationYear;
        private Label lblPublicationYear;
        private Label lblDescription;
        private Label lblTotalCopies;
        private TextBox txtDescription;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private Label lblBookList;
        private DataGridView dgvBooks;
        private PictureBox pictureBox1;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnRefresh;
        private Button btnDelete;
    }
}