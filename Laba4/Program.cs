using System;
using System.Diagnostics.CodeAnalysis;

namespace Laba4
{
    public class SDArray
    {
        public SDArray(int[] arr)
        {
            Arr = arr;
        }
        public int[] Arr = new int[5];
        public static SDArray operator *(SDArray array1, SDArray array2)
        {
            int[] tmp = new int[5];
            for (var i = 0; i < array1.Arr.Length; i++)
            {
                tmp[i] = array1.Arr[i] * array2.Arr[i];
            }

            return new SDArray(tmp);
        }

        public static bool operator true(SDArray array1)
        {
            for (var i = 0; i < array1.Arr.Length; i++)
            {
                if (array1.Arr[i] < 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator false(SDArray array1)
        {
            for (var i = 0; i < array1.Arr.Length; i++)
            {
                if (array1.Arr[i] > 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static explicit operator int(SDArray array1)
        {
            return array1.Arr.Length;
        }

        public static bool operator ==(SDArray array1, SDArray array2)
        {
            return array2 is { } && array1 is { } && array1.Arr.Equals(array2.Arr);
        }

        public static bool operator !=(SDArray array1, SDArray array2)
        {
            return !(array1 == array2);
        }

        public static bool operator >(SDArray array1, SDArray array2)
        {
            if (array2 != null && array1 != null && array1.Arr.Length > array2.Arr.Length)
            {
                return true;
            }
            return false;
        }

        public static bool operator <(SDArray array1, SDArray array2)
        {
            return !(array1 > array2);
        }
        public class Owner
        {
            private int ID;
            public int id
            {
                get => ID;
                set => ID = value;
            }

            private string Name;
            public string name
            {
                get => Name;
                set => Name = value;
            }
            private string Organization;
            public string organization
            {
                get => Organization;
                set => Organization = value;
            }
            public Owner(int Id, string ownerName, string org)
            {
                id = Id;
                name = ownerName;
                organization = org;
            }
        }
        public class Date
        {
            private DateTime dateTime;
            public DateTime date
            {
                get => dateTime;
                set => dateTime = value;
            }
            public Date()
            {
                date = DateTime.Now;
            }
        }

        static class StatiscticOperation
        {
            public static int Sum(SDArray array)
            {
                int sum = 0;
                foreach (var item in array.Arr)
                {
                    sum += item;
                }
                return sum;
            }

            public static int MaxMinDiff(SDArray array)
            {
                int max = 0;
                int min = 101;
                foreach (var item in array.Arr)
                {
                    if (item > max)
                    {
                        max = item;
                    }

                    if (item < min)
                    {
                        min = item;
                    }
                }
                return max - min;
            }

            public static int Count(SDArray array)
            {
                return array.Arr.Length;
            }
        }
    }
    public static class StringExtension
    {
        public static bool CharMatch(string str, char chr)
        {
            foreach (var letter in str)
            {
                if (letter == chr)
                {
                    return true;
                }
            }

            return false;
        }
    }

    public static class ArrayExtension
    {
        public static int[] FindAll(SDArray array)
        {
            for(var i = 0; i < array.Arr.Length; i++)
            {
                if (array.Arr[i] < 0)
                {
                    array.Arr[i] = 0;
                }
            }
            return array.Arr;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            SDArray.Owner owner = new SDArray.Owner(1, "Roman", "Gachi");
            SDArray.Date date = new SDArray.Date();
            Random rand = new Random();
            int[] arr1 = new int[5];
            int[] arr2 = new int[5];
            for (var i = 0; i < 5; i++)
            {
                arr1[i] = rand.Next(-100, 100);
                arr2[i] = rand.Next(-100, 100);
            }
            SDArray Array1 = new SDArray(arr1); 
            SDArray Array2 = new SDArray(arr2);
            Console.WriteLine(Array1 * Array2);
            Console.WriteLine(Array1 == Array2);
            Console.WriteLine(Array1 != Array2);
            Console.WriteLine(Array1 > Array2);
            Console.WriteLine(Array1 < Array2);
            Console.WriteLine((int)Array1);
            Console.WriteLine($"{owner.id} {owner.name} {owner.organization}");
            Console.WriteLine($"{date.date}");
        }
    }
}