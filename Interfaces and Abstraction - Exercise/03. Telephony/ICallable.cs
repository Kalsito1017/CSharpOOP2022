﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony.Models
{
    public interface ICallable
    {
        string Calling(string phoneNumber);
    }
}