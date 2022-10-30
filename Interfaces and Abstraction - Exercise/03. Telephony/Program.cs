using System;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;

namespace Telephony.Models
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            string[] urls = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var smartPhone = new Smartphone();
            ICallable phone = new StationaryPhone();

            MakeCalls(phoneNumbers, phone, smartPhone);
            Browse(urls, smartPhone);
        }

        public static void Browse(string[] urls, Smartphone smartPhone)
        {
            foreach (var url in urls)
            {
                try
                {
                    if (!IsURLValid(url))
                    {
                        throw new ArgumentException("Invalid URL!");
                    }

                    Console.WriteLine(smartPhone.Browsing(url));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static bool IsURLValid(string url)
        {
            Regex regex = new Regex(@"^[\D]+$");

            if (regex.IsMatch(url))
            {
                return true;
            }
            return false;
        }

        public static void MakeCalls(string[] phoneNumbers, ICallable phone, ICallable smartPhone)
        {
            foreach (var number in phoneNumbers)
            {
                try
                {
                    if (!IsNumberValid(number))
                    {
                        throw new ArgumentException("Invalid number!");
                    }

                    Console.WriteLine(number.Length == 7
                        ? phone.Calling(number)
                        : smartPhone.Calling(number));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static bool IsNumberValid(string number)
        {
            Regex regex = new Regex(@"\b[0-9]+\b");

            if (regex.IsMatch(number))
            {
                return true;
            }
            return false;
        }
    }
}
