using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace StoreManagementSystem.Models
{
    [Table("tblProduct")]
    public partial class TblProduct
    {
        [Key]
        [Column("intProductId")]
        public long IntProductId { get; set; }
        [Column("intUserId")]
        public long IntUserId { get; set; }
        [Required]
        [Column("strUserName")]
        [StringLength(50)]
        public string StrUserName { get; set; }
        [Required]
        [Column("strProductName")]
        [StringLength(500)]
        public string StrProductName { get; set; }
        [Column("intProductPrice", TypeName = "decimal(18, 2)")]
        public decimal IntProductPrice { get; set; }
        public bool IsActive { get; set; }
        [Column("dteLastActionDateTime", TypeName = "datetime")]
        public DateTime DteLastActionDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DteServerDateTime { get; set; }

        [ForeignKey(nameof(IntUserId))]
        [InverseProperty(nameof(TblUser.TblProduct))]
        public virtual TblUser IntUser { get; set; }
    }
}
