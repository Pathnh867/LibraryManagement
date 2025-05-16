#nullable disable
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
    public partial class fDashboard : Form
    {
        private LibraryDbContext context;
        private System.Windows.Forms.Timer refreshTimer;

        // Colors for consistency with other forms
        private Color primaryColor = Color.FromArgb(210, 121, 106);
        private Color accentColor = Color.FromArgb(129, 195, 215);
        private Color backgroundColor = Color.FromArgb(249, 241, 240);
        private Color cardBackColor = Color.White;

        public fDashboard()
        {
            InitializeComponent();
            context = new LibraryDbContext();
            refreshTimer = new System.Windows.Forms.Timer(); // Initialize here
            InitializeDashboard();
        }

        private void InitializeDashboard()
        {
            // Apply styling first
            ApplyFormStyling();

            // Load data
            LoadStatistics();
            LoadRecentActivities();
            LoadPopularBooks();
            SetupChart();

            // Setup auto-refresh timer (5 minutes)
            refreshTimer.Interval = 300000; // 5 minutes
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();

            // Wire up events
            btnRefreshActivities.Click += BtnRefreshActivities_Click;
            btnViewReports.Click += BtnViewReports_Click;
            btnExportReport.Click += BtnExportReport_Click;
            dgvRecentActivities.CellDoubleClick += DgvRecentActivities_CellDoubleClick;
            this.Load += FDashboard_Load;
        }

        #region Styling Methods

        private void ApplyFormStyling()
        {
            // Apply rounded corners to panels
            ApplyRoundedCorners(pnlTotalBooks);
            ApplyRoundedCorners(pnlTotalMembers);
            ApplyRoundedCorners(pnlCurrentBorrows);
            ApplyRoundedCorners(pnlOverdue);
            ApplyRoundedCorners(pnlRecentActivities);
            ApplyRoundedCorners(pnlPopularBooks);
            ApplyRoundedCorners(pnlCharts);

            // Style statistic cards with accent borders
            StyleStatisticCard(pnlTotalBooks, primaryColor);
            StyleStatisticCard(pnlTotalMembers, Color.FromArgb(52, 152, 219));
            StyleStatisticCard(pnlCurrentBorrows, Color.FromArgb(46, 204, 113));
            StyleStatisticCard(pnlOverdue, Color.FromArgb(231, 76, 60));

            // Style buttons
            ApplyButtonStyling(btnRefreshActivities, accentColor);
            ApplyButtonStyling(btnViewReports, Color.FromArgb(231, 76, 60));
            ApplyButtonStyling(btnExportReport, accentColor);

            // Style DataGridView and ListView
            StyleDataGridView(dgvRecentActivities);
            StyleListView(lvPopularBooks);
        }

        private void ApplyRoundedCorners(Panel panel)
        {
            panel.Paint += (s, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                using (GraphicsPath path = CreateRoundedRectanglePath(panel.ClientRectangle, 10))
                {
                    panel.Region = new Region(path);

                    // Draw subtle shadow
                    using (Pen shadowPen = new Pen(Color.FromArgb(20, 0, 0, 0), 1))
                    {
                        Rectangle shadowRect = panel.ClientRectangle;
                        shadowRect.Offset(2, 2);
                        using (GraphicsPath shadowPath = CreateRoundedRectanglePath(shadowRect, 10))
                        {
                            g.DrawPath(shadowPen, shadowPath);
                        }
                    }
                }
            };
        }

        private GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
            path.AddArc(rect.Right - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90);
            path.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseAllFigures();
            return path;
        }

        private void StyleStatisticCard(Panel card, Color accentColor)
        {
            card.BackColor = cardBackColor;
            card.Paint += (s, e) =>
            {
                // Draw left accent border
                using (Brush brush = new SolidBrush(accentColor))
                {
                    e.Graphics.FillRectangle(brush, 0, 0, 4, card.Height);
                }
            };
        }

        private void ApplyButtonStyling(Button button, Color color)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = color;
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;

            // Apply rounded corners
            button.Paint += (s, e) =>
            {
                using (GraphicsPath path = CreateRoundedRectanglePath(button.ClientRectangle, 8))
                {
                    button.Region = new Region(path);
                }
            };

            // Hover effects
            Color originalColor = color;
            Color hoverColor = ControlPaint.Dark(color, 0.1f);
            button.MouseEnter += (s, e) => button.BackColor = hoverColor;
            button.MouseLeave += (s, e) => button.BackColor = originalColor;
        }

        private void StyleDataGridView(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = cardBackColor;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;

            // Header styling
            dgv.ColumnHeadersDefaultCellStyle.BackColor = primaryColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // Row styling
            dgv.DefaultCellStyle.BackColor = cardBackColor;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 121, 106, 50);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(64, 64, 64);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 245, 245);

            dgv.RowTemplate.Height = 30;
            dgv.GridColor = Color.FromArgb(224, 224, 224);

            // Allow column resizing
            dgv.AllowUserToResizeColumns = true;
            dgv.AllowUserToResizeRows = false;
        }

        private void StyleListView(ListView lv)
        {
            lv.BackColor = cardBackColor;
            lv.ForeColor = Color.FromArgb(64, 64, 64);
            lv.Font = new Font("Segoe UI", 9F);
        }

        #endregion

        #region Data Loading Methods

        private void LoadStatistics()
        {
            try
            {
                // Total books
                int totalBooks = context.Books.Count();
                lblBooksValue.Text = totalBooks.ToString("N0");

                // Total active members
                int totalMembers = context.Members.Count(m => m.Status);
                lblMembersValue.Text = totalMembers.ToString("N0");

                // Currently borrowed books
                int currentBorrows = context.BorrowRecords.Count(br => br.ReturnDate == null);
                lblBorrowsValue.Text = currentBorrows.ToString("N0");

                // Overdue books
                int overdueBooks = context.BorrowRecords.Count(br =>
                    br.ReturnDate == null && br.DueDate < DateTime.Today);
                lblOverdueValue.Text = overdueBooks.ToString("N0");

                // Update colors based on overdue count
                if (overdueBooks > 0)
                {
                    lblOverdueValue.ForeColor = Color.FromArgb(231, 76, 60);
                }
                else
                {
                    lblOverdueValue.ForeColor = Color.FromArgb(46, 204, 113);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thống kê: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRecentActivities()
        {
            try
            {
                var activities = new List<dynamic>();

                // Get recent borrows (last 30 days)
                var recentBorrows = context.BorrowRecords
                    .Include(br => br.Book)
                    .Include(br => br.Member)
                    .Where(br => br.BorrowDate >= DateTime.Today.AddDays(-30))
                    .OrderByDescending(br => br.BorrowDate)
                    .Take(10)
                    .ToList();

                foreach (var borrow in recentBorrows)
                {
                    activities.Add(new
                    {
                        Thời_gian = borrow.BorrowDate.ToString("dd/MM HH:mm"),
                        Hoạt_động = $"{borrow.Member.Name} mượn sách '{borrow.Book.Title}'"
                    });
                }

                // Get recent returns (last 30 days)
                var recentReturns = context.BorrowRecords
                    .Include(br => br.Book)
                    .Include(br => br.Member)
                    .Where(br => br.ReturnDate != null && br.ReturnDate >= DateTime.Today.AddDays(-30))
                    .OrderByDescending(br => br.ReturnDate)
                    .Take(5)
                    .ToList();

                foreach (var returnRecord in recentReturns)
                {
                    activities.Add(new
                    {
                        Thời_gian = returnRecord.ReturnDate.Value.ToString("dd/MM HH:mm"),
                        Hoạt_động = $"{returnRecord.Member.Name} trả sách '{returnRecord.Book.Title}'"
                    });
                }

                // Get new members (last 7 days)
                var newMembers = context.Members
                    .Where(m => m.JoinDate >= DateTime.Today.AddDays(-7))
                    .OrderByDescending(m => m.JoinDate)
                    .Take(5)
                    .ToList();

                foreach (var member in newMembers)
                {
                    activities.Add(new
                    {
                        Thời_gian = member.JoinDate.ToString("dd/MM"),
                        Hoạt_động = $"{member.Name} đăng ký thành viên mới"
                    });
                }

                // Sort by time and take top 15
                var sortedActivities = activities
                    .OrderByDescending(a => a.Thời_gian)
                    .Take(15)
                    .ToList();

                dgvRecentActivities.DataSource = sortedActivities;

                // Configure columns after binding data
                if (dgvRecentActivities.Columns.Count >= 2)
                {
                    dgvRecentActivities.Columns[0].HeaderText = "Thời gian";
                    dgvRecentActivities.Columns[1].HeaderText = "Hoạt động";
                    dgvRecentActivities.Columns[0].Width = 100;
                    dgvRecentActivities.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải hoạt động gần đây: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPopularBooks()
        {
            try
            {
                var popularBooks = context.BorrowRecords
                    .Include(br => br.Book)
                    .ThenInclude(b => b.Author)
                    .GroupBy(br => br.BookId)
                    .Select(g => new
                    {
                        BookTitle = g.First().Book.Title,
                        AuthorName = g.First().Book.Author.Name,
                        BorrowCount = g.Count(),
                        AvailableCopies = g.First().Book.AvailableCopies
                    })
                    .OrderByDescending(x => x.BorrowCount)
                    .Take(10)
                    .ToList();

                lvPopularBooks.Items.Clear();
                lvPopularBooks.View = View.Details;
                lvPopularBooks.Columns.Clear();
                lvPopularBooks.Columns.Add("Tên sách", 180);
                lvPopularBooks.Columns.Add("Tác giả", 100);
                lvPopularBooks.Columns.Add("Lượt mượn", 70);
                lvPopularBooks.Columns.Add("Còn lại", 60);

                foreach (var book in popularBooks)
                {
                    ListViewItem item = new ListViewItem(book.BookTitle);
                    item.SubItems.Add(book.AuthorName);
                    item.SubItems.Add(book.BorrowCount.ToString());
                    item.SubItems.Add(book.AvailableCopies.ToString());

                    // Color coding based on availability
                    if (book.AvailableCopies == 0)
                    {
                        item.BackColor = Color.FromArgb(255, 235, 235);
                        item.ForeColor = Color.FromArgb(192, 0, 0);
                    }
                    else if (book.AvailableCopies <= 2)
                    {
                        item.BackColor = Color.FromArgb(255, 248, 220);
                        item.ForeColor = Color.FromArgb(255, 140, 0);
                    }

                    lvPopularBooks.Items.Add(item);
                }

                // Additional ListView styling
                lvPopularBooks.FullRowSelect = true;
                lvPopularBooks.GridLines = true;
                lvPopularBooks.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải sách phổ biến: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupChart()
        {
            try
            {
                pnlChart.Paint += PnlChart_Paint;
                pnlChart.Invalidate(); // Force initial draw
            }
            catch (Exception ex)
            {
                Console.WriteLine("Chart setup error: " + ex.Message);
            }
        }

        private void PnlChart_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.Clear(cardBackColor);

                // Get monthly statistics for current year
                var monthlyStats = GetMonthlyBorrowStatistics();

                // Draw chart
                DrawBarChart(g, monthlyStats, pnlChart.ClientRectangle);
            }
            catch (Exception ex)
            {
                // Don't show error message to avoid interrupting user experience
                Console.WriteLine("Chart drawing error: " + ex.Message);
            }
        }

        private int[] GetMonthlyBorrowStatistics()
        {
            var monthlyStats = new int[12];
            try
            {
                var borrowsByMonth = context.BorrowRecords
                    .Where(br => br.BorrowDate.Year == DateTime.Now.Year)
                    .GroupBy(br => br.BorrowDate.Month)
                    .Select(g => new { Month = g.Key, Count = g.Count() })
                    .ToDictionary(x => x.Month, x => x.Count);

                for (int i = 1; i <= 12; i++)
                {
                    monthlyStats[i - 1] = borrowsByMonth.ContainsKey(i) ? borrowsByMonth[i] : 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting monthly statistics: " + ex.Message);
            }
            return monthlyStats;
        }

        private void DrawBarChart(Graphics g, int[] data, Rectangle bounds)
        {
            if (data == null || data.Length == 0) return;

            int maxValue = data.Max();
            if (maxValue == 0) maxValue = 1;

            float barWidth = (float)bounds.Width / data.Length * 0.8f;
            float spacing = (float)bounds.Width / data.Length * 0.2f;

            using (Brush barBrush = new SolidBrush(primaryColor))
            using (Brush textBrush = new SolidBrush(Color.FromArgb(64, 64, 64)))
            using (Font font = new Font("Segoe UI", 8))
            {
                for (int i = 0; i < data.Length; i++)
                {
                    float barHeight = (float)data[i] / maxValue * (bounds.Height - 40);
                    float x = i * (barWidth + spacing) + spacing / 2;
                    float y = bounds.Height - barHeight - 20;

                    // Draw bar with gradient
                    using (LinearGradientBrush gradientBrush = new LinearGradientBrush(
                        new PointF(x, y), new PointF(x, y + barHeight),
                        primaryColor, ControlPaint.Light(primaryColor, 0.3f)))
                    {
                        g.FillRectangle(gradientBrush, x, y, barWidth, barHeight);
                    }

                    // Draw month label
                    string monthName = new DateTime(DateTime.Now.Year, i + 1, 1).ToString("MMM");
                    SizeF textSize = g.MeasureString(monthName, font);
                    g.DrawString(monthName, font, textBrush,
                        x + (barWidth - textSize.Width) / 2, bounds.Height - 15);

                    // Draw value on top of bar
                    if (data[i] > 0)
                    {
                        string valueText = data[i].ToString();
                        SizeF valueSize = g.MeasureString(valueText, font);
                        g.DrawString(valueText, font, textBrush,
                            x + (barWidth - valueSize.Width) / 2, Math.Max(5, y - 20));
                    }
                }
            }
        }

        #endregion

        #region Event Handlers

        private void FDashboard_Load(object sender, EventArgs e)
        {
            // Additional initialization if needed
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            RefreshAllData();
        }

        private void BtnRefreshActivities_Click(object sender, EventArgs e)
        {
            LoadRecentActivities();
            MessageBox.Show("Đã làm mới hoạt động gần đây", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnViewReports_Click(object sender, EventArgs e)
        {
            ShowDetailedReports();
        }

        private void ShowDetailedReports()
        {
            try
            {
                Form reportForm = new Form();
                reportForm.Text = "Báo cáo chi tiết";
                reportForm.Size = new Size(900, 600);
                reportForm.StartPosition = FormStartPosition.CenterParent;
                reportForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                reportForm.MaximizeBox = false;
                reportForm.MinimizeBox = false;

                TabControl tabControl = new TabControl();
                tabControl.Dock = DockStyle.Fill;
                tabControl.Font = new Font("Segoe UI", 10F);

                // Create tab pages
                TabPage monthlyTab = new TabPage("Thống kê theo tháng");
                TabPage categoryTab = new TabPage("Thống kê theo thể loại");
                TabPage memberTab = new TabPage("Thống kê thành viên");

                // Add event handler for tab selection change
                tabControl.SelectedIndexChanged += (sender, e) =>
                {
                    LoadTabData(tabControl.SelectedTab);
                };

                // Monthly Statistics Tab
                DataGridView dgvMonthly = new DataGridView();
                dgvMonthly.Name = "dgvMonthly";
                dgvMonthly.Dock = DockStyle.Fill;
                dgvMonthly.ReadOnly = true;
                StyleDataGridView(dgvMonthly);
                monthlyTab.Controls.Add(dgvMonthly);
                tabControl.TabPages.Add(monthlyTab);

                // Category Statistics Tab
                DataGridView dgvCategory = new DataGridView();
                dgvCategory.Name = "dgvCategory";
                dgvCategory.Dock = DockStyle.Fill;
                dgvCategory.ReadOnly = true;
                StyleDataGridView(dgvCategory);
                categoryTab.Controls.Add(dgvCategory);
                tabControl.TabPages.Add(categoryTab);

                // Member Statistics Tab
                DataGridView dgvMember = new DataGridView();
                dgvMember.Name = "dgvMember";
                dgvMember.Dock = DockStyle.Fill;
                dgvMember.ReadOnly = true;
                StyleDataGridView(dgvMember);
                memberTab.Controls.Add(dgvMember);
                tabControl.TabPages.Add(memberTab);

                // Close button
                Button btnClose = new Button();
                btnClose.Text = "Đóng";
                btnClose.Size = new Size(100, 35);
                btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
                btnClose.Location = new Point(reportForm.Width - 120, reportForm.Height - 60);
                btnClose.BackColor = primaryColor;
                btnClose.ForeColor = Color.White;
                btnClose.FlatStyle = FlatStyle.Flat;
                btnClose.FlatAppearance.BorderSize = 0;
                btnClose.Click += (s, e) => reportForm.Close();
                reportForm.Controls.Add(btnClose);

                reportForm.Controls.Add(tabControl);

                // Load initial data for first tab
                LoadTabData(tabControl.SelectedTab);

                reportForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo báo cáo: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTabData(TabPage tab)
        {
            try
            {
                if (tab == null) return;

                DataGridView dgv = tab.Controls.OfType<DataGridView>().FirstOrDefault();
                if (dgv == null) return;

                // Completely clear and reset the DataGridView
                dgv.DataSource = null;
                dgv.Rows.Clear();
                dgv.Columns.Clear();
                dgv.Refresh();

                // Force garbage collection
                GC.Collect();
                GC.WaitForPendingFinalizers();

                switch (tab.Text)
                {
                    case "Thống kê theo tháng":
                        LoadMonthlyData(dgv);
                        break;
                    case "Thống kê theo thể loại":
                        LoadCategoryData(dgv);
                        break;
                    case "Thống kê thành viên":
                        LoadMemberData(dgv);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMonthlyData(DataGridView dgv)
        {
            // Clear everything first
            dgv.DataSource = null;
            dgv.Rows.Clear();
            dgv.Columns.Clear();

            var monthlyData = context.BorrowRecords
                .Where(br => br.BorrowDate.Year == DateTime.Now.Year)
                .GroupBy(br => br.BorrowDate.Month)
                .ToList() // Execute query first
                .Select(g => new
                {
                    TenThang = new DateTime(DateTime.Now.Year, g.Key, 1).ToString("MMMM yyyy"),
                    SoLuotMuon = g.Count(),
                    SoLuotTra = g.Count(br => br.ReturnDate != null),
                    DangMuon = g.Count(br => br.ReturnDate == null),
                    QuaHan = g.Count(br => br.ReturnDate == null && br.DueDate < DateTime.Today)
                })
                .OrderBy(x => DateTime.ParseExact(x.TenThang, "MMMM yyyy", System.Globalization.CultureInfo.CurrentCulture).Month)
                .ToList();

            dgv.DataSource = monthlyData;
            StyleDataGridView(dgv);

            // Customize column headers and widths after data binding
            if (dgv.Columns.Count >= 5)
            {
                dgv.Columns[0].HeaderText = "Tên tháng";
                dgv.Columns[0].Width = 150;

                dgv.Columns[1].HeaderText = "Số lượt mượn";
                dgv.Columns[1].Width = 120;

                dgv.Columns[2].HeaderText = "Số lượt trả";
                dgv.Columns[2].Width = 120;

                dgv.Columns[3].HeaderText = "Đang mượn";
                dgv.Columns[3].Width = 120;

                dgv.Columns[4].HeaderText = "Quá hạn";
                dgv.Columns[4].Width = 100;

                // Auto size columns to display content
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }

        private void LoadCategoryData(DataGridView dgv)
        {
            // Clear everything first
            dgv.DataSource = null;
            dgv.Rows.Clear();
            dgv.Columns.Clear();

            var categoryData = context.BorrowRecords
                .Include(br => br.Book)
                .ThenInclude(b => b.Category)
                .ToList() // Execute query first
                .GroupBy(br => br.Book.Category.Name)
                .Select(g => new
                {
                    TheLoai = g.Key,
                    SoLuotMuon = g.Count(),
                    SoSachKhacNhau = g.Select(br => br.BookId).Distinct().Count(),
                    TyLe = Math.Round((double)g.Count() / context.BorrowRecords.Count() * 100, 2)
                })
                .OrderByDescending(x => x.SoLuotMuon)
                .ToList();

            dgv.DataSource = categoryData;
            StyleDataGridView(dgv);

            // Customize column headers and widths after data binding
            if (dgv.Columns.Count >= 4)
            {
                dgv.Columns[0].HeaderText = "Thể loại";
                dgv.Columns[0].Width = 200;

                dgv.Columns[1].HeaderText = "Số lượt mượn";
                dgv.Columns[1].Width = 130;

                dgv.Columns[2].HeaderText = "Số sách khác nhau";
                dgv.Columns[2].Width = 150;

                dgv.Columns[3].HeaderText = "Tỷ lệ (%)";
                dgv.Columns[3].Width = 100;

                // Auto size columns to display content
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }

        private void LoadMemberData(DataGridView dgv)
        {
            // Clear everything first
            dgv.DataSource = null;
            dgv.Rows.Clear();
            dgv.Columns.Clear();

            var memberData = context.Members
                .Where(m => m.Status)
                .Include(m => m.BorrowRecords)
                .OrderByDescending(m => m.BorrowRecords.Count())
                .Take(20)
                .ToList()
                .Select(m => new
                {
                    TenThanhVien = m.Name,
                    SoLuotMuon = m.BorrowRecords.Count(),
                    DangMuon = m.BorrowRecords.Count(br => br.ReturnDate == null),
                    NgayDangKy = m.JoinDate.ToString("dd/MM/yyyy")
                })
                .ToList();

            dgv.DataSource = memberData;
            StyleDataGridView(dgv);

            // Customize column headers and widths after data binding
            if (dgv.Columns.Count >= 4)
            {
                dgv.Columns[0].HeaderText = "Tên thành viên";
                dgv.Columns[0].Width = 200;

                dgv.Columns[1].HeaderText = "Số lượt mượn";
                dgv.Columns[1].Width = 130;

                dgv.Columns[2].HeaderText = "Đang mượn";
                dgv.Columns[2].Width = 120;

                dgv.Columns[3].HeaderText = "Ngày đăng ký";
                dgv.Columns[3].Width = 130;

                // Auto size columns to display content
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }

        private void BtnExportReport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Text files (*.txt)|*.txt|CSV files (*.csv)|*.csv";
                saveDialog.FileName = $"BaoCaoThuVien_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportReportToFile(saveDialog.FileName);
                    MessageBox.Show($"Báo cáo đã được xuất thành công!\nĐường dẫn: {saveDialog.FileName}",
                        "Xuất báo cáo thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất báo cáo: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvRecentActivities_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvRecentActivities.Rows.Count > e.RowIndex)
            {
                // Safely get cell values with index-based approach
                DataGridViewRow row = dgvRecentActivities.Rows[e.RowIndex];
                string time = row.Cells.Count > 0 ? row.Cells[0].Value?.ToString() ?? "" : "";
                string activity = row.Cells.Count > 1 ? row.Cells[1].Value?.ToString() ?? "" : "";

                if (!string.IsNullOrEmpty(time) && !string.IsNullOrEmpty(activity))
                {
                    MessageBox.Show($"Thời gian: {time}\nChi tiết: {activity}",
                        "Thông tin hoạt động", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        #endregion

        #region Helper Methods

        public void RefreshAllData()
        {
            try
            {
                LoadStatistics();
                LoadRecentActivities();
                LoadPopularBooks();
                pnlChart.Invalidate(); // Redraw chart
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi làm mới dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportReportToFile(string fileName)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(fileName, false, System.Text.Encoding.UTF8))
            {
                writer.WriteLine("===========================================");
                writer.WriteLine("BÁO CÁO THỐNG KÊ HỆ THỐNG THƯ VIỆN");
                writer.WriteLine("===========================================");
                writer.WriteLine($"Thời gian xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                writer.WriteLine($"Người xuất: {Utility.CurrentEmployee?.Name ?? "Hệ thống"}");
                writer.WriteLine();

                // General Statistics
                writer.WriteLine("1. THỐNG KÊ TỔNG QUAN:");
                writer.WriteLine($"   - Tổng số sách: {lblBooksValue.Text}");
                writer.WriteLine($"   - Số thành viên đang hoạt động: {lblMembersValue.Text}");
                writer.WriteLine($"   - Sách đang cho mượn: {lblBorrowsValue.Text}");
                writer.WriteLine($"   - Sách quá hạn: {lblOverdueValue.Text}");
                writer.WriteLine();

                // Popular Books
                writer.WriteLine("2. SÁCH PHỔ BIẾN NHẤT:");
                foreach (ListViewItem item in lvPopularBooks.Items)
                {
                    writer.WriteLine($"   - {item.Text}");
                    writer.WriteLine($"     Tác giả: {item.SubItems[1].Text}");
                    writer.WriteLine($"     Lượt mượn: {item.SubItems[2].Text}, Còn lại: {item.SubItems[3].Text}");
                    writer.WriteLine();
                }

                // Recent Activities
                writer.WriteLine("3. HOẠT ĐỘNG GẦN ĐÂY:");
                foreach (DataGridViewRow row in dgvRecentActivities.Rows)
                {
                    if (row.Cells.Count >= 2 && row.Cells[0].Value != null && row.Cells[1].Value != null)
                    {
                        writer.WriteLine($"   [{row.Cells[0].Value}] {row.Cells[1].Value}");
                    }
                }
                writer.WriteLine();

                // Monthly Statistics
                writer.WriteLine("4. THỐNG KÊ THEO THÁNG (NĂM " + DateTime.Now.Year + "):");
                var monthlyStats = GetMonthlyBorrowStatistics();
                for (int i = 0; i < 12; i++)
                {
                    string monthName = new DateTime(DateTime.Now.Year, i + 1, 1).ToString("MMMM");
                    writer.WriteLine($"   - {monthName}: {monthlyStats[i]} lượt mượn");
                }
                writer.WriteLine();

                writer.WriteLine("===========================================");
                writer.WriteLine("HẾT BÁO CÁO");
                writer.WriteLine("===========================================");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            refreshTimer?.Stop();
            refreshTimer?.Dispose();
            context?.Dispose();
            base.OnFormClosing(e);
        }

        #endregion
    }
}