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
    public partial class fMainForm : Form
    {
        private Color primaryColor = ColorTranslator.FromHtml("#E9967A");     // Hồng đào chủ đạo
        private Color primaryDarkColor = ColorTranslator.FromHtml("#D2796A"); // Hồng đào đậm
        private Color primaryLightColor = ColorTranslator.FromHtml("#F5C3B8"); // Hồng đào nhạt
        private Color accentColor = ColorTranslator.FromHtml("#81C3D7");      // Xanh lơ
        private Color backgroundColor = ColorTranslator.FromHtml("#F9F1F0");  // Kem nhạt
        private Color textColor = ColorTranslator.FromHtml("#5E4C4C");        // Nâu đen
        private Color sidebarColor = ColorTranslator.FromHtml("#D2796A");     // Màu sidebar
        private Color headerColor = ColorTranslator.FromHtml("#E9967A");      // Màu header

        // Biến để di chuyển form
        private bool mouseDown;
        private Point lastLocation;

        // Biến lưu trữ Button đang được chọn trong menu sidebar
        private Button currentButton;
        public fMainForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Load += fMainForm_Load;
            pnlHeader.MouseDown += pnlHeader_MouseDown;
            pnlHeader.MouseMove += pnlHeader_MouseMove;
            pnlHeader.MouseUp += pnlHeader_MouseUp;
            btnClose.Click += btnClose_Click;
            btnMinimize.Click += btnMinimize_Click;
        }
        private void MenuButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                ActivateButton(clickedButton);

                // Xử lý các chức năng tương ứng với mỗi nút
                switch (clickedButton.Name)
                {
                    case "btnDashboard":
                        OpenDashboard();
                        break;
                    case "btnBooks":
                        OpenBookManagement();
                        break;
                    case "btnMembers":
                        OpenMemberManagement();
                        break;
                    case "btnBorrow":
                        OpenBorrowReturn();
                        break;
                    case "btnStatistics":
                        OpenStatistics();
                        break;
                    case "btnSettings":
                        OpenSettings();
                        break;
                    case "btnLogout":
                        Logout();
                        break;
                }
            }
        }

        private void MenuButton_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != currentButton)
            {
                // Hiệu ứng gradient khi hover
                btn.BackColor = primaryDarkColor;

                // Thêm thanh bên trái để làm nổi bật
                Panel indicator = new Panel();
                indicator.Name = "pnlIndicator";
                indicator.Size = new Size(3, btn.Height);
                indicator.Location = new Point(0, 0);
                indicator.BackColor = Color.White;

                // Chỉ thêm nếu chưa có
                if (!btn.Controls.ContainsKey("pnlIndicator"))
                    btn.Controls.Add(indicator);
            }
        }

        private void MenuButton_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != currentButton)
            {
                btn.BackColor = sidebarColor;

                // Xóa thanh chỉ báo khi rời chuột
                Control[] indicators = btn.Controls.Find("pnlIndicator", false);
                if (indicators.Length > 0)
                    btn.Controls.Remove(indicators[0]);
            }
        }

        private void ActivateButton(Button button)
        {
            if (currentButton != null)
            {
                // Đặt lại màu nút trước đó
                currentButton.BackColor = sidebarColor;
                currentButton.ForeColor = Color.White;
                currentButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            }

            // Đặt màu nút hiện tại
            button.BackColor = accentColor;
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            currentButton = button;
            lblTitle.Text = button.Text.Trim().Substring(3).ToUpper();
        }


        // Phương thức mở form quản lý sách
        private void OpenBookManagement()
        {
            // Xóa nội dung hiện tại
            pnlContent.Controls.Clear();

            // Tạo instance của form quản lý sách
            fBookManagement bookForm = new fBookManagement();

            // Cấu hình form con
            bookForm.TopLevel = false;
            bookForm.FormBorderStyle = FormBorderStyle.None;
            bookForm.Dock = DockStyle.Fill;

            // Thêm form con vào panel nội dung
            pnlContent.Controls.Add(bookForm);
            bookForm.Show();
        }

        // Phương thức mở form quản lý thành viên
        private void OpenMemberManagement()
        {
            // Xóa nội dung hiện tại
            pnlContent.Controls.Clear();

            // Tạo instance của form quản lý thành viên
            fMemberManagement memberForm = new fMemberManagement();

            // Cấu hình form con
            memberForm.TopLevel = false;
            memberForm.FormBorderStyle = FormBorderStyle.None;
            memberForm.Dock = DockStyle.Fill;

            // Thêm form con vào panel nội dung
            pnlContent.Controls.Add(memberForm);
            memberForm.Show();
        }

        // Phương thức mở form mượn/trả sách
        private void OpenBorrowReturn()
        {
            // Xóa nội dung hiện tại
            pnlContent.Controls.Clear();

            // Tạo instance của form mượn/trả sách
            fBorrowReturn borrowForm = new fBorrowReturn();

            // Cấu hình form con
            borrowForm.TopLevel = false;
            borrowForm.FormBorderStyle = FormBorderStyle.None;
            borrowForm.Dock = DockStyle.Fill;

            // Thêm form con vào panel nội dung
            pnlContent.Controls.Add(borrowForm);
            borrowForm.Show();
        }

        // Phương thức mở form thống kê báo cáo
        private void OpenStatistics()
        {
            // Hiện thực phần này khi bạn có form thống kê
        }

        // Phương thức mở form cài đặt
        private void OpenSettings()
        {
            // Hiện thực phần này khi bạn có form cài đặt
        }

        // Phương thức xử lý đăng xuất
        private void Logout()
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?",
                                                 "Xác nhận đăng xuất",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Đặt lại thông tin người dùng hiện tại
                Utility.CurrentEmployee = null;

                // Mở lại form đăng nhập
                Form loginForm = new fLogin();
                this.Hide();
                loginForm.ShowDialog();
                this.Close();
            }
        }

        //Phương thức mở form con trong panel nội dung
        //private void OpenChildForm(Form childForm)
        //{
        //    pnlContent.Controls.Clear();

        //    // Cấu hình form con
        //    childForm.TopLevel = false;
        //    childForm.FormBorderStyle = FormBorderStyle.None;
        //    childForm.Dock = DockStyle.Fill;
        //    childForm.Opacity = 0; // Bắt đầu với độ trong suốt = 0

        //    // Thêm form con vào panel nội dung
        //    pnlContent.Controls.Add(childForm);
        //    childForm.Show();

        //    // Hiệu ứng fade-in
        //    for (double i = 0; i <= 1; i += 0.1)
        //    {
        //        childForm.Opacity = i;
        //        await Task.Delay(15);
        //    }
        //    childForm.Opacity = 1;
        //}
        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void pnlHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X,
                    (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void pnlHeader_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
        private Button CreateMenuButton(string name, string text, int yPos)
        {
            Button btn = new Button();
            btn.Name = name;
            btn.Text = text;
            btn.Size = new Size(220, 45);
            btn.Location = new Point(5, yPos);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            btn.ForeColor = Color.White;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(10, 0, 0, 0);
            btn.BackColor = sidebarColor;
            btn.Cursor = Cursors.Hand;
            btn.Click += MenuButton_Click;
            btn.MouseEnter += MenuButton_MouseEnter;
            btn.MouseLeave += MenuButton_MouseLeave;

            return btn;
        }

        private void fMainForm_Load(object sender, EventArgs e)
        {
            Button btnDashboard = CreateMenuButton("btnDashboard", "🏠  Trang chính", 170);
            Button btnBooks = CreateMenuButton("btnBooks", "📚  Quản lý sách", 225);
            Button btnMembers = CreateMenuButton("btnMembers", "👥  Quản lý thành viên", 280);
            Button btnBorrow = CreateMenuButton("btnBorrow", "📝  Mượn / Trả sách", 335);
            Button btnStatistics = CreateMenuButton("btnStatistics", "📊  Thống kê báo cáo", 390);
            Button btnSettings = CreateMenuButton("btnSettings", "⚙️  Cài đặt hệ thống", 445);
            Button btnLogout = CreateMenuButton("btnLogout", "🚪  Đăng xuất", 580);

            // Thêm các nút vào sidebar
            pnlSidebar.Controls.Add(btnDashboard);
            pnlSidebar.Controls.Add(btnBooks);
            pnlSidebar.Controls.Add(btnMembers);
            pnlSidebar.Controls.Add(btnBorrow);
            pnlSidebar.Controls.Add(btnStatistics);
            pnlSidebar.Controls.Add(btnSettings);
            pnlSidebar.Controls.Add(btnLogout);

            // Kích hoạt nút Dashboard mặc định
            ActivateButton(btnDashboard);

            // Thiết lập thông tin người dùng
            if (Utility.CurrentEmployee != null)
            {
                lblUserName.Text = Utility.CurrentEmployee.Name;
                lblUserRole.Text = Utility.GetRoleText(Utility.CurrentEmployee.RoleId);
            }
            AddNotificationBadge(btnBorrow, 5);
        }

        private void pnlUserInfo_Paint(object sender, PaintEventArgs e)
        {

        }
        private void OpenDashboard()
        {
            pnlContent.Controls.Clear();

            // Panel chứa các thẻ thống kê
            Panel pnlStats = new Panel();
            pnlStats.Size = new Size(pnlContent.Width - 60, 120);
            pnlStats.Location = new Point(30, 30);
            pnlStats.BackColor = Color.White;
            pnlStats.Paint += (s, e) => DrawPanelBorder(s, e, pnlStats);

            // Tạo 4 thẻ thống kê nhanh
            CreateStatCard(pnlStats, "TỔNG SỐ SÁCH", "1,245", "📚", 0);
            CreateStatCard(pnlStats, "THÀNH VIÊN", "356", "👥", 1);
            CreateStatCard(pnlStats, "ĐANG CHO MƯỢN", "127", "📝", 2);
            CreateStatCard(pnlStats, "QUÁ HẠN", "18", "⏰", 3);

            // Panel hoạt động gần đây
            Panel pnlRecent = new Panel();
            pnlRecent.Size = new Size((pnlContent.Width - 90) / 2, 300);
            pnlRecent.Location = new Point(30, 170);
            pnlRecent.BackColor = Color.White;
            pnlRecent.Paint += (s, e) => DrawPanelBorder(s, e, pnlRecent);

            // Tiêu đề
            Label lblRecentTitle = new Label();
            lblRecentTitle.Text = "Hoạt động gần đây";
            lblRecentTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblRecentTitle.ForeColor = primaryDarkColor;
            lblRecentTitle.Location = new Point(15, 15);
            lblRecentTitle.AutoSize = true;
            pnlRecent.Controls.Add(lblRecentTitle);

            // Danh sách hoạt động
            ListView lvRecent = new ListView();
            lvRecent.View = View.Details;
            lvRecent.Size = new Size(pnlRecent.Width - 30, 230);
            lvRecent.Location = new Point(15, 50);
            lvRecent.BorderStyle = BorderStyle.None;
            lvRecent.FullRowSelect = true;
            lvRecent.Columns.Add("Thời gian", 120);
            lvRecent.Columns.Add("Hoạt động", 250);

            // Thêm dữ liệu mẫu
            string[] times = { "Hôm nay, 10:45", "Hôm nay, 09:30", "Hôm qua, 15:20", "Hôm qua, 11:15", "20/05/2025, 14:30" };
            string[] activities = {
        "Nguyễn Văn A mượn sách 'Lập trình C#'",
        "Trần Thị B trả sách 'Toán cao cấp'",
        "Thêm 5 sách mới vào thư viện",
        "Lê Văn C đăng ký thành viên mới",
        "Phạm Thị D gia hạn mượn sách"
    };

            for (int i = 0; i < times.Length; i++)
            {
                ListViewItem item = new ListViewItem(times[i]);
                item.SubItems.Add(activities[i]);
                lvRecent.Items.Add(item);
            }

            pnlRecent.Controls.Add(lvRecent);

            // Panel sách phổ biến
            Panel pnlPopular = new Panel();
            pnlPopular.Size = new Size((pnlContent.Width - 90) / 2, 300);
            pnlPopular.Location = new Point(pnlRecent.Right + 30, 170);
            pnlPopular.BackColor = Color.White;
            pnlPopular.Paint += (s, e) => DrawPanelBorder(s, e, pnlPopular);

            // Tiêu đề
            Label lblPopularTitle = new Label();
            lblPopularTitle.Text = "Sách phổ biến";
            lblPopularTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblPopularTitle.ForeColor = primaryDarkColor;
            lblPopularTitle.Location = new Point(15, 15);
            lblPopularTitle.AutoSize = true;
            pnlPopular.Controls.Add(lblPopularTitle);

            // Thêm các sách phổ biến dưới dạng ListBox hoặc FlowLayoutPanel

            // Thêm tất cả panel vào panel nội dung
            pnlContent.Controls.Add(pnlStats);
            pnlContent.Controls.Add(pnlRecent);
            pnlContent.Controls.Add(pnlPopular);
        }

        // Hàm vẽ viền bo tròn và đổ bóng cho panel
        private void DrawPanelBorder(object sender, PaintEventArgs e, Panel panel)
        {
            // Vẽ viền và đổ bóng
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Vẽ đường viền bo tròn
            using (GraphicsPath path = new GraphicsPath())
            {
                int radius = 8;
                Rectangle rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);

                path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
                path.AddArc(rect.Width - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90);
                path.AddArc(rect.Width - radius * 2, rect.Height - radius * 2, radius * 2, radius * 2, 0, 90);
                path.AddArc(rect.X, rect.Height - radius * 2, radius * 2, radius * 2, 90, 90);
                path.CloseAllFigures();

                using (Pen pen = new Pen(Color.FromArgb(230, 230, 230), 1))
                {
                    g.DrawPath(pen, path);
                }
            }
        }

        // Hàm tạo thẻ thống kê
        private void CreateStatCard(Panel container, string title, string value, string icon, int position)
        {
            int cardWidth = (container.Width - 50) / 4;
            int cardHeight = container.Height - 20;

            Panel card = new Panel();
            card.Size = new Size(cardWidth, cardHeight);
            card.Location = new Point(10 + position * (cardWidth + 10), 10);
            card.BackColor = Color.White;
            card.Paint += (s, e) =>
            {
                // Vẽ đường viền sáng
                using (Pen pen = new Pen(primaryLightColor, 2))
                {
                    e.Graphics.DrawLine(pen, 0, 0, 0, card.Height);
                }
            };

            // Icon
            Label lblIcon = new Label();
            lblIcon.Text = icon;
            lblIcon.Font = new Font("Segoe UI", 24, FontStyle.Regular);
            lblIcon.AutoSize = true;
            lblIcon.Location = new Point(15, 15);

            // Giá trị
            Label lblValue = new Label();
            lblValue.Text = value;
            lblValue.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            lblValue.ForeColor = primaryDarkColor;
            lblValue.AutoSize = true;
            lblValue.Location = new Point(15, 55);

            // Tiêu đề
            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            lblTitle.ForeColor = Color.Gray;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(15, 90);

            card.Controls.Add(lblIcon);
            card.Controls.Add(lblValue);
            card.Controls.Add(lblTitle);

            container.Controls.Add(card);
        }
        private void ImproveMenuDesign()
        {
            // Thêm đường phân cách giữa mục quản lý và cài đặt
            Panel separator = new Panel();
            separator.BackColor = Color.FromArgb(200, 200, 200, 50); // Màu trắng trong suốt
            separator.Height = 1;
            separator.Width = pnlSidebar.Width - 40;
            separator.Location = new Point(20, 500);
            pnlSidebar.Controls.Add(separator);

            // Thêm icon cho avatar
            using (MemoryStream ms = new MemoryStream(Properties.Resources.eye_closed))
            {
                picAvatar.Image = Image.FromStream(ms);
            }
            // Tạo hiệu ứng bo tròn cho avatar
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, picAvatar.Width, picAvatar.Height);
            picAvatar.Region = new Region(path);

            // Thêm đường viền cho avatar
            picAvatar.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(Color.White, 2))
                {
                    e.Graphics.DrawEllipse(pen, 0, 0, picAvatar.Width - 1, picAvatar.Height - 1);
                }
            };

        }
        private void AddNotificationBadge(Button button, int count)
        {
            if (count <= 0) return;

            // Tạo badge thông báo
            Label badge = new Label();
            badge.Name = "lblBadge";
            badge.Text = count > 9 ? "9+" : count.ToString();
            badge.AutoSize = false;
            badge.Size = new Size(20, 20);
            badge.Location = new Point(button.Width - 25, 5);
            badge.TextAlign = ContentAlignment.MiddleCenter;
            badge.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            badge.ForeColor = Color.White;
            badge.BackColor = Color.Red;

            // Bo tròn badge
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, badge.Width, badge.Height);
            badge.Region = new Region(path);

            // Thêm badge vào nút nếu chưa có
            if (!button.Controls.ContainsKey("lblBadge"))
                button.Controls.Add(badge);
        }

        private void pnlHeader_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
