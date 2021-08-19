using System;
using System.Collections.Generic;
using System.Text;

namespace Event
{
    public class EmployeeSeperator
    {
        public delegate void EmployeeSeparatedEventHandler();
        public event EmployeeSeparatedEventHandler EmployeeSeparatedEvent;

        public void Seperator()
        {
            if(EmployeeSeparatedEvent!=null)
              EmployeeSeparatedEvent();
        }
    }
}
