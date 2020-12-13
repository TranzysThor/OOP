using System;
using System.Collections.Generic;
using static Laba15.ThreadOperations;
using System.Threading;

namespace Laba15
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("\nChoose an operation:\n" +
                                  "1 - List Processes\n" +
                                  "2 - Current Domain\n" +
                                  "3 - New Thread\n" +
                                  "4 - Odd and Even\n" +
                                  "5 - Timer\n" +
                                  "0 - Exit\n");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        ListProcesses();
                        break;
                    case 2: 
                        GetCurrentDomain();
                        break;
                    case 3:
                        Thread newThread = new Thread(SetRemoteThread);
                        newThread.Start();
                        Console.WriteLine($"ID: {newThread.ManagedThreadId}\n" +
                                          $"Name: {newThread.Name}\n" +
                                          $"Priority: {newThread.Priority}\n" +
                                          $"Status: {newThread.ThreadState}\n");
                        Thread.Sleep(3300);
                        break;
                    case 4:
                        Console.WriteLine("Input a number: ");
                        int n = Convert.ToInt32(Console.ReadLine());
                        Thread one = new Thread(Even);
                        Thread two = new Thread(Odd);
                        one.Start(n);
                        two.Start(n);
                        Thread.Sleep(7000);
                        break;
                    case 5:
                        TimerCallback tm = new TimerCallback(TimerExample);
                        Timer timer = new Timer(tm, 2, 0, 5000);
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("No such operation");
                        break;
                }
            } while (choice != 0);
        }
    }
}