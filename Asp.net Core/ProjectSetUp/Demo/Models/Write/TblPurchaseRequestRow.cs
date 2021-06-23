using System;
using System.Collections.Generic;

namespace TestWeb.Models.Write
{
    public partial class TblPurchaseRequestRow
    {
        public long IntRowId { get; set; }
        public long IntPurchaseRequestId { get; set; }
        public long IntItemId { get; set; }
        public string StrItemName { get; set; }
        public string StrItemCode { get; set; }
        public long IntUoMid { get; set; }
        public string StrUoMname { get; set; }
        public decimal NumRequestQuantity { get; set; }
        public decimal? NumApprovedQuantity { get; set; }
        public decimal? NumPurchaseOrderQuantity { get; set; }
        public DateTime? DteRequiredDate { get; set; }
        public long? IntCostElementId { get; set; }
        public string StrCostElementName { get; set; }
        public long? IntCostcenterId { get; set; }
        public string StrCostCenterName { get; set; }
        public bool IsActive { get; set; }

        public virtual TblPurchaseRequestHeader IntPurchaseRequest { get; set; }
    }
}
