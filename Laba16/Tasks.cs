using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Threading.Tasks;

namespace Laba16
{
    public static class Tasks
    {
        public static void VectorMultiplication(CancellationToken token)
        {
            Random rand = new Random();
            int number = 10;
            List<int> vector = new List<int>(100000);
            for (int i = 0; i < 100000; i++)
            {
                vector.Add(rand.Next(1, 100));
            }

            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Operation has been cancelled");
                return;
            }
                
            for (int i = 0; i < 100000; i++)
            {
                vector[i] *= number;
            }
        }

        public static double Task1()
        {
            return Math.PI * 8;
        }

        public static double Task2(Task t)
        {
            return Math.E;
        }

        public static double Task3(Task t)
        {
            return Math.Exp(10);
        }

        public static double Task4(Task t)
        {
            return Task1() * Task2(t) * Task3(t);
        }
        public static Task<int> FactorialAsync(int x)
        {
            int result = 1;
            return Task.Run(() =>
            {
                
                for (int i = 1; i <= x; i++)
                {
                    result *= i;
                }
                Thread.Sleep(2000);
                return result;
            });
        }
        public static async Task DisplayResultAsync()
        {
            int result = await FactorialAsync(5);
            Console.WriteLine($"Factorial of 5 is {result}");
        }
    }
}