using System;

namespace DelegatesIntro
{
    class Program
    {
        public delegate int CalculationSum1(int x);
        public delegate int CalculationSum2(int x, int y);

        static void Main(string[] args)
        {
            var sum = new CalculationSum1(Sum);
            var sum1 = new CalculationSum1(Sum1);
            var sum2 = new CalculationSum2(Sum);

            var sumN1 = sum1(10);
            var sumN2 = sum2(10, 20);
            var sumInvoke1 = sum1.Invoke(5);
            var sumInvoke2 = sum2.Invoke(10, 15);

            #region MultiCastDeligates
            var multicastDelegate = (CalculationSum1)Delegate.Combine(sum, sum1);
            multicastDelegate.Invoke(10);

            CalculationSum1 d = null;
            d += sum;
            d += sum1;
            d.Invoke(10);
            #endregion

            Console.ReadKey();
        }

        static int Sum(int x)
        {
            Console.WriteLine("Sum");
            return x;
        }

        static int Sum1(int x)
        {
            Console.WriteLine("Sum1");
            return x + 10;
        }

        static int Sum(int x, int y)
        {
            Console.WriteLine("Sum- X+Y");
            return x + y;
        }
    }
}
