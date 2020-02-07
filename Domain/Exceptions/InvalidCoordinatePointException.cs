using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Exceptions
{
    public class InvalidCoordinatePointException : Exception
    {
        public InvalidCoordinatePointException(string error): base($"Invalid point \"{error}\".")
        {
        }
    }
}
