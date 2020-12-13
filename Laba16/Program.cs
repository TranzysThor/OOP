using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Threading;
using System.Threading.Tasks;
using static Laba16.Tasks;
using static Laba16.Paralleler;

namespace Laba16
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource ct = new CancellationTokenSource();
            CancellationToken token = ct.Token;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Task vectorTask = new Task(() => VectorMultiplication(token));
            vectorTask.Start();
            ct.Cancel();
            vectorTask.Wait();
            stopwatch.Stop();
            Console.WriteLine($"Task ID: {vectorTask.Id}");
            Console.WriteLine($"Task Status: {vectorTask.Status}");
            Console.WriteLine(stopwatch.Elapsed);
            Task<double> task1 = new Task<double>(Task1);
            Task<double> task2 = task1.ContinueWith(Task2);
            Task<double> task3 = task2.ContinueWith(Task3);
            Task task4 = task3.ContinueWith(Task4);
            task1.Start();
            task4.Wait();
            For();
            ForEach();
            DoubleTask(100000);
            Console.WriteLine();
            Task task = DisplayResultAsync();
            task.Wait();
        }
    }
}