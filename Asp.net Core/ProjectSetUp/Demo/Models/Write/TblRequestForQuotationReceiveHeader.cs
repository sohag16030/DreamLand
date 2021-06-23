using System;
using System.Collections.Generic;

namespace TestWeb.Models.Write
{
    public partial class TblRequestForQuotationReceiveHeader
    {
        public TblRequestForQuotationReceiveHeader()
        {
            TblRequestForQuotationReceiveRow = new HashSet<TblRequestForQuotationReceiveRow>();
        }

        public long IntPartnerRfqid { get; set; }
        public long IntRequestForQuotationId { get; set; }
        public string StrRequestForQuotationCode { get; set; }
        public long IntAccountId { get; set; }
        public long IntBusinessUnitId { get; set; }
        public long IntSupplierId { get; set; }
        public string StrSupplierName { get; set; }
        public string StrSupplierCode { get; set; }
        public string StrSupplierAddress { get; set; }
        public string StrSupplierRefNo { get; set; }
        public DateTime DteSupplierRefDate { get; set; }
        public string StrEmail { get; set; }
        public string StrContactNumber { get; set; }
        public DateTime DteIssueDate { get; set; }
        public DateTime? DteReleaseDate { get; set; }
        public string StrDocAttachmentLink { get; set; }
        public bool? IsQuotationReceived { get; set; }
        public bool? IsEmailSend { get; set; }
        public long IntActionBy { get; set; }
        public DateTime DteLastActionDateTime { get; set; }
        public DateTime DteServerDateTime { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<TblRequestForQuotationReceiveRow> TblRequestForQuotationReceiveRow { get; set; }
    }
}
