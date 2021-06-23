using System;
using System.Collections.Generic;

namespace TestWeb.Models.Write
{
    public partial class TblPurchaseRequestType
    {
        public TblPurchaseRequestType()
        {
            TblRequestForQuotationHeader = new HashSet<TblRequestForQuotationHeader>();
        }

        public long IntPurchaseRequestTypeId { get; set; }
        public string StrPurchaseRequestTypeName { get; set; }
        public long IntActionBy { get; set; }
        public DateTime DteLastActionDateTime { get; set; }
        public DateTime DteServerDateTime { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<TblRequestForQuotationHeader> TblRequestForQuotationHeader { get; set; }
    }
}
