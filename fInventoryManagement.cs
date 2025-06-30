#nullable disable
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class fInventoryManagement : Form
    {
        private LibraryDbContext context;
        private BindingSource inventoryBindingSource = new BindingSource();
        private InventoryCheck currentInventory = null;
        private bool isAddNew = false;

        public fInventoryManagement()
        {
            InitializeComponent();
            dgvInventory.AutoGenerateColumns = true;
            context = new LibraryDbContext();

            // Apply form styling
            ApplyFormStyle();

            // Gán sự kiện Load cho form (có thể làm trong Designer hoặc ở đây)
            this.Load += fInventoryManagement_Load;

            dgvInventory.DataBindingComplete += dgvInventory_DataBindingComplete;
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
            ApplyRoundedCorners(btnSelectBooks, 8);

            // Set custom colors
            btnAdd.BackColor = Color.FromArgb(210, 121, 106);
            btnUpdate.BackColor = Color.FromArgb(210, 121, 106);
            btnDelete.BackColor = Color.FromArgb(192, 0, 0);
            btnRefresh.BackColor = Color.FromArgb(129, 195, 215);
            btnSearch.BackColor = Color.FromArgb(129, 195, 215);
            btnSelectBooks.BackColor = Color.FromArgb(34, 139, 34);

            // Setup hover events
            SetupHoverEvents();

            // Add drop shadow to panels
            AddShadow(pnlInventoryInfo);
            AddShadow(pnlSearch);
            AddShadow(pnlDataGrid);

            // Format DataGridView
            FormatDataGridView();
        }

        private void SetupHoverEvents()
        {
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
            btnSelectBooks.MouseEnter += Button_MouseEnter;
            btnSelectBooks.MouseLeave += Button_MouseLeave;
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
                else if (btn == btnSelectBooks)
                    btn.BackColor = Color.FromArgb(24, 119, 24);
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
                else if (btn == btnSelectBooks)
                    btn.BackColor = Color.FromArgb(34, 139, 34);
            }
        }

        private void FormatDataGridView()
        {
            // Set text color
            dgvInventory.ForeColor = Color.FromArgb(64, 64, 64);
            dgvInventory.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);

            // Header style
            dgvInventory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvInventory.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(210, 121, 106);
            dgvInventory.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvInventory.EnableHeadersVisualStyles = false;

            // Alternate row colors
            dgvInventory.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 245, 245);
            dgvInventory.DefaultCellStyle.BackColor = Color.White;

            // Selection style
            dgvInventory.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 121, 106);
            dgvInventory.DefaultCellStyle.SelectionForeColor = Color.White;

            // Row height and grid lines
            dgvInventory.RowTemplate.Height = 28;
            dgvInventory.GridColor = Color.FromArgb(224, 224, 224);
            dgvInventory.BorderStyle = BorderStyle.None;
            dgvInventory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        }

        #endregion

        #region Data Loading

        private void LoadEmployees()
        {
            try
            {
                var employees = context.Employees
                    .Where(e => e.Status)
                    .OrderBy(e => e.Name)
                    .ToList();

                cboEmployee.DataSource = employees;
                cboEmployee.DisplayMember = "Name";
                cboEmployee.ValueMember = "EmployeeId";
                cboEmployee.SelectedIndex = -1;

                // Auto-select current employee if available
                if (Utility.CurrentEmployee != null)
                {
                    cboEmployee.SelectedValue = Utility.CurrentEmployee.EmployeeId;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadInventoryData()
        {
                var inventories = context.InventoryChecks
                    .Include(ic => ic.Employee)
                    .Include(ic => ic.InventoryDetails)
                    .OrderByDescending(ic => ic.CheckDate)
                    .Select(ic => new
                    {
                        ic.InventoryId,
                        ic.CheckDate,
                        EmployeeName = ic.Employee != null ? ic.Employee.Name : "",
                        TotalItems = ic.InventoryDetails != null ? ic.InventoryDetails.Count : 0,
                        DiscrepancyCount = ic.InventoryDetails != null
                        ? ic.InventoryDetails.Count(id => id.ExpectedStatus != id.ActualStatus)
                        : 0,
                        ic.Notes
                    }).ToList();

                dgvInventory.AutoGenerateColumns = true;
                inventoryBindingSource.DataSource = inventories;
                dgvInventory.DataSource = null; // Reset trước để tránh lỗi giữ state cũ
                dgvInventory.DataSource = inventoryBindingSource;
        }

        private void FormatInventoryGridColumns()
        {
            if (dgvInventory.Columns.Count == 0)
                return;

            // Header & width
            if (dgvInventory.Columns["InventoryId"] != null)
            {
                dgvInventory.Columns["InventoryId"].HeaderText = "Mã kiểm kê";
                dgvInventory.Columns["InventoryId"].Width = 80;
            }
            if (dgvInventory.Columns["CheckDate"] != null)
            {
                dgvInventory.Columns["CheckDate"].HeaderText = "Ngày kiểm kê";
                dgvInventory.Columns["CheckDate"].Width = 120;
                dgvInventory.Columns["CheckDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
            if (dgvInventory.Columns["EmployeeName"] != null)
            {
                dgvInventory.Columns["EmployeeName"].HeaderText = "Nhân viên";
                dgvInventory.Columns["EmployeeName"].Width = 150;
            }
            if (dgvInventory.Columns["TotalItems"] != null)
            {
                dgvInventory.Columns["TotalItems"].HeaderText = "Tổng số";
                dgvInventory.Columns["TotalItems"].Width = 70;
            }
            if (dgvInventory.Columns["DiscrepancyCount"] != null)
            {
                dgvInventory.Columns["DiscrepancyCount"].HeaderText = "Sai lệch";
                dgvInventory.Columns["DiscrepancyCount"].Width = 80;
            }
            if (dgvInventory.Columns["Notes"] != null)
            {
                dgvInventory.Columns["Notes"].HeaderText = "Ghi chú";
                dgvInventory.Columns["Notes"].Width = 200;
            }
        }

        private void SetColumnHeaderAndWidth(string colName, string header, int width)
        {
            if (dgvInventory.Columns.Contains(colName))
            {
                var col = dgvInventory.Columns[colName];
                if (col == null) return;
                col.HeaderText = header;
                if (width > 0)
                    col.Width = width;
            }
        }




        #endregion

        #region Form Operations

        private void SetControlState(bool isEditing)
        {
            dtpCheckDate.Enabled = isEditing;
            cboEmployee.Enabled = isEditing;
            txtNotes.Enabled = isEditing;
            btnSelectBooks.Enabled = isEditing;

            btnAdd.Text = isEditing && isAddNew ? "Lưu" : "Tạo mới";
            btnUpdate.Enabled = !isEditing && currentInventory != null;
            btnDelete.Enabled = !isEditing && currentInventory != null;
            btnRefresh.Text = isEditing ? "Hủy" : "Làm mới";

            txtSearch.Enabled = !isEditing;
            btnSearch.Enabled = !isEditing;
            dgvInventory.Enabled = !isEditing;
        }

        private void ClearFields()
        {
            txtInventoryId.Text = string.Empty;
            dtpCheckDate.Value = DateTime.Today;
            cboEmployee.SelectedIndex = -1;
            txtNotes.Text = string.Empty;
            currentInventory = null;

            // Auto-select current employee
            if (Utility.CurrentEmployee != null)
            {
                cboEmployee.SelectedValue = Utility.CurrentEmployee.EmployeeId;
            }
        }

        private void DisplayInventoryData(InventoryCheck inventory)
        {
            if (inventory != null)
            {
                txtInventoryId.Text = inventory.InventoryId.ToString();
                dtpCheckDate.Value = inventory.CheckDate;
                cboEmployee.SelectedValue = inventory.EmployeeId;
                txtNotes.Text = inventory.Notes;
            }
        }

        private bool ValidateInventoryData()
        {
            if (cboEmployee.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên kiểm kê", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboEmployee.Focus();
                return false;
            }
            return true;
        }

        #endregion

        #region Event Handlers

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Tạo mới")
            {
                isAddNew = true;
                ClearFields();
                SetControlState(true);
                dtpCheckDate.Focus();
            }
            else // Save
            {
                SaveInventory();
            }
        }

        private void SaveInventory()
        {
            try
            {
                if (!ValidateInventoryData())
                    return;

                if (isAddNew)
                {
                    InventoryCheck newInventory = new InventoryCheck
                    {
                        CheckDate = dtpCheckDate.Value.Date,
                        EmployeeId = (int)cboEmployee.SelectedValue,
                        Notes = txtNotes.Text.Trim()
                    };

                    context.InventoryChecks.Add(newInventory);
                    context.SaveChanges();

                    MessageBox.Show("Tạo phiếu kiểm kê thành công! Bây giờ hãy chọn sách để kiểm kê.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reload and select the new inventory
                    LoadInventoryData();
                    currentInventory = newInventory;
                    DisplayInventoryData(currentInventory);
                }
                else
                {
                    currentInventory.CheckDate = dtpCheckDate.Value.Date;
                    currentInventory.EmployeeId = (int)cboEmployee.SelectedValue;
                    currentInventory.Notes = txtNotes.Text.Trim();

                    context.Update(currentInventory);
                    context.SaveChanges();

                    MessageBox.Show("Cập nhật phiếu kiểm kê thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                isAddNew = false;
                LoadInventoryData();
                SetControlState(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (currentInventory == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu kiểm kê để cập nhật", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            isAddNew = false;
            SetControlState(true);
            dtpCheckDate.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currentInventory == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu kiểm kê để xóa", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa phiếu kiểm kê ngày {currentInventory.CheckDate:dd/MM/yyyy}?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Delete inventory details first
                    var details = context.InventoryDetails
                        .Where(id => id.InventoryId == currentInventory.InventoryId)
                        .ToList();

                    context.InventoryDetails.RemoveRange(details);
                    context.InventoryChecks.Remove(currentInventory);
                    context.SaveChanges();

                    MessageBox.Show("Xóa phiếu kiểm kê thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadInventoryData();
                    ClearFields();
                    SetControlState(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa phiếu kiểm kê: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (btnRefresh.Text == "Làm mới")
            {
                ClearFields();
                LoadInventoryData();
                SetControlState(false);
                txtSearch.Clear();
            }
            else // Cancel
            {
                isAddNew = false;
                ClearFields();
                SetControlState(false);
                if (dgvInventory.SelectedRows.Count > 0)
                {
                    dgvInventory_SelectionChanged(dgvInventory, EventArgs.Empty);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadInventoryData();
                return;
            }

            try
            {
                var inventories = context.InventoryChecks
                    .Include(ic => ic.Employee)
                    .Include(ic => ic.InventoryDetails)
                    .Where(ic =>
                        ic.Employee.Name.ToLower().Contains(searchTerm) ||
                        ic.Notes.ToLower().Contains(searchTerm) ||
                        ic.InventoryId.ToString().Contains(searchTerm)
                    )
                    .OrderByDescending(ic => ic.CheckDate)
                    .Select(ic => new
                    {
                        ic.InventoryId,
                        ic.CheckDate,
                        EmployeeName = ic.Employee.Name,
                        TotalItems = ic.InventoryDetails.Count,
                        DiscrepancyCount = ic.InventoryDetails.Count(id => id.ExpectedStatus != id.ActualStatus),
                        ic.Notes
                    })
                    .ToList();

                inventoryBindingSource.DataSource = inventories;
                dgvInventory.DataSource = inventoryBindingSource;

                // Format columns lại (an toàn)
                SetColumnHeaderAndWidth("InventoryId", "Mã kiểm kê", 100);
                SetColumnHeaderAndWidth("CheckDate", "Ngày kiểm kê", 120);
                SetColumnHeaderAndWidth("EmployeeName", "Nhân viên", 150);
                SetColumnHeaderAndWidth("TotalItems", "Tổng số", 80);
                SetColumnHeaderAndWidth("DiscrepancyCount", "Sai lệch", 80);
                SetColumnHeaderAndWidth("Notes", "Ghi chú", 0);

                if (dgvInventory.Columns["CheckDate"] != null)
                    dgvInventory.Columns["CheckDate"].DefaultCellStyle.Format = "dd/MM/yyyy";

                if (inventories.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelectBooks_Click(object sender, EventArgs e)
        {
            if (currentInventory == null)
            {
                MessageBox.Show("Vui lòng tạo hoặc chọn phiếu kiểm kê trước", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ShowBookSelectionForm();
        }

        private void dgvInventory_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInventory.SelectedRows.Count > 0 && dgvInventory.SelectedRows[0].Cells["InventoryId"].Value != null)
            {
                int inventoryId = (int)dgvInventory.SelectedRows[0].Cells["InventoryId"].Value;
                currentInventory = context.InventoryChecks.Find(inventoryId);

                if (currentInventory != null)
                {
                    DisplayInventoryData(currentInventory);
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                    btnSelectBooks.Enabled = true;
                }
            }
        }

        #endregion

        #region Book Selection

        private void ShowBookSelectionForm()
        {
            Form bookSelectionForm = new Form();
            bookSelectionForm.Text = "Chọn sách để kiểm kê";
            bookSelectionForm.Size = new Size(800, 600);
            bookSelectionForm.StartPosition = FormStartPosition.CenterParent;
            bookSelectionForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            bookSelectionForm.MaximizeBox = false;
            bookSelectionForm.MinimizeBox = false;

            // Create controls for book selection
            DataGridView dgvBooks = new DataGridView();
            dgvBooks.Location = new Point(20, 20);
            dgvBooks.Size = new Size(740, 400);
            dgvBooks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBooks.AllowUserToAddRows = false;
            dgvBooks.ReadOnly = true;
            dgvBooks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Load available book copies
            var bookCopies = context.BookCopies
                .Include(bc => bc.Book)
                .ThenInclude(b => b.BookAuthors)
                .ThenInclude(ba => ba.Author)
                .Include(bc => bc.Location)
                .Where(bc => bc.Status == 1 || bc.Status == 2) // Available or borrowed
                .Select(bc => new
                {
                    bc.CopyId,
                    BookTitle = bc.Book.Title,
                    AuthorName = string.Join(", ", bc.Book.BookAuthors.Select(ba => ba.Author.Name)),
                    Status = bc.Status,
                    StatusText = bc.Status == 1 ? "Có sẵn" : "Đang mượn",
                    Location = bc.Location != null ? $"{bc.Location.AreaCode}-{bc.Location.ShelfNumber}" : "N/A"
                })
                .ToList();

            dgvBooks.DataSource = bookCopies;

            // Format columns
            if (dgvBooks.Columns["CopyId"] != null)
                dgvBooks.Columns["CopyId"].HeaderText = "Mã bản sao";
            if (dgvBooks.Columns["BookTitle"] != null)
                dgvBooks.Columns["BookTitle"].HeaderText = "Tên sách";
            if (dgvBooks.Columns["AuthorName"] != null)
                dgvBooks.Columns["AuthorName"].HeaderText = "Tác giả";
            if (dgvBooks.Columns["Status"] != null)
                dgvBooks.Columns["Status"].Visible = false;
            if (dgvBooks.Columns["StatusText"] != null)
                dgvBooks.Columns["StatusText"].HeaderText = "Trạng thái";
            if (dgvBooks.Columns["Location"] != null)
                dgvBooks.Columns["Location"].HeaderText = "Vị trí";

            // Add buttons
            Button btnConfirm = new Button();
            btnConfirm.Text = "Xác nhận";
            btnConfirm.Size = new Size(100, 35);
            btnConfirm.Location = new Point(560, 440);
            btnConfirm.BackColor = Color.FromArgb(210, 121, 106);
            btnConfirm.ForeColor = Color.White;
            btnConfirm.FlatStyle = FlatStyle.Flat;
            btnConfirm.FlatAppearance.BorderSize = 0;

            Button btnCancel = new Button();
            btnCancel.Text = "Hủy";
            btnCancel.Size = new Size(100, 35);
            btnCancel.Location = new Point(670, 440);
            btnCancel.BackColor = Color.FromArgb(129, 195, 215);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;

            btnConfirm.Click += (s, e) =>
            {
                // Process selected books and create inventory details
                ProcessSelectedBooks(bookCopies);
                bookSelectionForm.Close();
            };

            btnCancel.Click += (s, e) => bookSelectionForm.Close();

            bookSelectionForm.Controls.Add(dgvBooks);
            bookSelectionForm.Controls.Add(btnConfirm);
            bookSelectionForm.Controls.Add(btnCancel);

            bookSelectionForm.ShowDialog();
        }

        private void ProcessSelectedBooks(dynamic bookCopies)
        {
            try
            {
                // Remove existing inventory details
                var existingDetails = context.InventoryDetails
                    .Where(id => id.InventoryId == currentInventory.InventoryId)
                    .ToList();
                context.InventoryDetails.RemoveRange(existingDetails);

                // Create new inventory details for all book copies
                foreach (var bookCopy in bookCopies)
                {
                    var inventoryDetail = new InventoryDetail
                    {
                        InventoryId = currentInventory.InventoryId,
                        CopyId = bookCopy.CopyId,
                        ExpectedStatus = bookCopy.Status,
                        ActualStatus = bookCopy.Status, // Default to same as expected
                        Notes = ""
                    };

                    context.InventoryDetails.Add(inventoryDetail);
                }

                context.SaveChanges();

                MessageBox.Show($"Đã thêm {bookCopies.Count} bản sao vào phiếu kiểm kê", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadInventoryData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xử lý dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (context != null)
            {
                context.Dispose();
            }
        }

        private void fInventoryManagement_Load(object sender, EventArgs e)
        {
            LoadEmployees();
            LoadInventoryData();
            SetControlState(false);
            dtpCheckDate.Value = DateTime.Today;
        }

        private void dgvInventory_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Kiểm tra đã có handle để tránh lỗi khi form chưa khởi tạo xong
            if (!this.IsHandleCreated) return;

            this.BeginInvoke((MethodInvoker)delegate
            {
                if (dgvInventory.DataSource == null || dgvInventory.Columns.Count == 0)
                    return;

                if (dgvInventory.Columns["InventoryId"] != null)
                {
                    dgvInventory.Columns["InventoryId"].HeaderText = "Mã kiểm kê";
                    dgvInventory.Columns["InventoryId"].Width = 80;
                }
                if (dgvInventory.Columns["CheckDate"] != null)
                {
                    dgvInventory.Columns["CheckDate"].HeaderText = "Ngày kiểm kê";
                    dgvInventory.Columns["CheckDate"].Width = 120;
                    dgvInventory.Columns["CheckDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
                }
                if (dgvInventory.Columns["EmployeeName"] != null)
                {
                    dgvInventory.Columns["EmployeeName"].HeaderText = "Nhân viên";
                    dgvInventory.Columns["EmployeeName"].Width = 150;
                }
                if (dgvInventory.Columns["TotalItems"] != null)
                {
                    dgvInventory.Columns["TotalItems"].HeaderText = "Tổng số";
                    dgvInventory.Columns["TotalItems"].Width = 80;
                }
                if (dgvInventory.Columns["DiscrepancyCount"] != null)
                {
                    dgvInventory.Columns["DiscrepancyCount"].HeaderText = "Sai lệch";
                    dgvInventory.Columns["DiscrepancyCount"].Width = 80;
                }
                if (dgvInventory.Columns["Notes"] != null)
                {
                    dgvInventory.Columns["Notes"].HeaderText = "Ghi chú";
                    dgvInventory.Columns["Notes"].Width = 200;
                }
            });
        }






    }
}
