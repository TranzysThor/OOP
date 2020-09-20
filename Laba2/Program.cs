using System;
using System.Linq;
using System.Text;

namespace Laba2
{
    class Program
    {
        static void Main()
        {
            //-----------------------------Task 1 Part A-------------------------------
            int IntVar = -2_147_483_648;
            Console.WriteLine(IntVar);
            uint UIntVar = 4_294_967_295;
            Console.WriteLine(UIntVar);
            long LongVar = -9_223_372_036_854_775_808;
            Console.WriteLine(LongVar);
            ulong ULongVar = 18_446_744_073_709_551_615;
            Console.WriteLine(ULongVar);
            short ShortVar = -32_768;
            Console.WriteLine(ShortVar);
            ushort UShortVar = 65_535;
            Console.WriteLine(UShortVar);
            bool BoolVar = true;
            Console.WriteLine(BoolVar);
            byte ByteVar = 255;
            Console.WriteLine(ByteVar);
            sbyte SByteVar = -127;
            Console.WriteLine(SByteVar);
            char CharVar = 'a';
            Console.WriteLine(CharVar);
            decimal DecimalVar = 7.9m;
            Console.WriteLine(DecimalVar);
            double DoubleVar = 1.7D;
            Console.WriteLine(DoubleVar);
            float FloatVar = 3.4f;
            Console.WriteLine(FloatVar);
            //-----------------------------Task 1 Part B-------------------------------
            int DoubleToInt = (int) DoubleVar;
            double IntToDouble = (double) IntVar;
            float DecimalToFloat = (float) DecimalVar;
            long IntToLong = (long) IntVar;
            short IntToShort = (short) IntVar;
            int DoubleToIntConvert = Convert.ToInt32(DoubleVar);
            double IntToDoubleConvert = Convert.ToDouble(IntVar);
            float DecimalToFloatConvert = Convert.ToSingle(DecimalVar);
            long IntToLongConvert = Convert.ToInt64(IntVar);
            short IntToShortConvert = Convert.ToInt16(IntVar / 16777216);
            //-----------------------------Task 1 Part С-------------------------------
            object PackedInt = IntVar;
            Console.WriteLine($"Packed {PackedInt}");
            int UnpackedInt = (int) PackedInt;
            Console.WriteLine($"Unpacked {UnpackedInt}");
            object PackedFloat = FloatVar;
            Console.WriteLine($"Packed {PackedFloat}");
            float UnpackedFloat = (float) PackedFloat;
            Console.WriteLine($"Unpacked {UnpackedFloat}");
            object PackedDouble = DoubleVar;
            Console.WriteLine($"Packed {PackedDouble}");
            double UnpackedDouble = (double) PackedDouble;
            Console.WriteLine($"Unpacked {UnpackedDouble}");
            object PackedDecimal = DecimalVar;
            Console.WriteLine($"Packed {PackedDecimal}");
            decimal UnpackedDecimal = (decimal) PackedDecimal;
            Console.WriteLine($"Unpacked {UnpackedDecimal}");
            object PackedShort = ShortVar;
            Console.WriteLine($"Packed {PackedShort}");
            short UnpackedShort = (short) PackedShort;
            Console.WriteLine($"Unpacked {UnpackedShort}");
            //-----------------------------Task 1 Part D-------------------------------
            var str = "string";
            var UntypedVar = 123;
            Console.WriteLine(UntypedVar.GetType());
            Console.WriteLine(str.GetType());
            //-----------------------------Task 1 Part E-------------------------------
            Nullable<int> NullableInt = null;
            Console.WriteLine("Null");
            Console.Write("Input a value: ");
            /*NullableInt = Console.Read();
            if (NullableInt.HasValue)
            {
                Console.WriteLine((char)NullableInt.Value);
            }
            else
            {
                Console.WriteLine("Null");
            }*/
            //-----------------------------Task 1 Part F-------------------------------
            var VarInt = 124;
            //VarInt = "string";
            //-----------------------------Task 2 Part A-------------------------------
            string stringLiteral = "string ";
            string stringLiteral2 = "with ";
            Console.WriteLine(stringLiteral.CompareTo(stringLiteral2));
            //-----------------------------Task 2 Part B-------------------------------
            string stringLiteral3 = "words";
            string stringConcat = String.Concat(stringLiteral, stringLiteral2, stringLiteral3);
            Console.WriteLine(stringConcat);
            string stringCopy = String.Copy(stringLiteral);
            Console.WriteLine(stringCopy);
            Console.WriteLine(stringLiteral.Substring(1, 3));
            string[] words = stringConcat.Split();
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine(stringLiteral.Insert(7, "number one"));
            Console.WriteLine(stringLiteral.Remove(1, 4));
            //-----------------------------Task 2 Part C-------------------------------
            string nullString = null;
            string emptyString = "";
            Console.WriteLine(String.IsNullOrEmpty(nullString));
            Console.WriteLine(String.IsNullOrEmpty(emptyString));
            //-----------------------------Task 2 Part D-------------------------------
            StringBuilder sb = new StringBuilder("String Builder", 50);
            Console.WriteLine(sb.Remove(6, 3));
            Console.WriteLine(sb.Append("that's that"));
            Console.WriteLine(sb.Insert(0, "better"));
            //-----------------------------Task 3 Part A-------------------------------
            int[,] array2D = {{1, 2, 3}, {4, 5, 6}, {7, 8, 9}};
            for (var i = 0; i < array2D.GetLength(0); i++)
            {
                for (var j = 0; j < array2D.GetLength(1); j++)
                {
                    Console.Write($"{array2D[i, j]} ");
                }
                Console.Write("\n");
            }
            //-----------------------------Task 3 Part B-------------------------------
            /*string[] strings = words;
            foreach (var word in strings)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine(strings.Length);
            Console.Write("Input a position: ");
            string val = Console.ReadLine();
            int pos = Convert.ToInt32(val);
            Console.Write("Input a string: ");
            string value = Console.ReadLine();
            for (var i = 0; i < strings.Length; i++)
            {
                if (i == pos)
                {
                    strings[i] = value;
                }
            }
            foreach (var word in strings)
            {
                Console.WriteLine(word);
            }*/
            //-----------------------------Task 3 Part C-------------------------------
            /*float[][] jaggedArray = new float[3][];
            jaggedArray[0] = new float[2];
            jaggedArray[1] = new float[3];
            jaggedArray[2] = new float[4];
            for (var i = 0; i < jaggedArray.Length; i++)
            {
                for (var j = 0; j < jaggedArray[i].Length; j++)
                {
                    string newValue = Console.ReadLine();
                    jaggedArray[i][j] = Convert.ToSingle(newValue);
                }
            }
            Console.WriteLine();
            for (var i = 0; i < jaggedArray.Length; i++)
            {
                for (var j = 0; j < jaggedArray[i].Length; j++)
                {
                    Console.Write($"{jaggedArray[i][j]}\t");
                }
                Console.WriteLine();
            }*/
            //-----------------------------Task 3 Part D-------------------------------
            var varIntArray = new[] { 1, 10, 100, 1000 };
            var varStringArray = new[] { "hello", null, "world" }; 
            //-----------------------------Task 4 Part A-------------------------------
            (int age, string firstName, char sex, string occupation, ulong _) tuple = (18, "Maxim", 'm', "Student", 41412L);
            //-----------------------------Task 4 Part B-------------------------------
            Console.WriteLine(tuple);
            Console.WriteLine(tuple.Item1);
            Console.WriteLine(tuple.Item3);
            Console.WriteLine(tuple.Item4);
            //-----------------------------Task 4 Part C-------------------------------
            /*var age = tuple.Item1;
            var firstName = tuple.Item2;
            var sex = tuple.Item3;
            var occupation = tuple.Item4;
            var randomNumber = tuple.Item5;*/
            /*var age = tuple.age;
            var firstName = tuple.firstName;
            var sex = tuple.sex;
            var occupation = tuple.occupation;
            var randomNumber = tuple.randomNumber;*/
            var age = tuple.age;
            var firstName = tuple.firstName;
            var sex = tuple.sex;
            var occupation = tuple.occupation;
            //var randomNumber = tuple.randomNumber << compiler throws away this value from the tuple
            //-----------------------------Task 4 Part D-------------------------------
            (int age, string firstName, char sex, string occupation, ulong randomNumber) tuple2 = (18, "Maxim", 'm', "Student", 41412L);
            Console.WriteLine(tuple.CompareTo(tuple2));
            //-----------------------------Task 5--------------------------------------
            static (int max, int min, int sum, char firstLetter) localFunc(int[] array, string str)
            {
                int max = 0;
                int min = 9999;
                int sum = 0;
                for (var i = 0; i < array.Length; i++)
                {
                    if (array[i] > max)
                    {
                        max = array[i];
                    }

                    if (array[i] < min)
                    {
                        min = array[i];
                    }
                    sum += array[i];
                }
                char firstLetter = str[0];
                return (max, min, sum, firstLetter);
            }
            var localTuple = localFunc(varIntArray, str);
            Console.WriteLine(localTuple);
            //-----------------------------Task 6 Part A-------------------------------
            static int intLocalFunc1(int num)
            {
                checked
                {
                    num = Int32.MaxValue;
                }
                return num;
            }

            static int intLocalFunc2(int num)
            {
                unchecked
                {
                    num = Int32.MaxValue + 1;
                }
                return num;
            }
            Console.WriteLine(intLocalFunc1(Int32.MaxValue));
            Console.WriteLine(intLocalFunc2(Int32.MaxValue));
        }
    }
}
