using LibraryManagement.Models;
using System.Windows.Forms;

namespace LibraryManagement
{
    public static class Utility
    {
        // Lưu thông tin nhân viên đang đăng nhập
        public static Employee CurrentEmployee { get; set; }

        // Kiểm tra xem form đã được mở hay chưa
        public static bool IsOpeningForm(string formName)
        {
            foreach (Form f in Application.OpenForms)
                if (f.Name == formName)
                    return true;
            return false;
        }

        // Kiểm tra quyền hạn của người dùng
        public static bool HasPermission(int requiredRoleId)
        {
            if (CurrentEmployee == null)
                return false;

            // RoleId: 1 = Quản trị viên (có tất cả quyền)
            // RoleId: 2 = Thủ thư
            // RoleId: 3 = Nhân viên (quyền hạn thấp nhất)
            return CurrentEmployee.RoleId <= requiredRoleId;
        }

        // Phương thức tính tiền phạt trễ hạn (nếu có)
        public static decimal CalculateLateFee(DateTime dueDate, DateTime returnDate, decimal feePerDay = 5000M)
        {
            if (returnDate <= dueDate)
                return 0;

            int lateDays = (int)(returnDate - dueDate).TotalDays;
            return lateDays * feePerDay;
        }

        // Các trạng thái của bản sao sách
        public static string GetCopyStatusText(int status)
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

        // Các vai trò của nhân viên
        public static string GetRoleText(int roleId)
        {
            switch (roleId)
            {
                case 1: return "Quản trị viên";
                case 2: return "Thủ thư";
                case 3: return "Nhân viên";
                default: return "Không xác định";
            }
        }
    }
}