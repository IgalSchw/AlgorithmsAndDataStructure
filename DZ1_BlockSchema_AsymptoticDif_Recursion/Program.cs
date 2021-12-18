using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgoDataSructure
{
    class program
    {
        class TestCase
        {
            public int N { get; set; }
            public long ExpectedN { get; set; }
            public bool Expected { get; set; }
            public Exception ExpectedException { get; set; }
        }

        // Test prime number
        static void TestNumber(TestCase testCase)
        {
            try
            {
                var actual = IsSimple(testCase.N);

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
                    Console.WriteLine("Description: " + ex.Message);
                    Console.WriteLine("INVALID TEST");
                }
            }
        }

        // algorithm to check if the number is simple
        static bool IsSimple(int n)
        {
            if (n < 0)
            {
                throw new ArgumentException("The number must be positive");
            }

            int d = 0, i = 2;

            while (i < n)
            {
                if (n % i == 0)
                    d++;

                i++;
            }

            if (d == 0)
                return true;
            else
                return false;
        }

        // Test fibonacci function
        static void TestFibo(TestCase testCase, bool isRecursionFuncTest)
        {
            try
            {
                var res = 1;

                if (isRecursionFuncTest)
                    res = Fibonacci(testCase.N); // recursion
                else
                    res = FibonacciSeries(testCase.N); // iterate


                if (res == testCase.ExpectedN)
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
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("Description: " + ex.Message);
                    Console.WriteLine("INVALID TEST");
                }
            }
        }

        // recursion
        static int Fibonacci(int n)
        {
            if (n == 1 || n == 0)
                return n;

            return Fibonacci(n - 2) + Fibonacci(n - 1);
        }

        // iterate (using loop)
        static int FibonacciSeries(int n)
        {
            int firstnumber = 0, secondnumber = 1, result = 0;

            if (n == 0) return 0; //To return the first Fibonacci number   
            if (n == 1) return 1; //To return the second Fibonacci number   


            for (int i = 2; i <= n; i++)
            {
                result = firstnumber + secondnumber;
                firstnumber = secondnumber;
                secondnumber = result;
            }

            return result;
        }

        static void Main(string[] args)
        {
            #region 1. Напишите на C# функцию согласно блок-схеме

            int n;
            TestCase testcase = null;
            Console.WriteLine("Please enter N integer number to check if the number is simple or not.");

            // user input
            try
            {
                n = int.Parse(Console.ReadLine());

                // dynamic test
                testcase = new TestCase()
                {
                    N = n,
                    Expected = true, // true = simple, false = not simple
                    ExpectedException = null
                };
                TestNumber(testcase);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Description: " + ex.Message);
                Console.WriteLine("INVALID TEST");
            }

            // *** static ***
            // simple number
            TestCase testCase1 = new TestCase()
            {
                N = 5,
                Expected = false,
                ExpectedException = null
            };

            // not simple number
            TestCase testCase2 = new TestCase()
            {
                N = 4,
                Expected = false,
                ExpectedException = null
            };

            TestNumber(testCase1);
            TestNumber(testCase2);
            #endregion

            Console.WriteLine("\n\n\n");

            #region 3. Реализуйте функцию вычисления числа Фибоначчи
            Console.WriteLine("Please enter number of steps in fibonacci sequence");
            int FiboNumber = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Fibonacci recursion result: " + Fibonacci(FiboNumber));

            Console.WriteLine("Fibonacci Iterate result:" + FibonacciSeries(FiboNumber));

            // static input
            TestCase testCaseFib1 = new TestCase()
            {
                N = 18,
                ExpectedN = 2584,
                ExpectedException = null
            };

            TestCase testCaseFib2 = new TestCase()
            {
                N = 10,
                ExpectedN = 54,
                ExpectedException = null
            };

            TestFibo(testCaseFib1, true);
            TestFibo(testCaseFib1, false);

            #endregion
        }

        #region 2. Посчитайте сложность функции

        // = O(1+ N^3 + 1 + 1 + 1)
        // = O(N^3)
        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0; // O(1)

            for (int i = 0; i < inputArray.Length; i++) // O(N)
            {
                for (int j = 0; j < inputArray.Length; j++) // O(N)
                {
                    for (int k = 0; k < inputArray.Length; k++) // O(N)
                    {
                        int y = 0; // O(1)

                        if (j != 0)
                        {
                            y = k / j;
                        }

                        sum += inputArray[i] + i + k + j + y; // O(1)
                    }
                }
            }

            return sum; // O(1)
        }
        #endregion     
    }
}


