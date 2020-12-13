using System;
using System.ComponentModel;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace Laba15
{
    
    public static class ThreadOperations
    {
        static object locker = new object();
        public static void ListProcesses()
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                try
                    {
                        Console.WriteLine($"ID: {process.Id}\n" +
                                          $"Name: {process.ProcessName}\n" +
                                          $"Priority: {process.PriorityClass}\n" +
                                          $"Start Time: {process.StartTime}\n"  +
                                          $"Current State: {process.Responding}\n" +
                                          $"Total Processor Use Time: {process.TotalProcessorTime}\n");
                    }
                    catch (Win32Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Current Process Cannot Be Accessed");
                    }
            }
        }

        public static void GetCurrentDomain()
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            Console.WriteLine($"Domain Name: {currentDomain.FriendlyName}");
            Console.WriteLine($"Base Directory: {currentDomain.BaseDirectory}");
            Console.WriteLine("Assemblies:");
            foreach (var assembly in currentDomain.GetAssemblies())
            { 
                Console.WriteLine(assembly.GetName().Name);
            }
        }

        public static void SetRemoteThread()
        {
            Console.WriteLine("Thread");
            for (int i = 2; i <= 10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(400);
            }
        }
        public static void Even(object n)
        {
            bool acquiredLock = false;
            try
            {
                Monitor.Enter(locker, ref acquiredLock);
                int limit = (int) n;
                for (int i = 0; i < limit; i++)
                {
                    if (i % 2 == 0 && i != 0)
                    {
                        using (StreamWriter sw = new StreamWriter(@"D:\2_Course\OOP_1sem\Numbers.txt", true))
                        {
                            sw.WriteLine($"Thread 1: {i}");
                            Console.WriteLine($"Thread 1: {i}");
                            Thread.Yield();
                        }
                    }
                }
            }
            finally
            {
                if(acquiredLock) Monitor.Exit(locker);
            }
        }

        public static void Odd(object n)
        {
            bool acquiredLock = false;
            try
            {
                Monitor.Enter(locker, ref acquiredLock);
                int limit = (int) n;
                for (int i = 0; i < limit; i++)
                {
                    if (i % 2 != 0)
                    {
                        using (StreamWriter sw = new StreamWriter(@"D:\2_Course\OOP_1sem\Numbers.txt", true))
                        {
                            sw.WriteLine($"Thread 2: {i}");
                            Console.WriteLine($"Thread 2: {i}");
                            Thread.Yield();
                        }
                    }
                }
            } 
            finally
            {
                if(acquiredLock) Monitor.Exit(locker);
            }
        }
        public static void TimerExample(object obj)
        {
            Console.WriteLine(DateTime.Now);
        }
    }
}