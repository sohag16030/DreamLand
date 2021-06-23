using System;

namespace TestWeb.Core
{
    public class BaseEntity
    {
        public long IntId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DteLastActionDateTime { get; set; }
        public DateTime? DteServerDateTime { get; set; }
    }
}