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
    public partial class fEmployeeManagement : Form
    {
        private LibraryDbContext context;
        private Employee currentEmployee = null;
        private bool isAddNew = false; //Kiểm tra thêm mới
        private BindingSource employeeBindingSource = new BindingSource(); // Nguồn dữ liệu cho DataGridView

        public fEmployeeManagement()
        {
            InitializeComponent();
            context = new LibraryDbContext(); //Tạo database context
            ApplyFormStyle(); //Thiết lập kiểu cho form
            LoadEmployeeData(); //Tải dữ liệu nhân viên
            SetControlState(false); //Thiết lập trạng thái điều khiển
        }
        private void ApplyFormStyle()
        {
            // Áp dụng bo góc cho các buttons
            ApplyRoundedCorners(btnAdd, 8);
            ApplyRoundedCorners(btnUpdate, 8);
            ApplyRoundedCorners(btnDelete, 8);
            ApplyRoundedCorners(btnRefresh, 8);
            ApplyRoundedCorners(btnSearch, 8);
            ApplyRoundedCorners(btnChangePassword, 8);
            ApplyRoundedCorners(btnResetPassword, 8);
            // Thiết lập hover effects cho buttons
            SetupButtonHoverEffects();

            // Thêm shadow cho panels
            AddShadow(pnlEmployeeInfo);
            AddShadow(pnlSearch);
            AddShadow(pnlDataGrid);
        }
        private void ApplyRoundedCorners(Control control, int radius)
        {
            // Tạo path bo góc
            Rectangle rect = new Rectangle(0, 0, control.Width, control.Height);
            GraphicsPath path = new GraphicsPath();

            // Vẽ 4 góc bo tròn
            path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);                          // Góc trên trái
            path.AddArc(rect.Width - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90);         // Góc trên phải
            path.AddArc(rect.Width - radius * 2, rect.Height - radius * 2, radius * 2, radius * 2, 0, 90);  // Góc dưới phải
            path.AddArc(rect.X, rect.Height - radius * 2, radius * 2, radius * 2, 90, 90);         // Góc dưới trái
            path.CloseAllFigures();

            // Áp dụng region cho control
            control.Region = new Region(path);
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
                    // Tạo hình bo góc giống như trên
                    path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
                    path.AddArc(rect.Width - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90);
                    path.AddArc(rect.Width - radius * 2, rect.Height - radius * 2, radius * 2, radius * 2, 0, 90);
                    path.AddArc(rect.X, rect.Height - radius * 2, radius * 2, radius * 2, 90, 90);
                    path.CloseAllFigures();

                    // Áp dụng region và vẽ shadow
                    panel.Region = new Region(path);
                    using (Pen pen = new Pen(Color.FromArgb(30, 0, 0, 0), 1))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            };

        }
        private void SetupButtonHoverEffects()
        {
            // Danh sách các buttons cần áp dụng hover effect
            Button[] buttons = { btnAdd, btnUpdate, btnDelete, btnRefresh, btnSearch, btnChangePassword, btnResetPassword };

            foreach (Button btn in buttons)
            {
                btn.MouseEnter += Button_MouseEnter;
                btn.MouseLeave += Button_MouseLeave;
            }
        }
        private void Button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                if (btn == btnAdd || btn == btnUpdate || btn == btnChangePassword)
                    btn.BackColor = Color.FromArgb(190, 101, 86);       // Màu đậm hơn của primary
                else if (btn == btnDelete)
                    btn.BackColor = Color.FromArgb(172, 0, 0);          // Màu đậm hơn của đỏ
                else if (btn == btnResetPassword)
                    btn.BackColor = Color.FromArgb(200, 60, 40);        // Màu đậm hơn
                else if (btn == btnRefresh || btn == btnSearch)
                    btn.BackColor = Color.FromArgb(109, 175, 195);      // Màu đậm hơn của xanh
            }
        }
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                // Trở về màu gốc
                if (btn == btnAdd || btn == btnUpdate || btn == btnChangePassword)
                    btn.BackColor = Color.FromArgb(210, 121, 106);
                else if (btn == btnDelete)
                    btn.BackColor = Color.FromArgb(192, 0, 0);
                else if (btn == btnResetPassword)
                    btn.BackColor = Color.FromArgb(231, 76, 60);
                else if (btn == btnRefresh || btn == btnSearch)
                    btn.BackColor = Color.FromArgb(129, 195, 215);
            }
        }
        private void LoadEmployeeData()
        {
            try
            {
                //Truy vẫn dữ liệu từ database
                var employees = context.Employees.OrderBy(e => e.Name).Select(e => new
                {
                    e.EmployeeId,
                    e.Name,
                    e.Email,
                    RoleText = Utility.GetRoleText(e.RoleId),
                    e.RoleId,
                    StatusText = e.Status ? "Hoạt động" : "Tạm khóa", //Convert status thành text
                    e.Status
                })
                .ToList();
                employeeBindingSource.DataSource = employees; //Gán dữ liệu cho BindingSource
                dgvEmployees.DataSource = employeeBindingSource; //Gán BindingSource cho DataGridView
                //Format DataGridView
                FormatDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FormatDataGridView()
        {
            // Đặt tên tiêu đề cột
            dgvEmployees.Columns["EmployeeId"].HeaderText = "Mã NV";
            dgvEmployees.Columns["Name"].HeaderText = "Họ và tên";
            dgvEmployees.Columns["Email"].HeaderText = "Email";
            dgvEmployees.Columns["RoleText"].HeaderText = "Vai trò";
            dgvEmployees.Columns["StatusText"].HeaderText = "Trạng thái";

            // Ẩn các cột không cần thiết
            dgvEmployees.Columns["RoleId"].Visible = false;
            dgvEmployees.Columns["Status"].Visible = false;

            // Đặt độ rộng cột
            dgvEmployees.Columns["EmployeeId"].Width = 80;
            dgvEmployees.Columns["Name"].Width = 200;
            dgvEmployees.Columns["Email"].Width = 250;
            dgvEmployees.Columns["RoleText"].Width = 150;
            dgvEmployees.Columns["StatusText"].Width = 100;

            // Styling DataGridView
            dgvEmployees.ForeColor = Color.FromArgb(64, 64, 64);
            dgvEmployees.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);

            // Style cho header
            dgvEmployees.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvEmployees.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(210, 121, 106);
            dgvEmployees.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEmployees.EnableHeadersVisualStyles = false;

            // Style cho rows
            dgvEmployees.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 245, 245);
            dgvEmployees.DefaultCellStyle.BackColor = Color.White;
            dgvEmployees.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 121, 106);
            dgvEmployees.DefaultCellStyle.SelectionForeColor = Color.White;

            // Thiết lập khác
            dgvEmployees.RowTemplate.Height = 28;
            dgvEmployees.GridColor = Color.FromArgb(224, 224, 224);
            dgvEmployees.BorderStyle = BorderStyle.None;
            dgvEmployees.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        }

        //Xóa dữ liệu trên form
        private void ClearForm()
        {
            txtEmployeeId.Text = string.Empty;
            txtName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cboRole.SelectedIndex = 2; //Mặc định "Nhân viên"
            cboStatus.SelectedIndex = 0; //Mặc định là hoạt động
            txtPassword.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            chkRequirePasswordChange.Checked = false;
            currentEmployee = null; //Đặt lại nhân viên hiện tại
        }
        private void SetControlState(bool isEditing)
        {
            // Enable/Disable controls dựa trên trạng thái editing
            txtName.Enabled = isEditing;
            txtEmail.Enabled = isEditing;
            cboRole.Enabled = isEditing;
            cboStatus.Enabled = isEditing;
            txtPassword.Enabled = isEditing;
            txtConfirmPassword.Enabled = isEditing;
            chkRequirePasswordChange.Enabled = isEditing;

            // Thay đổi text của buttons dựa trên trạng thái
            btnAdd.Text = isEditing && isAddNew ? "Lưu" : "Tạo mới";
            btnUpdate.Enabled = !isEditing && currentEmployee != null;
            btnDelete.Enabled = !isEditing && currentEmployee != null;
            btnRefresh.Text = isEditing ? "Hủy" : "Làm mới";

            // Enable/Disable các buttons khác
            btnChangePassword.Enabled = !isEditing && currentEmployee != null;
            btnResetPassword.Enabled = !isEditing && currentEmployee != null;

            // Enable/Disable search và DataGridView
            txtSearch.Enabled = !isEditing;
            btnSearch.Enabled = !isEditing;
            dgvEmployees.Enabled = !isEditing;
        }
        private void DisplayEmployeeData(Employee employee)
        {
            if (employee != null)
            {
                txtEmployeeId.Text = employee.EmployeeId.ToString();
                txtName.Text = employee.Name;
                txtEmail.Text = employee.Email;
                cboRole.SelectedIndex = employee.RoleId - 1;  // RoleId bắt đầu từ 1
                cboStatus.SelectedIndex = employee.Status ? 0 : 1;

                // Không hiển thị mật khẩu vì lý do bảo mật
                txtPassword.Text = string.Empty;
                txtConfirmPassword.Text = string.Empty;
                chkRequirePasswordChange.Checked = false;
            }
        }
        private bool ValidateEmployeeData()
        {
            // Kiểm tra họ tên
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            // Kiểm tra email
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập email", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // Validate format email
            try
            {
                var email = new System.Net.Mail.MailAddress(txtEmail.Text);
            }
            catch
            {
                MessageBox.Show("Email không hợp lệ", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            // Kiểm tra mật khẩu cho nhân viên mới
            if (isAddNew)
            {
                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return false;
                }

                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Mật khẩu xác nhận không khớp", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtConfirmPassword.Focus();
                    return false;
                }

                if (txtPassword.Text.Length < 6)
                {
                    MessageBox.Show("Mật khẩu phải có ít nhất 6 ký tự", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Focus();
                    return false;
                }
            }

            // Kiểm tra email đã tồn tại chưa
            if (isAddNew || (currentEmployee != null && currentEmployee.Email != txtEmail.Text))
            {
                var existingEmployee = context.Employees.FirstOrDefault(e => e.Email == txtEmail.Text);
                if (existingEmployee != null)
                {
                    MessageBox.Show("Email này đã được sử dụng", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmail.Focus();
                    return false;
                }
            }

            return true;
        }

        private void fEmployeeManagement_Load(object sender, EventArgs e)
        {
            // Thiết lập giá trị mặc định
            cboRole.SelectedIndex = 2;      // "Nhân viên"
            cboStatus.SelectedIndex = 0;    // "Hoạt động"

            
            txtSearch.KeyDown += txtSearch_KeyDown; // Sự kiện nhấn phím
            dgvEmployees.DoubleClick += dgvEmployees_DoubleClick; // Sự kiện nháy đúp
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (currentEmployee == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên để đổi mật khẩu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowChangePasswordDialog();
        }
        private void ShowChangePasswordDialog()
        {
            // Tạo form đổi mật khẩu
            Form changePasswordForm = new Form();
            changePasswordForm.Text = "Đổi mật khẩu - " + currentEmployee.Name;
            changePasswordForm.Size = new Size(400, 250);
            changePasswordForm.StartPosition = FormStartPosition.CenterParent;
            changePasswordForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            changePasswordForm.MaximizeBox = false;
            changePasswordForm.MinimizeBox = false;

            Panel pnlMain = new Panel();
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Padding = new Padding(15);
            changePasswordForm.Controls.Add(pnlMain);

            // Current password
            Label lblCurrentPassword = new Label();
            lblCurrentPassword.Text = "Mật khẩu hiện tại:";
            lblCurrentPassword.Location = new Point(15, 15);
            lblCurrentPassword.Size = new Size(120, 20);
            pnlMain.Controls.Add(lblCurrentPassword);

            TextBox txtCurrentPassword = new TextBox();
            txtCurrentPassword.Location = new Point(145, 15);
            txtCurrentPassword.Size = new Size(200, 25);
            txtCurrentPassword.PasswordChar = '*';
            pnlMain.Controls.Add(txtCurrentPassword);

            // New password
            Label lblNewPassword = new Label();
            lblNewPassword.Text = "Mật khẩu mới:";
            lblNewPassword.Location = new Point(15, 55);
            lblNewPassword.Size = new Size(120, 20);
            pnlMain.Controls.Add(lblNewPassword);

            TextBox txtNewPassword = new TextBox();
            txtNewPassword.Location = new Point(145, 55);
            txtNewPassword.Size = new Size(200, 25);
            txtNewPassword.PasswordChar = '*';
            pnlMain.Controls.Add(txtNewPassword);

            // Confirm new password
            Label lblConfirmNewPassword = new Label();
            lblConfirmNewPassword.Text = "Xác nhận MK mới:";
            lblConfirmNewPassword.Location = new Point(15, 95);
            lblConfirmNewPassword.Size = new Size(120, 20);
            pnlMain.Controls.Add(lblConfirmNewPassword);

            TextBox txtConfirmNewPassword = new TextBox();
            txtConfirmNewPassword.Location = new Point(145, 95);
            txtConfirmNewPassword.Size = new Size(200, 25);
            txtConfirmNewPassword.PasswordChar = '*';
            pnlMain.Controls.Add(txtConfirmNewPassword);

            // Buttons
            Button btnSave = new Button();
            btnSave.Text = "Lưu";
            btnSave.Size = new Size(100, 35);
            btnSave.Location = new Point(145, 140);
            btnSave.BackColor = Color.FromArgb(210, 121, 106);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += (s, e) => {
                // Validate và lưu mật khẩu mới
                if (txtCurrentPassword.Text != currentEmployee.Password)
                {
                    MessageBox.Show("Mật khẩu hiện tại không đúng", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtNewPassword.Text) || txtNewPassword.Text.Length < 6)
                {
                    MessageBox.Show("Mật khẩu mới phải có ít nhất 6 ký tự", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (txtNewPassword.Text != txtConfirmNewPassword.Text)
                {
                    MessageBox.Show("Mật khẩu xác nhận không khớp", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try
                {
                    currentEmployee.Password = txtNewPassword.Text; // Trong production, hash password
                    context.Update(currentEmployee);
                    context.SaveChanges();

                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    changePasswordForm.DialogResult = DialogResult.OK;
                    changePasswordForm.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi đổi mật khẩu: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            pnlMain.Controls.Add(btnSave);

            Button btnCancel = new Button();
            btnCancel.Text = "Hủy";
            btnCancel.Size = new Size(100, 35);
            btnCancel.Location = new Point(255, 140);
            btnCancel.BackColor = Color.FromArgb(129, 195, 215);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => changePasswordForm.Close();
            pnlMain.Controls.Add(btnCancel);

            changePasswordForm.ShowDialog();
        }
        private void SaveEmployee()
        {
            try
            {
                if(!ValidateEmployeeData())
                    return;
                if (isAddNew)
                {
                    //Tạo nhân viên mới
                    Employee newEmployee = new Employee
                    {
                        Name = txtName.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        Password = txtPassword.Text, //Trong production, cần hash mật khẩu
                        RoleId = cboRole.SelectedIndex + 1, // RoleId bắt đầu từ 1
                        Status = cboStatus.SelectedIndex == 0 // Hoạt động
                    };
                    context.Employees.Add(newEmployee);
                    context.SaveChanges();
                    MessageBox.Show("Thêm nhân viên thành công", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    currentEmployee.Name = txtName.Text.Trim();
                    currentEmployee.Email = txtEmail.Text.Trim();
                    currentEmployee.RoleId = cboRole.SelectedIndex + 1; // RoleId bắt đầu từ 1
                    currentEmployee.Status = cboStatus.SelectedIndex == 0; // Hoạt động

                    context.Update(currentEmployee);
                    context.SaveChanges();

                    MessageBox.Show("Cập nhật thông tin nhân viên thành công", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                // Tải lại dữ liệu
                isAddNew = false;
                LoadEmployeeData();
                ClearForm();
                SetControlState(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu thông tin nhân viên: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (currentEmployee == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên để reset mật khẩu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn reset mật khẩu cho '{currentEmployee.Name}'?\nMật khẩu mới sẽ là: 123456",
                "Xác nhận reset mật khẩu",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    currentEmployee.Password = "123456"; // Trong production, hash password
                    context.Update(currentEmployee);
                    context.SaveChanges();

                    MessageBox.Show("Reset mật khẩu thành công!\nMật khẩu mới: 123456", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi reset mật khẩu: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (context != null)
            {
                context.Dispose();  // Giải phóng database context
            }
        }
        private void ShowEmployeeDetail(int employeeId)
        {
            try
            {
                var employee = context.Employees
                    .Include(e => e.InventoryChecks)
                    .Include(e => e.ReportedLostBooks)
                    .FirstOrDefault(e => e.EmployeeId == employeeId);

                if (employee == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin nhân viên!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Tạo form chi tiết nhân viên
                Form frmDetail = new Form();
                frmDetail.Text = "Chi tiết nhân viên";
                frmDetail.Size = new Size(600, 500);
                frmDetail.StartPosition = FormStartPosition.CenterParent;
                frmDetail.FormBorderStyle = FormBorderStyle.FixedDialog;
                frmDetail.MaximizeBox = false;
                frmDetail.MinimizeBox = false;

                // Thêm các controls hiển thị thông tin chi tiết
                // (Chi tiết implementation có thể tham khảo từ ShowMemberDetail trong fMemberManagement)

                frmDetail.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị chi tiết nhân viên: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadEmployeeData(); // Nếu không có từ khóa tìm kiếm, tải lại tất cả dữ liệu
                return;
            }
            try 
            {
                var employees = context.Employees.Where(e =>
                e.Name.ToLower().Contains(searchTerm) ||
                e.Email.ToLower().Contains(searchTerm)
                )
                .OrderBy(e => e.Name)
                .Select(e => new
                {
                    e.EmployeeId,
                    e.Name,
                    e.Email,
                    RoleText = Utility.GetRoleText(e.RoleId),
                    e.RoleId,
                    StatusText = e.Status ? "Hoạt động" : "Tạm khóa", //Convert status thành text
                    e.Status
                })
                .ToList();
                employeeBindingSource.DataSource = employees; //Gán dữ liệu cho BindingSource
                dgvEmployees.DataSource = employeeBindingSource; //Gán BindingSource cho DataGridView
                if (employees.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy nhân viên nào với từ khóa tìm kiếm", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } 
            catch (Exception ex) 
            {
               MessageBox.Show("Lỗi khi tìm kiếm nhân viên: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Tạo mới")
            {
                // Chuyển sang chế độ thêm mới
                isAddNew = true;
                ClearForm();
                SetControlState(true);
                txtName.Focus();                // Focus vào textbox đầu tiên
            }
            else
            {
                // Lưu dữ liệu
                SaveEmployee();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(currentEmployee != null)
            {
                MessageBox.Show("Chọn nhân viên để chỉnh sửa", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //Kiểm tra quyền sửa admin account
            if(currentEmployee.RoleId == 1 && Utility.CurrentEmployee.RoleId != 1)
            {
                MessageBox.Show("Bạn không có quyền sửa tài khoản admin", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            isAddNew = false;
            SetControlState(true);
            txtName.Focus(); //Focus vào textbox đầu tiên
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currentEmployee == null) {
            MessageBox.Show("Vui lòng chọn nhân viên để xóa","Thông Báo",
                MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                return;
            }
            //Không cho phép xóa admin account
            if (currentEmployee.RoleId == 1)
            {
                MessageBox.Show("Không thể xóa tài khoản quản trị viên","Thông Báo",
                    MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            //Không che phép xóa tài khoản chính mình
            if(currentEmployee.EmployeeId == Utility.CurrentEmployee.EmployeeId)
            {
                MessageBox.Show("Không thê xóa tài khoản của bạn", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên '{currentEmployee.Name}'?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                try
                {
                    bool hasActivities = context.InventoryChecks.Any(ic => ic.EmployeeId == currentEmployee.EmployeeId) ||
                                         context.LostBooks.Any(lb => lb.EmployeeId == currentEmployee.EmployeeId);
                    if (hasActivities)
                    {
                        MessageBox.Show("Không thể xóa nhân viên này vì đã có hoạt động liên quan", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    context.Employees.Remove(currentEmployee);
                    context.SaveChanges();
                    MessageBox.Show("Xóa nhân viên thành công", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadEmployeeData();
                    ClearForm();
                    SetControlState(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa nhân viên: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if(btnRefresh.Text == "Làm mới")
            {
                // Làm mới dữ liệu
                LoadEmployeeData();
                ClearForm();
                SetControlState(false);
                txtSearch.Clear();
            }
            else
            {
                // Hủy thao tác
                isAddNew = false;
                SetControlState(false);
                ClearForm();
                if(dgvEmployees.SelectedRows.Count > 0)
                {
                    dgvEmployees_SelectionChanged(dgvEmployees,EventArgs.Empty); //Bỏ chọn hàng hiện tại
                }
            }
        }

        private void dgvEmployees_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows.Count > 0 && dgvEmployees.SelectedRows[0].Cells["EmployeeId"].Value != null)
            {
                //Lấy nhân viên được chọn
                int employeeId = (int)dgvEmployees.SelectedRows[0].Cells["EmployeeId"].Value;
                currentEmployee = context.Employees.Find(employeeId);

                if (currentEmployee != null)
                { 
                    DisplayEmployeeData(currentEmployee);
                    btnUpdate.Enabled = true;
                    btnDelete.Enabled = true;
                    btnChangePassword.Enabled = true;
                    btnResetPassword.Enabled = true;
                }
            }
        }

        private void dgvEmployees_DoubleClick(object sender, EventArgs e)
        {

        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
                e.SuppressKeyPress = true; //Ngăn chặn âm thanh "ding" khi nhấn Enter

            }
        }
    }
}
