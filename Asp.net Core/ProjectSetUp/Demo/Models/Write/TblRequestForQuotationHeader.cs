using System;
using System.Collections.Generic;

namespace TestWeb.Models.Write
{
    public partial class TblRequestForQuotationHeader
    {
        public TblRequestForQuotationHeader()
        {
            TblBusinessPartnerRequestForQuotationHeader = new HashSet<TblBusinessPartnerRequestForQuotationHeader>();
            TblRequestForQuotationRow = new HashSet<TblRequestForQuotationRow>();
        }

        public long IntRequestForQuotationId { get; set; }
        public string StrRequestForQuotationCode { get; set; }
        public DateTime DteRfqdate { get; set; }
        public long IntAccountId { get; set; }
        public long IntBusinessUnitId { get; set; }
        public long IntPurchaseOrganizationId { get; set; }
        public long IntWarehouseId { get; set; }
        public long IntRequestTypeId { get; set; }
        public string StrReferenceTypeName { get; set; }
        public long IntCurrencyId { get; set; }
        public DateTime DteValidTillDate { get; set; }
        public long? IntApprovedBy { get; set; }
        public DateTime? DteApprovalDate { get; set; }
        public bool IsApproved { get; set; }
        public long IntActionBy { get; set; }
        public DateTime DteLastActionDateTime { get; set; }
        public DateTime DteServerDateTime { get; set; }
        public bool? IsActive { get; set; }

        public virtual TblBusinessUnit IntBusinessUnit { get; set; }
        public virtual TblPurchaseOrganization IntPurchaseOrganization { get; set; }
        public virtual TblPurchaseRequestType IntRequestType { get; set; }
        public virtual ICollection<TblBusinessPartnerRequestForQuotationHeader> TblBusinessPartnerRequestForQuotationHeader { get; set; }
        public virtual ICollection<TblRequestForQuotationRow> TblRequestForQuotationRow { get; set; }
    }
}
