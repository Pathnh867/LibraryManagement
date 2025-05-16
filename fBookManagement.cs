using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement
{
    public partial class fBookManagement : Form
    {
        private LibraryDbContext context;
        private Book currentBook = null;
        private bool isAddNew = false;

        public fBookManagement()
        {
            InitializeComponent();

            // Initialize database context
            context = new LibraryDbContext();

            // Set form style
            ApplyFormStyle();

            // Load data to form
            LoadCategories();
            LoadAuthors();
            LoadBookData();
            this.Load += fBookManagement_Load;
            SetControlState(false);
        }

        #region UI/UX Functions

        private void ApplyFormStyle()
        {
            // Apply rounded corners to buttons
            ApplyRoundedCorners(btnAdd, 8);
            ApplyRoundedCorners(btnUpdate, 8); // Update button
            ApplyRoundedCorners(btnDelete, 8);
            ApplyRoundedCorners(btnRefresh, 8); // Refresh button
            ApplyRoundedCorners(btnSearch, 8);

            // Set custom colors
            btnAdd.BackColor = Color.FromArgb(210, 121, 106);
            btnUpdate.BackColor = Color.FromArgb(210, 121, 106);
            btnDelete.BackColor = Color.FromArgb(192, 0, 0);
            btnRefresh.BackColor = Color.FromArgb(129, 195, 215);
            btnSearch.BackColor = Color.FromArgb(129, 195, 215);

            // Setup hover events
            btnAdd.MouseEnter += Button_MouseEnter;
            btnAdd.MouseLeave += Button_MouseLeave;
            btnUpdate.MouseEnter += Button_MouseEnter;
            btnUpdate.MouseLeave += Button_MouseLeave;
            btnDelete.MouseEnter += Button_MouseEnter;
            btnDelete.MouseLeave += Button_MouseLeave;
            btnRefresh.MouseEnter += Button_MouseEnter;
            btnRefresh.MouseLeave += Button_MouseLeave;
            btnSearch.MouseEnter += Button_MouseEnter;
            btnSearch.MouseLeave += Button_MouseLeave;

            // Set event handlers for CRUD operations
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnSearch.Click += btnSearch_Click;

            // GridView selection changed
            dgvBooks.SelectionChanged += dgvBooks_SelectionChanged;

            // Add drop shadow to panels
            AddShadow(pnlBookInfo);
            AddShadow(pnlSearch);
            AddShadow(pnlDataGird);
        }

        private void AddShadow(Panel panel)
        {
            panel.Paint += (s, e) =>
            {
                Graphics g = e.Graphics;
                Rectangle rect = new Rectangle(0, 0, panel.Width, panel.Height);
                g.SmoothingMode = SmoothingMode.AntiAlias;

                using (GraphicsPath path = new GraphicsPath())
                {
                    int radius = 10;
                    path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
                    path.AddArc(rect.Width - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90);
                    path.AddArc(rect.Width - radius * 2, rect.Height - radius * 2, radius * 2, radius * 2, 0, 90);
                    path.AddArc(rect.X, rect.Height - radius * 2, radius * 2, radius * 2, 90, 90);
                    path.CloseAllFigures();

                    panel.Region = new Region(path);

                    using (Pen pen = new Pen(Color.FromArgb(30, 0, 0, 0), 1))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            };
        }

        private void ApplyRoundedCorners(Control control, int radius)
        {
            Rectangle rect = new Rectangle(0, 0, control.Width, control.Height);
            GraphicsPath path = new GraphicsPath();

            path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
            path.AddArc(rect.Width - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90);
            path.AddArc(rect.Width - radius * 2, rect.Height - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(rect.X, rect.Height - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseAllFigures();

            control.Region = new Region(path);
        }

        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Darker shade on hover
                if (btn == btnAdd || btn == this.btnUpdate)
                    btn.BackColor = Color.FromArgb(190, 101, 86);
                else if (btn == btnDelete)
                    btn.BackColor = Color.FromArgb(172, 0, 0);
                else if (btn == btnRefresh || btn == btnSearch)
                    btn.BackColor = Color.FromArgb(109, 175, 195);
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Restore original color
                if (btn == btnAdd || btn == this.btnUpdate)
                    btn.BackColor = Color.FromArgb(210, 121, 106);
                else if (btn == btnDelete)
                    btn.BackColor = Color.FromArgb(192, 0, 0);
                else if (btn == btnRefresh || btn == btnSearch)
                    btn.BackColor = Color.FromArgb(129, 195, 215);
            }
        }

        #endregion

        #region Data Access Functions

        private void LoadCategories()
        {
            try
            {
                var categories = context.Categories.OrderBy(c => c.Name).ToList();
                comboBox1.DataSource = categories;
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "CategoryId";
                comboBox1.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh mục: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAuthors()
        {
            try
            {
                var authors = context.Authors.OrderBy(a => a.Name).ToList();
                cboAuthor.DataSource = authors;
                cboAuthor.DisplayMember = "Name";
                cboAuthor.ValueMember = "AuthorId";
                cboAuthor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải tác giả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBookData()
        {
            try
            {
                var books = context.Books
                    .Include(b => b.Author)
                    .Include(b => b.Category)
                    .OrderBy(b => b.Title)
                    .Select(b => new {
                        b.BookId,
                        b.Title,
                        b.ISBN,
                        b.PublicationYear,
                        CategoryName = b.Category.Name,
                        AuthorName = b.Author.Name,
                        b.TotalCopies,
                        b.AvailableCopies,
                        b.Description
                    })
                    .ToList();

                dgvBooks.DataSource = books;

                // Format datagrid
                dgvBooks.Columns["BookId"].HeaderText = "Mã sách";
                dgvBooks.Columns["Title"].HeaderText = "Tên sách";
                dgvBooks.Columns["ISBN"].HeaderText = "ISBN";
                dgvBooks.Columns["PublicationYear"].HeaderText = "Năm XB";
                dgvBooks.Columns["CategoryName"].HeaderText = "Thể loại";
                dgvBooks.Columns["AuthorName"].HeaderText = "Tác giả";
                dgvBooks.Columns["TotalCopies"].HeaderText = "Tổng số";
                dgvBooks.Columns["AvailableCopies"].HeaderText = "Khả dụng";
                dgvBooks.Columns["Description"].Visible = false;

                // Auto size columns
                dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Set text color to black or dark gray
                dgvBooks.ForeColor = Color.FromArgb(64, 64, 64); // Dark gray
                dgvBooks.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);

                // Header style
                dgvBooks.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                dgvBooks.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(210, 121, 106);
                dgvBooks.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvBooks.EnableHeadersVisualStyles = false;

                // Alternate row colors for better readability
                dgvBooks.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 245, 245);
                dgvBooks.DefaultCellStyle.BackColor = Color.White;

                // Selection style
                dgvBooks.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 121, 106);
                dgvBooks.DefaultCellStyle.SelectionForeColor = Color.White;

                // Set row height
                dgvBooks.RowTemplate.Height = 28;

                // Adjust grid lines
                dgvBooks.GridColor = Color.FromArgb(224, 224, 224);
                dgvBooks.BorderStyle = BorderStyle.None;
                dgvBooks.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearFields()
        {
            txtTitle.Text = string.Empty;
            txtISBN.Text = string.Empty;
            txtPublicationYear.Text = string.Empty;
            comboBox1.SelectedIndex = -1;
            cboAuthor.SelectedIndex = -1;
            numTotalCopies.Value = 1;
            txtDescription.Text = string.Empty;
            currentBook = null;
        }

        private void SetControlState(bool isEditing)
        {
            txtTitle.Enabled = isEditing;
            txtISBN.Enabled = isEditing;
            txtPublicationYear.Enabled = isEditing;
            comboBox1.Enabled = isEditing;
            cboAuthor.Enabled = isEditing;
            numTotalCopies.Enabled = isEditing;
            txtDescription.Enabled = isEditing;

            btnAdd.Enabled = !isEditing;
            btnUpdate.Enabled = !isEditing && currentBook != null;
            btnDelete.Enabled = !isEditing && currentBook != null;
        }

        private void DisplayBookData(Book book)
        {
            if (book != null)
            {
                txtTitle.Text = book.Title;
                txtISBN.Text = book.ISBN;
                txtPublicationYear.Text = book.PublicationYear.ToString();
                comboBox1.SelectedValue = book.CategoryId;
                cboAuthor.SelectedValue = book.AuthorId;
                numTotalCopies.Value = book.TotalCopies;
                txtDescription.Text = book.Description;
            }
        }

        private bool ValidateBookData()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Vui lòng nhập tên sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return false;
            }

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn thể loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBox1.Focus();
                return false;
            }

            if (cboAuthor.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn tác giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboAuthor.Focus();
                return false;
            }

            int year;
            if (!int.TryParse(txtPublicationYear.Text, out year) || year < 1900 || year > DateTime.Now.Year)
            {
                MessageBox.Show($"Vui lòng nhập năm xuất bản hợp lệ (1900-{DateTime.Now.Year})", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPublicationYear.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region Event Handlers

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isAddNew = true;
            ClearFields();
            SetControlState(true);
            txtTitle.Focus();

            // Change buttons text
            btnAdd.Text = "Lưu";
            btnAdd.Click -= btnAdd_Click;
            btnAdd.Click += btnSave_Click;

            btnRefresh.Text = "Hủy";
            btnRefresh.Click -= btnRefresh_Click;
            btnRefresh.Click += btnCancel_Click;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateBookData())
                    return;

                if (isAddNew)
                {
                    Book newBook = new Book
                    {
                        Title = txtTitle.Text.Trim(),
                        ISBN = txtISBN.Text.Trim(),
                        PublicationYear = int.Parse(txtPublicationYear.Text),
                        CategoryId = (int)comboBox1.SelectedValue,
                        AuthorId = (int)cboAuthor.SelectedValue,
                        TotalCopies = (int)numTotalCopies.Value,
                        AvailableCopies = (int)numTotalCopies.Value,
                        Description = txtDescription.Text.Trim()
                    };

                    context.Books.Add(newBook);
                    context.SaveChanges();

                    MessageBox.Show("Thêm sách mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    currentBook.Title = txtTitle.Text.Trim();
                    currentBook.ISBN = txtISBN.Text.Trim();
                    currentBook.PublicationYear = int.Parse(txtPublicationYear.Text);
                    currentBook.CategoryId = (int)comboBox1.SelectedValue;
                    currentBook.AuthorId = (int)cboAuthor.SelectedValue;

                    // Check if total copies increased
                    int oldTotal = currentBook.TotalCopies;
                    currentBook.TotalCopies = (int)numTotalCopies.Value;

                    if (currentBook.TotalCopies > oldTotal)
                    {
                        currentBook.AvailableCopies += (currentBook.TotalCopies - oldTotal);
                    }
                    else if (currentBook.TotalCopies < oldTotal)
                    {
                        // Make sure we don't go below 0 available
                        int difference = oldTotal - currentBook.TotalCopies;
                        currentBook.AvailableCopies = Math.Max(0, currentBook.AvailableCopies - difference);
                    }

                    currentBook.Description = txtDescription.Text.Trim();

                    context.Update(currentBook);
                    context.SaveChanges();

                    MessageBox.Show("Cập nhật sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Reset UI
                isAddNew = false;
                LoadBookData();
                ClearFields();
                SetControlState(false);

                // Restore button handlers
                btnAdd.Text = "Tạo mới";
                btnAdd.Click -= btnSave_Click;
                btnAdd.Click += btnAdd_Click;

                btnRefresh.Text = "Làm mới";
                btnRefresh.Click -= btnCancel_Click;
                btnRefresh.Click += btnRefresh_Click;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (currentBook == null)
            {
                MessageBox.Show("Vui lòng chọn sách để cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            isAddNew = false;
            SetControlState(true);
            txtTitle.Focus();

            // Change buttons text
            btnAdd.Text = "Lưu";
            btnAdd.Click -= btnAdd_Click;
            btnAdd.Click += btnSave_Click;

            btnRefresh.Text = "Hủy";
            btnRefresh.Click -= btnRefresh_Click;
            btnRefresh.Click += btnCancel_Click;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currentBook == null)
            {
                MessageBox.Show("Vui lòng chọn sách để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa sách '{currentBook.Title}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Check if book has any borrow records or copies before deleting
                    bool hasBorrowRecords = context.BorrowRecords.Any(br => br.BookId == currentBook.BookId);
                    bool hasBookCopies = context.BookCopies.Any(bc => bc.BookId == currentBook.BookId);

                    if (hasBorrowRecords)
                    {
                        MessageBox.Show("Không thể xóa sách này vì có lịch sử mượn trả.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (hasBookCopies)
                    {
                        MessageBox.Show("Không thể xóa sách này vì có các bản sao trong kho. Vui lòng xóa các bản sao trước.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    context.Books.Remove(currentBook);
                    context.SaveChanges();

                    MessageBox.Show("Xóa sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadBookData();
                    ClearFields();
                    SetControlState(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadBookData();
            SetControlState(false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            isAddNew = false;

            // If editing an existing book, reload its data
            if (currentBook != null)
            {
                DisplayBookData(currentBook);
            }
            else
            {
                ClearFields();
            }

            SetControlState(false);

            // Restore button handlers
            btnAdd.Text = "Tạo mới";
            btnAdd.Click -= btnSave_Click;
            btnAdd.Click += btnAdd_Click;

            btnRefresh.Text = "Làm mới";
            btnRefresh.Click -= btnCancel_Click;
            btnRefresh.Click += btnRefresh_Click;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadBookData();
                return;
            }

            try
            {
                var books = context.Books
                    .Include(b => b.Author)
                    .Include(b => b.Category)
                    .Where(b =>
                        b.Title.ToLower().Contains(searchTerm) ||
                        b.ISBN.ToLower().Contains(searchTerm) ||
                        b.Author.Name.ToLower().Contains(searchTerm) ||
                        b.Category.Name.ToLower().Contains(searchTerm)
                    )
                    .OrderBy(b => b.Title)
                    .Select(b => new {
                        b.BookId,
                        b.Title,
                        b.ISBN,
                        b.PublicationYear,
                        CategoryName = b.Category.Name,
                        AuthorName = b.Author.Name,
                        b.TotalCopies,
                        b.AvailableCopies,
                        b.Description
                    })
                    .ToList();

                dgvBooks.DataSource = books;

                if (books.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvBooks_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count > 0 && dgvBooks.SelectedRows[0].Cells["BookId"].Value != null)
            {
                int bookId = (int)dgvBooks.SelectedRows[0].Cells["BookId"].Value;
                currentBook = context.Books.Find(bookId);
                DisplayBookData(currentBook);
                SetControlState(false);

                // Update button states
                btnUpdate.Enabled = true; // Enable update button
                btnDelete.Enabled = true; // Enable delete button
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            context?.Dispose();
        }
        private void fBookManagement_Load(object sender, EventArgs e)
        {
            // Khởi tạo database context
            context = new LibraryDbContext();

            // Set form style
            ApplyFormStyle();

            // Load data to form
            LoadCategories();
            LoadAuthors();
            LoadBookData();
            SetControlState(false);
        }
        #endregion
    }
}