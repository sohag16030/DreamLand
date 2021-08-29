using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace StoreManagementSystem.Models
{
    [Table("tblUser")]
    public partial class TblUser
    {
        public TblUser()
        {
            TblProduct = new HashSet<TblProduct>();
        }

        [Key]
        [Column("intUserId")]
        public long IntUserId { get; set; }
        [Required]
        [Column("strUserName")]
        [StringLength(500)]
        public string StrUserName { get; set; }
        [Required]
        [Column("strUserRole")]
        [StringLength(500)]
        public string StrUserRole { get; set; }
        public bool IsActive { get; set; }
        [Column("dteLastActionDateTime", TypeName = "datetime")]
        public DateTime DteLastActionDateTime { get; set; }
        [Column("dteServerDateTime", TypeName = "datetime")]
        public DateTime DteServerDateTime { get; set; }

        [InverseProperty("IntUser")]
        public virtual ICollection<TblProduct> TblProduct { get; set; }
    }
}
