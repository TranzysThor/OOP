using System;

namespace Laba3
{
    public class Vector
    {
        private string ErrorCode;
        public byte NumberOfElements
        {
            set
            {
                if (value < 2 || value > 10)
                {
                    Console.WriteLine("Input a correct size between 2 and 10");
                }
                else
                {
                    NumberOfElements = value;
                }
            }
            get { return NumberOfElements; }
        }
        public int[] Array;

        /*public Vector()
        {
            Random rnd = new Random();
            for (var i = 0; i < NumberOfElements; i++)
            {
                Array[i] = rnd.Next(0, 100);
            }
        }

        public Vector(int size = 10) : this()
        {
            Random rnd = new Random();
            for (var i = 0; i < size; i++)
            {
                Array[i] = rnd.Next(0, 100);
            }
        }

        public Vector(int[] arr)
        {
            Array = arr;
        }*/
        
        public int Add(int[] arr, int index, int num)
        {
            return arr[index - 1] + num;
        }
        public int Multiply(int[] arr, int index, int num)
        {
            return arr[index - 1] * num;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Vector[] vectors = new Vector[5];
            Random rnd = new Random();
            int[][] arr = new int[5][];
            for (var i = 0; i < arr.Length; i++)
            {
                arr[i] = new int[10];
                for (var j = 0; j < arr[i].Length; j++)
                {
                    arr[i][j] = rnd.Next(0, 100);
                }
                vectors[i].Array = arr[i];
                vectors[i].NumberOfElements = Convert.ToByte(arr[i].Length);
            }

            foreach (var vec in vectors)
            {
                for (var i = 0; i < vec.Array.Length; i++)
                {
                    if (vec.Array[i] == 0)
                    {
                        Console.WriteLine($"{vec.Array}\n");
                    }
                }
            }
        }
    }
}