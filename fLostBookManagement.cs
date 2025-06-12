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
            dgvLostBooks.Columns["ReportDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
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
                var newLostBook = new LostBook
                {
                    CopyId = int.Parse(txtCopyId.Text.Trim()),
                    ReportDate = dtpReportDate.Value,
                    EmployeeId = ((Employee)cboEmployee.SelectedItem).EmployeeId,
                    Reason = txtReason.Text.Trim(),
                    Description = txtDescription.Text.Trim()
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
            // Ví dụ đơn giản: chọn bản sao từ danh sách những sách chưa mất
            var availableCopies = context.BookCopies
                .Include(bc => bc.Book)
                .Where(bc => bc.Status != 3) // 3 = Đã mất
                .ToList();

            var form = new Form(); // Popup chọn sách
                                   // Add logic hiển thị danh sách và chọn một dòng để điền vào txtCopyId, txtBookTitle
                                   // (Có thể dùng DataGridView hoặc ListBox)
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
    }
}
