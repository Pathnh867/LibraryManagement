using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models
{
    public class InventoryDetail
    {
        [Key]
        public int InventoryDetailId { get; set; }

        [Required]
        public int InventoryId { get; set; }

        [ForeignKey("InventoryId")]
        public virtual InventoryCheck InventoryCheck { get; set; }

        [Required]
        public int CopyId { get; set; }

        [ForeignKey("CopyId")]
        public virtual BookCopy BookCopy { get; set; }

        public int ExpectedStatus { get; set; }

        public int ActualStatus { get; set; }

        [StringLength(500, ErrorMessage = "Ghi chú không được vượt quá 500 ký tự")]
        public string Notes { get; set; }
    }
}