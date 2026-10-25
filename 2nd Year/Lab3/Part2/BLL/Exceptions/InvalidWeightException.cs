using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3.BLL.Exceptions
{
    public class InvalidWeightException : Exception
    {
        public InvalidWeightException(string message) : base(message) { }
    }
}
