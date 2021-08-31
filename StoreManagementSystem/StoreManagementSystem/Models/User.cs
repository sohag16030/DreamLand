using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace StoreManagementSystem.Models
{
    [Table("User")]
    public partial class User
    {
        public User()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public long UserId { get; set; }
        [Required]
        [StringLength(500)]
        public string UserName { get; set; }
        [Required]
        [StringLength(500)]
        public string Password { get; set; }
        [Required]
        [StringLength(500)]
        public string ConfirmPassword { get; set; }
        [Required]
        [StringLength(500)]
        public string UserRole { get; set; }
        public bool Active { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime LastActionDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime ServerDateTime { get; set; }

        [InverseProperty(nameof(Product.User))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
