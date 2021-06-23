using System;
using System.Collections.Generic;

namespace TestWeb.Models.Read
{
    public partial class TblPurchaseRequestHeader
    {
        public TblPurchaseRequestHeader()
        {
            TblPurchaseRequestRow = new HashSet<TblPurchaseRequestRow>();
        }

        public long IntPurchaseRequestId { get; set; }
        public string StrPurchaseRequestCode { get; set; }
        public long IntPurchaseRequestTypeId { get; set; }
        public string StrPurchaseRequestTypeName { get; set; }
        public long IntAccountId { get; set; }
        public string StrAccountName { get; set; }
        public long IntBusinessUnitId { get; set; }
        public string StrBusinessUnitName { get; set; }
        public long IntPurchaseOrganizationId { get; set; }
        public string StrPurchaseOrganizationName { get; set; }
        public long IntWarehouseId { get; set; }
        public string StrWarehouseName { get; set; }
        public string StrDeliveryAddress { get; set; }
        public DateTime DteRequestDate { get; set; }
        public string StrNarration { get; set; }
        public bool? IsApproved { get; set; }
        public bool? IsComplete { get; set; }
        public bool? IsClosed { get; set; }
        public long? IntClosedBy { get; set; }
        public string StrClosedBy { get; set; }
        public DateTime? DteClosedDateTime { get; set; }
        public long IntActionBy { get; set; }
        public DateTime DteLastActionDateTime { get; set; }
        public DateTime DteServerDateTime { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TblPurchaseRequestRow> TblPurchaseRequestRow { get; set; }
    }
}
