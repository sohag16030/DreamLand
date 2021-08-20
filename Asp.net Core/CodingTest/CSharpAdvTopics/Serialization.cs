//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.Text;

//namespace CSharpAdvTopics
//{
//    [Serializable]
//    public class Student
//    {
//        public int StudentId { get; set; }
//        public string StudentName { get; set; }
//    }
//    class Serialization
//    {
//       public static void Main()
//        {
//            var student = new Student()
//            {
//                StudentId = 1,
//                StudentName = "Dimond"
//            };

//            var formatter = new BinaryFormatter();
//            var streamSerialize = new FileStream(@"G:\NewFile.txt", FileMode.Create, FileAccess.Write);

//            formatter.Serialize(streamSerialize, student);
//            streamSerialize.Close();

//            var streamDesirialize = new FileStream(@"G:\NewFile.txt", FileMode.Open, FileAccess.Read);
//            var deStudent = (Student)formatter.Deserialize(streamDesirialize);
//            Console.WriteLine(deStudent.StudentId);
//            Console.WriteLine(deStudent.StudentName);

//        }
//    }
//}
