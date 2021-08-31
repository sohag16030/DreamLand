using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace StoreManagementSystem.Models
{
    [Table("Product")]
    public partial class Product
    {
        [Key]
        public long ProductId { get; set; }
        public long UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
        [Required]
        [StringLength(500)]
        public string ProductName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal ProductPrice { get; set; }
        public bool Active { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastActionDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ServerDateTime { get; set; }

        [ForeignKey(nameof(UserId))]
        [InverseProperty("Products")]
        public virtual User User { get; set; }
    }
}
