using System;
using System.Collections.Generic;
using System.IO;

namespace Laba8
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            List<int> IntList1 = new List<int>(5);
            List<int> IntList2 = new List<int>(5);
            List<double> DoubleList = new List<double>(5);
            List<string> StringList = new List<string> {"Marshall Mathers", "Slim Shady", "Eminem", "B-Rabbit", "Ken Kaniff"};
            double tmp = 0;
            for (var i = 0; i < 5; i++)
            {
                IntList1.Add(rand.Next(-100, 100));
                IntList2.Add(rand.Next(-100, 100));
                tmp = rand.NextDouble();
                DoubleList.Add(tmp);
            }
            CollectionType<int> CTInt1 = new CollectionType<int>(IntList1);
            CollectionType<int> CTInt2 = new CollectionType<int>(IntList2);
            CollectionType<double> CTDouble = new CollectionType<double>(DoubleList);
            CollectionType<string> CTString = new CollectionType<string>(StringList);
            CTInt1.add(CTInt1, CTInt2);
            CTDouble.Del(CTDouble, tmp);
            string writePath = @"D:\2_Course\OOP_1se\path.txt";
            string writePath2 = @"D:\2_Course\OOP_1sem\stringpath.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    foreach (var value in CTDouble.Arr)
                    {
                        sw.WriteLine(value);
                    }
                }

                Console.WriteLine("Written");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                writePath = @"D:\2_Course\OOP_1sem\path.txt";
            }
            finally
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    foreach (var value in CTDouble.Arr)
                    {
                        sw.WriteLine(value);
                    }
                }
                Console.WriteLine("Written using finally");
            }

            try
            {
                using (StreamReader sr = new StreamReader(writePath, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath2, false, System.Text.Encoding.Default))
                {
                    foreach (var value in CTString.Arr)
                    {
                        sw.WriteLine(value);
                    }
                }

                Console.WriteLine("Written");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            try
            {
                using (StreamReader sr = new StreamReader(writePath2, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }

    interface IOperations<T>
    {
        CollectionType<T> add(CollectionType<T> c, CollectionType<T> v);
        CollectionType<T> Del(CollectionType<T> c, T value);
        CollectionType<T> Display(CollectionType<T> c);
    }

    public class CollectionType<T> : IOperations<T>
    {
        public List<T> Arr { get; set; }
        
        public CollectionType(List<T> list)
        {
            Arr = list;
        }
        
        public CollectionType<T> add(CollectionType<T> c, CollectionType<T> v)
        {
            foreach (var val in v.Arr)
            {
                c.Arr.Add(val);
            }
            return c;
        }

        public CollectionType<T> Del(CollectionType<T> c, T value)
        {
            c.Arr.Remove(value);
            return c;
        }

        public CollectionType<T> Display(CollectionType<T> c)
        {
            foreach (var item in c.Arr)
            {
                Console.WriteLine(item);
            }
            return c;
        }
    }
}
