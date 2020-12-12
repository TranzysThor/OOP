using System;
using static Laba14.Serializator;

namespace Laba14
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("Choose an operation:\n" +
                                  "1 - XML Serialization\n" +
                                  "2 - JSON Serialization\n" +
                                  "3 - SOAP Serialization (Implemented, but doesn't work)\n" +
                                  "4 - Binary Serialization\n" +
                                  "5 - Array of Objects\n" +
                                  "6 - XPath\n" +
                                  "7 - LINQ to XML\n" +
                                  "0 - Exit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Serialization via XML");
                        XML();
                        break;
                    case 2:
                        Console.WriteLine("Serialization via JSON");
                        JSON();
                        break;
                    case 3:
                        Console.WriteLine("Serialization via SOAP");
                        SOAP();
                        break;
                    case 4:
                        Console.WriteLine("Serialization via Binary");
                        Binary();
                        break;
                    case 5:
                        Console.WriteLine("Array Serialization");
                        ArraySerialization();
                        break;
                    case 6:
                        xPath();
                        break;
                    case 7:
                        LtoX();
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