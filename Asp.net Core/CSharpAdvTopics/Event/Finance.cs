using System;
using System.Collections.Generic;
using System.Text;

namespace Event
{
    public class Finance
    {
        public EmployeeSeperator _employeeSeperator { set; get;  }

        public Finance(EmployeeSeperator employeeSeperator)
        {
            _employeeSeperator = employeeSeperator;
            _employeeSeperator.EmployeeSeparatedEvent += EmployeeSeparatedEventHandler;
        }
        public void EmployeeSeparatedEventHandler()
        {
            Console.WriteLine("Employee is seperated from finace Department");
        }

    }
}
