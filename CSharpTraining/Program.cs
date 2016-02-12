using System;

namespace CSharpTraining
{
    public delegate int Transformer(int x, int y);
    public delegate int Transformer2(int x);
    public delegate void ProgressReporter(int percentComplete);
    internal class Program
    {
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
            ProgressReporter p = WriteToConsole;
            p += WriteToFile;
            Util.HardWork(p);

            Console.Write("press any key to exit ...");
            Console.ReadLine();
        }
        static void WriteToConsole(int percentComplete){ Console.WriteLine("{0}% completed",percentComplete); }
        static void WriteToFile(int percentComplete) { System.IO.File.WriteAllText("progress.txt", percentComplete.ToString());}
        public class Util
        {
            public static void Transform(int[] ints, Transformer2 trs)
            {
                int i;
                for (i = 0; i < ints.Length; i++)
                {
                    ints[i] = trs(ints[i]);
                }
            }

            public static void HardWork(ProgressReporter p)
            {
                for (var i = 1; i <= 10; i++)
                {
                    p(i*10);
                    System.Threading.Thread.Sleep(500);
                }
            }
        }
    }
}