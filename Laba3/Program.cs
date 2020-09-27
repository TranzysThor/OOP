using System;
using System.Diagnostics.CodeAnalysis;

namespace Laba3
{
    public class Vector
    {
        public int NumberOfElements
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
        public string ErrorCode;
        
        public Vector()
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