using System;
using System.Collections.Generic;

namespace TestWeb.Models.Read
{
    public partial class TblPurchaseOrganizationBusinessUnitConfig
    {
        public long IntConfigId { get; set; }
        public long IntPurchaseOrganizationId { get; set; }
        public long IntAccountId { get; set; }
        public long IntBusinessUnitId { get; set; }
        public long IntActionBy { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastActionDateTime { get; set; }
        public DateTime DteServerDateTime { get; set; }

        public virtual TblBusinessUnit IntBusinessUnit { get; set; }
        public virtual TblPurchaseOrganization IntPurchaseOrganization { get; set; }
    }
}
