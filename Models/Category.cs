using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên thể loại")]
        [StringLength(50, ErrorMessage = "Tên thể loại không được vượt quá 50 ký tự")]
        public string Name { get; set; }

        [StringLength(200, ErrorMessage = "Mô tả không được vượt quá 200 ký tự")]
        public string Description { get; set; }

        // Navigation property
        public virtual ICollection<Book> Books { get; set; }
    }
}