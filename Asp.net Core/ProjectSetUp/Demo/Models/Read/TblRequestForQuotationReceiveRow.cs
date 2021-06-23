using System;
using System.Collections.Generic;

namespace TestWeb.Models.Read
{
    public partial class TblRequestForQuotationReceiveRow
    {
        public long IntRowId { get; set; }
        public long IntPartnerRfqid { get; set; }
        public long IntItemId { get; set; }
        public string StrItemCode { get; set; }
        public string StrItemName { get; set; }
        public long IntUoMid { get; set; }
        public string StrUoMname { get; set; }
        public decimal NumRequestQuantity { get; set; }
        public decimal NumRate { get; set; }
        public decimal NumValue { get; set; }
        public bool? IsSelected { get; set; }
        public string StrSelectionComments { get; set; }
        public string StrNarration { get; set; }
        public long IntActionBy { get; set; }
        public DateTime DteLastActionDateTime { get; set; }
        public DateTime DteServerDateTime { get; set; }
        public bool? IsActive { get; set; }

        public virtual TblRequestForQuotationReceiveHeader IntPartnerRfq { get; set; }
    }
}
