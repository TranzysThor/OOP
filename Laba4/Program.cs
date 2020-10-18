using System;

namespace Laba4
{
    class SDArray
    {
        SDArray(int[] arr)
        {
            Arr = arr;
        }
        public int[] Arr { get; set; }
        public static SDArray operator *(SDArray array1, SDArray array2)
        {
            int[] tmp = {};
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
            return array1.Arr.Equals(array2.Arr);
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
            Owner(int Id, string ownerName, string org)
            {
                id = Id;
                name = ownerName;
                organization = org;
            }
        }

        class Date
        {
            private DateTime dateTime;
            public DateTime date
            {
                get => dateTime;
                set => dateTime = value;
            }
            Date()
            {
                date = DateTime.Now;
            }
        }
    }

    static class StatisticOperation
    {
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}