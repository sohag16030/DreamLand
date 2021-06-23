using System;
using System.Collections.Generic;

namespace TestWeb.Models.Read
{
    public partial class TblBusinessPartner
    {
        public TblBusinessPartner()
        {
            TblBusinessPartnerRequestForQuotationHeader = new HashSet<TblBusinessPartnerRequestForQuotationHeader>();
        }

        public long IntBusinessPartnerId { get; set; }
        public long IntAccountId { get; set; }
        public long IntBusinessUnitId { get; set; }
        public string StrBusinessPartnerCode { get; set; }
        public string StrBusinessPartnerName { get; set; }
        public string StrBusinessPartnerAddress { get; set; }
        public string StrContactNumber { get; set; }
        public string StrBin { get; set; }
        public string StrLicenseNo { get; set; }
        public string StrEmail { get; set; }
        public string StrNid { get; set; }
        public long? IntBusinessPartnerTypeId { get; set; }
        public string StrPartnerSalesType { get; set; }
        public long? IntTaxBracketId { get; set; }
        public string StrAttachmentLink { get; set; }
        public long IntActionBy { get; set; }
        public DateTime DteLastActionDateTime { get; set; }
        public DateTime DteServerDateTime { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TblBusinessPartnerRequestForQuotationHeader> TblBusinessPartnerRequestForQuotationHeader { get; set; }
    }
}
