using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Laba3
{
    partial class Vector
    {
        static readonly int readOnlyValue;
        private Vector(string e)
        {
            Array = new int[] { };
            NumberOfElements = 0;
            ErrorCode = e;
        }
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return ErrorCode.GetHashCode();
        }

        public override string ToString()
        {
            return $"{ErrorCode}";
        }
    }
    public partial class Vector
    {
        public static List<Vector> Data { get; private set; }
        private string ErrorCode { get; set; }
        public byte NumberOfElements {get; set; }
        public int[] Array { get; set; }
        public static int counter { get; set; }

        static Vector()
        {
            counter = 0;
            Random rnd = new Random();
            int[][] arr = new int[5][];
            for (var i = 0; i < arr.Length - 1; i++)
            {
                arr[i] = new int[10];
                for (var j = 0; j < arr[i].Length - 1; j++)
                {
                    arr[i][j] = rnd.Next(0, 100);
                }
            }
            Data = new List<Vector> {
                new Vector(arr[0], Convert.ToByte(arr[0].Length), "ok"),
                new Vector(arr[1], Convert.ToByte(arr[1].Length), "ok"),
                new Vector(arr[2], Convert.ToByte(arr[2].Length), "ok"),
                new Vector(arr[3], Convert.ToByte(arr[3].Length), "ok"),
                new Vector(arr[4], Convert.ToByte(arr[4].Length), "ok")
            };
        }
        public Vector(int[] arr, byte size, string e = "ok")
        {
            ErrorCode = e;
            NumberOfElements = size;
            Array = arr;
        }

        public Vector()
        {
            ErrorCode = "ok";
            NumberOfElements = 0;
            Array = new int[] { };
        }
        public static void Add(Vector vector)
        {
            Data.Add(vector);
            counter++;
        }

        public static void ListZero()
        {
            Console.WriteLine("Vectors that contain '0':");
            foreach (var arr in Data)
            {
                foreach (var el in arr.Array)
                {
                    if (el == 0)
                    {
                        Console.WriteLine(arr.Array);
                    }
                }
            }
        }

        public static List<Vector> GetErrorCode(ref string e)
        {
            var list = new List<Vector>();
            foreach (var el in Data)
            {
                if (el.ErrorCode == e)
                {
                    list.Add(el);
                }
            }

            return list;
        }

        public static void IsOK(int arrInd, out string e)
        {
            e = "ok";
            for (var i = 0; i < Data.Count; i++)
            {
                if (i == arrInd)
                {
                    if (Data[i].ErrorCode == "not ok")
                    {
                        e = "not ok";
                        break;
                    }
                }
            }
        }
        
        public static void Addition(int arrInd, int index, int num)
        {
            for (var i = 0; i < Data.Count; i++)
            {
                if (i == arrInd)
                {
                    for (var j = 0; j < Data[i].Array.Length; j++)
                    {
                        if (index == Data[i].Array[j])
                        {
                            Data[i].Array[j] += num;
                        }
                    }
                }
            }

            return;
        }
        public static void Multiply(int arrInd, int index, int num)
        {
            for (var i = 0; i < Data.Count; i++)
            {
                if (i == arrInd)
                {
                    for (var j = 0; j < Data[i].Array.Length; j++)
                    {
                        if (index == Data[i].Array[j])
                        {
                            Data[i].Array[j] *= num;
                        }
                    }
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose an action:\n" +
                              "1 - Add a Vector\n" +
                              "2 - List all vectors, that contain '0'\n" +
                              "3 - Add a value to an element\n" +
                              "4 - Multiply a value of an element\n" +
                              "5 - Exit");
            int chc;
            chc = Convert.ToInt32(Console.ReadLine());
            switch (chc)
            {
                case 1:
                    AddVector();
                    break;
                case 2:
                    Vector.ListZero();
                    break;
                case 3:
                    Console.WriteLine("Input an index of an array:");
                    int arrInd = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Input an index of an element:");
                    int index = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Input a number you want to add:");
                    int num = Convert.ToInt32(Console.ReadLine());
                    Vector.Addition(arrInd, index, num);
                    break;
                case 4:
                    Console.WriteLine("Input an index of an array:");
                    int arrIndM = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Input an index of an element:");
                    int indexM = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Input a number you want to add:");
                    int numM = Convert.ToInt32(Console.ReadLine());
                    Vector.Multiply(arrIndM, indexM, numM);
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("There's no such option, please choose a different option");
                    break;
            }
        }

        private static void AddVector()
        {
            Vector vector;
            Console.WriteLine("Input a size of a vector:");
            byte size = Convert.ToByte(Console.ReadLine());
            int[] arr = new int[size];
            Console.WriteLine($"Input {size} elements:");
            for (var i = 0; i < size; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Input an Error Code (i.e. 'ok', 'not ok':");
            string e = Console.ReadLine();
            vector = new Vector(arr, size, e);
            Vector.Add(vector);
            Console.WriteLine("Vector has been succesfully added");
        }
    }
}