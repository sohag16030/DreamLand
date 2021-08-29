using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_OOD
{
    public class Calculator
    {
        public int A { get; set; }
        public int B { get; set; }
        public Calculator(int x,int y)
        {
            A = x;
            B = y;
        }
        public static Calculator operator -(Calculator c1)
        {
            c1.A = -c1.A;
            c1.B = -c1.B;
            return c1;
        }
        public void Print()
        {
            Console.WriteLine(A);
            Console.WriteLine(B);
        }
    }
    class OperatiorOverloading
    {
        public static void Main()
        {
            Calculator cal = new Calculator(-5, 10);
            cal = -cal;
            cal.Print();

        }
    }
}
