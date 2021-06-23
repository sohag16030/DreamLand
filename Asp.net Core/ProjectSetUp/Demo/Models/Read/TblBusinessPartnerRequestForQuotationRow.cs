using System;
using System.Collections.Generic;

namespace TestWeb.Models.Read
{
    public partial class TblBusinessPartnerRequestForQuotationRow
    {
        public long IntRowId { get; set; }
        public long IntPartnerRfqid { get; set; }
        public long IntItemId { get; set; }
        public long IntUoMid { get; set; }
        public decimal NumRequestQuantity { get; set; }
        public decimal? NumRate { get; set; }
        public decimal? NumValue { get; set; }
        public bool? IsSelected { get; set; }
        public string StrSelectionComments { get; set; }
        public string StrRemarks { get; set; }
        public long IntActionBy { get; set; }
        public DateTime DteLastActionDateTime { get; set; }
        public DateTime DteServerDateTime { get; set; }
        public bool? IsActive { get; set; }

        public virtual TblItemBasicInfo IntItem { get; set; }
        public virtual TblBusinessPartnerRequestForQuotationHeader IntPartnerRfq { get; set; }
        public virtual TblUnitOfMeasurement IntUoM { get; set; }
    }
}
