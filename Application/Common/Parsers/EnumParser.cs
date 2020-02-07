using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Parsers
{
    public class EnumParser
    {
        public static T ToEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }
}
