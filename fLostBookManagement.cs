using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{

    public partial class fLostBookManagement : Form
    {
        private LibraryDbContext context;
        private BindingSource lostBookBindingSource = new BindingSource();
        public fLostBookManagement()
        {
            InitializeComponent();
            context = new LibraryDbContext();
            LoadLostBookData();

        }
        private void LoadLostBookData()
        {
            var lostBooks = context.LostBooks
                .Include(lb => lb.BookCopy)
                .Include(lb => lb.Employee)
                .Select(lb => new
                {
                    lb.LostBookId,
                    lb.CopyId,
                    BookTitle = lb.BookCopy.Book.Title,
                    EmployeeName = lb.Employee.Name,
                    lb.Reason,
                    lb.Description,
                    lb.ReportDate,
                })
                .ToList();
            lostBookBindingSource.DataSource = lostBooks;
            dgvLostBooks.DataSource = lostBookBindingSource;
            if (dgvLostBooks.Columns["ReportDate"] != null)
                dgvLostBooks.Columns["ReportDate"].DefaultCellStyle.Format = "dd/MM/yyyy";

            FormatDataGridView();
            
        }

        private void fLostBookManagement_Load(object sender, EventArgs e)
        {
            dgvLostBooks.CellClick += dgvLostBooks_CellClick;
            // Load danh sách nhân viên cho combobox
            var employees = context.Employees
                .Where(e => e.Status) // chỉ lấy nhân viên đang hoạt động
                .ToList();
            cboEmployee.DataSource = employees;
            cboEmployee.DisplayMember = "Name";
            cboEmployee.ValueMember = "EmployeeId";
        }

        private void dgvLostBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLostBooks.Rows[e.RowIndex];

                txtLostBookId.Text = row.Cells["LostBookId"].Value.ToString();
                txtCopyId.Text = row.Cells["CopyId"].Value.ToString();
                txtBookTitle.Text = row.Cells["BookTitle"].Value.ToString();
                txtReason.Text = row.Cells["Reason"].Value.ToString();
                txtDescription.Text = row.Cells["Description"].Value.ToString();
                cboEmployee.Text = row.Cells["EmployeeName"].Value.ToString();

                if (DateTime.TryParse(row.Cells["ReportDate"].Value.ToString(), out DateTime reportDate))
                {
                    dtpReportDate.Value = reportDate;
                }

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCopyId.Text))
            {
                MessageBox.Show("Vui lòng nhập mã bản sao sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboEmployee.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên báo mất sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                int copyId = int.Parse(txtCopyId.Text.Trim());

                // Kiểm tra bản sao đã được báo mất chưa
                if (context.LostBooks.Any(lb => lb.CopyId == copyId))
                {
                    MessageBox.Show("Bản sao này đã được báo mất trước đó.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var newLostBook = new LostBook
                {
                    CopyId = copyId,
                    ReportDate = dtpReportDate.Value,
                    EmployeeId = ((Employee)cboEmployee.SelectedItem).EmployeeId,
                    Reason = txtReason.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    Notes = txtDescription.Text.Trim()
                };
                context.LostBooks.Add(newLostBook);
                context.SaveChanges();

                MessageBox.Show("Đã thêm báo mất sách thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadLostBookData();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm báo mất sách: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearForm()
        {
            txtLostBookId.Clear();
            txtCopyId.Clear();
            txtBookTitle.Clear();
            txtReason.Clear();
            txtDescription.Clear();
            dtpReportDate.Value = DateTime.Today;
            cboEmployee.SelectedIndex = -1;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLostBookId.Text))
            {
                MessageBox.Show("Vui lòng chọn báo mất sách cần cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cboEmployee.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên báo mất sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                int lostBookdId = int.Parse(txtLostBookId.Text.Trim());
                var existingReport = context.LostBooks.FirstOrDefault(lb => lb.LostBookId == lostBookdId);
                if (existingReport == null)
                {
                    MessageBox.Show("Báo mất sách không tồn tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                existingReport.Reason = txtReason.Text.Trim();
                existingReport.Description = txtDescription.Text.Trim();
                existingReport.Notes = txtDescription.Text.Trim();
                existingReport.ReportDate = dtpReportDate.Value;
                existingReport.EmployeeId = ((Employee)cboEmployee.SelectedItem).EmployeeId;

                context.SaveChanges();

                MessageBox.Show("Đã cập nhật báo mất sách thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadLostBookData();
                ClearForm();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật báo mất sách: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelectCopy_Click(object sender, EventArgs e)
        {
            ShowCopySelectionForm();
        }
        private void ShowCopySelectionForm()
        {
            var copies = context.BookCopies
                .Include(bc => bc.Book)
                 .ThenInclude(b => b.BookAuthors)
                   .ThenInclude(ba => ba.Author)
                .Include(bc => bc.Location)
                .Where(bc => bc.Status != 3 && bc.LostBook == null)
                .Select(bc => new
                {
                    bc.CopyId,
                    BookTitle = bc.Book.Title,
                    AuthorName = string.Join(", ", bc.Book.BookAuthors.Select(ba => ba.Author.Name)),
                    StatusText = Utility.GetCopyStatusText(bc.Status),
                    Location = bc.Location != null
                        ? $"{bc.Location.AreaCode}-{bc.Location.ShelfNumber}"
                        : "N/A"
                })
                .ToList();

            Form form = new Form();
            form.Text = "Chọn bản sao sách";
            form.Size = new Size(800, 500);
            form.StartPosition = FormStartPosition.CenterParent;
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.MaximizeBox = false;
            form.MinimizeBox = false;

            DataGridView dgvCopies = new DataGridView();
            dgvCopies.Location = new Point(20, 20);
            dgvCopies.Size = new Size(740, 360);
            dgvCopies.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCopies.AllowUserToAddRows = false;
            dgvCopies.ReadOnly = true;
            dgvCopies.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCopies.DataSource = copies;
            FormatGrid(dgvCopies);

            if (dgvCopies.Columns["CopyId"] != null)
                dgvCopies.Columns["CopyId"].HeaderText = "Mã bản sao";
            if (dgvCopies.Columns["BookTitle"] != null)
                dgvCopies.Columns["BookTitle"].HeaderText = "Tên sách";
            if (dgvCopies.Columns["AuthorName"] != null)
                dgvCopies.Columns["AuthorName"].HeaderText = "Tác giả";
            if (dgvCopies.Columns["StatusText"] != null)
                dgvCopies.Columns["StatusText"].HeaderText = "Trạng thái";
            if (dgvCopies.Columns["Location"] != null)
                dgvCopies.Columns["Location"].HeaderText = "Vị trí";

            Button btnSelect = new Button();
            btnSelect.Text = "Chọn";
            btnSelect.Size = new Size(100, 35);
            btnSelect.Location = new Point(560, 400);
            btnSelect.BackColor = Color.FromArgb(210, 121, 106);
            btnSelect.ForeColor = Color.White;
            btnSelect.FlatStyle = FlatStyle.Flat;
            btnSelect.FlatAppearance.BorderSize = 0;

            Button btnCancel = new Button();
            btnCancel.Text = "Hủy";
            btnCancel.Size = new Size(100, 35);
            btnCancel.Location = new Point(670, 400);
            btnCancel.BackColor = Color.FromArgb(129, 195, 215);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;

            btnSelect.Click += (s, e) =>
            {
                if (dgvCopies.SelectedRows.Count > 0)
                {
                    txtCopyId.Text = dgvCopies.SelectedRows[0].Cells["CopyId"].Value.ToString();
                    txtBookTitle.Text = dgvCopies.SelectedRows[0].Cells["BookTitle"].Value.ToString();
                    form.Close();
                }
            };

            btnCancel.Click += (s, e) => form.Close();

            form.Controls.Add(dgvCopies);
            form.Controls.Add(btnSelect);
            form.Controls.Add(btnCancel);

            form.ShowDialog();
        }

        private void FormatGrid(DataGridView dgv)
        {
            dgv.ForeColor = Color.FromArgb(64, 64, 64);
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(210, 121, 106);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.EnableHeadersVisualStyles = false;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 245, 245);
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 121, 106);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.RowTemplate.Height = 28;
            dgv.GridColor = Color.FromArgb(224, 224, 224);
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.RowHeadersVisible = false;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLostBookId.Text))
            {
                MessageBox.Show("Vui lòng chọn báo mất sách cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = int.Parse(txtLostBookId.Text.Trim());
            var report = context.LostBooks.Find(id);
            if (report != null)
            {
                var result = MessageBox.Show("Bạn có chắc muốn xóa báo mất này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    context.LostBooks.Remove(report);
                    context.SaveChanges();
                    MessageBox.Show("Đã xóa báo mất sách thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLostBookData();
                    ClearForm();
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ClearForm();
            LoadLostBookData();

            // Bỏ chọn dòng nào đang được chọn
            dgvLostBooks.ClearSelection();
        }
        private void FormatDataGridView()
        {
            if (dgvLostBooks.DataSource == null || dgvLostBooks.Columns.Count == 0)
                return;

            if (dgvLostBooks.Columns["LostBookId"] != null)
                dgvLostBooks.Columns["LostBookId"].HeaderText = "Mã báo mất";
            if (dgvLostBooks.Columns["CopyId"] != null)
                dgvLostBooks.Columns["CopyId"].HeaderText = "Mã bản sao";
            if (dgvLostBooks.Columns["BookTitle"] != null)
                dgvLostBooks.Columns["BookTitle"].HeaderText = "Tên sách";
            if (dgvLostBooks.Columns["EmployeeName"] != null)
                dgvLostBooks.Columns["EmployeeName"].HeaderText = "Nhân viên";
            if (dgvLostBooks.Columns["Reason"] != null)
                dgvLostBooks.Columns["Reason"].HeaderText = "Lý do";
            if (dgvLostBooks.Columns["Description"] != null)
                dgvLostBooks.Columns["Description"].HeaderText = "Mô tả";
            if (dgvLostBooks.Columns["ReportDate"] != null)
                dgvLostBooks.Columns["ReportDate"].HeaderText = "Ngày báo mất";

            dgvLostBooks.ForeColor = Color.FromArgb(64, 64, 64);
            dgvLostBooks.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dgvLostBooks.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvLostBooks.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(210, 121, 106);
            dgvLostBooks.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvLostBooks.EnableHeadersVisualStyles = false;
            dgvLostBooks.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 245, 245);
            dgvLostBooks.DefaultCellStyle.BackColor = Color.White;
            dgvLostBooks.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 121, 106);
            dgvLostBooks.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvLostBooks.RowTemplate.Height = 28;
            dgvLostBooks.GridColor = Color.FromArgb(224, 224, 224);
            dgvLostBooks.BorderStyle = BorderStyle.None;
            dgvLostBooks.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        }
    }
}
