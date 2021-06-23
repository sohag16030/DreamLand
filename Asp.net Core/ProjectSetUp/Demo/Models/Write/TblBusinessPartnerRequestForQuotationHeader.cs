using System;
using System.Collections.Generic;

namespace TestWeb.Models.Write
{
    public partial class TblBusinessPartnerRequestForQuotationHeader
    {
        public TblBusinessPartnerRequestForQuotationHeader()
        {
            TblBusinessPartnerRequestForQuotationRow = new HashSet<TblBusinessPartnerRequestForQuotationRow>();
        }

        public long IntPartnerRfqid { get; set; }
        public long IntRequestForQuotationId { get; set; }
        public long IntAccountId { get; set; }
        public long IntBusinessUnitId { get; set; }
        public long IntBusinessPartnerId { get; set; }
        public string StrSupplierRefNo { get; set; }
        public DateTime DteSupplierRefDate { get; set; }
        public string StrEmail { get; set; }
        public string StrContactNumber { get; set; }
        public DateTime DteIssueDate { get; set; }
        public DateTime? DteReleaseDate { get; set; }
        public string StrDocAttachmentLink { get; set; }
        public bool? IsQuotationReceived { get; set; }
        public bool? IsEmailSend { get; set; }
        public long IntLastActionBy { get; set; }
        public DateTime DteLastActionDateTime { get; set; }
        public DateTime DteServerDateTime { get; set; }
        public bool? IsActive { get; set; }

        public virtual TblBusinessUnit IntBusinessUnit { get; set; }
        public virtual TblRequestForQuotationHeader IntRequestForQuotation { get; set; }
        public virtual ICollection<TblBusinessPartnerRequestForQuotationRow> TblBusinessPartnerRequestForQuotationRow { get; set; }
    }
}
