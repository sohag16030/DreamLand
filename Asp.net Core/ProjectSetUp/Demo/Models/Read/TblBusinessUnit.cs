using System;
using System.Collections.Generic;

namespace TestWeb.Models.Read
{
    public partial class TblBusinessUnit
    {
        public TblBusinessUnit()
        {
            TblBusinessPartnerRequestForQuotationHeader = new HashSet<TblBusinessPartnerRequestForQuotationHeader>();
            TblPurchaseOrganizationBusinessUnitConfig = new HashSet<TblPurchaseOrganizationBusinessUnitConfig>();
            TblRequestForQuotationHeader = new HashSet<TblRequestForQuotationHeader>();
        }

        public long IntBusinessUnitId { get; set; }
        public long IntAccountId { get; set; }
        public string StrBusinessUnitCode { get; set; }
        public string StrBusinessUnitName { get; set; }
        public string StrBusinessUnitAddress { get; set; }
        public long IntActionBy { get; set; }
        public DateTime DteLastActionDateTime { get; set; }
        public DateTime DteServerDateTime { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<TblBusinessPartnerRequestForQuotationHeader> TblBusinessPartnerRequestForQuotationHeader { get; set; }
        public virtual ICollection<TblPurchaseOrganizationBusinessUnitConfig> TblPurchaseOrganizationBusinessUnitConfig { get; set; }
        public virtual ICollection<TblRequestForQuotationHeader> TblRequestForQuotationHeader { get; set; }
    }
}
