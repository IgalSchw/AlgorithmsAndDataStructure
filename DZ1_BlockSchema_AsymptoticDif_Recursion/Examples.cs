using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoDataSructure.Lesson1
{
    /*
    class Program
    {
        public class TestCase
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }
        static int SumPositive(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                throw new ArgumentException("x and y must be positive");
            }
            return x + y;
        }
        static void TestSum(TestCase testCase)
        {
            try
            {
                var actual = SumPositive(testCase.X, testCase.Y);
                if (actual == testCase.Expected)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
            catch (Exception ex)
            {
                if (testCase.ExpectedException != null)
                {
                    //TODO add type exception tests;
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
        }
        
        static void Loop(int a, int b)
        {
            Console.WriteLine(a);
            if (a < b)
                Loop(a + 1, b);
        }
        static int Factorial(int n)
        {
            if (n == 0)
                return 1;

            return n * (Factorial(n - 1));
        }
        static int FactorialStruc(int n)
        {
            if (n == 0)
                return 1;

            int factorial = 1;

            Stack<int> stack = new Stack<int>();
            stack.Push(n);

            while (stack.Count > 0)
            {
                int currentN = stack.Pop();
                factorial *= currentN;

                int nextN = currentN - 1;

                if (nextN > 0)
                    stack.Push(currentN - 1);

            }

            return factorial;
        }


        static void Main(string[] args)
        {
            Loop(0, 10);
            Console.WriteLine("\n");
            Console.WriteLine("Factorial Number");
            Console.WriteLine(Factorial(5));

            Console.WriteLine("Factorial Structure Number");
            Console.WriteLine(FactorialStruc(5));


            // 1.  create test objects
            var testCase1 = new TestCase()
            {
                X = 6,
                Y = 4,
                Expected = 10,
                ExpectedException = null
            };


            var testCase2 = new TestCase()
            {
                X = 1,
                Y = 4,
                Expected = 5,
                ExpectedException = null
            };
            TestSum(testCase1);
            TestSum(testCase2);
        }
    }  
 */
}
