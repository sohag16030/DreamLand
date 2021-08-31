using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace StoreManagementSystem.Models
{
    [Table("ActionActivity")]
    public partial class ActionActivity
    {
        [Key]
        public long AutoId { get; set; }
        public long ActionId { get; set; }
        [Required]
        [StringLength(500)]
        public string ActionName { get; set; }
        public bool ActionStatus { get; set; }
    }
}
