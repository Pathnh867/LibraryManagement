using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên tác giả")]
        [StringLength(100, ErrorMessage = "Tên tác giả không được vượt quá 100 ký tự")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Tiểu sử không được vượt quá 500 ký tự")]
        public string Biography { get; set; }

        // Navigation property
        public virtual ICollection<Book> Books { get; set; }
    }
}