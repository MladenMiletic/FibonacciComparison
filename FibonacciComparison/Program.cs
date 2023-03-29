using System.Diagnostics;

namespace FibonacciComparison
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Fibonacci!");
            Console.WriteLine("NOTE: Fibonacci(0) = 0, Fibonacci(1) = 1");
            long n;
            while (true) 
            {
                Console.Write("Which n-th Fibonacci number are you interesed in: "); // Fibb: 0, 1, 1, 2, 3, 5, 8
                n = Convert.ToInt64(Console.ReadLine());
                if (n < 0)
                {
                    Console.WriteLine("The value of n must be 0 or greater!");
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine("Recursion:");
            Stopwatch stopwatch = Stopwatch.StartNew();
            long result_recursion = Fibonacci_Recursion(n);
            stopwatch.Stop();
            Console.WriteLine("Result: " + result_recursion);
            Console.WriteLine("Elapsed Time: " + stopwatch.ElapsedTicks);

            Console.WriteLine("Dynamic programming with lookup:");
            stopwatch = Stopwatch.StartNew();
            long?[] cache_dynamic = new long?[n+1];
            cache_dynamic[0] = 0;
            cache_dynamic[1] = 1;
            long? result_dynamic = Fibonacci_Dynamic_Programming(n, cache_dynamic);
            stopwatch.Stop();
            Console.WriteLine("Result: " + result_dynamic);
            Console.WriteLine("Elapsed Time: " + stopwatch.ElapsedTicks);

            Console.WriteLine("Classic approach:");
            stopwatch = Stopwatch.StartNew();
            long? result_classic = Fibonacci_Classic(n);
            stopwatch.Stop();
            Console.WriteLine("Result: " + result_classic);
            Console.WriteLine("Elapsed Time: " + stopwatch.ElapsedTicks);
        }


        private static long? Fibonacci_Dynamic_Programming(long n, long?[] cache)
        {
            if (cache[n] != null)
            {
                return cache[n];
            }
            cache[n] = Fibonacci_Dynamic_Programming(n-1, cache) + Fibonacci_Dynamic_Programming(n-2, cache);
            return cache[n];
        }

        private static long Fibonacci_Recursion(long n)
        {
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }
            return Fibonacci_Recursion(n - 1) + Fibonacci_Recursion(n - 2);
        }
        private static long Fibonacci_Classic(long n)
        {
            long first = 0;
            long second = 1;
            long third = 1;
            for (int i = 2; i <= n; i++) 
            {
                third = first + second;
                first = second;
                second = third;
            }
            return third;
        }
    }
}