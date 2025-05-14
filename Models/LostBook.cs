using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models
{
    public class LostBook
    {
        [Key]
        public int LostBookId { get; set; }

        [Required]
        public int CopyId { get; set; }

        [ForeignKey("CopyId")]
        public virtual BookCopy BookCopy { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime ReportDate { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        [StringLength(200, ErrorMessage = "Lý do không được vượt quá 200 ký tự")]
        public string Reason { get; set; }

        [StringLength(500, ErrorMessage = "Ghi chú không được vượt quá 500 ký tự")]
        public string Notes { get; set; }
    }
}