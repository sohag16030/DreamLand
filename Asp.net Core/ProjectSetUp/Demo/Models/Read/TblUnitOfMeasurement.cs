using System;
using System.Collections.Generic;

namespace TestWeb.Models.Read
{
    public partial class TblUnitOfMeasurement
    {
        public TblUnitOfMeasurement()
        {
            TblBusinessPartnerRequestForQuotationRow = new HashSet<TblBusinessPartnerRequestForQuotationRow>();
            TblItemBasicInfo = new HashSet<TblItemBasicInfo>();
            TblRequestForQuotationRow = new HashSet<TblRequestForQuotationRow>();
        }

        public long IntUomid { get; set; }
        public long IntAccountId { get; set; }
        public long IntBusinessUnitId { get; set; }
        public string StrUomName { get; set; }
        public string StrUomCode { get; set; }
        public long IntActionBy { get; set; }
        public DateTime DteLastActionDateTime { get; set; }
        public DateTime DteServerDateTime { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<TblBusinessPartnerRequestForQuotationRow> TblBusinessPartnerRequestForQuotationRow { get; set; }
        public virtual ICollection<TblItemBasicInfo> TblItemBasicInfo { get; set; }
        public virtual ICollection<TblRequestForQuotationRow> TblRequestForQuotationRow { get; set; }
    }
}
