
namespace Stealer
{
     using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Part I: Reflection
            Spy spy = new Spy();
            string result = spy.StealFieldInfo(investigatedClass:"Stealer.Hacker", "username", "password");
            Console.WriteLine(result);

        }
    }
}
