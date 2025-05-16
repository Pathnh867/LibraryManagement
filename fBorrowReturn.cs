using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
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

namespace LibraryManagement
{
    public partial class fBorrowReturn : Form
    {
        private LibraryDbContext context;
        private Member selectedMember = null;
        private Book selectedBook = null;
        private BookCopy selectedBookCopy = null;
        private BindingSource currentBorrowsBindingSource = new BindingSource();
        private BindingSource borrowHistoryBindingSource = new BindingSource();

        public fBorrowReturn()
        {
            InitializeComponent();
            context = new LibraryDbContext();
            ApplyFormStyle();
            InitializeForm();
        }

        #region UI/UX Functions

        private void ApplyFormStyle()
        {
            // Apply rounded corners to buttons
            ApplyRoundedCorners(btnSearchMember, 8);
            ApplyRoundedCorners(btnSearchBook, 8);
            ApplyRoundedCorners(btnBorrow, 8);
            ApplyRoundedCorners(btnReturn, 8);
            ApplyRoundedCorners(btnRenew, 8);
            ApplyRoundedCorners(btnRefresh, 8);

            // Set hover events
            btnSearchMember.MouseEnter += Button_MouseEnter;
            btnSearchMember.MouseLeave += Button_MouseLeave;
            btnSearchBook.MouseEnter += Button_MouseEnter;
            btnSearchBook.MouseLeave += Button_MouseLeave;
            btnBorrow.MouseEnter += Button_MouseEnter;
            btnBorrow.MouseLeave += Button_MouseLeave;
            btnReturn.MouseEnter += Button_MouseEnter;
            btnReturn.MouseLeave += Button_MouseLeave;
            btnRenew.MouseEnter += Button_MouseEnter;
            btnRenew.MouseLeave += Button_MouseLeave;
            btnRefresh.MouseEnter += Button_MouseEnter;
            btnRefresh.MouseLeave += Button_MouseLeave;

            // Add shadow to panels
            AddShadow(pnlMemberSearch);
            AddShadow(pnlBookSearch);
            AddShadow(pnlBorrowInfo);
            AddShadow(pnlCurrentBorrows);
            AddShadow(pnlBorrowHistory);

            // Format DataGridViews
            FormatDataGridView(dgvCurrentBorrows);
            FormatDataGridView(dgvBorrowHistory);
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
                if (btn == btnBorrow)
                    btn.BackColor = Color.FromArgb(190, 101, 86);
                else if (btn == btnReturn)
                    btn.BackColor = Color.FromArgb(24, 119, 24);
                else if (btn == btnRenew)
                    btn.BackColor = Color.FromArgb(255, 145, 0);
                else if (btn == btnSearchMember || btn == btnSearchBook || btn == btnRefresh)
                    btn.BackColor = Color.FromArgb(109, 175, 195);
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Restore original color
                if (btn == btnBorrow)
                    btn.BackColor = Color.FromArgb(210, 121, 106);
                else if (btn == btnReturn)
                    btn.BackColor = Color.FromArgb(34, 139, 34);
                else if (btn == btnRenew)
                    btn.BackColor = Color.FromArgb(255, 165, 0);
                else if (btn == btnSearchMember || btn == btnSearchBook || btn == btnRefresh)
                    btn.BackColor = Color.FromArgb(129, 195, 215);
            }
        }

        private void FormatDataGridView(DataGridView dgv)
        {
            // Set text color to black or dark gray
            dgv.ForeColor = Color.FromArgb(64, 64, 64);
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);

            // Header style
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(210, 121, 106);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.EnableHeadersVisualStyles = false;

            // Alternate row colors for better readability
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 245, 245);
            dgv.DefaultCellStyle.BackColor = Color.White;

            // Selection style
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 121, 106);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            // Set row height
            dgv.RowTemplate.Height = 28;

            // Adjust grid lines
            dgv.GridColor = Color.FromArgb(224, 224, 224);
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Remove row headers
            dgv.RowHeadersVisible = false;
        }

        #endregion

        #region Form Initialization

        private void InitializeForm()
        {
            // Set default dates
            dtpBorrowDate.Value = DateTime.Today;
            dtpDueDate.Value = DateTime.Today.AddDays(30); // Default 30 days

            // Set button states
            SetButtonStates();

            // Load data
            LoadCurrentBorrows();
            LoadBorrowHistory();

            // Setup key events
            txtMemberSearch.KeyDown += TxtMemberSearch_KeyDown;
            txtBookSearch.KeyDown += TxtBookSearch_KeyDown;

            // Setup selection events
            dgvCurrentBorrows.SelectionChanged += DgvCurrentBorrows_SelectionChanged;
            dgvBorrowHistory.SelectionChanged += DgvBorrowHistory_SelectionChanged;
        }

        private void SetButtonStates()
        {
            btnBorrow.Enabled = selectedMember != null && selectedBook != null && selectedBookCopy != null;
            btnReturn.Enabled = dgvCurrentBorrows.SelectedRows.Count > 0;
            btnRenew.Enabled = dgvCurrentBorrows.SelectedRows.Count > 0;
        }

        #endregion

        #region Member Search

        private void btnSearchMember_Click(object sender, EventArgs e)
        {
            SearchMember();
        }

        private void TxtMemberSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchMember();
                e.SuppressKeyPress = true;
            }
        }

        private void SearchMember()
        {
            string searchTerm = txtMemberSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Vui lòng nhập tên hoặc số điện thoại thành viên", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var members = context.Members
                    .Where(m => m.Status && (m.Name.Contains(searchTerm) || m.Phone.Contains(searchTerm)))
                    .ToList();

                if (members.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy thành viên", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    selectedMember = null;
                    txtMemberInfo.Text = "";
                }
                else if (members.Count == 1)
                {
                    selectedMember = members[0];
                    txtMemberInfo.Text = $"{selectedMember.Name} - {selectedMember.Phone}";
                    LoadCurrentBorrows();
                    LoadBorrowHistory();
                }
                else
                {
                    // Multiple members found, show selection form
                    ShowMemberSelectionForm(members);
                }

                SetButtonStates();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm thành viên: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowMemberSelectionForm(List<Member> members)
        {
            Form memberForm = new Form();
            memberForm.Text = "Chọn thành viên";
            memberForm.Size = new Size(600, 400);
            memberForm.StartPosition = FormStartPosition.CenterParent;
            memberForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            memberForm.MaximizeBox = false;
            memberForm.MinimizeBox = false;

            DataGridView dgvMembers = new DataGridView();
            dgvMembers.Location = new Point(20, 20);
            dgvMembers.Size = new Size(540, 280);
            dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMembers.AllowUserToAddRows = false;
            dgvMembers.ReadOnly = true;
            dgvMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            FormatDataGridView(dgvMembers);

            var memberData = members.Select(m => new
            {
                m.MemberId,
                m.Name,
                m.Phone,
                m.Email,
                m.JoinDate
            }).ToList();

            dgvMembers.DataSource = memberData;
            dgvMembers.Columns["MemberId"].HeaderText = "Mã TV";
            dgvMembers.Columns["Name"].HeaderText = "Họ tên";
            dgvMembers.Columns["Phone"].HeaderText = "Điện thoại";
            dgvMembers.Columns["Email"].HeaderText = "Email";
            dgvMembers.Columns["JoinDate"].HeaderText = "Ngày đăng ký";

            Button btnSelect = new Button();
            btnSelect.Text = "Chọn";
            btnSelect.Size = new Size(100, 35);
            btnSelect.Location = new Point(360, 320);
            btnSelect.BackColor = Color.FromArgb(210, 121, 106);
            btnSelect.ForeColor = Color.White;
            btnSelect.FlatStyle = FlatStyle.Flat;
            btnSelect.FlatAppearance.BorderSize = 0;
            btnSelect.Click += (s, e) =>
            {
                if (dgvMembers.SelectedRows.Count > 0)
                {
                    int memberId = (int)dgvMembers.SelectedRows[0].Cells["MemberId"].Value;
                    selectedMember = members.First(m => m.MemberId == memberId);
                    txtMemberInfo.Text = $"{selectedMember.Name} - {selectedMember.Phone}";
                    LoadCurrentBorrows();
                    LoadBorrowHistory();
                    SetButtonStates();
                    memberForm.Close();
                }
            };

            Button btnCancel = new Button();
            btnCancel.Text = "Hủy";
            btnCancel.Size = new Size(100, 35);
            btnCancel.Location = new Point(470, 320);
            btnCancel.BackColor = Color.FromArgb(129, 195, 215);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => memberForm.Close();

            memberForm.Controls.Add(dgvMembers);
            memberForm.Controls.Add(btnSelect);
            memberForm.Controls.Add(btnCancel);

            memberForm.ShowDialog();
        }

        #endregion

        #region Book Search

        private void btnSearchBook_Click(object sender, EventArgs e)
        {
            SearchBook();
        }

        private void TxtBookSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchBook();
                e.SuppressKeyPress = true;
            }
        }

        private void SearchBook()
        {
            string searchTerm = txtBookSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Vui lòng nhập tên sách hoặc ISBN", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var books = context.Books
                    .Include(b => b.Author)
                    .Include(b => b.Category)
                    .Include(b => b.BookCopies)
                    .Where(b => b.Title.Contains(searchTerm) || b.ISBN.Contains(searchTerm))
                    .ToList();

                if (books.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy sách", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    selectedBook = null;
                    selectedBookCopy = null;
                    txtBookInfo.Text = "";
                }
                else if (books.Count == 1)
                {
                    var book = books[0];
                    var availableCopy = book.BookCopies.FirstOrDefault(bc => bc.Status == 1); // Available

                    if (availableCopy == null)
                    {
                        MessageBox.Show("Sách này hiện không có bản sao nào có sẵn", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        selectedBook = null;
                        selectedBookCopy = null;
                        txtBookInfo.Text = "";
                    }
                    else
                    {
                        selectedBook = book;
                        selectedBookCopy = availableCopy;
                        txtBookInfo.Text = $"{book.Title} - {book.Author.Name} (Bản sao: {availableCopy.CopyId})";
                    }
                }
                else
                {
                    // Multiple books found, show selection form
                    ShowBookSelectionForm(books);
                }

                SetButtonStates();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm sách: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowBookSelectionForm(List<Book> books)
        {
            Form bookForm = new Form();
            bookForm.Text = "Chọn sách";
            bookForm.Size = new Size(700, 400);
            bookForm.StartPosition = FormStartPosition.CenterParent;
            bookForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            bookForm.MaximizeBox = false;
            bookForm.MinimizeBox = false;

            DataGridView dgvBooks = new DataGridView();
            dgvBooks.Location = new Point(20, 20);
            dgvBooks.Size = new Size(640, 280);
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.ReadOnly = true;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            FormatDataGridView(dgvBooks);

            var bookData = books.Select(b => new
            {
                b.BookId,
                b.Title,
                AuthorName = b.Author.Name,
                b.ISBN,
                AvailableCopies = b.BookCopies.Count(bc => bc.Status == 1),
                b.TotalCopies
            }).ToList();

            dgvBooks.DataSource = bookData;
            dgvBooks.Columns["BookId"].HeaderText = "Mã sách";
            dgvBooks.Columns["Title"].HeaderText = "Tên sách";
            dgvBooks.Columns["AuthorName"].HeaderText = "Tác giả";
            dgvBooks.Columns["ISBN"].HeaderText = "ISBN";
            dgvBooks.Columns["AvailableCopies"].HeaderText = "Có sẵn";
            dgvBooks.Columns["TotalCopies"].HeaderText = "Tổng số";

            Button btnSelect = new Button();
            btnSelect.Text = "Chọn";
            btnSelect.Size = new Size(100, 35);
            btnSelect.Location = new Point(430, 320);
            btnSelect.BackColor = Color.FromArgb(210, 121, 106);
            btnSelect.ForeColor = Color.White;
            btnSelect.FlatStyle = FlatStyle.Flat;
            btnSelect.FlatAppearance.BorderSize = 0;
            btnSelect.Click += (s, e) =>
            {
                if (dgvBooks.SelectedRows.Count > 0)
                {
                    int bookId = (int)dgvBooks.SelectedRows[0].Cells["BookId"].Value;
                    var book = books.First(b => b.BookId == bookId);
                    var availableCopy = book.BookCopies.FirstOrDefault(bc => bc.Status == 1);

                    if (availableCopy == null)
                    {
                        MessageBox.Show("Sách này hiện không có bản sao nào có sẵn", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    selectedBook = book;
                    selectedBookCopy = availableCopy;
                    txtBookInfo.Text = $"{book.Title} - {book.Author.Name} (Bản sao: {availableCopy.CopyId})";
                    SetButtonStates();
                    bookForm.Close();
                }
            };

            Button btnCancel = new Button();
            btnCancel.Text = "Hủy";
            btnCancel.Size = new Size(100, 35);
            btnCancel.Location = new Point(540, 320);
            btnCancel.BackColor = Color.FromArgb(129, 195, 215);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => bookForm.Close();

            bookForm.Controls.Add(dgvBooks);
            bookForm.Controls.Add(btnSelect);
            bookForm.Controls.Add(btnCancel);

            bookForm.ShowDialog();
        }

        #endregion

        #region Borrow Operations

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            if (selectedMember == null)
            {
                MessageBox.Show("Vui lòng chọn thành viên", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedBook == null || selectedBookCopy == null)
            {
                MessageBox.Show("Vui lòng chọn sách", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if member already borrowed this book
            var existingBorrow = context.BorrowRecords
                .FirstOrDefault(br => br.MemberId == selectedMember.MemberId &&
                               br.BookId == selectedBook.BookId &&
                               br.ReturnDate == null);

            if (existingBorrow != null)
            {
                MessageBox.Show("Thành viên này đã mượn sách này rồi", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check member's current borrow limit
            var currentBorrows = context.BorrowRecords
                .Count(br => br.MemberId == selectedMember.MemberId && br.ReturnDate == null);

            if (currentBorrows >= 5) // Assume limit is 5 books
            {
                MessageBox.Show("Thành viên đã đạt giới hạn mượn sách (5 cuốn)", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Create borrow record
                BorrowRecord borrowRecord = new BorrowRecord
                {
                    BookId = selectedBook.BookId,
                    MemberId = selectedMember.MemberId,
                    CopyId = selectedBookCopy.CopyId,
                    BorrowDate = dtpBorrowDate.Value.Date,
                    DueDate = dtpDueDate.Value.Date,
                    Notes = txtNotes.Text.Trim()
                };

                context.BorrowRecords.Add(borrowRecord);

                // Update book copy status
                selectedBookCopy.Status = 2; // Borrowed
                context.Update(selectedBookCopy);

                // Update book available copies
                selectedBook.AvailableCopies--;
                context.Update(selectedBook);

                context.SaveChanges();

                MessageBox.Show("Mượn sách thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset form
                ClearBookSelection();
                LoadCurrentBorrows();
                LoadBorrowHistory();
                SetButtonStates();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mượn sách: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearBookSelection()
        {
            selectedBook = null;
            selectedBookCopy = null;
            txtBookSearch.Text = "";
            txtBookInfo.Text = "";
            txtNotes.Text = "";
            dtpBorrowDate.Value = DateTime.Today;
            dtpDueDate.Value = DateTime.Today.AddDays(30);
        }

        #endregion

        #region Return Operations

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (dgvCurrentBorrows.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sách cần trả", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int borrowRecordId = (int)dgvCurrentBorrows.SelectedRows[0].Cells["BorrowRecordId"].Value;

            try
            {
                var borrowRecord = context.BorrowRecords
                    .Include(br => br.Book)
                    .Include(br => br.BookCopy)
                    .FirstOrDefault(br => br.BorrowRecordId == borrowRecordId);

                if (borrowRecord == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin mượn sách", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update return date
                borrowRecord.ReturnDate = DateTime.Today;

                // Calculate late fee if any
                if (DateTime.Today > borrowRecord.DueDate)
                {
                    borrowRecord.LateFee = Utility.CalculateLateFee(borrowRecord.DueDate, DateTime.Today);

                    if (borrowRecord.LateFee > 0)
                    {
                        MessageBox.Show($"Sách trả muộn {(DateTime.Today - borrowRecord.DueDate).Days} ngày.\n" +
                                      $"Phí phạt: {borrowRecord.LateFee:N0} VNĐ", "Thông báo phí phạt",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                // Update book copy status
                borrowRecord.BookCopy.Status = 1; // Available
                context.Update(borrowRecord.BookCopy);

                // Update book available copies
                borrowRecord.Book.AvailableCopies++;
                context.Update(borrowRecord.Book);

                // Update borrow record
                context.Update(borrowRecord);

                context.SaveChanges();

                MessageBox.Show("Trả sách thành công!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadCurrentBorrows();
                LoadBorrowHistory();
                SetButtonStates();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi trả sách: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (dgvCurrentBorrows.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sách cần gia hạn", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int borrowRecordId = (int)dgvCurrentBorrows.SelectedRows[0].Cells["BorrowRecordId"].Value;

            try
            {
                var borrowRecord = context.BorrowRecords
                    .FirstOrDefault(br => br.BorrowRecordId == borrowRecordId);

                if (borrowRecord == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin mượn sách", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if already overdue
                if (DateTime.Today > borrowRecord.DueDate)
                {
                    MessageBox.Show("Không thể gia hạn sách đã quá hạn. Vui lòng trả sách trước.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Extend due date by 30 days
                borrowRecord.DueDate = borrowRecord.DueDate.AddDays(30);
                borrowRecord.Notes += $" [Gia hạn ngày {DateTime.Today:dd/MM/yyyy}]";

                context.Update(borrowRecord);
                context.SaveChanges();

                MessageBox.Show($"Gia hạn thành công! Hạn trả mới: {borrowRecord.DueDate:dd/MM/yyyy}", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadCurrentBorrows();
                SetButtonStates();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gia hạn: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Data Loading

        private void LoadCurrentBorrows()
        {
            try
            {
                if (selectedMember == null)
                {
                    currentBorrowsBindingSource.DataSource = null;
                    dgvCurrentBorrows.DataSource = null;
                    return;
                }

                // Fetch raw data first without complex operations
                var rawData = context.BorrowRecords
                    .Include(br => br.Book)
                    .ThenInclude(b => b.Author)
                    .Include(br => br.BookCopy)
                    .Where(br => br.MemberId == selectedMember.MemberId && br.ReturnDate == null)
                    .Select(br => new
                    {
                        br.BorrowRecordId,
                        BookTitle = br.Book.Title,
                        AuthorName = br.Book.Author.Name,
                        br.CopyId,
                        br.BorrowDate,
                        br.DueDate
                    })
                    .ToList();

                // Process data in memory to calculate days and status
                var today = DateTime.Today;
                var currentBorrows = rawData.Select(item => new
                {
                    item.BorrowRecordId,
                    item.BookTitle,
                    item.AuthorName,
                    CopyId = item.CopyId,
                    BorrowDate = item.BorrowDate,
                    DueDate = item.DueDate,
                    DaysLeft = (item.DueDate - today).Days,
                    Status = item.DueDate < today ? "Quá hạn" :
                             (item.DueDate - today).Days <= 3 ? "Sắp hết hạn" : "Bình thường"
                }).OrderBy(item => item.DueDate).ToList();

                currentBorrowsBindingSource.DataSource = currentBorrows;
                dgvCurrentBorrows.DataSource = currentBorrowsBindingSource;

                if (dgvCurrentBorrows.Columns.Count > 0)
                {
                    dgvCurrentBorrows.Columns["BorrowRecordId"].Visible = false;
                    dgvCurrentBorrows.Columns["BookTitle"].HeaderText = "Tên sách";
                    dgvCurrentBorrows.Columns["AuthorName"].HeaderText = "Tác giả";
                    dgvCurrentBorrows.Columns["CopyId"].HeaderText = "Bản sao";
                    dgvCurrentBorrows.Columns["BorrowDate"].HeaderText = "Ngày mượn";
                    dgvCurrentBorrows.Columns["DueDate"].HeaderText = "Hạn trả";
                    dgvCurrentBorrows.Columns["DaysLeft"].HeaderText = "Còn lại";
                    dgvCurrentBorrows.Columns["Status"].HeaderText = "Trạng thái";

                    // Format date columns
                    dgvCurrentBorrows.Columns["BorrowDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvCurrentBorrows.Columns["DueDate"].DefaultCellStyle.Format = "dd/MM/yyyy";

                    // Color rows based on status
                    foreach (DataGridViewRow row in dgvCurrentBorrows.Rows)
                    {
                        string status = row.Cells["Status"].Value?.ToString();
                        if (status == "Quá hạn")
                        {
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235);
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(192, 0, 0);
                        }
                        else if (status == "Sắp hết hạn")
                        {
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 220);
                            row.DefaultCellStyle.ForeColor = Color.FromArgb(255, 140, 0);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách sách đang mượn: " + ex.Message + "\n" + ex.StackTrace, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBorrowHistory()
        {
            try
            {
                if (selectedMember == null)
                {
                    borrowHistoryBindingSource.DataSource = null;
                    dgvBorrowHistory.DataSource = null;
                    return;
                }

                // Fetch raw data first without complex operations
                var rawHistory = context.BorrowRecords
                    .Include(br => br.Book)
                    .ThenInclude(b => b.Author)
                    .Where(br => br.MemberId == selectedMember.MemberId)
                    .Select(br => new
                    {
                        BookTitle = br.Book.Title,
                        AuthorName = br.Book.Author.Name,
                        br.BorrowDate,
                        br.DueDate,
                        br.ReturnDate,
                        br.LateFee
                    })
                    .OrderByDescending(br => br.BorrowDate)
                    .Take(50)
                    .ToList();

                // Process data in memory
                var borrowHistory = rawHistory.Select(item => new
                {
                    item.BookTitle,
                    item.AuthorName,
                    BorrowDate = item.BorrowDate,
                    DueDate = item.DueDate,
                    ReturnDate = item.ReturnDate,
                    LateFee = item.LateFee ?? 0,
                    Status = item.ReturnDate == null ? "Đang mượn" : "Đã trả"
                }).ToList();

                borrowHistoryBindingSource.DataSource = borrowHistory;
                dgvBorrowHistory.DataSource = borrowHistoryBindingSource;

                if (dgvBorrowHistory.Columns.Count > 0)
                {
                    dgvBorrowHistory.Columns["BookTitle"].HeaderText = "Tên sách";
                    dgvBorrowHistory.Columns["AuthorName"].HeaderText = "Tác giả";
                    dgvBorrowHistory.Columns["BorrowDate"].HeaderText = "Ngày mượn";
                    dgvBorrowHistory.Columns["DueDate"].HeaderText = "Hạn trả";
                    dgvBorrowHistory.Columns["ReturnDate"].HeaderText = "Ngày trả";
                    dgvBorrowHistory.Columns["LateFee"].HeaderText = "Phí phạt";
                    dgvBorrowHistory.Columns["Status"].HeaderText = "Trạng thái";

                    // Format date columns
                    dgvBorrowHistory.Columns["BorrowDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvBorrowHistory.Columns["DueDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvBorrowHistory.Columns["ReturnDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvBorrowHistory.Columns["LateFee"].DefaultCellStyle.Format = "N0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lịch sử mượn: " + ex.Message + "\n" + ex.StackTrace, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Event Handlers

        private void fBorrowReturn_Load(object sender, EventArgs e)
        {
            // Form is already initialized in constructor
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCurrentBorrows();
            LoadBorrowHistory();
            MessageBox.Show("Dữ liệu đã được làm mới", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DgvCurrentBorrows_SelectionChanged(object sender, EventArgs e)
        {
            SetButtonStates();
        }

        private void DgvBorrowHistory_SelectionChanged(object sender, EventArgs e)
        {
            // Optional: Handle selection change in history grid
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (context != null)
            {
                context.Dispose();
            }
        }

        #endregion
    }
}