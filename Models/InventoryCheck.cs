using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models
{
    public class InventoryCheck
    {
        [Key]
        public int InventoryId { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime CheckDate { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        [StringLength(500, ErrorMessage = "Ghi chú không được vượt quá 500 ký tự")]
        public string Notes { get; set; }

        // Navigation property
        public virtual ICollection<InventoryDetail> InventoryDetails { get; set; }
    }
}