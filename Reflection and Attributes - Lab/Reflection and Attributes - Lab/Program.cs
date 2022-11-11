namespace Reflection_and_Attributes___Lab
{
     using System;
    public class Program
    {
        static void Main(string[] args)
        {
            //Examples
            int x = 5;
            PrintTypeInfo(new Writer());
            PrintTypeInfo(x.GetType());
            PrintTypeInfo(new int[] { 1, 2, 3 });
        }

        private static void PrintTypeInfo(object obj)
        {
            Type type = obj.GetType();
            Console.WriteLine($"Name   == >>>      {type.Name}");
            Console.WriteLine($"FullName   == >>>      {type.FullName}");
            Console.WriteLine($"IsGenericType   == >>>      {type.IsGenericType}");
            Console.WriteLine($"Assembly   == >>>      {type.Assembly}");
            Console.WriteLine($"BaseType   == >>>      {type.BaseType}");
            Console.WriteLine($"IsArray   == >>>      {type.IsArray}");
            Console.WriteLine($"IsPrimitive   == >>>      {type.IsPrimitive}");
        }
    }
    class Writer
    {
    }
}
