using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;

namespace DZ3_Class_Structure_Distance
{
    public class Program
    {

        public static int NumIteration = 2;
        public static double[] arr;

        // class
        //[SimpleJob(BenchmarkDotNet.Engines.RunStrategy.ColdStart, launchCount:50)] // different strategies
        public class PointClass
        {
            public double X1;
            public double Y1;

            public double X2;
            public double Y2;

            [Benchmark]
            public float PointDistanceFloat()
            {
                float x = (float)(this.X1 - this.X2);
                float y = (float)(this.Y1 - this.Y2);
                return MathF.Sqrt((x * x) + (y * y));
            }


            [Benchmark]
            public double PointDistancedouble()
            {
                double x = this.X1 - this.X2;
                double y = this.Y1 - this.Y2;
                return Math.Sqrt((x * x) + (y * y));
            }
        }

        // struct
        public struct PointStruct
        {
            public double X1;
            public double Y1;

            public double X2;
            public double Y2;


            [Benchmark]
            public float PointDistanceFloat()
            {
                float x = (float)(this.X1 - this.X2);
                float y = (float)(this.Y1 - this.Y2);
                return MathF.Sqrt((x * x) + (y * y));
            }


            [Benchmark]
            public double PointDistancedouble()
            {
                double x = this.X1 - this.X2;
                double y = this.Y1 - this.Y2;
                return Math.Sqrt((x * x) + (y * y));
            }
        }


        public static void GenerateArrayValues()
        {
            Random rnd = new Random();

            for (int i = 0; i < NumIteration; i++)
            {
                arr[i] = rnd.NextDouble();

            }
        }

        static void Main(string[] args)
        {
            // for few types several benchmarks
            //var summary = BenchmarkRunner.Run<PointClass>();


            PointClass pClass = new PointClass();
            pClass.X1 = 10;
            pClass.X2 = 20;

            pClass.Y1 = 20;
            pClass.Y2 = 25;



            PointStruct pStruct = new PointStruct();
            pStruct.X1 = 10;
            pStruct.X2 = 20;

            pStruct.Y1 = 20;
            pStruct.Y2 = 25;

            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);

        }
    }
}
