using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models
{
    public class BookLocation
    {
        [Key]
        public int LocationId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập mã khu vực")]
        [StringLength(10, ErrorMessage = "Mã khu vực không được vượt quá 10 ký tự")]
        public string AreaCode { get; set; } // A, B, C...

        [Required(ErrorMessage = "Vui lòng nhập số kệ")]
        public int ShelfNumber { get; set; }

        public int SectionNumber { get; set; }

        [StringLength(200, ErrorMessage = "Mô tả không được vượt quá 200 ký tự")]
        public string Description { get; set; }

        // Navigation property
        public virtual ICollection<BookCopy> BookCopies { get; set; }
    }
}