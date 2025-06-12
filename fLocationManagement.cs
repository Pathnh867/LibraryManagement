using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class fLocationManagement : Form
    {
        #region Fields and Properties
        private LibraryDbContext context;
        private BookLocation currentLocation = null;
        private bool isAddNew = false;
        private BindingSource locationBindingSource = new BindingSource();
        #endregion

        #region Constructor and Initialization
        public fLocationManagement()
        {
            InitializeComponent();
            dgvLocations.AutoGenerateColumns = true; // BẮT BUỘC phải có dòng này
            context = new LibraryDbContext();
            ApplyFormStyle();
            dgvLocations.DataBindingComplete += DgvLocations_DataBindingComplete;
            LoadLocationData();
            SetControlState(false);
        }
        #endregion

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

            // Add drop shadow to panels
            AddShadow(pnlLocationInfo);
            AddShadow(pnlSearch);
            AddShadow(pnlDataGrid);
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
                if (btn == btnAdd || btn == btnUpdate)
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
                if (btn == btnAdd || btn == btnUpdate)
                    btn.BackColor = Color.FromArgb(210, 121, 106);
                else if (btn == btnDelete)
                    btn.BackColor = Color.FromArgb(192, 0, 0);
                else if (btn == btnRefresh || btn == btnSearch)
                    btn.BackColor = Color.FromArgb(129, 195, 215);
            }
        }
        #endregion

        #region Data Access Functions
        private void LoadLocationData()
        {
            try
            {
                var locations = context.BookLocations
                    .Include(l => l.BookCopies)
                    .ThenInclude(bc => bc.Book)
                    .OrderBy(l => l.AreaCode)
                    .ThenBy(l => l.ShelfNumber)
                    .ThenBy(l => l.SectionNumber)
                    .Select(l => new
                    {
                        l.LocationId,
                        l.AreaCode,
                        l.ShelfNumber,
                        l.SectionNumber,
                        LocationCode = $"{l.AreaCode}-{l.ShelfNumber:D2}-{l.SectionNumber:D2}",
                        l.Description,
                        BookCount = l.BookCopies.Count,
                        AvailableCount = l.BookCopies.Count(bc => bc.Status == 1),
                        OccupiedCount = l.BookCopies.Count(bc => bc.Status != 1)
                    })
                    .ToList();

                locationBindingSource.DataSource = locations;
                dgvLocations.DataSource = locationBindingSource;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu vị trí: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView()
        {
            if (dgvLocations.DataSource == null || dgvLocations.Columns.Count == 0)
                return;

            // Thiết lập tiêu đề, chiều rộng, kiểm tra null cho từng cột
            if (dgvLocations.Columns["LocationId"] != null)
            {
                dgvLocations.Columns["LocationId"].HeaderText = "Mã vị trí";
                dgvLocations.Columns["LocationId"].Width = 50;
            }
            if (dgvLocations.Columns["AreaCode"] != null)
            {
                dgvLocations.Columns["AreaCode"].HeaderText = "Khu vực";
                dgvLocations.Columns["AreaCode"].Width = 80;
            }
            if (dgvLocations.Columns["ShelfNumber"] != null)
            {
                dgvLocations.Columns["ShelfNumber"].HeaderText = "Số kệ";
                dgvLocations.Columns["ShelfNumber"].Width = 70;
            }
            if (dgvLocations.Columns["SectionNumber"] != null)
            {
                dgvLocations.Columns["SectionNumber"].HeaderText = "Số ngăn";
                dgvLocations.Columns["SectionNumber"].Width = 80;
            }
            if (dgvLocations.Columns["LocationCode"] != null)
            {
                dgvLocations.Columns["LocationCode"].HeaderText = "Mã định vị";
                dgvLocations.Columns["LocationCode"].Width = 120;
            }
            if (dgvLocations.Columns["Description"] != null)
                dgvLocations.Columns["Description"].HeaderText = "Mô tả";
            if (dgvLocations.Columns["BookCount"] != null)
                dgvLocations.Columns["BookCount"].HeaderText = "Tổng sách";
            if (dgvLocations.Columns["AvailableCount"] != null)
                dgvLocations.Columns["AvailableCount"].HeaderText = "Có sẵn";
            if (dgvLocations.Columns["OccupiedCount"] != null)
                dgvLocations.Columns["OccupiedCount"].HeaderText = "Đang sử dụng";

            // Style cho DataGridView
            dgvLocations.ForeColor = Color.FromArgb(64, 64, 64);
            dgvLocations.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dgvLocations.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvLocations.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(210, 121, 106);
            dgvLocations.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLocations.EnableHeadersVisualStyles = false;
            dgvLocations.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 245, 245);
            dgvLocations.DefaultCellStyle.BackColor = Color.White;
            dgvLocations.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 121, 106);
            dgvLocations.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvLocations.RowTemplate.Height = 28;
            dgvLocations.GridColor = Color.FromArgb(224, 224, 224);
            dgvLocations.BorderStyle = BorderStyle.None;
            dgvLocations.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        }
        #endregion

        #region 

        private void ClearFields()
        {
            txtLocationId.Text = string.Empty;
            txtAreaCode.Text = string.Empty;
            numShelfNumber.Value = 1;
            numSectionNumber.Value = 1;
            txtDescription.Text = string.Empty;
            currentLocation = null;
        }

        private void SetControlState(bool isEditing)
        {
            txtAreaCode.Enabled = isEditing;
            numShelfNumber.Enabled = isEditing;
            numSectionNumber.Enabled = isEditing;
            txtDescription.Enabled = isEditing;

            btnAdd.Text = isEditing && isAddNew ? "Lưu" : "Tạo mới";
            btnUpdate.Enabled = !isEditing && currentLocation != null;
            btnDelete.Enabled = !isEditing && currentLocation != null;
            btnRefresh.Text = isEditing ? "Hủy" : "Làm mới";

            // Disable search when editing
            txtSearch.Enabled = !isEditing;
            btnSearch.Enabled = !isEditing;

            // Disable datagrid selection when editing
            dgvLocations.Enabled = !isEditing;
        }

        private void DisplayLocationData(BookLocation location)
        {
            if (location != null)
            {
                txtLocationId.Text = location.LocationId.ToString();
                txtAreaCode.Text = location.AreaCode;
                numShelfNumber.Value = location.ShelfNumber;
                numSectionNumber.Value = location.SectionNumber;
                txtDescription.Text = location.Description ?? string.Empty;
            }
        }

        private bool ValidateLocationData()
        {
            if (string.IsNullOrWhiteSpace(txtAreaCode.Text))
            {
                MessageBox.Show("Vui lòng nhập mã khu vực", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAreaCode.Focus();
                return false;
            }

            if (txtAreaCode.Text.Length > 10)
            {
                MessageBox.Show("Mã khu vực không được vượt quá 10 ký tự", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAreaCode.Focus();
                return false;
            }

            string areaCode = txtAreaCode.Text.Trim().ToUpper();
            int shelfNumber = (int)numShelfNumber.Value;
            int sectionNumber = (int)numSectionNumber.Value;

            var existingLocation = context.BookLocations.FirstOrDefault(l =>
                l.AreaCode.ToUpper() == areaCode &&
                l.ShelfNumber == shelfNumber &&
                l.SectionNumber == sectionNumber &&
                (isAddNew || l.LocationId != currentLocation.LocationId));

            if (existingLocation != null)
            {
                MessageBox.Show($"Vị trí {areaCode}-{shelfNumber:D2}-{sectionNumber:D2} đã tồn tại!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private string GenerateLocationCode(string areaCode, int shelfNumber, int sectionNumber)
        {
            return $"{areaCode.ToUpper()}-{shelfNumber:D2}-{sectionNumber:D2}";
        }
        #endregion

        #region Event Handlers (giữ nguyên như code của bạn)
        private void fLocationManagement_Load(object sender, EventArgs e)
        {
            LoadLocationData();
            SetControlState(false);

            txtSearch.KeyDown += txtSearch_KeyDown;
            dgvLocations.CellDoubleClick += dgvLocations_CellDoubleClick;
            dgvLocations.DataBindingComplete += DgvLocations_DataBindingComplete;
        }
        private void DgvLocations_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            FormatDataGridView();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Tạo mới")
            {
                isAddNew = true;
                ClearFields();
                SetControlState(true);
                txtAreaCode.Focus();
            }
            else // Save
            {
                SaveLocation();
            }
        }

        private void SaveLocation()
        {
            try
            {
                if (!ValidateLocationData())
                    return;

                if (isAddNew)
                {
                    BookLocation newLocation = new BookLocation
                    {
                        AreaCode = txtAreaCode.Text.Trim().ToUpper(),
                        ShelfNumber = (int)numShelfNumber.Value,
                        SectionNumber = (int)numSectionNumber.Value,
                        Description = txtDescription.Text.Trim()
                    };

                    context.BookLocations.Add(newLocation);
                    context.SaveChanges();

                    MessageBox.Show("Thêm vị trí mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    currentLocation.AreaCode = txtAreaCode.Text.Trim().ToUpper();
                    currentLocation.ShelfNumber = (int)numShelfNumber.Value;
                    currentLocation.SectionNumber = (int)numSectionNumber.Value;
                    currentLocation.Description = txtDescription.Text.Trim();

                    context.Update(currentLocation);
                    context.SaveChanges();

                    MessageBox.Show("Cập nhật vị trí thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                isAddNew = false;
                LoadLocationData();
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
            if (currentLocation == null)
            {
                MessageBox.Show("Vui lòng chọn vị trí để cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            isAddNew = false;
            SetControlState(true);
            txtAreaCode.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currentLocation == null)
            {
                MessageBox.Show("Vui lòng chọn vị trí để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int bookCount = context.BookCopies.Count(bc => bc.LocationId == currentLocation.LocationId);
            if (bookCount > 0)
            {
                MessageBox.Show($"Không thể xóa vị trí này vì có {bookCount} cuốn sách đang được lưu trữ tại đây.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string locationCode = GenerateLocationCode(currentLocation.AreaCode, currentLocation.ShelfNumber, currentLocation.SectionNumber);
            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa vị trí '{locationCode}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    context.BookLocations.Remove(currentLocation);
                    context.SaveChanges();

                    MessageBox.Show("Xóa vị trí thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadLocationData();
                    ClearFields();
                    SetControlState(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa vị trí: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (btnRefresh.Text == "Làm mới")
            {
                ClearFields();
                LoadLocationData();
                SetControlState(false);
                txtSearch.Clear();
            }
            else
            {
                isAddNew = false;
                ClearFields();
                SetControlState(false);
                if (dgvLocations.SelectedRows.Count > 0)
                {
                    dgvLocations_SelectionChanged(dgvLocations, EventArgs.Empty);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim().ToUpper();

            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadLocationData();
                return;
            }

            try
            {
                var locations = context.BookLocations
                    .Include(l => l.BookCopies)
                    .ThenInclude(bc => bc.Book)
                    .Where(l =>
                        l.AreaCode.ToUpper().Contains(searchTerm) ||
                        l.ShelfNumber.ToString().Contains(searchTerm) ||
                        l.SectionNumber.ToString().Contains(searchTerm) ||
                        l.Description.ToUpper().Contains(searchTerm) ||
                        (l.AreaCode + "-" + l.ShelfNumber.ToString("D2") + "-" + l.SectionNumber.ToString("D2")).Contains(searchTerm)
                    )
                    .OrderBy(l => l.AreaCode)
                    .ThenBy(l => l.ShelfNumber)
                    .ThenBy(l => l.SectionNumber)
                    .Select(l => new
                    {
                        l.LocationId,
                        l.AreaCode,
                        l.ShelfNumber,
                        l.SectionNumber,
                        LocationCode = $"{l.AreaCode}-{l.ShelfNumber:D2}-{l.SectionNumber:D2}",
                        l.Description,
                        BookCount = l.BookCopies.Count,
                        AvailableCount = l.BookCopies.Count(bc => bc.Status == 1),
                        OccupiedCount = l.BookCopies.Count(bc => bc.Status != 1)
                    })
                    .ToList();

                locationBindingSource.DataSource = locations;
                dgvLocations.DataSource = locationBindingSource;

                if (locations.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLocations_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvLocations.SelectedRows.Count > 0 && dgvLocations.SelectedRows[0].Cells["LocationId"].Value != null)
            {
                int locationId = (int)dgvLocations.SelectedRows[0].Cells["LocationId"].Value;
                currentLocation = context.BookLocations.Find(locationId);

                if (currentLocation != null)
                {
                    DisplayLocationData(currentLocation);
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                }
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void dgvLocations_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvLocations.Rows[e.RowIndex].Cells["LocationId"].Value != null)
            {
                int locationId = (int)dgvLocations.Rows[e.RowIndex].Cells["LocationId"].Value;
                ShowBooksAtLocation(locationId);
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
        #endregion

        #region Additional Features
        private void ShowBooksAtLocation(int locationId)
        {
            try
            {
                var location = context.BookLocations
                    .Include(l => l.BookCopies)
                    .ThenInclude(bc => bc.Book)
                    .ThenInclude(b => b.Author)
                    .FirstOrDefault(l => l.LocationId == locationId);

                if (location == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin vị trí!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string locationCode = GenerateLocationCode(location.AreaCode, location.ShelfNumber, location.SectionNumber);

                // Create detail form
                Form frmDetail = new Form();
                frmDetail.Text = $"Danh sách sách tại vị trí {locationCode}";
                frmDetail.Size = new Size(800, 600);
                frmDetail.StartPosition = FormStartPosition.CenterParent;
                frmDetail.FormBorderStyle = FormBorderStyle.FixedDialog;
                frmDetail.MaximizeBox = false;
                frmDetail.MinimizeBox = false;

                // Main panel
                Panel pnlMain = new Panel();
                pnlMain.Dock = DockStyle.Fill;
                pnlMain.Padding = new Padding(15);
                frmDetail.Controls.Add(pnlMain);

                // Title
                Label lblTitle = new Label();
                lblTitle.Text = $"Vị trí: {locationCode}";
                lblTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                lblTitle.ForeColor = Color.FromArgb(210, 121, 106);
                lblTitle.Location = new Point(15, 15);
                lblTitle.Size = new Size(750, 30);
                pnlMain.Controls.Add(lblTitle);

                // Location info
                Label lblLocationInfo = new Label();
                lblLocationInfo.Text = $"Mô tả: {location.Description}";
                lblLocationInfo.Font = new Font("Segoe UI", 10);
                lblLocationInfo.Location = new Point(15, 50);
                lblLocationInfo.Size = new Size(750, 20);
                pnlMain.Controls.Add(lblLocationInfo);

                // Statistics
                int totalBooks = location.BookCopies.Count;
                int availableBooks = location.BookCopies.Count(bc => bc.Status == 1);
                int borrowedBooks = location.BookCopies.Count(bc => bc.Status == 2);
                int lostBooks = location.BookCopies.Count(bc => bc.Status == 3);
                int damagedBooks = location.BookCopies.Count(bc => bc.Status == 4);

                Label lblStats = new Label();
                lblStats.Text = $"Tổng số sách: {totalBooks} | Có sẵn: {availableBooks} | Đang mượn: {borrowedBooks} | Mất: {lostBooks} | Hư hỏng: {damagedBooks}";
                lblStats.Font = new Font("Segoe UI", 10);
                lblStats.Location = new Point(15, 75);
                lblStats.Size = new Size(750, 20);
                pnlMain.Controls.Add(lblStats);

                // DataGridView for books
                DataGridView dgvBooks = new DataGridView();
                dgvBooks.Location = new Point(15, 105);
                dgvBooks.Size = new Size(750, 400);
                dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvBooks.AllowUserToAddRows = false;
                dgvBooks.AllowUserToDeleteRows = false;
                dgvBooks.ReadOnly = true;
                dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvBooks.RowHeadersVisible = false;

                // Format DataGridView
                dgvBooks.DefaultCellStyle.BackColor = Color.White;
                dgvBooks.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 245, 245);
                dgvBooks.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
                dgvBooks.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(210, 121, 106);
                dgvBooks.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvBooks.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgvBooks.EnableHeadersVisualStyles = false;
                dgvBooks.GridColor = Color.FromArgb(224, 224, 224);
                dgvBooks.BorderStyle = BorderStyle.None;
                dgvBooks.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

                pnlMain.Controls.Add(dgvBooks);

                // Load book data
                var bookData = location.BookCopies.Select(bc => new
                {
                    bc.CopyId,
                    BookTitle = bc.Book.Title,
                    Author = bc.Book.Author.Name,
                    ISBN = bc.Book.ISBN,
                    Status = GetCopyStatusText(bc.Status),
                    AcquisitionDate = bc.AcquisitionDate.ToString("dd/MM/yyyy"),
                    bc.Notes
                }).ToList();

                dgvBooks.DataSource = bookData;
                dgvBooks.Columns["CopyId"].HeaderText = "Mã bản sao";
                dgvBooks.Columns["BookTitle"].HeaderText = "Tên sách";
                dgvBooks.Columns["Author"].HeaderText = "Tác giả";
                dgvBooks.Columns["ISBN"].HeaderText = "ISBN";
                dgvBooks.Columns["Status"].HeaderText = "Trạng thái";
                dgvBooks.Columns["AcquisitionDate"].HeaderText = "Ngày nhập";
                dgvBooks.Columns["Notes"].HeaderText = "Ghi chú";

                // Close button
                Button btnClose = new Button();
                btnClose.Text = "Đóng";
                btnClose.Size = new Size(100, 35);
                btnClose.Location = new Point(665, 515);
                btnClose.BackColor = Color.FromArgb(210, 121, 106);
                btnClose.ForeColor = Color.White;
                btnClose.FlatStyle = FlatStyle.Flat;
                btnClose.FlatAppearance.BorderSize = 0;
                btnClose.Click += (s, e) => frmDetail.Close();
                pnlMain.Controls.Add(btnClose);

                // Move books button
                Button btnMoveBooks = new Button();
                btnMoveBooks.Text = "Di chuyển sách";
                btnMoveBooks.Size = new Size(120, 35);
                btnMoveBooks.Location = new Point(15, 515);
                btnMoveBooks.BackColor = Color.FromArgb(34, 139, 34);
                btnMoveBooks.ForeColor = Color.White;
                btnMoveBooks.FlatStyle = FlatStyle.Flat;
                btnMoveBooks.FlatAppearance.BorderSize = 0;
                btnMoveBooks.Click += (s, e) => MoveBooksFromLocation(location);
                pnlMain.Controls.Add(btnMoveBooks);

                // Show form
                frmDetail.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị danh sách sách: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MoveBooksFromLocation(BookLocation fromLocation)
        {
            try
            {
                var availableBooks = context.BookCopies
                    .Include(bc => bc.Book)
                    .Where(bc => bc.LocationId == fromLocation.LocationId && bc.Status == 1)
                    .ToList();

                if (availableBooks.Count == 0)
                {
                    MessageBox.Show("Không có sách nào có thể di chuyển từ vị trí này.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Create move form
                Form frmMove = new Form();
                frmMove.Text = "Di chuyển sách";
                frmMove.Size = new Size(600, 400);
                frmMove.StartPosition = FormStartPosition.CenterParent;
                frmMove.FormBorderStyle = FormBorderStyle.FixedDialog;
                frmMove.MaximizeBox = false;
                frmMove.MinimizeBox = false;

                Panel pnlMoveMain = new Panel();
                pnlMoveMain.Dock = DockStyle.Fill;
                pnlMoveMain.Padding = new Padding(15);
                frmMove.Controls.Add(pnlMoveMain);

                // Title
                Label lblMoveTitle = new Label();
                lblMoveTitle.Text = "Chọn sách cần di chuyển:";
                lblMoveTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                lblMoveTitle.ForeColor = Color.FromArgb(210, 121, 106);
                lblMoveTitle.Location = new Point(15, 15);
                lblMoveTitle.Size = new Size(550, 25);
                pnlMoveMain.Controls.Add(lblMoveTitle);

                // CheckedListBox for books
                CheckedListBox clbBooks = new CheckedListBox();
                clbBooks.Location = new Point(15, 50);
                clbBooks.Size = new Size(550, 200);
                clbBooks.CheckOnClick = true;

                // Create a dictionary to map display text to BookCopy objects
                Dictionary<string, BookCopy> bookMap = new Dictionary<string, BookCopy>();

                foreach (var book in availableBooks)
                {
                    string displayText = $"{book.Book.Title} (Mã: {book.CopyId})";
                    clbBooks.Items.Add(displayText);
                    bookMap.Add(displayText, book);
                }
                pnlMoveMain.Controls.Add(clbBooks);

                // Destination location
                Label lblDestination = new Label();
                lblDestination.Text = "Vị trí đích:";
                lblDestination.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                lblDestination.Location = new Point(15, 265);
                lblDestination.Size = new Size(100, 20);
                pnlMoveMain.Controls.Add(lblDestination);

                ComboBox cboDestination = new ComboBox();
                cboDestination.Location = new Point(120, 265);
                cboDestination.Size = new Size(300, 25);
                cboDestination.DropDownStyle = ComboBoxStyle.DropDownList;

                var otherLocations = context.BookLocations
                    .Where(l => l.LocationId != fromLocation.LocationId)
                    .OrderBy(l => l.AreaCode)
                    .ThenBy(l => l.ShelfNumber)
                    .ThenBy(l => l.SectionNumber)
                    .ToList();

                cboDestination.DataSource = otherLocations;
                cboDestination.DisplayMember = "Description";
                cboDestination.ValueMember = "LocationId";
                pnlMoveMain.Controls.Add(cboDestination);

                // Move button
                Button btnMove = new Button();
                btnMove.Text = "Di chuyển";
                btnMove.Size = new Size(100, 35);
                btnMove.Location = new Point(465, 310);
                btnMove.BackColor = Color.FromArgb(210, 121, 106);
                btnMove.ForeColor = Color.White;
                btnMove.FlatStyle = FlatStyle.Flat;
                btnMove.FlatAppearance.BorderSize = 0;
                btnMove.Click += (s, e) =>
                {
                    if (clbBooks.CheckedItems.Count == 0)
                    {
                        MessageBox.Show("Vui lòng chọn ít nhất một cuốn sách để di chuyển.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (cboDestination.SelectedValue == null)
                    {
                        MessageBox.Show("Vui lòng chọn vị trí đích.", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    try
                    {
                        int destinationId = (int)cboDestination.SelectedValue;
                        int movedCount = 0;

                        foreach (string selectedItem in clbBooks.CheckedItems)
                        {
                            if (bookMap.ContainsKey(selectedItem))
                            {
                                BookCopy selectedBook = bookMap[selectedItem];
                                selectedBook.LocationId = destinationId;
                                movedCount++;
                            }
                        }

                        context.SaveChanges();

                        MessageBox.Show($"Đã di chuyển thành công {movedCount} cuốn sách!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        frmMove.DialogResult = DialogResult.OK;
                        frmMove.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi di chuyển sách: " + ex.Message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };
                pnlMoveMain.Controls.Add(btnMove);

                // Cancel button
                Button btnCancel = new Button();
                btnCancel.Text = "Hủy";
                btnCancel.Size = new Size(100, 35);
                btnCancel.Location = new Point(355, 310);
                btnCancel.BackColor = Color.FromArgb(129, 195, 215);
                btnCancel.ForeColor = Color.White;
                btnCancel.FlatStyle = FlatStyle.Flat;
                btnCancel.FlatAppearance.BorderSize = 0;
                btnCancel.Click += (s, e) => frmMove.Close();
                pnlMoveMain.Controls.Add(btnCancel);

                // Show dialog and refresh if books were moved
                if (frmMove.ShowDialog() == DialogResult.OK)
                {
                    LoadLocationData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chuẩn bị di chuyển sách: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetCopyStatusText(int status)
        {
            switch (status)
            {
                case 1: return "Có sẵn";
                case 2: return "Đang mượn";
                case 3: return "Bị mất";
                case 4: return "Hư hỏng";
                default: return "Không xác định";
            }
        }

        // Method to generate location report
        private void GenerateLocationReport()
        {
            try
            {
                var locationStats = context.BookLocations
                    .Include(l => l.BookCopies)
                    .ThenInclude(bc => bc.Book)
                    .Select(l => new
                    {
                        LocationCode = $"{l.AreaCode}-{l.ShelfNumber:D2}-{l.SectionNumber:D2}",
                        l.Description,
                        TotalBooks = l.BookCopies.Count,
                        AvailableBooks = l.BookCopies.Count(bc => bc.Status == 1),
                        BorrowedBooks = l.BookCopies.Count(bc => bc.Status == 2),
                        LostBooks = l.BookCopies.Count(bc => bc.Status == 3),
                        DamagedBooks = l.BookCopies.Count(bc => bc.Status == 4),
                        UtilizationRate = l.BookCopies.Count > 0 ?
                            (double)l.BookCopies.Count(bc => bc.Status != 1) / l.BookCopies.Count * 100 : 0
                    })
                    .OrderBy(l => l.LocationCode)
                    .ToList();

                // Create report form
                Form frmReport = new Form();
                frmReport.Text = "Báo cáo thống kê vị trí";
                frmReport.Size = new Size(1000, 700);
                frmReport.StartPosition = FormStartPosition.CenterParent;
                frmReport.FormBorderStyle = FormBorderStyle.Sizable;

                // Create DataGridView for report
                DataGridView dgvReport = new DataGridView();
                dgvReport.Dock = DockStyle.Fill;
                dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvReport.AllowUserToAddRows = false;
                dgvReport.AllowUserToDeleteRows = false;
                dgvReport.ReadOnly = true;
                dgvReport.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                dgvReport.DataSource = locationStats;

                // Format columns
                dgvReport.Columns["LocationCode"].HeaderText = "Mã vị trí";
                dgvReport.Columns["Description"].HeaderText = "Mô tả";
                dgvReport.Columns["TotalBooks"].HeaderText = "Tổng sách";
                dgvReport.Columns["AvailableBooks"].HeaderText = "Có sẵn";
                dgvReport.Columns["BorrowedBooks"].HeaderText = "Đang mượn";
                dgvReport.Columns["LostBooks"].HeaderText = "Mất";
                dgvReport.Columns["DamagedBooks"].HeaderText = "Hư hỏng";
                dgvReport.Columns["UtilizationRate"].HeaderText = "Tỷ lệ sử dụng (%)";
                dgvReport.Columns["UtilizationRate"].DefaultCellStyle.Format = "F1";

                frmReport.Controls.Add(dgvReport);
                frmReport.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo báo cáo: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
