using System;
using System.Collections.Generic;

namespace LeaveManageMent
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int DepartmentId { get; set; }
        public List<LeaveSummary> leaveSummaries { get; set; }
 
    }
}
