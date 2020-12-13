using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Laba16
{
    public static class Paralleler
    {
        public static void For()
        {
            Stopwatch stopwatch= new Stopwatch();
            stopwatch.Start();
            Generate(10000);
            stopwatch.Stop();
            Console.WriteLine($"General: {stopwatch.Elapsed}");
            stopwatch.Start();
            Parallel.For(1, 10000, Generate);
            stopwatch.Stop();
            Console.WriteLine($"Parallel: {stopwatch.Elapsed}");
        }
        public static void ForEach()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach (int vec in new List<int>{ 1000000, 1000000 })
            {
                Generate(vec);
            }
            stopwatch.Stop();
            Console.WriteLine($"General: {stopwatch.Elapsed}");
            stopwatch.Start();
            ParallelLoopResult result = Parallel.ForEach(new List<int> { 1000000, 1000000 }, Generate);
            stopwatch.Stop();
            Console.WriteLine($"Parallel: {stopwatch.Elapsed}");
        }
        public static void Generate(int n)
        {
            Random rand = new Random();
            List<int> vector = new List<int>(n);
            for (int i = 0; i < n; i++)
            {
                vector.Add(rand.Next(n));
            }
        }
        public static void DoubleTask(int n)
        {
            Parallel.Invoke(Display, () =>
            {
                Console.WriteLine($"Current ID: {Task.CurrentId}");
                Thread.Sleep(300);
                Generate(n);
            });
        }
        private static void Display()
        {
            Console.WriteLine($"Current ID: {Task.CurrentId}");
            Thread.Sleep(3000);
        }
    }
}