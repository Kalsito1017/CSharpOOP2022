using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        public string Calling(string phoneNumber) => $"Dialing... {phoneNumber}";
    }
}
