using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên sách")]
        [StringLength(100, ErrorMessage = "Tên sách không được vượt quá 100 ký tự")]
        public string Title { get; set; }

        [StringLength(50, ErrorMessage = "ISBN không được vượt quá 50 ký tự")]
        public string ISBN { get; set; }

        [Range(1900, 2100, ErrorMessage = "Năm xuất bản phải từ 1900 đến 2100")]
        public int PublicationYear { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }

        public int TotalCopies { get; set; }

        public int AvailableCopies { get; set; }

        [StringLength(1000, ErrorMessage = "Mô tả không được vượt quá 1000 ký tự")]
        public string Description { get; set; }

        // Navigation properties
        public virtual ICollection<BorrowRecord> BorrowRecords { get; set; }
        public virtual ICollection<BookCopy> BookCopies { get; set; }
    }
}