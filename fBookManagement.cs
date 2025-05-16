using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class fBookManagement : Form
    {
        private LibraryDbContext context;
        private Book currentBook = null;
        private bool isAddNew = false;
        private BindingSource bookBindingSource = new BindingSource();

        // Thêm ComboBox tùy chỉnh để cho phép thêm mới
        private ComboBox cboCategory;
        private ComboBox cboAuthorName;
        private Button btnAddCategory;
        private Button btnAddAuthor;

        public fBookManagement()
        {
            InitializeComponent();

            // Initialize database context
            context = new LibraryDbContext();

            // Tạo controls mới để thay thế comboBox1 và cboAuthor
            CreateCustomControls();

            // Set form style
            ApplyFormStyle();

            // Load data to form
            LoadCategories();
            LoadAuthors();
            LoadBookData();
            SetControlState(false);
        }

        private void CreateCustomControls()
        {
            // Xóa comboBox1 và cboAuthor khỏi form
            pnlBookInfo.Controls.Remove(comboBox1);
            pnlBookInfo.Controls.Remove(cboAuthor);

            // Tạo comboBox mới cho thể loại với AutoCompleteMode
            cboCategory = new ComboBox();
            cboCategory.Location = comboBox1.Location;
            cboCategory.Size = comboBox1.Size;
            cboCategory.DropDownStyle = ComboBoxStyle.DropDown; // Cho phép nhập text
            cboCategory.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboCategory.AutoCompleteSource = AutoCompleteSource.ListItems;
            pnlBookInfo.Controls.Add(cboCategory);

            // Tạo nút thêm thể loại mới
            btnAddCategory = new Button();
            btnAddCategory.Text = "+";
            btnAddCategory.Size = new Size(25, 25);
            btnAddCategory.Location = new Point(cboCategory.Right + 5, cboCategory.Top);
            btnAddCategory.BackColor = Color.FromArgb(210, 121, 106);
            btnAddCategory.ForeColor = Color.White;
            btnAddCategory.FlatStyle = FlatStyle.Flat;
            btnAddCategory.FlatAppearance.BorderSize = 0;
            btnAddCategory.Click += BtnAddCategory_Click;
            pnlBookInfo.Controls.Add(btnAddCategory);

            // Tạo comboBox mới cho tác giả với AutoCompleteMode
            cboAuthorName = new ComboBox();
            cboAuthorName.Location = cboAuthor.Location;
            cboAuthorName.Size = cboAuthor.Size;
            cboAuthorName.DropDownStyle = ComboBoxStyle.DropDown; // Cho phép nhập text
            cboAuthorName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboAuthorName.AutoCompleteSource = AutoCompleteSource.ListItems;
            pnlBookInfo.Controls.Add(cboAuthorName);

            // Tạo nút thêm tác giả mới
            btnAddAuthor = new Button();
            btnAddAuthor.Text = "+";
            btnAddAuthor.Size = new Size(25, 25);
            btnAddAuthor.Location = new Point(cboAuthorName.Right + 5, cboAuthorName.Top);
            btnAddAuthor.BackColor = Color.FromArgb(210, 121, 106);
            btnAddAuthor.ForeColor = Color.White;
            btnAddAuthor.FlatStyle = FlatStyle.Flat;
            btnAddAuthor.FlatAppearance.BorderSize = 0;
            btnAddAuthor.Click += BtnAddAuthor_Click;
            pnlBookInfo.Controls.Add(btnAddAuthor);

            // Áp dụng bo góc cho nút
            ApplyRoundedCorners(btnAddCategory, 5);
            ApplyRoundedCorners(btnAddAuthor, 5);
        }

        private void BtnAddCategory_Click(object sender, EventArgs e)
        {
            string newCategoryName = cboCategory.Text.Trim();
            if (string.IsNullOrEmpty(newCategoryName))
            {
                MessageBox.Show("Vui lòng nhập tên thể loại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Kiểm tra xem thể loại đã tồn tại chưa
                var existingCategory = context.Categories.FirstOrDefault(c => c.Name.ToLower() == newCategoryName.ToLower());
                if (existingCategory != null)
                {
                    MessageBox.Show("Thể loại này đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboCategory.SelectedItem = existingCategory;
                    return;
                }

                // Tạo thể loại mới
                var newCategory = new Category
                {
                    Name = newCategoryName,
                    Description = "Thêm từ form quản lý sách"
                };

                context.Categories.Add(newCategory);
                context.SaveChanges();

                // Cập nhật lại danh sách thể loại và chọn thể loại mới
                LoadCategories();
                cboCategory.Text = newCategoryName;

                MessageBox.Show("Thêm thể loại mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm thể loại mới: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddAuthor_Click(object sender, EventArgs e)
        {
            string newAuthorName = cboAuthorName.Text.Trim();
            if (string.IsNullOrEmpty(newAuthorName))
            {
                MessageBox.Show("Vui lòng nhập tên tác giả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Kiểm tra xem tác giả đã tồn tại chưa
                var existingAuthor = context.Authors.FirstOrDefault(a => a.Name.ToLower() == newAuthorName.ToLower());
                if (existingAuthor != null)
                {
                    MessageBox.Show("Tác giả này đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cboAuthorName.SelectedItem = existingAuthor;
                    return;
                }

                // Tạo tác giả mới
                var newAuthor = new Author
                {
                    Name = newAuthorName,
                    Biography = "Thêm từ form quản lý sách"
                };

                context.Authors.Add(newAuthor);
                context.SaveChanges();

                // Cập nhật lại danh sách tác giả và chọn tác giả mới
                LoadAuthors();
                cboAuthorName.Text = newAuthorName;

                MessageBox.Show("Thêm tác giả mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm tác giả mới: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region UI/UX Functions

        private void ApplyFormStyle()
        {
            // Apply rounded corners to buttons
            ApplyRoundedCorners(btnAdd, 8);
            ApplyRoundedCorners(btnUpdate, 8);
            ApplyRoundedCorners(btnDelete, 8);
            ApplyRoundedCorners(btnRefresh, 8);
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
            btnAddCategory.MouseEnter += Button_MouseEnter;
            btnAddCategory.MouseLeave += Button_MouseLeave;
            btnAddAuthor.MouseEnter += Button_MouseEnter;
            btnAddAuthor.MouseLeave += Button_MouseLeave;

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
                if (btn == btnAdd || btn == btnUpdate || btn == btnAddCategory || btn == btnAddAuthor)
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
                if (btn == btnAdd || btn == btnUpdate || btn == btnAddCategory || btn == btnAddAuthor)
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
                cboCategory.DataSource = null; // Clear first to avoid binding issues
                cboCategory.DataSource = categories;
                cboCategory.DisplayMember = "Name";
                cboCategory.ValueMember = "CategoryId";
                cboCategory.SelectedIndex = -1;
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
                cboAuthorName.DataSource = null; // Clear first to avoid binding issues
                cboAuthorName.DataSource = authors;
                cboAuthorName.DisplayMember = "Name";
                cboAuthorName.ValueMember = "AuthorId";
                cboAuthorName.SelectedIndex = -1;
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

                bookBindingSource.DataSource = books;
                dgvBooks.DataSource = bookBindingSource;

                // Format datagrid
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
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
            dgvBooks.ForeColor = Color.FromArgb(64, 64, 64);
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

        private void ClearFields()
        {
            txtTitle.Text = string.Empty;
            txtISBN.Text = string.Empty;
            txtPublicationYear.Text = string.Empty;
            cboCategory.SelectedIndex = -1;
            cboCategory.Text = string.Empty;
            cboAuthorName.SelectedIndex = -1;
            cboAuthorName.Text = string.Empty;
            numTotalCopies.Value = 1;
            txtDescription.Text = string.Empty;
            currentBook = null;
        }

        private void SetControlState(bool isEditing)
        {
            txtTitle.Enabled = isEditing;
            txtISBN.Enabled = isEditing;
            txtPublicationYear.Enabled = isEditing;
            cboCategory.Enabled = isEditing;
            cboAuthorName.Enabled = isEditing;
            numTotalCopies.Enabled = isEditing;
            txtDescription.Enabled = isEditing;
            btnAddCategory.Enabled = isEditing;
            btnAddAuthor.Enabled = isEditing;

            btnAdd.Text = isEditing && isAddNew ? "Lưu" : "Tạo mới";
            btnUpdate.Enabled = !isEditing && currentBook != null;
            btnDelete.Enabled = !isEditing && currentBook != null;
            btnRefresh.Text = isEditing ? "Hủy" : "Làm mới";

            // Disable search when editing
            txtSearch.Enabled = !isEditing;
            btnSearch.Enabled = !isEditing;

            // Disable datagrid selection when editing
            dgvBooks.Enabled = !isEditing;
        }

        private void DisplayBookData(Book book)
        {
            if (book != null)
            {
                txtTitle.Text = book.Title;
                txtISBN.Text = book.ISBN;
                txtPublicationYear.Text = book.PublicationYear.ToString();

                // Lấy đối tượng Category và Author từ context để hiển thị
                var category = context.Categories.Find(book.CategoryId);
                var author = context.Authors.Find(book.AuthorId);

                if (category != null)
                {
                    cboCategory.SelectedValue = category.CategoryId;
                }

                if (author != null)
                {
                    cboAuthorName.SelectedValue = author.AuthorId;
                }

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

            if (string.IsNullOrWhiteSpace(cboCategory.Text))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập thể loại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboCategory.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(cboAuthorName.Text))
            {
                MessageBox.Show("Vui lòng chọn hoặc nhập tác giả", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboAuthorName.Focus();
                return false;
            }

            int year;
            if (!int.TryParse(txtPublicationYear.Text, out year) || year < 1900 || year > DateTime.Now.Year)
            {
                MessageBox.Show($"Vui lòng nhập năm xuất bản hợp lệ (1900-{DateTime.Now.Year})", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPublicationYear.Focus();
                return false;
            }

            if (numTotalCopies.Value < 1)
            {
                MessageBox.Show("Số lượng sách phải lớn hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numTotalCopies.Focus();
                return false;
            }

            return true;
        }

        private int GetOrCreateCategory(string categoryName)
        {
            var category = context.Categories.FirstOrDefault(c => c.Name.Equals(categoryName, StringComparison.OrdinalIgnoreCase));

            if (category == null)
            {
                category = new Category
                {
                    Name = categoryName,
                    Description = "Thêm từ form quản lý sách"
                };

                context.Categories.Add(category);
                context.SaveChanges();
            }

            return category.CategoryId;
        }

        private int GetOrCreateAuthor(string authorName)
        {
            var author = context.Authors.FirstOrDefault(a => a.Name.Equals(authorName, StringComparison.OrdinalIgnoreCase));

            if (author == null)
            {
                author = new Author
                {
                    Name = authorName,
                    Biography = "Thêm từ form quản lý sách"
                };

                context.Authors.Add(author);
                context.SaveChanges();
            }

            return author.AuthorId;
        }

        #endregion

        #region Event Handlers

        private void fBookManagement_Load(object sender, EventArgs e)
        {
            // Khởi tạo database context
            context = new LibraryDbContext();

            // Load data to form
            LoadCategories();
            LoadAuthors();
            LoadBookData();
            SetControlState(false);

            // Subscribe to events
            dgvBooks.SelectionChanged += dgvBooks_SelectionChanged;
            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnDelete.Click += btnDelete_Click;
            btnRefresh.Click += btnRefresh_Click;
            btnSearch.Click += btnSearch_Click;

            // Add Enter key event for search
            txtSearch.KeyDown += txtSearch_KeyDown;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Tạo mới")
            {
                isAddNew = true;
                ClearFields();
                SetControlState(true);
                txtTitle.Focus();
            }
            else // Save
            {
                SaveBook();
            }
        }

        private void SaveBook()
        {
            try
            {
                if (!ValidateBookData())
                    return;

                // Lấy hoặc tạo CategoryId và AuthorId
                int categoryId = GetOrCreateCategory(cboCategory.Text.Trim());
                int authorId = GetOrCreateAuthor(cboAuthorName.Text.Trim());

                if (isAddNew)
                {
                    Book newBook = new Book
                    {
                        Title = txtTitle.Text.Trim(),
                        ISBN = txtISBN.Text.Trim(),
                        PublicationYear = int.Parse(txtPublicationYear.Text),
                        CategoryId = categoryId,
                        AuthorId = authorId,
                        TotalCopies = (int)numTotalCopies.Value,
                        AvailableCopies = (int)numTotalCopies.Value, // New books are all available
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
                    currentBook.CategoryId = categoryId;
                    currentBook.AuthorId = authorId;

                    // Check if total copies increased
                    int oldTotal = currentBook.TotalCopies;
                    currentBook.TotalCopies = (int)numTotalCopies.Value;

                    if (currentBook.TotalCopies > oldTotal)
                    {
                        // If we add more copies, they're all available
                        currentBook.AvailableCopies += (currentBook.TotalCopies - oldTotal);
                    }
                    else if (currentBook.TotalCopies < oldTotal)
                    {
                        // If we reduce copies, ensure we don't go negative
                        // This assumes we're removing available books first
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
                LoadCategories(); // Reload để cập nhật danh sách nếu có thêm mới
                LoadAuthors();    // Reload để cập nhật danh sách nếu có thêm mới
                ClearFields();
                SetControlState(false);
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
            if (btnRefresh.Text == "Làm mới")
            {
                ClearFields();
                LoadBookData();
                SetControlState(false);
                txtSearch.Clear();
            }
            else // Cancel
            {
                isAddNew = false;
                ClearFields();
                SetControlState(false);
                if (dgvBooks.SelectedRows.Count > 0)
                {
                    dgvBooks_SelectionChanged(dgvBooks, EventArgs.Empty);
                }
            }
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
                        b.Category.Name.ToLower().Contains(searchTerm) ||
                        b.Description.ToLower().Contains(searchTerm)
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

                bookBindingSource.DataSource = books;
                dgvBooks.DataSource = bookBindingSource;

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

                if (currentBook != null)
                {
                    DisplayBookData(currentBook);
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (context != null)
            {
                context.Dispose();
            }
        }

        // Phương thức xử lý khi nhấn Enter trong ô tìm kiếm
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
                e.SuppressKeyPress = true; // Ngăn tiếng beep
            }
        }

        // Thêm phương thức xuất dữ liệu sách ra Excel
        private void ExportToExcel()
        {
            try
            {
                // Tạo SaveFileDialog để chọn vị trí lưu file
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    Title = "Xuất danh sách sách ra Excel",
                    FileName = "DanhSachSach_" + DateTime.Now.ToString("yyyyMMdd")
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Hiển thị thông báo đang xử lý
                    MessageBox.Show("Đang xuất dữ liệu ra Excel. Vui lòng đợi...", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // TODO: Triển khai code xuất Excel thực tế ở đây
                    // Sử dụng thư viện như EPPlus hoặc ClosedXML

                    MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Tạo nút xuất Excel và thêm vào form
        private void CreateExportButton()
        {
            Button btnExport = new Button();
            btnExport.Text = "Xuất Excel";
            btnExport.Size = new Size(96, 29);
            btnExport.Location = new Point(500 - 110, 15); // Đặt trước nút Tạo mới
            btnExport.BackColor = Color.FromArgb(34, 139, 34); // Màu xanh lá
            btnExport.ForeColor = Color.White;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnExport.Click += (s, e) => ExportToExcel();

            // Thêm hiệu ứng hover
            btnExport.MouseEnter += (s, e) => btnExport.BackColor = Color.FromArgb(0, 120, 0);
            btnExport.MouseLeave += (s, e) => btnExport.BackColor = Color.FromArgb(34, 139, 34);

            // Áp dụng bo góc
            ApplyRoundedCorners(btnExport, 8);

            // Thêm vào panel
            pnlDataGird.Controls.Add(btnExport);
        }

        // Phương thức thêm vào Load để khởi tạo các component mới
        private void InitializeCustomComponents()
        {
            CreateCustomControls(); // Tạo controls ComboBox và nút + cho Category và Author
            CreateExportButton();   // Tạo nút Xuất Excel

            // Cập nhật lại vị trí của các nút nếu cần
            btnAdd.Location = new Point(500, 15);
            btnUpdate.Location = new Point(605, 15);
            btnDelete.Location = new Point(710, 15);
            btnRefresh.Location = new Point(815, 15);
        }

        #endregion

        #region Additional Features

        // Tạo phương thức để hiển thị thông tin chi tiết sách khi double-click vào một hàng
        private void ShowBookDetail(int bookId)
        {
            try
            {
                var book = context.Books
                    .Include(b => b.Author)
                    .Include(b => b.Category)
                    .Include(b => b.BookCopies)
                    .Include(b => b.BorrowRecords)
                    .FirstOrDefault(b => b.BookId == bookId);

                if (book == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo form chi tiết sách
                Form frmDetail = new Form();
                frmDetail.Text = "Chi tiết sách";
                frmDetail.Size = new Size(600, 500);
                frmDetail.StartPosition = FormStartPosition.CenterParent;
                frmDetail.FormBorderStyle = FormBorderStyle.FixedDialog;
                frmDetail.MaximizeBox = false;
                frmDetail.MinimizeBox = false;

                // Tạo Panel chính
                Panel pnlMain = new Panel();
                pnlMain.Dock = DockStyle.Fill;
                pnlMain.Padding = new Padding(15);
                frmDetail.Controls.Add(pnlMain);

                // Tiêu đề
                Label lblTitle = new Label();
                lblTitle.Text = book.Title;
                lblTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                lblTitle.ForeColor = Color.FromArgb(210, 121, 106);
                lblTitle.Location = new Point(15, 15);
                lblTitle.Size = new Size(550, 30);
                pnlMain.Controls.Add(lblTitle);

                // ISBN
                Label lblISBN = new Label();
                lblISBN.Text = "ISBN: " + book.ISBN;
                lblISBN.Font = new Font("Segoe UI", 10);
                lblISBN.Location = new Point(15, 55);
                lblISBN.Size = new Size(550, 20);
                pnlMain.Controls.Add(lblISBN);

                // Tác giả
                Label lblAuthor = new Label();
                lblAuthor.Text = "Tác giả: " + book.Author.Name;
                lblAuthor.Font = new Font("Segoe UI", 10);
                lblAuthor.Location = new Point(15, 80);
                lblAuthor.Size = new Size(550, 20);
                pnlMain.Controls.Add(lblAuthor);

                // Thể loại
                Label lblCategory = new Label();
                lblCategory.Text = "Thể loại: " + book.Category.Name;
                lblCategory.Font = new Font("Segoe UI", 10);
                lblCategory.Location = new Point(15, 105);
                lblCategory.Size = new Size(550, 20);
                pnlMain.Controls.Add(lblCategory);

                // Năm xuất bản
                Label lblYear = new Label();
                lblYear.Text = "Năm xuất bản: " + book.PublicationYear;
                lblYear.Font = new Font("Segoe UI", 10);
                lblYear.Location = new Point(15, 130);
                lblYear.Size = new Size(550, 20);
                pnlMain.Controls.Add(lblYear);

                // Số lượng
                Label lblCopies = new Label();
                lblCopies.Text = $"Số lượng: {book.AvailableCopies}/{book.TotalCopies} (Khả dụng/Tổng)";
                lblCopies.Font = new Font("Segoe UI", 10);
                lblCopies.Location = new Point(15, 155);
                lblCopies.Size = new Size(550, 20);
                pnlMain.Controls.Add(lblCopies);

                // Mô tả
                Label lblDescTitle = new Label();
                lblDescTitle.Text = "Mô tả:";
                lblDescTitle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                lblDescTitle.Location = new Point(15, 185);
                lblDescTitle.Size = new Size(550, 20);
                pnlMain.Controls.Add(lblDescTitle);

                TextBox txtDesc = new TextBox();
                txtDesc.Text = book.Description;
                txtDesc.Font = new Font("Segoe UI", 10);
                txtDesc.Location = new Point(15, 210);
                txtDesc.Size = new Size(550, 120);
                txtDesc.Multiline = true;
                txtDesc.ReadOnly = true;
                txtDesc.ScrollBars = ScrollBars.Vertical;
                pnlMain.Controls.Add(txtDesc);

                // Thông tin mượn/trả
                int borrowedCount = book.BorrowRecords.Count(br => br.ReturnDate == null);

                Label lblBorrow = new Label();
                lblBorrow.Text = $"Số lượng đang mượn: {borrowedCount}";
                lblBorrow.Font = new Font("Segoe UI", 10);
                lblBorrow.Location = new Point(15, 340);
                lblBorrow.Size = new Size(550, 20);
                pnlMain.Controls.Add(lblBorrow);

                // Nút đóng
                Button btnClose = new Button();
                btnClose.Text = "Đóng";
                btnClose.Size = new Size(100, 35);
                btnClose.Location = new Point(465, 400);
                btnClose.BackColor = Color.FromArgb(210, 121, 106);
                btnClose.ForeColor = Color.White;
                btnClose.FlatStyle = FlatStyle.Flat;
                btnClose.FlatAppearance.BorderSize = 0;
                btnClose.Click += (s, e) => frmDetail.Close();
                pnlMain.Controls.Add(btnClose);

                // Hiển thị form
                frmDetail.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị chi tiết sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thêm sự kiện double-click cho DataGridView
        private void dgvBooks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvBooks.Rows[e.RowIndex].Cells["BookId"].Value != null)
            {
                int bookId = (int)dgvBooks.Rows[e.RowIndex].Cells["BookId"].Value;
                ShowBookDetail(bookId);
            }
        }

        // Phương thức kiểm tra tất cả bản sao của một sách
        private void ViewBookCopies(int bookId)
        {
            try
            {
                var book = context.Books
                    .Include(b => b.BookCopies)
                    .ThenInclude(bc => bc.Location)
                    .FirstOrDefault(b => b.BookId == bookId);

                if (book == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin sách!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo form hiển thị bản sao
                Form frmCopies = new Form();
                frmCopies.Text = "Danh sách bản sao - " + book.Title;
                frmCopies.Size = new Size(700, 500);
                frmCopies.StartPosition = FormStartPosition.CenterParent;
                frmCopies.FormBorderStyle = FormBorderStyle.FixedDialog;
                frmCopies.MaximizeBox = false;
                frmCopies.MinimizeBox = false;

                // Tạo DataGridView để hiển thị danh sách bản sao
                DataGridView dgvCopies = new DataGridView();
                dgvCopies.Location = new Point(15, 15);
                dgvCopies.Size = new Size(655, 400);
                dgvCopies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvCopies.AllowUserToAddRows = false;
                dgvCopies.AllowUserToDeleteRows = false;
                dgvCopies.ReadOnly = true;
                dgvCopies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvCopies.RowHeadersVisible = false;

                // Định dạng cho DataGridView
                dgvCopies.DefaultCellStyle.BackColor = Color.White;
                dgvCopies.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 245, 245);
                dgvCopies.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
                dgvCopies.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(210, 121, 106);
                dgvCopies.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvCopies.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgvCopies.EnableHeadersVisualStyles = false;
                dgvCopies.GridColor = Color.FromArgb(224, 224, 224);
                dgvCopies.BorderStyle = BorderStyle.None;
                dgvCopies.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

                frmCopies.Controls.Add(dgvCopies);

                // Nút đóng
                Button btnClose = new Button();
                btnClose.Text = "Đóng";
                btnClose.Size = new Size(100, 35);
                btnClose.Location = new Point(570, 425);
                btnClose.BackColor = Color.FromArgb(210, 121, 106);
                btnClose.ForeColor = Color.White;
                btnClose.FlatStyle = FlatStyle.Flat;
                btnClose.FlatAppearance.BorderSize = 0;
                btnClose.Click += (s, e) => frmCopies.Close();
                frmCopies.Controls.Add(btnClose);

                // Tạo nút thêm bản sao mới
                Button btnAddCopy = new Button();
                btnAddCopy.Text = "Thêm bản sao";
                btnAddCopy.Size = new Size(110, 35);
                btnAddCopy.Location = new Point(15, 425);
                btnAddCopy.BackColor = Color.FromArgb(34, 139, 34);
                btnAddCopy.ForeColor = Color.White;
                btnAddCopy.FlatStyle = FlatStyle.Flat;
                btnAddCopy.FlatAppearance.BorderSize = 0;
                btnAddCopy.Click += (s, e) => AddNewBookCopy(book);
                frmCopies.Controls.Add(btnAddCopy);

                // Load dữ liệu vào DataGridView
                var bookCopies = book.BookCopies.Select(bc => new {
                    bc.CopyId,
                    bc.Status,
                    StatusText = Utility.GetCopyStatusText(bc.Status),
                    Location = bc.Location != null ? $"{bc.Location.AreaCode}-{bc.Location.ShelfNumber}-{bc.Location.SectionNumber}" : "Chưa xác định",
                    bc.AcquisitionDate,
                    bc.Notes
                }).ToList();

                dgvCopies.DataSource = bookCopies;
                dgvCopies.Columns["CopyId"].HeaderText = "Mã bản sao";
                dgvCopies.Columns["Status"].Visible = false;
                dgvCopies.Columns["StatusText"].HeaderText = "Trạng thái";
                dgvCopies.Columns["Location"].HeaderText = "Vị trí";
                dgvCopies.Columns["AcquisitionDate"].HeaderText = "Ngày nhập";
                dgvCopies.Columns["Notes"].HeaderText = "Ghi chú";

                // Hiển thị form
                frmCopies.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị bản sao sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Phương thức thêm bản sao mới cho sách
        private void AddNewBookCopy(Book book)
        {
            try
            {
                // Tạo form thêm bản sao
                Form frmAddCopy = new Form();
                frmAddCopy.Text = "Thêm bản sao - " + book.Title;
                frmAddCopy.Size = new Size(400, 350);
                frmAddCopy.StartPosition = FormStartPosition.CenterParent;
                frmAddCopy.FormBorderStyle = FormBorderStyle.FixedDialog;
                frmAddCopy.MaximizeBox = false;
                frmAddCopy.MinimizeBox = false;

                // Panel chính
                Panel pnlMain = new Panel();
                pnlMain.Dock = DockStyle.Fill;
                pnlMain.Padding = new Padding(15);
                frmAddCopy.Controls.Add(pnlMain);

                // Tiêu đề
                Label lblTitle = new Label();
                lblTitle.Text = "Thêm bản sao sách mới";
                lblTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                lblTitle.ForeColor = Color.FromArgb(210, 121, 106);
                lblTitle.Location = new Point(15, 15);
                lblTitle.Size = new Size(350, 25);
                pnlMain.Controls.Add(lblTitle);

                // Vị trí
                Label lblLocation = new Label();
                lblLocation.Text = "Vị trí:";
                lblLocation.Font = new Font("Segoe UI", 10);
                lblLocation.Location = new Point(15, 60);
                lblLocation.Size = new Size(100, 20);
                pnlMain.Controls.Add(lblLocation);

                ComboBox cboLocation = new ComboBox();
                cboLocation.Location = new Point(115, 60);
                cboLocation.Size = new Size(250, 25);
                cboLocation.DropDownStyle = ComboBoxStyle.DropDownList;
                pnlMain.Controls.Add(cboLocation);

                // Load danh sách vị trí từ database
                var locations = context.BookLocations.OrderBy(l => l.AreaCode).ThenBy(l => l.ShelfNumber).ToList();
                cboLocation.DataSource = locations;
                cboLocation.DisplayMember = "Description";
                cboLocation.ValueMember = "LocationId";

                // Ngày nhập
                Label lblDate = new Label();
                lblDate.Text = "Ngày nhập:";
                lblDate.Font = new Font("Segoe UI", 10);
                lblDate.Location = new Point(15, 100);
                lblDate.Size = new Size(100, 20);
                pnlMain.Controls.Add(lblDate);

                DateTimePicker dtpDate = new DateTimePicker();
                dtpDate.Location = new Point(115, 100);
                dtpDate.Size = new Size(250, 25);
                dtpDate.Format = DateTimePickerFormat.Short;
                dtpDate.Value = DateTime.Today;
                pnlMain.Controls.Add(dtpDate);

                // Trạng thái
                Label lblStatus = new Label();
                lblStatus.Text = "Trạng thái:";
                lblStatus.Font = new Font("Segoe UI", 10);
                lblStatus.Location = new Point(15, 140);
                lblStatus.Size = new Size(100, 20);
                pnlMain.Controls.Add(lblStatus);

                ComboBox cboStatus = new ComboBox();
                cboStatus.Location = new Point(115, 140);
                cboStatus.Size = new Size(250, 25);
                cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
                cboStatus.Items.AddRange(new object[] { "Có sẵn", "Đang mượn", "Bị mất", "Hư hỏng" });
                cboStatus.SelectedIndex = 0; // Mặc định là "Có sẵn"
                pnlMain.Controls.Add(cboStatus);

                // Ghi chú
                Label lblNotes = new Label();
                lblNotes.Text = "Ghi chú:";
                lblNotes.Font = new Font("Segoe UI", 10);
                lblNotes.Location = new Point(15, 180);
                lblNotes.Size = new Size(100, 20);
                pnlMain.Controls.Add(lblNotes);

                TextBox txtNotes = new TextBox();
                txtNotes.Location = new Point(115, 180);
                txtNotes.Size = new Size(250, 60);
                txtNotes.Multiline = true;
                txtNotes.ScrollBars = ScrollBars.Vertical;
                pnlMain.Controls.Add(txtNotes);

                // Nút Lưu
                Button btnSave = new Button();
                btnSave.Text = "Lưu";
                btnSave.Size = new Size(100, 35);
                btnSave.Location = new Point(265, 250);
                btnSave.BackColor = Color.FromArgb(210, 121, 106);
                btnSave.ForeColor = Color.White;
                btnSave.FlatStyle = FlatStyle.Flat;
                btnSave.FlatAppearance.BorderSize = 0;
                btnSave.Click += (s, e) => {
                    try
                    {
                        // Lấy thông tin từ form
                        int locationId = (int)cboLocation.SelectedValue;
                        DateTime acquisitionDate = dtpDate.Value;
                        int status = cboStatus.SelectedIndex + 1; // Status: 1 = Có sẵn, 2 = Đang mượn, ...
                        string notes = txtNotes.Text.Trim();

                        // Tạo bản sao mới
                        BookCopy newCopy = new BookCopy
                        {
                            BookId = book.BookId,
                            LocationId = locationId,
                            Status = status,
                            AcquisitionDate = acquisitionDate,
                            Notes = notes
                        };

                        // Thêm vào database
                        context.BookCopies.Add(newCopy);

                        // Cập nhật số lượng sách
                        book.TotalCopies++;
                        if (status == 1) // Nếu trạng thái là "Có sẵn"
                        {
                            book.AvailableCopies++;
                        }

                        context.SaveChanges();

                        MessageBox.Show("Thêm bản sao mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmAddCopy.DialogResult = DialogResult.OK;
                        frmAddCopy.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm bản sao: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };
                pnlMain.Controls.Add(btnSave);

                // Nút Hủy
                Button btnCancel = new Button();
                btnCancel.Text = "Hủy";
                btnCancel.Size = new Size(100, 35);
                btnCancel.Location = new Point(155, 250);
                btnCancel.BackColor = Color.FromArgb(129, 195, 215);
                btnCancel.ForeColor = Color.White;
                btnCancel.FlatStyle = FlatStyle.Flat;
                btnCancel.FlatAppearance.BorderSize = 0;
                btnCancel.Click += (s, e) => frmAddCopy.Close();
                pnlMain.Controls.Add(btnCancel);

                // Hiển thị form và xử lý kết quả
                if (frmAddCopy.ShowDialog() == DialogResult.OK)
                {
                    // Refresh lại form bản sao và form chính
                    LoadBookData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm bản sao: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}