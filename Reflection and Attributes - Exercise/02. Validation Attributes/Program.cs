
namespace ValidationAttributes
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            var person = new Person("Kalsito", 40);

            bool isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}
