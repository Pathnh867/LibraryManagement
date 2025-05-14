using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models
{
    public class BorrowRecord
    {
        [Key]
        public int BorrowRecordId { get; set; }

        [Required]
        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }

        [Required]
        public int MemberId { get; set; }

        [ForeignKey("MemberId")]
        public virtual Member Member { get; set; }

        [Required]
        public int CopyId { get; set; }

        [ForeignKey("CopyId")]
        public virtual BookCopy BookCopy { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime BorrowDate { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime DueDate { get; set; }

        [Column(TypeName = "Date")]
        public DateTime? ReturnDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? LateFee { get; set; }

        [StringLength(500, ErrorMessage = "Ghi chú không được vượt quá 500 ký tự")]
        public string Notes { get; set; }
    }
}