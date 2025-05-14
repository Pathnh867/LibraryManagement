using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models
{
    public class BookCopy
    {
        [Key]
        public int CopyId { get; set; }

        [Required]
        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }

        public int? LocationId { get; set; }

        [ForeignKey("LocationId")]
        public virtual BookLocation Location { get; set; }

        // Status: 1 = Có sẵn, 2 = Đang mượn, 3 = Bị mất, 4 = Hư hỏng
        public int Status { get; set; }

        [Column(TypeName = "Date")]
        public DateTime AcquisitionDate { get; set; }

        [StringLength(500, ErrorMessage = "Ghi chú không được vượt quá 500 ký tự")]
        public string Notes { get; set; }

        // Navigation properties
        public virtual ICollection<BorrowRecord> BorrowRecords { get; set; }
        public virtual ICollection<InventoryDetail> InventoryDetails { get; set; }
        public virtual LostBook LostBook { get; set; }
    }
}