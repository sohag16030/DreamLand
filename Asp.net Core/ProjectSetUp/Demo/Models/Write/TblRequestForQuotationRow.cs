using System;
using System.Collections.Generic;

namespace TestWeb.Models.Write
{
    public partial class TblRequestForQuotationRow
    {
        public long IntRowId { get; set; }
        public long IntRequestForQuotationId { get; set; }
        public long IntItemId { get; set; }
        public long IntUoMid { get; set; }
        public decimal NumRfqquantity { get; set; }
        public long? IntReferenceId { get; set; }
        public string IntReferenceCode { get; set; }
        public decimal? NumReferenceQuantity { get; set; }
        public string StrDescription { get; set; }
        public bool IsActive { get; set; }

        public virtual TblRequestForQuotationHeader IntRequestForQuotation { get; set; }
    }
}
