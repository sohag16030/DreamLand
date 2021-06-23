using System;
using System.Collections.Generic;

namespace TestWeb.Models.Read
{
    public partial class TblItemBasicInfo
    {
        public TblItemBasicInfo()
        {
            TblBusinessPartnerRequestForQuotationRow = new HashSet<TblBusinessPartnerRequestForQuotationRow>();
            TblRequestForQuotationRow = new HashSet<TblRequestForQuotationRow>();
        }

        public long IntItemId { get; set; }
        public long IntAccountId { get; set; }
        public string StrItemCode { get; set; }
        public string StrItemName { get; set; }
        public string StrPartNumber { get; set; }
        public long IntItemTypeId { get; set; }
        public long IntItemCategoryId { get; set; }
        public long IntItemSubCategoryId { get; set; }
        public string StrHscode { get; set; }
        public long? IntUom { get; set; }
        public long IntActionBy { get; set; }
        public DateTime DteLastActionDateTime { get; set; }
        public DateTime DteServerDateTime { get; set; }
        public bool? IsActive { get; set; }

        public virtual TblUnitOfMeasurement IntUomNavigation { get; set; }
        public virtual ICollection<TblBusinessPartnerRequestForQuotationRow> TblBusinessPartnerRequestForQuotationRow { get; set; }
        public virtual ICollection<TblRequestForQuotationRow> TblRequestForQuotationRow { get; set; }
    }
}
