﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceInterfaces
{
    public interface ILoggingService
    {
        void Log(Exception e);
        void Log(string message);
    }
}
