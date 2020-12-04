using System;
using static Laba12.Reflector;

namespace Laba12
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAssembly(typeof(String));
            Console.WriteLine("\n----------------------------------------------------------------------\n");
            var ctr = GetPublicConstructors(typeof(String));
            foreach (var value in ctr)
            {
                Console.WriteLine(value);
            }
            Console.WriteLine("\n----------------------------------------------------------------------\n");
            var methods = GetPublicMethods(typeof(String));
            foreach (var method in methods)
            {
                Console.WriteLine(method);
            }
            Console.WriteLine("\n----------------------------------------------------------------------\n");
            var properties = GetPublicProperties(typeof(String));
            foreach (var property in properties)
            {
                Console.WriteLine(property);
            }
            Console.WriteLine("\n----------------------------------------------------------------------\n");
            var interfaces = GetUsedInterfaces(typeof(String));
            foreach (var face in interfaces)
            {
                Console.WriteLine(face);
            }
            Console.WriteLine("\n----------------------------------------------------------------------\n");
            GetMethodNames(typeof(String));
            Console.WriteLine("\n----------------------------------------------------------------------\n");
        }
    }
}