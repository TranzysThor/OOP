using System;
using System.Reflection;

namespace Laba12
{
    public static class Reflector
    {
        public static void GetAssembly(Type className)
        {
            Console.WriteLine(className.Assembly);
        }
        public static ConstructorInfo[] GetPublicConstructors(Type className)
        {
            return className.GetConstructors();
        }
        public static MethodInfo[] GetPublicMethods(Type className)
        {
            return className.GetMethods();
        }
        public static PropertyInfo[] GetPublicProperties(Type className)
        {
            return className.GetProperties();
        }
        public static Type[] GetUsedInterfaces(Type className)
        {
            return className.GetInterfaces();
        }
        public static void GetMethodNames(Type className)
        {
            foreach (var method in className.GetMethods())
            {
               
                    Console.WriteLine(method.Name);
            }
        }
    }
}