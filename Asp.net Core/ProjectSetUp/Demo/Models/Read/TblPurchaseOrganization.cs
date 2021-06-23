using System;
using System.Collections.Generic;

namespace TestWeb.Models.Read
{
    public partial class TblPurchaseOrganization
    {
        public TblPurchaseOrganization()
        {
            TblPurchaseOrganizationBusinessUnitConfig = new HashSet<TblPurchaseOrganizationBusinessUnitConfig>();
            TblRequestForQuotationHeader = new HashSet<TblRequestForQuotationHeader>();
        }

        public long IntPurchaseOrganizationId { get; set; }
        public long IntAccountId { get; set; }
        public string StrPurchaseOrganization { get; set; }
        public long IntActionBy { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DteServerDateTime { get; set; }
        public DateTime DteLastActionDateTime { get; set; }

        public virtual ICollection<TblPurchaseOrganizationBusinessUnitConfig> TblPurchaseOrganizationBusinessUnitConfig { get; set; }
        public virtual ICollection<TblRequestForQuotationHeader> TblRequestForQuotationHeader { get; set; }
    }
}
