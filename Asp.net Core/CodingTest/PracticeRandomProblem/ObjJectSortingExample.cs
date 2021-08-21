using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PracticeRandomProblem
{
    class ObjJectSortingExample
    {
        public class Student
        {
            public int StudentId { get; set; }
            public int StudentAge { get; set; }
            public int StudentWeight { get; set; }
            public int StudentMark { get; set; }
        }

        public static void Main()
        {
            var student1 = new Student { StudentId = 1, StudentAge = 6, StudentWeight = 40, StudentMark = 50 };
            var student2 = new Student { StudentId = 2, StudentAge = 7, StudentWeight = 41, StudentMark = 50 };
            var student3 = new Student { StudentId = 3, StudentAge = 6, StudentWeight = 40, StudentMark = 50 };
            var student4 = new Student { StudentId = 4, StudentAge = 7, StudentWeight = 40, StudentMark = 50 };
            var student5 = new Student { StudentId = 5, StudentAge = 5, StudentWeight = 45, StudentMark = 60 };
            var student6 = new Student { StudentId = 6, StudentAge = 5, StudentWeight = 45, StudentMark = 50 };
            var student7 = new Student { StudentId = 7, StudentAge = 5, StudentWeight = 45, StudentMark = 50 };

            var stuList = new List<Student>();
            stuList.Add(student6);
            stuList.Add(student5);
            stuList.Add(student4);
            stuList.Add(student3);
            stuList.Add(student2);
            stuList.Add(student1);
            stuList.Add(student7);

            stuList.Sort(Compare);

            foreach (var item in stuList)
            {
                Console.WriteLine($"{item.StudentId} {item.StudentAge} {item.StudentWeight} {item.StudentMark}");
            }
        }

        public static int Compare(Student x, Student y)
        {

            if (x.StudentAge == y.StudentAge)
            {
                if (x.StudentWeight == y.StudentWeight)
                {
                    if (x.StudentMark == y.StudentMark)
                    {
                        return x.StudentId.CompareTo(y.StudentId);
                    }
                    return x.StudentMark.CompareTo(y.StudentMark);
                }
                return x.StudentWeight.CompareTo(y.StudentWeight);
            }
            return x.StudentAge.CompareTo(y.StudentAge);

        }
    }
}
