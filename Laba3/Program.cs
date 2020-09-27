using System;
using System.Diagnostics.CodeAnalysis;

namespace Laba3
{
    class Vector
    {
        public int NumberOfElements;
        public int[] Array;
        public string ErrorCode;

        public Vector()
        {
            
        }

        public Vector(int size = 1)
        {
            NumberOfElements = size;
            Random rnd = new Random();
            for (var i = 0; i < NumberOfElements; i++)
            {
                Array[i] = rnd.Next(0, 100);
            }
        }

        public Vector(int[] arr)
        {
            Array = arr;
        }
        
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
            
        }
    }
}