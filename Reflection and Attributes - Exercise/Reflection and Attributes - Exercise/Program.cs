using System;
using System.Reflection;

namespace Reflection_and_Attributes___Exercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(32 | 16 | 8 | 4);
            Console.WriteLine((BindingFlags)(50));
            BindingFlags flags = BindingFlags.Instance | BindingFlags.Public;
            Console.WriteLine(flags);
        }
    }
}
