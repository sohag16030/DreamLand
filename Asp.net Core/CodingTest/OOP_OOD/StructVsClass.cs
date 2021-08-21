//using System;

//namespace OOP_OOD
//{
//    class StructVsClass
//    {
//        //struct Location // Struct is value type
//        //{ 
//        //    public string Name { get; set; }
//        //    public int Distance { get; set; }

//        //    public Location(string name,int distance)
//        //    {
//        //        Name = name;
//        //        Distance = distance;
//        //    }

//        //    public string GetInfo()
//        //    {
//        //        var ans = $"{Name} {Distance}";
//        //        return ans;
//        //    }
//        //}
//        public class Location // class is reference type
//        {
//            public string Name { get; set; }
//            public int Distance { get; set; }

//            public Location(string name, int distance)
//            {
//                Name = name;
//                Distance = distance;
//            }

//            public string GetInfo()
//            {
//                var ans = $"{Name} {Distance}";
//                return ans;
//            }
//        }
//        static void Main(string[] args)
//        {
//            var obj = new Location("Dhaka", 5000);
//            var obj2 = obj;
//            obj2.Distance = 2000;
//            Console.WriteLine(obj.GetInfo());
//            Console.WriteLine(obj2.GetInfo());
//        }
//    }
//}
