using System;
using System.Collections.Generic;

namespace TestWeb.Models.Write
{
    public partial class TblCourse
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Course { get; set; }
        public int Credit { get; set; }
        public decimal CreditFee { get; set; }
    }
}
