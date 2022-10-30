using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace Telephony.Models
{
    public class Smartphone : ICallable, IBrowseable
    {
        public string Calling(string phoneNumber) => $"Calling... {phoneNumber}";

        public string Browsing(string url) => $"Browsing: {url}!";
    }
}
