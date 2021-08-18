using System;

namespace Event
{
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeSeperator obj = new EmployeeSeperator();
            Finance obj2 = new Finance(obj);

            obj.Seperator();

        }
    }
}
