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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class fMemberManagement : Form
    {
        private LibraryDbContext context;
        private Member currentMember = null;
        private bool isAddNew = false;
        private BindingSource memberBindingSource = new BindingSource();
        public fMemberManagement()
        {
            InitializeComponent();
            context = new LibraryDbContext();
            ApplyFormStyle();
            LoadMemberData();
            SetControlState(false);
        }
        private void ApplyFormStyle()
        {
            ApplyRoundedCorners(btnAdd, 8);
            ApplyRoundedCorners(btnUpdate, 8);
            ApplyRoundedCorners(btnDelete, 8);
            ApplyRoundedCorners(btnRefresh, 8);
            ApplyRoundedCorners(btnSearch, 8);

            btnAdd.BackColor = Color.FromArgb(210, 121, 106);
            btnUpdate.BackColor = Color.FromArgb(210, 121, 106);
            btnDelete.BackColor = Color.FromArgb(192, 0, 0);
            btnRefresh.BackColor = Color.FromArgb(129, 195, 215);
            btnSearch.BackColor = Color.FromArgb(129, 195, 215);

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

            AddShadow(pnlMemberInfo);
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
                // Set màu tối khi hover vào
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
                // Trở về màu sắc ban đầu
                if (btn == btnAdd || btn == btnUpdate)
                    btn.BackColor = Color.FromArgb(210, 121, 106);
                else if (btn == btnDelete)
                    btn.BackColor = Color.FromArgb(192, 0, 0);
                else if (btn == btnRefresh || btn == btnSearch)
                    btn.BackColor = Color.FromArgb(129, 195, 215);
            }
        }
        private void LoadMemberData()
        {
            try
            {
                var members = context.Members.
                    OrderBy(m => m.Name).
                    Select(m => new
                    {
                        m.MemberId,
                        m.Name,
                        m.Phone,
                        m.Email,
                        m.Address,
                        m.JoinDate,
                        StatusText = m.Status ? "Hoạt động" : "Đã khóa",
                        m.Status
                    }).ToList();
                memberBindingSource.DataSource = members;
                dgvMembers.DataSource = memberBindingSource;

                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu thành viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormatDataGridView()
        {
            dgvMembers.Columns["MemberId"].HeaderText = "Mã TV";
            dgvMembers.Columns["Name"].HeaderText = "Họ và tên";
            dgvMembers.Columns["Phone"].HeaderText = "Điện thoại";
            dgvMembers.Columns["Email"].HeaderText = "Email";
            dgvMembers.Columns["Address"].HeaderText = "Địa chỉ";
            dgvMembers.Columns["JoinDate"].HeaderText = "Ngày đăng ký";
            dgvMembers.Columns["StatusText"].HeaderText = "Trạng thái";

            // Ẩn cột Status
            dgvMembers.Columns["Status"].Visible = false;

            // Format cột ngày đăng ký
            dgvMembers.Columns["JoinDate"].DefaultCellStyle.Format = "dd/MM/yyyy";

            // Auto size columns
            dgvMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Đặt màu cho chữ và nền
            dgvMembers.ForeColor = Color.FromArgb(64, 64, 64);
            dgvMembers.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);

            // style cho tiêu đề cột
            dgvMembers.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvMembers.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(210, 121, 106);
            dgvMembers.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMembers.EnableHeadersVisualStyles = false;

            // Tạo màu cho cột
            dgvMembers.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 245, 245);
            dgvMembers.DefaultCellStyle.BackColor = Color.White;

            // Style cho hàng được chọn
            dgvMembers.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 121, 106);
            dgvMembers.DefaultCellStyle.SelectionForeColor = Color.White;

            // Set chiều cao cho hàng
            dgvMembers.RowTemplate.Height = 28;

            // 
            dgvMembers.GridColor = Color.FromArgb(224, 224, 224);
            dgvMembers.BorderStyle = BorderStyle.None;
            dgvMembers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        }
        private void ClearFields()
        {
            txtMemberId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtAddress.Text = string.Empty;
            dtpJoinDate.Value = DateTime.Today;
            cboStatus.SelectedIndex = 0; //  "Hoạt động" là hiện trạng đầu tiên
            txtCardNumber.Text = string.Empty;
            dtpExpiryDate.Value = DateTime.Today.AddYears(1); // Default 1 năm từ hôm tạo
            txtNotes.Text = string.Empty;
            currentMember = null;
        }
        private void SetControlState(bool isEditing)
        {
            txtName.Enabled = isEditing;
            txtPhone.Enabled = isEditing;
            txtEmail.Enabled = isEditing;
            txtAddress.Enabled = isEditing;
            dtpJoinDate.Enabled = isEditing;
            cboStatus.Enabled = isEditing;
            txtCardNumber.Enabled = isEditing;
            dtpExpiryDate.Enabled = isEditing;
            txtNotes.Enabled = isEditing;

            btnAdd.Text = isEditing && isAddNew ? "Lưu" : "Tạo mới";
            btnUpdate.Enabled = !isEditing && currentMember != null;
            btnDelete.Enabled = !isEditing && currentMember != null;
            btnRefresh.Text = isEditing ? "Hủy" : "Làm mới";

            // ẩn tìm kiếm khi đang chỉnh sửa
            txtSearch.Enabled = !isEditing;
            btnSearch.Enabled = !isEditing;

            // Ânr data khi chỉnh sửa
            dgvMembers.Enabled = !isEditing;
        }
        private void DisplayMemberData(Member member)
        {
            if (member != null)
            {
                txtMemberId.Text = member.MemberId.ToString();
                txtName.Text = member.Name;
                txtPhone.Text = member.Phone;
                txtEmail.Text = member.Email ?? string.Empty;
                txtAddress.Text = member.Address ?? string.Empty;
                dtpJoinDate.Value = member.JoinDate;
                cboStatus.SelectedIndex = member.Status ? 0 : 2; // 0=Hoạt động, 2=Khóa

                // Tạo mã thẻ tự động
                txtCardNumber.Text = !string.IsNullOrEmpty(member.Phone) ?
                    $"TV{member.MemberId:D6}" : string.Empty;

                // Đặt thời gian 1 năm cho thành viên mới
                dtpExpiryDate.Value = member.JoinDate.AddYears(1);
                txtNotes.Text = string.Empty;
            }
        }
        private bool ValidateMemberData()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }

            // Validate phone number format (basic)
            if (txtPhone.Text.Length < 10)
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return false;
            }

            // Validate email if provided
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                try
                {
                    var email = new System.Net.Mail.MailAddress(txtEmail.Text);
                }
                catch
                {
                    MessageBox.Show("Email không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return false;
                }
            }

            // Check if phone number already exists (for new member or different member)
            if (isAddNew || (currentMember != null && currentMember.Phone != txtPhone.Text))
            {
                var existingMember = context.Members.FirstOrDefault(m => m.Phone == txtPhone.Text);
                if (existingMember != null)
                {
                    MessageBox.Show("Số điện thoại này đã được sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhone.Focus();
                    return false;
                }
            }

            return true;
        }

        private void fMemberManagement_Load(object sender, EventArgs e)
        {
            cboStatus.SelectedIndex = 0; // Hoạt động

            dtpJoinDate.Value = DateTime.Today;
            dtpExpiryDate.Value = DateTime.Today.AddYears(1); // Mặc định 1 năm từ hôm nay

            txtSearch.KeyDown += txtSearch_KeyDown;
            dgvMembers.DoubleClick += dgvMembers_DoubleClick;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Tạo mới")
            {
                isAddNew = true;
                ClearFields();
                SetControlState(true);
                txtName.Focus();
            }
            else
            {
                SaveMember();
            }
        }
        private void SaveMember()
        {
            try
            {
                if (!ValidateMemberData())
                    return;

                if (isAddNew)
                {
                    Member newMember = new Member
                    {
                        Name = txtName.Text.Trim(),
                        Phone = txtPhone.Text.Trim(),
                        Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim(),
                        Address = string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text.Trim(),
                        JoinDate = dtpJoinDate.Value.Date,
                        Status = cboStatus.SelectedIndex == 0 // true if "Hoạt động"
                    };

                    context.Members.Add(newMember);
                    context.SaveChanges();

                    MessageBox.Show("Thêm thành viên mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    currentMember.Name = txtName.Text.Trim();
                    currentMember.Phone = txtPhone.Text.Trim();
                    currentMember.Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();
                    currentMember.Address = string.IsNullOrWhiteSpace(txtAddress.Text) ? null : txtAddress.Text.Trim();
                    currentMember.JoinDate = dtpJoinDate.Value.Date;
                    currentMember.Status = cboStatus.SelectedIndex == 0; // true if "Hoạt động"

                    context.Update(currentMember);
                    context.SaveChanges();

                    MessageBox.Show("Cập nhật thành viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Reset UI
                isAddNew = false;
                LoadMemberData();
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
            if (currentMember == null)
            {
                MessageBox.Show("Vui lòng chọn thành viên để cập nhật", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            isAddNew = false;
            SetControlState(true);
            txtName.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currentMember == null)
            {
                MessageBox.Show("Vui lòng chọn thành viên để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa thành viên '{currentMember.Name}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    // Check if member has any borrow records
                    bool hasBorrowRecords = context.BorrowRecords.Any(br => br.MemberId == currentMember.MemberId);

                    if (hasBorrowRecords)
                    {
                        MessageBox.Show("Không thể xóa thành viên này vì có lịch sử mượn sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    context.Members.Remove(currentMember);
                    context.SaveChanges();

                    MessageBox.Show("Xóa thành viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadMemberData();
                    ClearFields();
                    SetControlState(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa thành viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (btnRefresh.Text == "Làm mới")
            {
                ClearFields();
                LoadMemberData();
                SetControlState(false);
                txtSearch.Clear();
            }
            else // Cancel
            {
                isAddNew = false;
                ClearFields();
                SetControlState(false);
                if (dgvMembers.SelectedRows.Count > 0)
                {
                    dgvMembers_SelectionChanged(dgvMembers, EventArgs.Empty);
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadMemberData();
                return;
            }

            try
            {
                var members = context.Members
                    .Where(m =>
                        m.Name.ToLower().Contains(searchTerm) ||
                        m.Phone.Contains(searchTerm) ||
                        (m.Email != null && m.Email.ToLower().Contains(searchTerm)) ||
                        (m.Address != null && m.Address.ToLower().Contains(searchTerm))
                    )
                    .OrderBy(m => m.Name)
                    .Select(m => new
                    {
                        m.MemberId,
                        m.Name,
                        m.Phone,
                        m.Email,
                        m.Address,
                        m.JoinDate,
                        StatusText = m.Status ? "Hoạt động" : "Khóa",
                        m.Status
                    })
                    .ToList();

                memberBindingSource.DataSource = members;
                dgvMembers.DataSource = memberBindingSource;

                if (members.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvMembers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMembers.SelectedRows.Count > 0 && dgvMembers.SelectedRows[0].Cells["MemberId"].Value != null)
            {
                int memberId = (int)dgvMembers.SelectedRows[0].Cells["MemberId"].Value;
                currentMember = context.Members.Find(memberId);

                if (currentMember != null)
                {
                    DisplayMemberData(currentMember);
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

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
                e.SuppressKeyPress = true; // Ngăn tiếng beep
            }
        }

        private void dgvMembers_DoubleClick(object sender, EventArgs e)
        {
            if (dgvMembers.SelectedRows.Count > 0 && dgvMembers.SelectedRows[0].Cells["MemberId"].Value != null)
            {
                int memberId = (int)dgvMembers.SelectedRows[0].Cells["MemberId"].Value;
                ShowMemberDetail(memberId);
            }
        }
        private void ShowMemberDetail(int memberId)
        {
            try
            {
                var member = context.Members
                    .Include(m => m.BorrowRecords)
                    .ThenInclude(br => br.Book)
                    .FirstOrDefault(m => m.MemberId == memberId);

                if (member == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin thành viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo form chi tiết thành viên
                Form frmDetail = new Form();
                frmDetail.Text = "Chi tiết thành viên";
                frmDetail.Size = new Size(600, 600);
                frmDetail.StartPosition = FormStartPosition.CenterParent;
                frmDetail.FormBorderStyle = FormBorderStyle.FixedDialog;
                frmDetail.MaximizeBox = false;
                frmDetail.MinimizeBox = false;

                // Panel chính
                Panel pnlMain = new Panel();
                pnlMain.Dock = DockStyle.Fill;
                pnlMain.Padding = new Padding(15);
                frmDetail.Controls.Add(pnlMain);

                // Thông tin cơ bản
                int yPos = 15;

                // Tên
                Label lblName = new Label();
                lblName.Text = member.Name;
                lblName.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                lblName.ForeColor = Color.FromArgb(210, 121, 106);
                lblName.Location = new Point(15, yPos);
                lblName.Size = new Size(550, 30);
                pnlMain.Controls.Add(lblName);
                yPos += 40;

                // Thông tin liên hệ
                AddDetailLabel(pnlMain, "Số điện thoại:", member.Phone, yPos);
                yPos += 30;

                if (!string.IsNullOrEmpty(member.Email))
                {
                    AddDetailLabel(pnlMain, "Email:", member.Email, yPos);
                    yPos += 30;
                }

                if (!string.IsNullOrEmpty(member.Address))
                {
                    AddDetailLabel(pnlMain, "Địa chỉ:", member.Address, yPos);
                    yPos += 30;
                }

                // Thông tin thẻ
                AddDetailLabel(pnlMain, "Ngày đăng ký:", member.JoinDate.ToString("dd/MM/yyyy"), yPos);
                yPos += 30;

                AddDetailLabel(pnlMain, "Trạng thái:", member.Status ? "Hoạt động" : "Khóa", yPos);
                yPos += 30;

                AddDetailLabel(pnlMain, "Số thẻ:", $"TV{member.MemberId:D6}", yPos);
                yPos += 30;

                // Thống kê mượn sách
                var totalBorrowed = member.BorrowRecords.Count;
                var currentlyBorrowed = member.BorrowRecords.Count(br => br.ReturnDate == null);
                var overdue = member.BorrowRecords.Count(br => br.ReturnDate == null && br.DueDate < DateTime.Today);

                AddDetailLabel(pnlMain, "Tổng số lần mượn:", totalBorrowed.ToString(), yPos);
                yPos += 30;

                AddDetailLabel(pnlMain, "Hiện đang mượn:", currentlyBorrowed.ToString(), yPos);
                yPos += 30;

                AddDetailLabel(pnlMain, "Sách quá hạn:", overdue.ToString(), yPos);
                yPos += 30;

                // Lịch sử mượn gần đây
                if (member.BorrowRecords.Any())
                {
                    Label lblHistory = new Label();
                    lblHistory.Text = "Lịch sử mượn gần đây:";
                    lblHistory.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                    lblHistory.Location = new Point(15, yPos);
                    lblHistory.Size = new Size(550, 20);
                    pnlMain.Controls.Add(lblHistory);
                    yPos += 30;

                    // DataGridView cho lịch sử
                    DataGridView dgvHistory = new DataGridView();
                    dgvHistory.Location = new Point(15, yPos);
                    dgvHistory.Size = new Size(550, 150);
                    dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvHistory.AllowUserToAddRows = false;
                    dgvHistory.AllowUserToDeleteRows = false;
                    dgvHistory.ReadOnly = true;
                    dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvHistory.RowHeadersVisible = false;

                    var historyData = member.BorrowRecords
                        .OrderByDescending(br => br.BorrowDate)
                        .Take(10)
                        .Select(br => new
                        {
                            BookTitle = br.Book.Title,
                            BorrowDate = br.BorrowDate.ToString("dd/MM/yyyy"),
                            DueDate = br.DueDate.ToString("dd/MM/yyyy"),
                            ReturnDate = br.ReturnDate?.ToString("dd/MM/yyyy") ?? "Chưa trả",
                            Status = br.ReturnDate == null ?
                                (br.DueDate < DateTime.Today ? "Quá hạn" : "Đang mượn") : "Đã trả"
                        })
                        .ToList();

                    dgvHistory.DataSource = historyData;
                    dgvHistory.Columns["BookTitle"].HeaderText = "Tên sách";
                    dgvHistory.Columns["BorrowDate"].HeaderText = "Ngày mượn";
                    dgvHistory.Columns["DueDate"].HeaderText = "Hạn trả";
                    dgvHistory.Columns["ReturnDate"].HeaderText = "Ngày trả";
                    dgvHistory.Columns["Status"].HeaderText = "Tình trạng";

                    pnlMain.Controls.Add(dgvHistory);
                    yPos += 160;
                }

                // Nút đóng
                Button btnClose = new Button();
                btnClose.Text = "Đóng";
                btnClose.Size = new Size(100, 35);
                btnClose.Location = new Point(465, yPos);
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
                MessageBox.Show("Lỗi khi hiển thị chi tiết thành viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddDetailLabel(Panel panel, string labelText, string valueText, int yPos)
        {
            Label lblTitle = new Label();
            lblTitle.Text = labelText;
            lblTitle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblTitle.Location = new Point(15, yPos);
            lblTitle.Size = new Size(130, 20);
            panel.Controls.Add(lblTitle);

            Label lblValue = new Label();
            lblValue.Text = valueText;
            lblValue.Font = new Font("Segoe UI", 10);
            lblValue.Location = new Point(150, yPos);
            lblValue.Size = new Size(400, 20);
            panel.Controls.Add(lblValue);
        }


    }
}
