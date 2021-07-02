using System;
using System.Collections.Generic;

namespace TestWeb.Models.Read
{
    public partial class TblStudent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal? Cgpa { get; set; }
    }
}
