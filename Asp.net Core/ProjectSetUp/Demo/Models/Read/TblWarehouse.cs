using System;
using System.Collections.Generic;

namespace TestWeb.Models.Read
{
    public partial class TblWarehouse
    {
        public TblWarehouse()
        {
            TblRequestForQuotationHeader = new HashSet<TblRequestForQuotationHeader>();
        }

        public long IntWarehouseId { get; set; }
        public long IntAccountId { get; set; }
        public string StrWarehouseCode { get; set; }
        public string StrWarehouseName { get; set; }
        public string StrWarehouseAddress { get; set; }
        public long? IntWarehouseTypeId { get; set; }
        public long IntActionBy { get; set; }
        public DateTime DteLastActionDateTime { get; set; }
        public DateTime DteServerDateTime { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<TblRequestForQuotationHeader> TblRequestForQuotationHeader { get; set; }
    }
}
