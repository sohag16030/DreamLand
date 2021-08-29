using System;
using System.Collections.Generic;
using System.Text;

namespace LeaveManageMent
{
    public class LeaveSummary
    {
        public int LeaveSummaryId { get; set; }
        public string LeaveSummaryDescription { get; set; }
        public int LeaveTypeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duaration { get; set; }
        public string CommentByManager { get; set; }
        public string ReportedInLastPaySlips { get; set; }
        public Employee employee { get; set; }
    }
}
