//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace OOP_OOD
//{
//    //****overloading/static binding/complile time binding***
//    public class Parent
//    {
//        public int A(int x)
//        {
//            return x;
//        }
//    }
//    public class Child : Parent
//    {
//        public int A(int x, int y)
//        {
//            return x + y;
//        }
//    }
//    //***********************************************

//    //******overridding/Dynamic binding/Run time binding*****
//    public class Root
//    {
//        public virtual int B(int x)
//        {
//            return x;
//        }
//    }
//    public class Leaf : Root
//    {
//        public override int B(int x)
//        {
//            return x*x;
//        }
//    }
//    //***********************************************
//    //***********************Hiding*****************
//    public class Top
//    {
//        public  int B(int x)
//        {
//            return x;
//        }
//    }
//    public class Bottom : Top
//    {
//        public new int B(int x)
//        {
//            return x * x;
//        }
//    }
//    //***********************************************

//    class OverLoading_Overriding_HidingExample
//    {
//        public static void Main()
//        {
//            //var load = new Child();
//            //Console.WriteLine(load.A(10));
//            //Console.WriteLine(load.A(10,20));
//            //var root = new Root();
//            //Console.WriteLine(root.B(10));
//            //Root root2 = new Leaf();
//            //Console.WriteLine(root2.B(10));
//            var bottom = new Bottom();
//            Console.WriteLine(bottom.B(10));
//        }
//    }
   
//}
