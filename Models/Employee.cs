using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        [StringLength(100, ErrorMessage = "Họ tên không được vượt quá 100 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập email")]
        [StringLength(100, ErrorMessage = "Email không được vượt quá 100 ký tự")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; } // Dùng làm tên đăng nhập

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [StringLength(100, ErrorMessage = "Mật khẩu không được vượt quá 100 ký tự")]
        public string Password { get; set; }

        // 1: Quản trị viên, 2: Thủ thư, 3: Nhân viên
        public int RoleId { get; set; }

        public bool Status { get; set; } // true: Đang hoạt động, false: Đã khóa

        // Navigation properties
        public virtual ICollection<InventoryCheck> InventoryChecks { get; set; }
        public virtual ICollection<LostBook> ReportedLostBooks { get; set; }
    }
}