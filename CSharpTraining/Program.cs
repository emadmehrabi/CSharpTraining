using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpTraining
{
    public delegate int Transformer(int x, int y);
    public delegate int Transformer2(int x);
    public delegate void ProgressReporter(int percentComplete);

    //public delegate bool FilterDelegate(Person p);

    internal class Program
    {
        //static void DisplayPeople(string title, IEnumerable<Person> people, FilterDelegate filter)
        //{
        //    Console.WriteLine(title);
        //    foreach (var p in people.Where(p => filter(p)))
        //    {
        //        Console.WriteLine("{0}, {1} years old", p.Name, p.Age);
        //    }
        //    Console.Write("\n\n");
        //}
        //static bool IsChild(Person p){return p.Age <= 18;}
        //static bool IsAdult(Person p){return p.Age >= 18;}
        //static bool IsSenior(Person p){return p.Age >= 65;}

        private static void Main()
        {
            //Console.WriteLine("541531".StringToNumber());
            //Console.WriteLine("damE".StringReverse());
            //Console.WriteLine("emad".IsCaptalized());

            //Anonymous types contain one or more public read-only properties.
            //var v = new { Amount = 108, Message = "Hello" };
            // Rest the mouse pointer over v.Amount and v.Message in the following statement to verify that their inferred types are int and string.
            //Console.WriteLine(v.Amount + v.Message);

            //create delegate instance
            //Transformer transformer = MyMathMethods.Sum;
            //Console.WriteLine(transformer(5, 3)); //8

            //transformer = MyMathMethods.Subtractor;
            //Console.WriteLine(transformer(5, 3).ToString()); //2

            //Transformer2 t2 = MyMathMethods.Square;
            //int[] values = {1,2,3};
            //Util.Transform(values,t2);
            //foreach (var value in values)
            //{
            //    Console.Write(value + " "); // 1 4 9
            //}

            // Multicast delegate
            //ProgressReporter p = WriteToConsole;
            //p += WriteToFile;
            //Util.HardWork(p);

            //Console.Write("press any key to exit ...");

            //List<Person> people = new List<Person>
            //{
            //    new Person { Name = "John", Age = 41 },
            //    new Person { Name = "Jane", Age = 69 },
            //    new Person { Name = "Jake", Age = 12 },
            //    new Person { Name = "Jessie", Age = 25 }
            //};
            //DisplayPeople("Children:", people, IsChild);
            //DisplayPeople("Adults:", people, IsAdult);
            //DisplayPeople("Seniors:", people, IsSenior);

            var studentQuery =
                from student in Students
                where student.Scores[0] > 90 && student.Scores[3] < 80
                orderby student.Last descending
                select student;

            var studentQuery2 =
                Students.GroupBy(student => student.Last[0]).OrderByDescending(student => student.Key);

            var studentQuery3 =
                Students.Select(
                    student =>
                        new
                        {
                            student,
                            sum = student.Scores[0] + student.Scores[1] + student.Scores[2] + student.Scores[3]
                        })
                    .Select(@t => @t.sum);
            var studentQuery4 =
                Students.Where(s => s.Last == "Garcia").Select
                (student => new
                {
                    student,
                    scores = student.Scores[0]
                
                });

            foreach (var std in studentQuery4)
            {
                Console.WriteLine(std);
            }

            double averageScore = studentQuery3.Average();
            Console.WriteLine("Class average score = {0}", averageScore);

            foreach (var studentGroup in studentQuery2)
            {
                Console.WriteLine(studentGroup.Key);
                foreach (var student in studentGroup)
                {
                    Console.WriteLine("{0},{1},{2}",student.Id,student.First,student.Last);
                }
            }
            Console.ReadLine();
        }

        public class Student
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int Id { get; set; }
            public List<int> Scores;
        }

        static readonly List<Student> Students = new List<Student>
            {
                new Student {First="Svetlana", Last="Omelchenko", Id=111, Scores= new List<int> {97, 92, 81, 60}},
                new Student {First="Claire", Last="O'Donnell", Id=112, Scores= new List<int> {75, 84, 91, 39}},
                new Student {First="Sven", Last="Mortensen", Id=113, Scores= new List<int> {88, 94, 65, 91}},
                new Student {First="Cesar", Last="Garcia", Id=114, Scores= new List<int> {97, 89, 85, 82}},
                new Student {First="Debra", Last="Garcia", Id=115, Scores= new List<int> {35, 72, 91, 70}},
                new Student {First="Fadi", Last="Fakhouri", Id=116, Scores= new List<int> {99, 86, 90, 94}},
                new Student {First="Hanying", Last="Feng", Id=117, Scores= new List<int> {93, 92, 80, 87}},
                new Student {First="Hugo", Last="Garcia", Id=118, Scores= new List<int> {92, 90, 83, 78}},
                new Student {First="Lance", Last="Tucker", Id=119, Scores= new List<int> {68, 79, 88, 92}},
                new Student {First="Terry", Last="Adams", Id=120, Scores= new List<int> {99, 82, 81, 79}},
                new Student {First="Eugene", Last="Zabokritski", Id=121, Scores= new List<int> {96, 85, 91, 60}},
                new Student {First="Michael", Last="Tucker", Id=122, Scores= new List<int> {94, 92, 91, 91} }
            };

        //static void WriteToConsole(int percentComplete) => Console.WriteLine("{0}% completed",percentComplete);
        //static void WriteToFile(int percentComplete) => File.WriteAllText("progress.txt", percentComplete.ToString());

        //public class Util
        //{
        //    public static void Transform(int[] ints, Transformer2 trs)
        //    {
        //        int i;
        //        for (i = 0; i < ints.Length; i++)
        //        {
        //            ints[i] = trs(ints[i]);
        //        }
        //    }

        //    public static void HardWork(ProgressReporter p)
        //    {
        //        for (var i = 1; i <= 10; i++)
        //        {
        //            p(i*10);
        //            Thread.Sleep(500);
        //        }
        //    }
        //}

    }
}