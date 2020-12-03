using System;
using System.Linq;
using System.Collections.Generic;

namespace Laba11
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] months =
            {
                "January", "February", "March", "April", "May", "June", "July", "August", "September", "October",
                "November", "December"
            };
            int n = Convert.ToInt32(Console.ReadLine());
            var nMonths = from month in months
                where month.Length == n
                select month;
            foreach (var item in nMonths)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n----------------------------------------------------------------\n");
            var summerAndWinter = from month in months
                where month.StartsWith("J") || month.StartsWith("Au") || month.StartsWith("F") || month.StartsWith("D")
                select month;
            foreach (var item in summerAndWinter)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n----------------------------------------------------------------\n");
            var alphabeticalOrder = from month in months
                orderby month
                select month;
            foreach (var item in alphabeticalOrder)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n----------------------------------------------------------------\n");
            var countMonths = (from month in months
                where month.Contains("u") && month.Length == 4
                select month).Count();
            Console.WriteLine(countMonths);
            var vectors = new List<int[]>(8);
            int[] array1 = {76, 6, 0, 66, 4};
            int[] array2 = {27, 48, 20};
            int[] array3 = {52, 80, 17, 21, 16, 6, 54};
            int[] array4 = {32, 70, 39, 13};
            int[] array5 = {-19, 99};
            int[] array6 = {94, 96, 20, 18};
            int[] array7 = {100, 20, 20, -19, 88, 91};
            int[] array8 = {47, 10, 46, 8, 44, 82, 79, 66};
            vectors.Add(array1);
            vectors.Add(array2);
            vectors.Add(array3);
            vectors.Add(array4);
            vectors.Add(array5);
            vectors.Add(array6);
            vectors.Add(array7);
            vectors.Add(array8);
            Console.WriteLine("\n----------------------------------------------------------------\n");
            var zeroVectors = vectors.Count(vector => vector.Contains(0));
            Console.WriteLine(zeroVectors);
            Console.WriteLine("\n----------------------------------------------------------------\n");
            var listWithLeastModule = vectors.Min(vector => Math.Abs(vector.Average()));
            Console.WriteLine(listWithLeastModule);
            Console.WriteLine("\n----------------------------------------------------------------\n");
            var threeFiveSeven =
                vectors.Where(vector => vector.Length == 3 || vector.Length == 5 || vector.Length == 7);
            foreach (var vector in threeFiveSeven)
            {
                for (int i = 0; i < vector.Length; i++)
                {
                    Console.WriteLine(vector[i]);
                }
            }
            Console.WriteLine("\n----------------------------------------------------------------\n");
            var maxVector = vectors.Max(vector => vector.Sum());
            Console.WriteLine(maxVector);
            Console.WriteLine("\n----------------------------------------------------------------\n");
            var firstNegative = from vector in vectors
                from el in vector
                where el < 0
                select vector;
            foreach (var vector in firstNegative)
            {
                for (int i = 0; i < vector.Length; i++)
                {
                    Console.WriteLine(vector[i]);
                }
                Console.WriteLine("\n----------------------------------------------------------------\n");
            }
            var sortBySize = from vector in vectors
                orderby vector.Length
                select vector.Length;
            foreach (var item in sortBySize)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n----------------------------------------------------------------\n");
            var artists = new Dictionary<string, string>();
            artists["Eminem"] = "The Marshall Mathers LP";
            artists["Dr. Dre"] = "Compton";
            artists["N.W.A"] = "Straight Outta Compton";
            artists["Big Sean"] = "Detroit 2";
            artists["Eric B. & Rakim"] = "Paid In Full";
            artists["2pac"] = "All Eyez On Me";
            artists["The Notorious B.I.G"] = "Life After Death";
            var albums = from artist in artists
                where artist.Key.Length > 5
                orderby artist.Value
                select artist.Value;
            foreach (var item in albums)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n----------------------------------------------------------------\n");
            var rand = albums.Aggregate((x, y) => x + y);
            Console.WriteLine(rand);
            Console.WriteLine("\n----------------------------------------------------------------\n");
            var artists2 = new Dictionary<string, string>();
            artists2["Dr. Dre"] = "2001";
            artists2["Eminem"] = "Kamikaze";
            artists2["N.W.A"] = "elif4zaggiN";
            var result = from artist1 in artists
                join artist2 in artists2 on artist1.Key equals artist2.Key
                select artist1;
            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} = {item.Value}");
            }
        }
    }
}