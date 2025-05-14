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
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
        }

        private void pnlTitleBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập!", "Thông báo",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var context = new LibraryDbContext())
            {
                var employee = context.Employees
                                    .Where(e => e.Email == username && e.Password == password && e.Status == true)
                                    .FirstOrDefault();

                if (employee != null)
                {
                    // Lưu thông tin người dùng hiện tại
                    Utility.CurrentEmployee = employee;

                    // Mở form chính
                    var mainForm = new fMainForm();
                    this.Hide();
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!", "Lỗi đăng nhập",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private bool mouseDown;
        private Point lastLocation;
        private void pnlTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void pnlTitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X,
                    (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void pnlTitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }
        private Color primaryColor = ColorTranslator.FromHtml("#E9967A");
        private Color primaryDarkColor = ColorTranslator.FromHtml("#D2796A");
        private Color accentColor = ColorTranslator.FromHtml("#81C3D7");
        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(201, 105, 87); // Tối hơn một chút
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = primaryDarkColor;
        }
        private void btnExit_MouseEnter(object sender, EventArgs e)
        {
            btnExit.BackColor = Color.FromArgb(107, 167, 184); // Tối hơn
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            btnExit.BackColor = accentColor;
        }

        private void fLogin_Load(object sender, EventArgs e)
        {
            // Bo tròn các nút
            ApplyRoundedCorners(btnLogin, 8);
            ApplyRoundedCorners(btnExit, 8);
            txtPassword.PasswordChar = '•';
            AdjustEyeIconPosition();
            using (MemoryStream ms = new MemoryStream(Properties.Resources.eye_closed))
            {
                picShowPassword.Image = Image.FromStream(ms);
            }
        }
        private void AdjustEyeIconPosition()
        {
            // Đặt vị trí icon sát bên phải của ô mật khẩu và căn giữa theo chiều cao
            picShowPassword.Location = new Point(
                txtPassword.Right + 5,
                txtPassword.Top + (txtPassword.Height - picShowPassword.Height) / 2
            );
        }

        private void ApplyRoundedCorners(Control control, int radius)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(control.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(control.Width - radius, control.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, control.Height - radius, radius, radius, 90, 90);
            control.Region = new Region(path);
        }

        private void picShowPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '\0')
            {
                // Nếu đang hiển thị mật khẩu, chuyển sang ẩn mật khẩu
                txtPassword.PasswordChar = '•';
                using (MemoryStream ms = new MemoryStream(Properties.Resources.eye_closed))
                {
                    picShowPassword.Image = Image.FromStream(ms);
                }
            }
            else
            {
                // Nếu đang ẩn mật khẩu, chuyển sang hiển thị mật khẩu
                txtPassword.PasswordChar = '\0';
                using (MemoryStream ms = new MemoryStream(Properties.Resources.eye_open))
                {
                    picShowPassword.Image = Image.FromStream(ms);
                }
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
    }
}
