using System;
using System.Collections.Generic;

namespace TestWeb.Models.Read
{
    public partial class TblCurrency
    {
        public TblCurrency()
        {
            TblRequestForQuotationHeader = new HashSet<TblRequestForQuotationHeader>();
        }

        public long IntCurrencyId { get; set; }
        public string StrCurrencyName { get; set; }
        public string StrCurrencyCode { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<TblRequestForQuotationHeader> TblRequestForQuotationHeader { get; set; }
    }
}
