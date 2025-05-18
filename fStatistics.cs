#nullable disable
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
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace LibraryManagement
{
    public partial class fStatistics : Form
    {
        private LibraryDbContext context;
        private Color primaryColor = Color.FromArgb(210, 121, 106);
        private Color accentColor = Color.FromArgb(129, 195, 215);
        private Color backgroundColor = Color.FromArgb(249, 241, 240);

        public fStatistics()
        {
            InitializeComponent();
            context = new LibraryDbContext();
            InitializeForm();
        }

        #region Khởi tạo Form

        private void InitializeForm()
        {
            // Áp dụng styling cho form
            ApplyFormStyling();

            // Thiết lập giá trị mặc định
            SetDefaultValues();

            // Gán sự kiện
            AttachEvents();

            // Tải dữ liệu ban đầu
            LoadInitialData();
        }

        private void SetDefaultValues()
        {
            // Thiết lập khoảng thời gian mặc định (tháng hiện tại)
            dtpFromDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpToDate.Value = DateTime.Now;

            // Thiết lập loại báo cáo mặc định
            cboReportType.SelectedIndex = 0;
        }

        private void AttachEvents()
        {
            // Gán sự kiện cho các nút
            btnGenerate.Click += BtnGenerate_Click;
            btnExportExcel.Click += BtnExportExcel_Click;
            btnExportPdf.Click += BtnExportPdf_Click;
            btnPrint.Click += BtnPrint_Click;

            // Gán sự kiện cho tab control
            tcReports.SelectedIndexChanged += TcReports_SelectedIndexChanged;

            // Gán sự kiện cho combo box
            cboReportType.SelectedIndexChanged += CboReportType_SelectedIndexChanged;

            // Gán sự kiện validation cho DateTimePicker
            dtpFromDate.ValueChanged += DtpFromDate_ValueChanged;
            dtpToDate.ValueChanged += DtpToDate_ValueChanged;
        }

        private void LoadInitialData()
        {
            // Tải dữ liệu tổng quan ban đầu
            LoadOverviewData();
        }

        #endregion

        #region Styling và UI

        private void ApplyFormStyling()
        {
            // Áp dụng bo góc cho các panel
            ApplyRoundedCorners(pnlFilters);
            ApplyRoundedCorners(pnlExport);

            // Styling cho các nút
            ApplyButtonStyling(btnGenerate, accentColor);
            ApplyButtonStyling(btnPrint, primaryColor);
            ApplyButtonStyling(btnExportExcel, Color.FromArgb(46, 204, 113));
            ApplyButtonStyling(btnExportPdf, Color.FromArgb(231, 76, 60));

            // Styling cho DataGridView
            StyleDataGridView(dgvOverview);
            StyleDataGridView(dgvBooks);
            StyleDataGridView(dgvMembers);
            StyleDataGridView(dgvOverdue);

            // Styling cho TabControl
            StyleTabControl(tcReports);
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

                    // Vẽ đổ bóng nhẹ
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

        private void ApplyButtonStyling(Button button, Color color)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = color;
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;

            // Áp dụng bo góc
            button.Paint += (s, e) =>
            {
                using (GraphicsPath path = CreateRoundedRectanglePath(button.ClientRectangle, 8))
                {
                    button.Region = new Region(path);
                }
            };

            // Hiệu ứng hover
            Color originalColor = color;
            Color hoverColor = ControlPaint.Dark(color, 0.1f);
            button.MouseEnter += (s, e) => button.BackColor = hoverColor;
            button.MouseLeave += (s, e) => button.BackColor = originalColor;
        }

        private void StyleDataGridView(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.White;
            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;

            // Styling cho header
            dgv.ColumnHeadersDefaultCellStyle.BackColor = primaryColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.EnableHeadersVisualStyles = false;

            // Styling cho rows
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 121, 106, 50);
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(64, 64, 64);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 245, 245);

            dgv.RowTemplate.Height = 30;
            dgv.GridColor = Color.FromArgb(224, 224, 224);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        }

        private void StyleTabControl(TabControl tc)
        {
            tc.DrawMode = TabDrawMode.OwnerDrawFixed;
            tc.DrawItem += (s, e) =>
            {
                TabControl tabControl = s as TabControl;
                TabPage tabPage = tabControl.TabPages[e.Index];
                Rectangle tabRect = tabControl.GetTabRect(e.Index);

                // Xác định màu sắc
                Color backColor = (e.State == DrawItemState.Selected) ? primaryColor : Color.White;
                Color textColor = (e.State == DrawItemState.Selected) ? Color.White : Color.FromArgb(64, 64, 64);

                // Vẽ background
                using (Brush brush = new SolidBrush(backColor))
                {
                    e.Graphics.FillRectangle(brush, tabRect);
                }

                // Vẽ text
                TextRenderer.DrawText(e.Graphics, tabPage.Text,
                    new Font("Segoe UI", 10F, FontStyle.Bold),
                    tabRect, textColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            };
        }

        #endregion

        #region Validation

        private bool ValidateInputs()
        {
            // Kiểm tra khoảng thời gian
            if (dtpFromDate.Value > dtpToDate.Value)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Lỗi Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpFromDate.Focus();
                return false;
            }

            // Kiểm tra khoảng thời gian không quá xa (ví dụ: không quá 1 năm)
            if ((dtpToDate.Value - dtpFromDate.Value).TotalDays > 365)
            {
                MessageBox.Show("Khoảng thời gian báo cáo không nên vượt quá 1 năm!", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Kiểm tra loại báo cáo được chọn
            if (cboReportType.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn loại báo cáo!", "Lỗi Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboReportType.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region Event Handlers

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                // Hiển thị loading indicator
                Cursor = Cursors.WaitCursor;
                btnGenerate.Enabled = false;
                btnGenerate.Text = "Đang tạo...";

                // Xóa dữ liệu cũ trước khi tạo báo cáo mới
                ClearAllDataGrids();

                // Tạo báo cáo theo loại được chọn
                switch (cboReportType.SelectedIndex)
                {
                    case 0: // Tổng quan
                        LoadOverviewData();
                        tcReports.SelectedIndex = 0;
                        break;
                    case 1: // Theo sách
                        LoadBooksData();
                        tcReports.SelectedIndex = 1;
                        break;
                    case 2: // Theo thành viên
                        LoadMembersData();
                        tcReports.SelectedIndex = 2;
                        break;
                    case 3: // Sách quá hạn
                        LoadOverdueData();
                        tcReports.SelectedIndex = 3;
                        break;
                }

                // Chỉ hiển thị thông báo khi click button Generate, không hiển thị khi đổi tab
                if (sender == btnGenerate)
                {
                    MessageBox.Show("Tạo báo cáo thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo báo cáo: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Khôi phục trạng thái
                Cursor = Cursors.Default;
                btnGenerate.Enabled = true;
                btnGenerate.Text = "Tạo báo cáo";
            }
        }

        private void ClearAllDataGrids()
        {
            // Xóa dữ liệu của tất cả DataGridView
            dgvOverview.DataSource = null;
            dgvBooks.DataSource = null;
            dgvMembers.DataSource = null;
            dgvOverdue.DataSource = null;

            // Refresh để đảm bảo UI được cập nhật
            dgvOverview.Refresh();
            dgvBooks.Refresh();
            dgvMembers.Refresh();
            dgvOverdue.Refresh();
        }

        private void CboReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Tự động tạo báo cáo khi thay đổi loại (không hiển thị thông báo)
            if (cboReportType.SelectedIndex >= 0)
            {
                // Gọi trực tiếp các method load data thay vì BtnGenerate_Click
                // để tránh hiển thị thông báo
                LoadReportByType(cboReportType.SelectedIndex);
            }
        }

        private void TcReports_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Đồng bộ combo box với tab được chọn
            if (tcReports.SelectedIndex >= 0 && tcReports.SelectedIndex < cboReportType.Items.Count)
            {
                // Tạm thời gỡ bỏ event để tránh gọi lại CboReportType_SelectedIndexChanged
                cboReportType.SelectedIndexChanged -= CboReportType_SelectedIndexChanged;
                cboReportType.SelectedIndex = tcReports.SelectedIndex;
                cboReportType.SelectedIndexChanged += CboReportType_SelectedIndexChanged;

                // Load dữ liệu cho tab được chọn (không hiển thị thông báo)
                LoadReportByType(tcReports.SelectedIndex);
            }
        }

        private void LoadReportByType(int reportType)
        {
            try
            {
                // Hiển thị loading indicator
                Cursor = Cursors.WaitCursor;

                // Xóa dữ liệu cũ trước khi tạo báo cáo mới
                ClearAllDataGrids();

                // Tạo báo cáo theo loại được chọn
                switch (reportType)
                {
                    case 0: // Tổng quan
                        LoadOverviewData();
                        break;
                    case 1: // Theo sách
                        LoadBooksData();
                        break;
                    case 2: // Theo thành viên
                        LoadMembersData();
                        break;
                    case 3: // Sách quá hạn
                        LoadOverdueData();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo báo cáo: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Khôi phục trạng thái
                Cursor = Cursors.Default;
            }
        }

        private void DtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            // Tự động cập nhật "đến ngày" nếu cần
            if (dtpFromDate.Value > dtpToDate.Value)
            {
                dtpToDate.Value = dtpFromDate.Value.AddMonths(1);
            }
        }

        private void DtpToDate_ValueChanged(object sender, EventArgs e)
        {
            // Kiểm tra và cảnh báo nếu khoảng thời gian quá lớn
            if ((dtpToDate.Value - dtpFromDate.Value).TotalDays > 365)
            {
                // Không hiển thị message box ở đây để tránh spam, chỉ cảnh báo khi generate
            }
        }

        #endregion

        #region Tải Dữ Liệu

        private void LoadOverviewData()
        {
            try
            {
                var fromDate = dtpFromDate.Value.Date;
                var toDate = dtpToDate.Value.Date.AddDays(1).AddTicks(-1);

                // Thống kê tổng quan
                var overviewData = new List<dynamic>
                {
                    new {
                        ChiTieu = "Tổng số sách",
                        GiaTri = context.Books.Count().ToString("N0"),
                        GhiChu = "Tất cả sách trong hệ thống"
                    },
                    new {
                        ChiTieu = "Tổng số thành viên",
                        GiaTri = context.Members.Count(m => m.Status).ToString("N0"),
                        GhiChu = "Thành viên đang hoạt động"
                    },
                    new {
                        ChiTieu = "Lượt mượn trong khoảng thời gian",
                        GiaTri = context.BorrowRecords
                            .Count(br => br.BorrowDate >= fromDate && br.BorrowDate <= toDate).ToString("N0"),
                        GhiChu = $"Từ {fromDate:dd/MM/yyyy} đến {toDate:dd/MM/yyyy}"
                    },
                    new {
                        ChiTieu = "Lượt trả trong khoảng thời gian",
                        GiaTri = context.BorrowRecords
                            .Count(br => br.ReturnDate.HasValue && br.ReturnDate >= fromDate && br.ReturnDate <= toDate).ToString("N0"),
                        GhiChu = $"Từ {fromDate:dd/MM/yyyy} đến {toDate:dd/MM/yyyy}"
                    },
                    new {
                        ChiTieu = "Sách đang mượn",
                        GiaTri = context.BorrowRecords.Count(br => br.ReturnDate == null).ToString("N0"),
                        GhiChu = "Hiện tại"
                    },
                    new {
                        ChiTieu = "Sách quá hạn",
                        GiaTri = context.BorrowRecords
                            .Count(br => br.ReturnDate == null && br.DueDate < DateTime.Today).ToString("N0"),
                        GhiChu = "Hiện tại"
                    },
                    new {
                        ChiTieu = "Tổng tiền phạt đã thu",
                        GiaTri = (context.BorrowRecords
                            .Where(br => br.ReturnDate.HasValue && br.ReturnDate >= fromDate && br.ReturnDate <= toDate)
                            .Select(br => br.LateFee ?? 0)
                            .Sum()).ToString("N0") + " VNĐ",
                        GhiChu = $"Từ {fromDate:dd/MM/yyyy} đến {toDate:dd/MM/yyyy}"
                    }
                };

                // Gán sự kiện trước khi binding
                dgvOverview.DataBindingComplete -= DgvOverview_DataBindingComplete;
                dgvOverview.DataBindingComplete += DgvOverview_DataBindingComplete;

                dgvOverview.DataSource = overviewData;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu tổng quan: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvOverview_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                // Tùy chỉnh header
                if (dgvOverview.Columns.Count >= 3)
                {
                    dgvOverview.Columns[0].HeaderText = "Chỉ tiêu";
                    dgvOverview.Columns[0].Width = 300;
                    dgvOverview.Columns[1].HeaderText = "Giá trị";
                    dgvOverview.Columns[1].Width = 150;
                    dgvOverview.Columns[2].HeaderText = "Ghi chú";
                    dgvOverview.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                // Gỡ bỏ sự kiện để tránh gọi nhiều lần
                dgvOverview.DataBindingComplete -= DgvOverview_DataBindingComplete;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi định dạng columns: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBooksData()
        {
            try
            {
                var fromDate = dtpFromDate.Value.Date;
                var toDate = dtpToDate.Value.Date.AddDays(1).AddTicks(-1);

                // Thống kê theo sách
                var booksData = context.BorrowRecords
                    .Include(br => br.Book)
                        .ThenInclude(b => b.Author)
                    .Include(br => br.Book)
                        .ThenInclude(b => b.Category)
                    .Where(br => br.BorrowDate >= fromDate && br.BorrowDate <= toDate)
                    .GroupBy(br => br.BookId)
                    .Select(g => new
                    {
                        TenSach = g.First().Book.Title,
                        TacGia = g.First().Book.Author.Name,
                        TheLoai = g.First().Book.Category.Name,
                        SoLanMuon = g.Count(),
                        SoLanTraDungHan = g.Count(br => br.ReturnDate.HasValue && br.ReturnDate <= br.DueDate),
                        SoLanTraTreHan = g.Count(br => br.ReturnDate.HasValue && br.ReturnDate > br.DueDate),
                        DangMuon = g.Count(br => br.ReturnDate == null),
                        TienPhat = g.Select(br => br.LateFee ?? 0).Sum()
                    })
                    .OrderByDescending(x => x.SoLanMuon)
                    .ToList();

                // Gán sự kiện trước khi binding
                dgvBooks.DataBindingComplete -= DgvBooks_DataBindingComplete;
                dgvBooks.DataBindingComplete += DgvBooks_DataBindingComplete;

                dgvBooks.DataSource = booksData;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu thống kê sách: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvBooks_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                // Tùy chỉnh header
                if (dgvBooks.Columns.Count >= 8)
                {
                    dgvBooks.Columns[0].HeaderText = "Tên sách";
                    dgvBooks.Columns[1].HeaderText = "Tác giả";
                    dgvBooks.Columns[2].HeaderText = "Thể loại";
                    dgvBooks.Columns[3].HeaderText = "Số lần mượn";
                    dgvBooks.Columns[4].HeaderText = "Trả đúng hạn";
                    dgvBooks.Columns[5].HeaderText = "Trả trễ hạn";
                    dgvBooks.Columns[6].HeaderText = "Đang mượn";
                    dgvBooks.Columns[7].HeaderText = "Tiền phạt (VNĐ)";

                    // Format cột tiền
                    dgvBooks.Columns[7].DefaultCellStyle.Format = "N0";
                }

                // Gỡ bỏ sự kiện để tránh gọi nhiều lần
                dgvBooks.DataBindingComplete -= DgvBooks_DataBindingComplete;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi định dạng columns: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMembersData()
        {
            try
            {
                var fromDate = dtpFromDate.Value.Date;
                var toDate = dtpToDate.Value.Date.AddDays(1).AddTicks(-1);

                // Thống kê theo thành viên
                var membersData = context.Members
                    .Include(m => m.BorrowRecords)
                    .Where(m => m.Status && m.BorrowRecords.Any(br => br.BorrowDate >= fromDate && br.BorrowDate <= toDate))
                    .Select(m => new
                    {
                        TenThanhVien = m.Name,
                        SoDienThoai = m.Phone,
                        Email = m.Email,
                        NgayDangKy = m.JoinDate,
                        TongSoLanMuon = m.BorrowRecords.Count(br => br.BorrowDate >= fromDate && br.BorrowDate <= toDate),
                        DangMuon = m.BorrowRecords.Count(br => br.ReturnDate == null),
                        SoLanTraTre = m.BorrowRecords.Count(br => br.ReturnDate.HasValue && br.ReturnDate > br.DueDate
                            && br.BorrowDate >= fromDate && br.BorrowDate <= toDate),
                        TongTienPhat = m.BorrowRecords
                            .Where(br => br.BorrowDate >= fromDate && br.BorrowDate <= toDate)
                            .Select(br => br.LateFee ?? 0)
                            .Sum()
                    })
                    .OrderByDescending(x => x.TongSoLanMuon)
                    .ToList();

                // Gán sự kiện trước khi binding
                dgvMembers.DataBindingComplete -= DgvMembers_DataBindingComplete;
                dgvMembers.DataBindingComplete += DgvMembers_DataBindingComplete;

                dgvMembers.DataSource = membersData;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu thống kê thành viên: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvMembers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                // Tùy chỉnh header
                if (dgvMembers.Columns.Count >= 8)
                {
                    dgvMembers.Columns[0].HeaderText = "Tên thành viên";
                    dgvMembers.Columns[1].HeaderText = "Số điện thoại";
                    dgvMembers.Columns[2].HeaderText = "Email";
                    dgvMembers.Columns[3].HeaderText = "Ngày đăng ký";
                    dgvMembers.Columns[4].HeaderText = "Tổng lần mượn";
                    dgvMembers.Columns[5].HeaderText = "Đang mượn";
                    dgvMembers.Columns[6].HeaderText = "Số lần trả trễ";
                    dgvMembers.Columns[7].HeaderText = "Tổng tiền phạt (VNĐ)";

                    // Format cột ngày
                    dgvMembers.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
                    // Format cột tiền
                    dgvMembers.Columns[7].DefaultCellStyle.Format = "N0";
                }

                // Gỡ bỏ sự kiện để tránh gọi nhiều lần
                dgvMembers.DataBindingComplete -= DgvMembers_DataBindingComplete;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi định dạng columns: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadOverdueData()
        {
            try
            {
                // Dữ liệu sách quá hạn - Tách thành 2 bước để tránh lỗi Expression Tree
                var overdueRecords = context.BorrowRecords
                    .Include(br => br.Book)
                        .ThenInclude(b => b.Author)
                    .Include(br => br.Member)
                    .Include(br => br.BookCopy)
                    .Where(br => br.ReturnDate == null && br.DueDate < DateTime.Today)
                    .OrderBy(br => br.DueDate)
                    .ToList(); // Thực hiện query trước

                // Tính toán phí phạt trong memory
                var overdueData = overdueRecords.Select(br => new
                {
                    TenSach = br.Book.Title,
                    TacGia = br.Book.Author.Name,
                    TenThanhVien = br.Member.Name,
                    SoDienThoai = br.Member.Phone,
                    NgayMuon = br.BorrowDate,
                    HanTra = br.DueDate,
                    SoNgayQuaHan = (DateTime.Today - br.DueDate).Days,
                    MaBanSao = br.CopyId,
                    TienPhatDuKien = Utility.CalculateLateFee(br.DueDate, DateTime.Today),
                    GhiChu = br.Notes ?? ""
                }).ToList();

                dgvOverdue.DataSource = overdueData;

                // Tùy chỉnh header và format
                if (dgvOverdue.Columns.Count >= 10)
                {
                    dgvOverdue.Columns[0].HeaderText = "Tên sách";
                    dgvOverdue.Columns[1].HeaderText = "Tác giả";
                    dgvOverdue.Columns[2].HeaderText = "Tên thành viên";
                    dgvOverdue.Columns[3].HeaderText = "Số điện thoại";
                    dgvOverdue.Columns[4].HeaderText = "Ngày mượn";
                    dgvOverdue.Columns[5].HeaderText = "Hạn trả";
                    dgvOverdue.Columns[6].HeaderText = "Số ngày quá hạn";
                    dgvOverdue.Columns[7].HeaderText = "Mã bản sao";
                    dgvOverdue.Columns[8].HeaderText = "Tiền phạt dự kiến (VNĐ)";
                    dgvOverdue.Columns[9].HeaderText = "Ghi chú";

                    // Format cột ngày
                    dgvOverdue.Columns[4].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvOverdue.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
                    // Format cột tiền
                    dgvOverdue.Columns[8].DefaultCellStyle.Format = "N0";

                    // Tô màu đỏ cho các row quá hạn nghiêm trọng (> 30 ngày)
                    foreach (DataGridViewRow row in dgvOverdue.Rows)
                    {
                        if (row.Cells[6].Value != null)
                        {
                            string cellValue = row.Cells[6].Value.ToString();
                            if (!string.IsNullOrEmpty(cellValue) && int.TryParse(cellValue, out int daysOverdue) && daysOverdue > 30)
                            {
                                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 235);
                                row.DefaultCellStyle.ForeColor = Color.FromArgb(192, 0, 0);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu sách quá hạn: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Export và In

        private void BtnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Text files (*.txt)|*.txt|CSV files (*.csv)|*.csv";
                saveDialog.FileName = $"BaoCaoThuVien_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportToCSV(saveDialog.FileName);
                    MessageBox.Show($"Xuất CSV thành công!\nFile đã được lưu tại: {saveDialog.FileName}",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất CSV: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExportPdf_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "RTF files (*.rtf)|*.rtf";
                saveDialog.FileName = $"BaoCaoThuVien_{DateTime.Now:yyyyMMdd_HHmmss}.rtf";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportToRTF(saveDialog.FileName);
                    MessageBox.Show($"Xuất RTF thành công!\nFile đã được lưu tại: {saveDialog.FileName}",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất RTF: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                PrintReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in báo cáo: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToCSV(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                // Header thông tin báo cáo
                writer.WriteLine("BÁO CÁO THỐNG KÊ THƯ VIỆN");
                writer.WriteLine($"Loại báo cáo,{cboReportType.Text}");
                writer.WriteLine($"Từ ngày,{dtpFromDate.Value:dd/MM/yyyy}");
                writer.WriteLine($"Đến ngày,{dtpToDate.Value:dd/MM/yyyy}");
                writer.WriteLine($"Ngày xuất,{DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                writer.WriteLine($"Người xuất,{Utility.CurrentEmployee?.Name ?? "Hệ thống"}");
                writer.WriteLine();

                // Data từ tab hiện tại
                DataGridView currentGrid = GetCurrentDataGridView();
                if (currentGrid?.DataSource != null)
                {
                    WriteDataGridToCSV(writer, currentGrid);
                }
            }
        }

        private void ExportToRTF(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                writer.WriteLine(@"{\rtf1\ansi\deff0 {\fonttbl {\f0 Times New Roman;}}");
                writer.WriteLine(@"{\colortbl;\red0\green0\blue0;\red255\green0\blue0;}");
                writer.WriteLine(@"\f0\fs24");

                // Header
                writer.WriteLine(@"\qc\b\fs28 BÁO CÁO THỐNG KÊ THƯ VIỆN\b0\fs24\par");
                writer.WriteLine($@"\ql Loại báo cáo: {cboReportType.Text}\par");
                writer.WriteLine($@"Từ ngày: {dtpFromDate.Value:dd/MM/yyyy} - Đến ngày: {dtpToDate.Value:dd/MM/yyyy}\par");
                writer.WriteLine($@"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\par");
                writer.WriteLine($@"Người xuất: {Utility.CurrentEmployee?.Name ?? "Hệ thống"}\par\par");

                // Data từ tab hiện tại
                DataGridView currentGrid = GetCurrentDataGridView();
                if (currentGrid?.DataSource != null)
                {
                    WriteDataGridToRtf(writer, currentGrid);
                }

                writer.WriteLine(@"}");
            }
        }

        private void PrintReport()
        {
            // Thực hiện in báo cáo
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                // Tạo nội dung in
                StringBuilder content = new StringBuilder();
                content.AppendLine("BÁO CÁO THỐNG KÊ THƯ VIỆN");
                content.AppendLine("".PadRight(50, '='));
                content.AppendLine($"Loại báo cáo: {cboReportType.Text}");
                content.AppendLine($"Từ ngày: {dtpFromDate.Value:dd/MM/yyyy} - Đến ngày: {dtpToDate.Value:dd/MM/yyyy}");
                content.AppendLine($"Ngày in: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                content.AppendLine($"Người in: {Utility.CurrentEmployee?.Name ?? "Hệ thống"}");
                content.AppendLine();

                // Thêm dữ liệu từ tab hiện tại
                DataGridView currentGrid = GetCurrentDataGridView();
                if (currentGrid?.DataSource != null)
                {
                    AddDataGridToContent(content, currentGrid);
                }

                // In nội dung
                PrintUsingNotepad(content.ToString());
            }
        }

        private DataGridView GetCurrentDataGridView()
        {
            switch (tcReports.SelectedIndex)
            {
                case 0: return dgvOverview;
                case 1: return dgvBooks;
                case 2: return dgvMembers;
                case 3: return dgvOverdue;
                default: return null;
            }
        }

        private void WriteDataGridToCSV(StreamWriter writer, DataGridView dgv)
        {
            // Headers
            List<string> headers = new List<string>();
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                headers.Add($"\"{col.HeaderText}\"");
            }
            writer.WriteLine(string.Join(",", headers));

            // Data
            foreach (DataGridViewRow row in dgv.Rows)
            {
                List<string> values = new List<string>();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    string value = cell.Value?.ToString() ?? "";
                    values.Add($"\"{value.Replace("\"", "\"\"")}\"");
                }
                writer.WriteLine(string.Join(",", values));
            }
        }

        private void WriteDataGridToRtf(StreamWriter writer, DataGridView dgv)
        {
            writer.WriteLine(@"\b Dữ liệu báo cáo:\b0\par");

            // Headers
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                writer.Write($"{col.HeaderText}\t");
            }
            writer.WriteLine(@"\par");

            writer.WriteLine(@"\par");
            // Data
            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    writer.Write($"{cell.Value?.ToString() ?? ""}\t");
                }
                writer.WriteLine(@"\par");
            }
        }

        private void AddDataGridToContent(StringBuilder content, DataGridView dgv)
        {
            // Headers
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                content.Append(col.HeaderText.PadRight(15));
            }
            content.AppendLine();
            content.AppendLine("".PadRight(dgv.Columns.Count * 15, '-'));

            // Data
            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    content.Append((cell.Value?.ToString() ?? "").PadRight(15));
                }
                content.AppendLine();
            }
        }

        private void PrintUsingNotepad(string content)
        {
            // Tạo file temp và mở bằng Notepad để in
            string tempFile = Path.GetTempFileName() + ".txt";
            File.WriteAllText(tempFile, content, Encoding.UTF8);

            System.Diagnostics.Process.Start("notepad.exe", $"/p \"{tempFile}\"");

            // Xóa file temp sau 10 giây
            Task.Delay(10000).ContinueWith(t =>
            {
                try { File.Delete(tempFile); }
                catch { /* Ignore */ }
            });
        }

        #endregion

        #region Form Lifecycle

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            context?.Dispose();
            base.OnFormClosing(e);
        }

        #endregion
    }
}